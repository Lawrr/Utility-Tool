using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

namespace UtilityTool.Layout {
    public class LayoutBuilder {
        public const string DefaultLayoutPath = @"layout.json";
        public LayoutDetails LayoutDetails { get; private set; }

        public LayoutBuilder(string layoutPath) {
            LayoutDetails = new LayoutDetails();

            // Create layout json file if it does not exist
            if (!File.Exists(layoutPath)) {
                File.WriteAllText(DefaultLayoutPath, "{}");
            }

            // Parse layout json file
            string content = Regex.Replace(File.ReadAllText(layoutPath), @"\\", @"\\");
            JObject obj = JsonConvert.DeserializeObject<JObject>(content);
            // Go through each property and set the value
            foreach (JProperty property in obj.Properties()) {
                // Special case for components
                if (property.Name == "Components") {
                    AddComponents(property.Value);
                } else {
                    LayoutDetails.SetProperty(property);
                }
            }
        }

        private void AddComponents(dynamic components) {
            IComponent component;

            // Create each component
            foreach (var properties in components) {
                // Check that there is a Type property
                if (properties.Type == null) {
                    // No type for component
                    Console.WriteLine("No type specified for component");
                    continue;
                }

                switch ((string)properties.Type) {
                    case "Button":
                        component = new LayoutButton();
                        foreach (JProperty property in properties) {
                            component.SetProperty(property);
                        }
                        LayoutDetails.Add(component);
                        break;

                    default:
                        // Unhandled type
                        Console.WriteLine("Unhandled type '{0}'", properties.Type);
                        break;
                }
            }
        }
    }
}
