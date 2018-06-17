using ChatClient.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatClient.ViewModels
{
    public class ChatPageViewModel : ViewModelBase
    {
        // プロパティ
        public ReactiveProperty<ReactiveCollection<Talk>> Talks { get; } = new ReactiveProperty<ReactiveCollection<Talk>>();

        public ReactiveProperty<string> InputText { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> UserName { get; set; } = new ReactiveProperty<string>("TestUser");

        // デリゲートコマンド
        private DelegateCommand _sendTextCommand;
        public DelegateCommand SendTextCommand =>
            _sendTextCommand ?? (_sendTextCommand = new DelegateCommand(ExecuteSendTextCommand));

        //private DelegateCommand<Memo> _itemSelectedCommand;
        //public DelegateCommand<Memo> ItemSelectedCommand =>
        //    _itemSelectedCommand ?? (_itemSelectedCommand = new DelegateCommand<Memo>(ExecuteItemSelectedCommand));

        // プライベート変数
        private readonly ITalkManager _talkManager;
        private readonly Setting _setting;

        // コンストラクタ
        public ChatPageViewModel(INavigationService navigationService, ITalkManager talkManager, Setting setting)
            : base(navigationService)
        {
            Title = "Chat Page";
            _talkManager = talkManager;
            _setting = setting;
            Talks = _talkManager.ToReactivePropertyAsSynchronized(x => x.Talks);
        }

        // プライベート関数
        private void ExecuteSendTextCommand()
        {
            // クラウドにトークを送信する

            // とりあえず今はローカルのコレクションに追加する
            var talk = new Talk
            {
                Text = InputText.Value,
                User = _setting.User
            };

            _talkManager.Add(talk);
            InputText.Value = string.Empty;
        }
    }
}
