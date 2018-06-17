using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClient.Models
{
    public class Setting : BindableBase
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public Setting()
        {
            User = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "TestUser"
            };
        }
    }
}
