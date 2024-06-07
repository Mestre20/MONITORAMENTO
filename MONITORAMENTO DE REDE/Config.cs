using System;
using System.IO;
using System.Text.Json;

namespace MONITORAMENTO_DE_REDE
{
    public class Config
    {
        public string[] IPAddresses { get; set; }
        public int PingInterval { get; set; } // Certifique-se de que esta propriedade está presente

        private static string configFilePath = "config.json";

        public Config()
        {
            IPAddresses = new string[]
            {
                "192.168.30.1", "192.168.30.2", "192.168.30.3",
                "192.168.30.4", "192.168.30.5", "192.168.30.6",
                "192.168.30.7", "192.168.30.8", "192.168.3.5",
                "192.168.30.10", "8.8.8.8"
            };
            PingInterval = 20000; // Intervalo padrão de 20 segundos
        }

        public static Config LoadConfig()
        {
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                return JsonSerializer.Deserialize<Config>(json);
            }
            return new Config();
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFilePath, json);
        }
    }
}
