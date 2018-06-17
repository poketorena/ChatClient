using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    public class TalkManager : BindableBase, ITalkManager
    {
        private ReactiveCollection<Talk> _talks;

        public ReactiveCollection<Talk> Talks
        {
            get { return _talks; }
            set { SetProperty(ref _talks, value); }
        }

        public void Add(Talk talk)
        {
            Talks.AddOnScheduler(talk);
        }

        public Task LoadAsync() => throw new NotImplementedException();

        public TalkManager()
        {
            Talks = new ReactiveCollection<Talk>();
        }
    }
}
