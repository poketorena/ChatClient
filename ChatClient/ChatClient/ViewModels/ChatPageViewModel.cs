using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatClient.ViewModels
{
    public class ChatPageViewModel : ViewModelBase
    {
        public ChatPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Chat Page";
        }
    }
}
