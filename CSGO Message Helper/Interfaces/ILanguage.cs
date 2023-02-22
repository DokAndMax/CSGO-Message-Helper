using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Message_Helper.Interfaces
{
    internal interface ILanguage
    {
        string RadioMessage { get; }
        string Template { get; }
        string Location { get; }

    }
}
