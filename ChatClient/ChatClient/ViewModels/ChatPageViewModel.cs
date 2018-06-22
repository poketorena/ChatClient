﻿using ChatClient.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModels
{
    public class ChatPageViewModel : ViewModelBase
    {
        // プロパティ
        public ReactiveProperty<ReactiveCollection<Talk>> Talks { get; } = new ReactiveProperty<ReactiveCollection<Talk>>();

        public ReactiveProperty<string> InputText { get; set; } = new ReactiveProperty<string>();

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
        private SignalRClient _signalRClient;

        // コンストラクタ
        public ChatPageViewModel(INavigationService navigationService, ITalkManager talkManager, Setting setting, SignalRClient signalRClient)
            : base(navigationService)
        {
            Title = "Chat Page";
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


            // とりあえず今はローカルのコレクションに追加する
            var talk = new Talk
            {
                Text = InputText.Value,
                User = _setting.User
            };

            // モデルのコレクションに追加
            //_talkManager.Add(talk);

            // クラウドにトークを送信する
            Task.Run(async () => await _signalRClient.SendMessage("MESSAGE", talk));

            // テキストを
            InputText.Value = string.Empty;
        }
    }
}
