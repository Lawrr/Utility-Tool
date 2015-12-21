using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UtilityTool {

    [Flags]
    public enum ModifierKeys : uint {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

    public delegate void HotKeyPressedEventHandler(object sender, HotKeyPressedEventArgs args);

    public class HotKeyPressedEventArgs : EventArgs {
        public ModifierKeys Modifiers { get; private set; }
        public Keys Key { get; private set; }

        public HotKeyPressedEventArgs(ModifierKeys modifiers, Keys key) {
            Modifiers = modifiers;
            Key = key;
        }
    }

    public class KeyboardHook : IDisposable {

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public event HotKeyPressedEventHandler HotKeyPressed;

        private Window HookWindow = new Window();
        private int CurrentHotKeyId;

        public KeyboardHook() {
            HookWindow.HotKeyPressed += delegate(object sender, HotKeyPressedEventArgs args) {
                // Invoke hot key pressed event
                if (HotKeyPressed != null) {
                    HotKeyPressed(this, args);
                }
            };
        }

        public void RegisterHotKey(ModifierKeys modifiers, Keys key) {
            // Register the hot key
            bool hotKeyRegistered = RegisterHotKey(HookWindow.Handle, CurrentHotKeyId, (uint)modifiers, (uint)key);
            if (hotKeyRegistered) {
                // Increment hot key id
                CurrentHotKeyId++;
            } else {
                // Could not register hot key
                throw new InvalidOperationException("Could not register hot key");
            }
        }

        public void Dispose() {
            // Unregister hot keys
            for (int i = 0; i < CurrentHotKeyId; i++) {
                UnregisterHotKey(HookWindow.Handle, i);
            }

            HookWindow.Dispose();
        }

        private class Window : NativeWindow, IDisposable {
            // Id of message for hot key press
            private static int WM_HOTKEY = 0x0312;

            public event HotKeyPressedEventHandler HotKeyPressed;

            public Window() {
                CreateHandle(new CreateParams());
            }
            
            protected override void WndProc(ref Message m) {
                base.WndProc(ref m);

                // Check if hot key pressed
                if (m.Msg == WM_HOTKEY) {
                    // Get the key that was pressed
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifiers = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // Invoke hot key pressed event
                    if (HotKeyPressed != null) {
                        HotKeyPressed(this, new HotKeyPressedEventArgs(modifiers, key));
                    }
                }
            }

            public void Dispose() {
                DestroyHandle();
            }
        }

    }
}
