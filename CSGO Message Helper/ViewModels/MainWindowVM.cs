using CSGO_Message_Helper.Interfaces;
using CSGO_Message_Helper.Models;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CSGO_Message_Helper
{
    internal class MainWindowVM : IPlayerParams, IGameParams, IChatTokens
    {
        private readonly IMessageGenerator messageGenerator;
        private readonly IOptions options;
        public ICommand GenerateMessageCommand => new DelegateCommand(GenerateMessage);

        public MainWindowVM(IMessageGenerator messageGenerator,
            IOptions options)
        {
            this.messageGenerator = messageGenerator;
            this.options = options;
        }

        public bool IsDead { get; set; }

        public bool IsLocation { get; set; }

        public bool IsCounterTerrorists { get; set; }

        public bool IsTerrorists { get; set; }

        public bool IsAll { get; set; }

        public char csColor => Color.csColor;
        public ColorRepresentation Color { get; set; }
        public IList<ColorRepresentation> Colors => options.Colors;

        public string Nickname { get; set; }

        public string Message { get; set; }

        public string Language { get; set; }
        public IList<string> Languages => options.Languages;

        public string RadioMessageToken { get; set; }
        public IList<string> RadioMessageTokens => options.RadioMessages;

        public string LocationToken { get; set; }
        public IList<string> LocationTokens => options.Locations;

        public string TemplateToken => messageGenerator.GetTemplateToken(this);

        private void GenerateMessage(object parameter)
        {
            Clipboard.SetText(messageGenerator.GetConsoleCommand(this, this));
        }
    }
}
