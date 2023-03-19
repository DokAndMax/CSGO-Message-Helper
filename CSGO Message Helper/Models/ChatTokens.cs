using CSGO_Message_Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
