using CSGO_Message_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Message_Helper.Interfaces
{
    internal interface IOptions
    {
        IList<ColorRepresentation> Colors { get; }
        IList<string> Languages { get; }
        IList<string> RadioMessages { get; }
        IList<string> Locations { get; }
    }
}
