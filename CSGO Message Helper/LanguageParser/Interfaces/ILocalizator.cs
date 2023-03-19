using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Message_Helper.Interfaces
{
    internal interface ILocalizator
    {
        string GetLocaleValue(string language, string token);
    }
}
