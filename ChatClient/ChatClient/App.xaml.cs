﻿using Prism;
using Prism.Ioc;
using ChatClient.ViewModels;
using ChatClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using ChatClient.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChatClient
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ChatPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ChatPage>();
            containerRegistry.RegisterSingleton<ITalkManager, TalkManager>();
            containerRegistry.RegisterSingleton<Setting>();
            containerRegistry.RegisterSingleton<MobileClient.SignalRClient>();
        }
    }
}
