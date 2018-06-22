using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    /// <summary>
    /// SignalR Client
    /// </summary>
    public class SignalRClient
    {
        private HubConnection _hub;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public HubConnection Hub { get { return _hub; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRClient"/> class.
        /// </summary>
        public SignalRClient()
        {
            Debug.WriteLine("SignalR Initialized...");
            InitializeSignalR().ContinueWith(task =>
            {
                Debug.WriteLine("SignalR Started...");
            });
        }

        /// <summary>
        /// Initializes SignalR.
        /// </summary>
        public async Task InitializeSignalR()
        {
            _hub = new HubConnectionBuilder()
                .WithUrl("http://aspnetcoresignalr20180618104929.azurewebsites.net/updater")
                .Build();

            // 受け取る側　未完成
            _hub.On<string, Talk>("NewMessage",
                (command, talk) => ValueChanged?
                .Invoke(this, new ValueChangedEventArgs(command, talk)));

            await _hub.StartAsync();
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="state">The state.</param>
        public async Task SendMessage(string command, Talk talk)
        {
            await _hub?.InvokeAsync("NewMessage", new object[] { command, talk });
        }
    }

}
