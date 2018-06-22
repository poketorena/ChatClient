using ChatClient.Data;
using Reactive.Bindings;
using System.ComponentModel;
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
