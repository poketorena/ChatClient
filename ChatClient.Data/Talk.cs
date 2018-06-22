using Prism.Mvvm;
using System;

namespace ChatClient.Data
{
    public class Talk : BindableBase
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private DateTime _dateTime;
        public DateTime PostedTime
        {
            get { return _dateTime; }
            set { SetProperty(ref _dateTime, value); }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public Talk()
        {
            Id = Guid.NewGuid().ToString();
            PostedTime = DateTime.Now;
        }
    }
}
