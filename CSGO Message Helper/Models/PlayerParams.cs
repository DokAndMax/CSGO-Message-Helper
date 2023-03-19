using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper
{
    internal class PlayerParams : IPlayerParams
    {
        public char csColor { get; set; }

        public string Nickname { get; set; }
                            
        public string Message { get; set; }
    }
}
