using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper.Models
{
    internal class ChatTokens : IChatTokens
    {
        public string Language { get; set; }

        public string RadioMessageToken { get; set; }

        public string TemplateToken { get; set; }

        public string LocationToken { get; set; }
}
}
