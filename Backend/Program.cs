using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.KlaseZaIzgradnjuStringova;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    HostConfig.CertPath = context.Configuration["CertPath"];
                    HostConfig.CertPassword = context.Configuration["CertPassword"];
                    HostConfig.MaxRequestBodySize = context.Configuration.GetValue<int>("TusConfig:TusMaxRequestBodySize");
                    HostConfig.HostDnsEntry = context.Configuration["HostDnsEntry"];
                    foreach (var tip in context.Configuration.GetSection("TusConfig:TusDozvoljeniFormati").Get<Dictionary<string, string>>())
                    {
                        Poruke.dozvoljeneEkstenzije += $"{tip.Value}, ";
                        Regex.tipFajla += $"({tip.Value})|";
                    }
                    Poruke.dozvoljeneEkstenzije = Poruke.dozvoljeneEkstenzije.Remove(Poruke.dozvoljeneEkstenzije.Length - 2, 2);
                    Regex.tipFajla = Regex.tipFajla.Remove(Regex.tipFajla.Length - 1, 1);
                    Regex.putanjaIEkstenzija += $"({Regex.tipFajla})$";
                    Regex.nazivSaEkstenzijom += $"({Regex.tipFajla})$";
                    Regex.putanjaNazivIEkstenzija += Regex.nazivSaEkstenzijom.Remove(0, 1);
                    Regex.tipFajla += "^(" + Regex.tipFajla + ")$";
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.ConfigureKestrel(opcije =>
                    {
                        var host = Dns.GetHostEntry(HostConfig.HostDnsEntry);
                        opcije.Limits.MaxRequestBodySize = HostConfig.MaxRequestBodySize;
                        opcije.Listen(host.AddressList[0], 5000);
                        opcije.Listen(host.AddressList[0], 5001, listenOpcije =>
                        {
                            listenOpcije.UseHttps(HostConfig.CertPath, HostConfig.CertPassword);
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
        public static class HostConfig
        {
            public static string CertPath { get; set; }
            public static string CertPassword { get; set; }
            public static int MaxRequestBodySize { get; set; }
            public static string HostDnsEntry { get; set; }
        }
    }
}
