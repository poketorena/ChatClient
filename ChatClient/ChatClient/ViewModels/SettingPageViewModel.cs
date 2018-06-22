using ChatClient.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Reactive.Bindings;

namespace ChatClient.ViewModels
{
    public class SettingPageViewModel : BindableBase
    {
        // プロパティ
        public ReactiveProperty<string> UserName { get; set; } = new ReactiveProperty<string>();

        // デリゲートコマンド
        private DelegateCommand _updateUserNameCommand;
        public DelegateCommand UpdateUserNameCommand =>
            _updateUserNameCommand ?? (_updateUserNameCommand = new DelegateCommand(() =>
            {
                _setting.User.Name = UserName.Value;
                _pageDialogService.DisplayAlertAsync("通知", $"ユーザー名が「{UserName.Value}」に変更されました。", "OK");
                UserName.Value = string.Empty;
            }));

        // プライベート変数
        private readonly IPageDialogService _pageDialogService;
        private readonly Setting _setting;

        // コンストラクタ
        public SettingPageViewModel(IPageDialogService pageDialogService, Setting setting)
        {
            _pageDialogService = pageDialogService;
            _setting = setting;
        }
    }
}
