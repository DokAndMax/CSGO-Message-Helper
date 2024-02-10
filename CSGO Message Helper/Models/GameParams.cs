using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper.Models
{
    internal class GameParams : IGameParams
    {
        public bool IsDead { get; set; }
        public bool IsLocation { get; set; }
        public bool IsTerrorists { get; set ; }
        public bool IsCounterTerrorists { get; set; }
        public bool IsAll { get; set; }
    }
}
