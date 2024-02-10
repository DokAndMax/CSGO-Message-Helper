using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper.Models
{
    internal class ChatParams : IChatParams
    {
        public string RadioMessage { get; set; }

        public string Template { get; set; }

        public string Location { get; set; }
    }
}
