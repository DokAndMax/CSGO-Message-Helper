using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Message_Helper
{
    class Langs
    {
        public string dead { get; set; }
        public string TeamT { get; set; }
        public string TeamCT { get; set; }
        public string radioMessage { get; set; }
        public string positionT { get; set; }
        public string positionCT { get; set; }

        public Langs(string dead, string TeamT, string TeamCT, string radioMessage, string positionT, string positionCT)
        {
            this.dead = dead;
            this.TeamT = TeamT;
            this.TeamCT = TeamCT;
            this.radioMessage = radioMessage;
            this.positionT = positionT;
            this.positionCT = positionCT;
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
