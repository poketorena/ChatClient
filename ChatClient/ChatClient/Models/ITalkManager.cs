using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    public interface ITalkManager : INotifyPropertyChanged
    {
        ReactiveCollection<Talk> Talks { get; set; }
        void Add(Talk talk);
        Task LoadAsync();
    }
}
