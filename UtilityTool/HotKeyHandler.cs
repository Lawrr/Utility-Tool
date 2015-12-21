using System;
using System.Windows.Forms;

namespace UtilityTool {
    class HotKeyHandler {

        public KeyboardHook KeyboardHook { get; private set; }

        public HotKeyHandler() {
            KeyboardHook = new KeyboardHook();
            KeyboardHook.HotKeyPressed += new EventHandler<HotKeyPressedEventArgs>(KeyboardHook_HotKeyPressed);
            RegisterHotKeys();
        }

        private void RegisterHotKeys() {
            KeyboardHook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt, Keys.Q);
        }

        private void KeyboardHook_HotKeyPressed(object sender, HotKeyPressedEventArgs args) {
            Program.MainForm.Open();
        }

    }
}
