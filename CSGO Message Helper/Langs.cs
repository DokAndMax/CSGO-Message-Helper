using System.Collections.ObjectModel;

namespace CSGO_Message_Helper
{
    class Langs
    {
        public string Dead { get; set; }
        public string TeamT { get; set; }
        public string TeamCT { get; set; }
        public string RadioMessage { get; set; }
        public string PositionT { get; set; }
        public string PositionCT { get; set; }

        public Langs(string dead, string teamT, string teamCT, string radioMessage, string positionT, string positionCT)
        {
            Dead = dead;
            TeamT = teamT;
            TeamCT = teamCT;
            RadioMessage = radioMessage;
            PositionT = positionT;
            PositionCT = positionCT;
        }
    }
    public class PlayerColors
    {
        public string ColorName { get; set; }
        public char CSGOColor { get; set; }
        public string ProgrammTextColor { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<PlayerColors> PlayerColorsCollection { get; private set; }

        public ViewModel()
        {
            PlayerColorsCollection = new ObservableCollection<PlayerColors>
        {
            new PlayerColors() { ColorName = "Yellow", CSGOColor = '\x09', ProgrammTextColor = "#Yellow" },
            new PlayerColors() { ColorName = "Purple", CSGOColor = '\x0E', ProgrammTextColor = "#d32ce6" },
            new PlayerColors() { ColorName = "Green", CSGOColor = '\x04', ProgrammTextColor = "#40ff40" },
            new PlayerColors() { ColorName = "Blue", CSGOColor = '\x0B', ProgrammTextColor = "#5e98d9" },
            new PlayerColors() { ColorName = "Orange", CSGOColor = '\x10', ProgrammTextColor = "#e4ae39" }
        };
        }
    }
}
