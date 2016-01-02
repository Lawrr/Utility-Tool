using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace UtilityTool {
    public static class Extensions {
        /// <summary>
        /// Invoke thread-safe calls to windows forms controls.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeSafe(this Control control, Action action) {
            if (control != null && !control.IsDisposed) {
                if (control.InvokeRequired) {
                    control.Invoke(action);
                } else {
                    action();
                }
            }
        }

        /// <summary>
        /// Shows and activates form.
        /// </summary>
        /// <param name="form"></param>
        public static void ShowActivate(this Form form) {
            if (!form.Visible) {
                form.Show();
            }

            if (form.WindowState == FormWindowState.Minimized) {
                form.WindowState = FormWindowState.Normal;
            }

            form.BringToFront();
            form.Activate();
        }

        public static void SetProperty(this object obj, JProperty jProperty) {
            PropertyInfo property = obj.GetType().GetProperty(jProperty.Name);

            // Have to explicitly cast JArray
            if (jProperty.Value is JArray) {
                property.SetValue(obj, ((JArray)jProperty.Value).ToObject<object[]>());
            } else {
                property.SetValue(obj, Convert.ChangeType(jProperty.Value, property.PropertyType));
            }
        }

        public static void SetProperty(this object obj, string propertyName, object value) {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
        }
    }
}
