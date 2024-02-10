using CSGO_Message_Helper.Models;
using System.Collections.Generic;

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
