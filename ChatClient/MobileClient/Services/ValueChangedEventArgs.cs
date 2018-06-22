using ChatClient.Data;
using System;

namespace MobileClient
{
    /// <summary>
    /// Value Changed EventArgs
    /// </summary>
    public class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
        /// <summary>
        /// Gets the state.
        /// </summary>
        public Talk Talk { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="talk">The state.</param>
        public ValueChangedEventArgs(string command, Talk talk)
        {
            Command = command;
            Talk = talk;
        }
    }
}
