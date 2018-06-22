using ChatClient.Data;
using ChatClient.Models;
using MobileClient;
using Prism.Commands;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Threading.Tasks;

namespace ChatClient.ViewModels
{
    public class TalkPageViewModel : ViewModelBase
    {
        // プロパティ
        public ReactiveProperty<ReactiveCollection<Talk>> Talks { get; } = new ReactiveProperty<ReactiveCollection<Talk>>();

        public ReactiveProperty<string> InputText { get; set; } = new ReactiveProperty<string>();

        // デリゲートコマンド
        private DelegateCommand _sendTextCommand;
        public DelegateCommand SendTextCommand =>
            _sendTextCommand ?? (_sendTextCommand = new DelegateCommand(ExecuteSendTextCommand));

        // プライベート変数
        private readonly ITalkManager _talkManager;
        private readonly Setting _setting;
        private MobileClient.SignalRClient _signalRClient;

        // コンストラクタ
        public TalkPageViewModel(INavigationService navigationService, ITalkManager talkManager, Setting setting, SignalRClient signalRClient)
            : base(navigationService)
        {
            _talkManager = talkManager;
            _setting = setting;
            _signalRClient = signalRClient;
            _signalRClient.ValueChanged += SignalR_ValueChanged;
            Talks = _talkManager.ToReactivePropertyAsSynchronized(x => x.Talks);
        }

        private void SignalR_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _talkManager.Talks.AddOnScheduler(e.Talk);
        }

        // プライベート関数
        private void ExecuteSendTextCommand()
        {
            var talk = new Talk
            {
                Text = InputText.Value,
                User = _setting.User
            };

            // クラウドにトークを送信する
            Task.Run(async () => await _signalRClient.SendMessage("MESSAGE", talk));

            // テキストを空にする
            InputText.Value = string.Empty;
        }
    }
}
