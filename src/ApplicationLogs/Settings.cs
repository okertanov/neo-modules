using Microsoft.Extensions.Configuration;

namespace Neo.Plugins
{
    internal class Settings
    {
        public string Path { get; }
        public uint Network { get; }
        public int MaxStackSize { get; }

        public static Settings Default { get; private set; }

        private Settings(IConfigurationSection section)
        {
            this.Path = section.GetValue("Path", "ApplicationLogs_{0}");
            this.Network = section.GetValue("Network", 5195086u);
            this.MaxStackSize = section.GetValue("MaxStackSize", (int)ushort.MaxValue);
        }

        public static void Load(IConfigurationSection section)
        {
            Default = new Settings(section);
        }
    }
}
