using CSGO_Message_Helper.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSGO_Message_Helper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IMessageGenerator, MessageGenerator>();
            services.AddTransient<ICTLocalizator, LanguageParser>();
            services.AddTransient<IOptions, OptionsParser>();

            services.AddTransient<MainWindowVM>();

            return services.BuildServiceProvider();
        }
    }
}
