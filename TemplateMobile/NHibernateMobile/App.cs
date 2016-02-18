using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Autofac;
using Demo.Configuration;
using Demo.Models.Domain.UserModels;
using Demo.ServicesPortable.UserProfileService;
using Xamarin.Forms;
using Demo.Validation;
using DemoMobile.Annotations;
using DemoMobile.Pages;

namespace DemoMobile
{
    public class App : Application
    {
        public static IContainer Container { get; set; }
        
        public App()
        {
            InitIOC();

            MainPage = new UserProfilePage();
        }

        private void InitIOC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MobileRepository>()
                .As<IRepository>();

            builder.RegisterType(typeof (UserProfileService));

            App.Container = builder.Build();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
