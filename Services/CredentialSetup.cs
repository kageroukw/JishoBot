using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JishoBot.Services
{
    public class CredentialSetup
    {
        public string Prefix { get; }
        
        public string Token { get; }

        public CredentialSetup()
        {
            if (!File.Exists("Data/credentials.json"))
            {
                Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "Data/credentials.json"));
                Console.WriteLine($"credentials.json not found!");
                Environment.Exit(1);
            }

            var config = new ConfigurationBuilder();
            config.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Data/credentials.json"));

            var data = config.Build();
            Prefix = data[nameof(Prefix)];
            Token = data[nameof(Token)];
        }
    }
}