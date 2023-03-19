using CSGO_Message_Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Message_Helper.Models
{
    internal class ChatParams : IChatParams
    {
        public string RadioMessage { get; set; }

        public string Template { get; set; }

        public string Location { get; set; }
    }
}
