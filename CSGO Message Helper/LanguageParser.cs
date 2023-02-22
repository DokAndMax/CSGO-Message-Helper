using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper
{
    internal class LanguageParser : ILanguage
    {
        private char color;
        private string nickname;
        private string message;

        public LanguageParser()
        {
        }

        public string RadioMessage => throw new NotImplementedException();

        public string Template => throw new NotImplementedException();

        public string Location => throw new NotImplementedException();

    }
}
