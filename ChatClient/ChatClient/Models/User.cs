using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClient.Models
{
    public class User : BindableBase
    {
        private string _iD;
        public string Id
        {
            get { return _iD; }
            set { SetProperty(ref _iD, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
