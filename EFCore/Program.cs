using Autofac.Extensions.DependencyInjection;
using EFCore.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ConfigurationBuilder�������ļ��ĺ���
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // ����Serilog
            Log.Logger = new LoggerConfiguration()
                // ��ȡ�����ļ�
                .ReadFrom.Configuration(configuration)
                // ��С����־�������
                // .MinimumLevel.Information()
                // ������־���������̨
                .MinimumLevel.Debug()
                // ��־�����������ռ������"Microsoft"��ͷ��������־�����С����ΪInformation
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                //.Enrich.FromLogContext()
                .WriteTo.Console()
                // ����logger
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // ע����������������
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
