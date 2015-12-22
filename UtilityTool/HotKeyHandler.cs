using System;
using System.Windows.Forms;

namespace UtilityTool {
    public class HotKeyHandler {
        public KeyboardHook KeyboardHook { get; private set; }

        public HotKeyHandler() {
            KeyboardHook = new KeyboardHook();
            RegisterHotKeys();

            KeyboardHook.HotKeyPressed += new EventHandler<HotKeyPressedEventArgs>(KeyboardHook_HotKeyPressed);
        }

        private void RegisterHotKeys() {
            KeyboardHook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt, Keys.Q);
        }

        private void KeyboardHook_HotKeyPressed(object sender, HotKeyPressedEventArgs e) {
            Program.MainForm.ShowActivate();
        }
    }
}
