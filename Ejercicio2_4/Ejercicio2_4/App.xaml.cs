﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio2_4.Controllers;

namespace Ejercicio2_4
{
    public partial class App : Application
    {
        static DataBase BaseDatos;

        public static DataBase BaseDatosObject
        {
            get
            {
                if (BaseDatos == null)
                {
                    BaseDatos = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Videos22.db3"));
                }
                return BaseDatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
