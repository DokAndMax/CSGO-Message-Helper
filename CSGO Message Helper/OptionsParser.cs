using CSGO_Message_Helper.Interfaces;
using CSGO_Message_Helper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace CSGO_Message_Helper
{
    internal class OptionsParser : IOptions
    {
        public IList<ColorRepresentation> Colors => GetColors();

        public IList<string> Languages => GetLanguages();

        public IList<string> RadioMessages => GetRadioMessages();

        public IList<string> Locations => GetLocations();


        private IList<ColorRepresentation> GetColors()
        {
            IList<ColorRepresentation> result = new List<ColorRepresentation>();
            foreach (var item in ParseParameters(3, "colors.txt"))
                result.Add(new ColorRepresentation
                {
                    Name = item[0],
                    csColor = item[1][0],
                    Color = (Color)ColorConverter.ConvertFromString(item[2]),
                });
            return result;
        }
        private IList<string> GetLanguages()
        {
            IList<string> result = new List<string>();
            foreach (var item in ParseParameters(1, "languages.txt"))
                result.Add(item[0]);
            return result;
        }
        private IList<string> GetRadioMessages()
        {
            IList<string> result = new List<string>();
            foreach(var item in ParseParameters(1, "radiomessages.txt"))
                result.Add(item[0]);
            return result;
        }
        private IList<string> GetLocations()
        {
            IList<string> result = new List<string>();
            foreach (var item in ParseParameters(1, "locations.txt"))
                result.Add(item[0]);
            return result;
        }

        private IList<string[]> ParseParameters(int parametersPerLine, string filePath)
        {
            char[] spearator = { ' ' };
            IList<string[]> result = new List<string[]>();
            foreach (var line in File.ReadLines(filePath))
            {
                var parameters = line.Split(spearator, parametersPerLine, StringSplitOptions.RemoveEmptyEntries);
                result.Add(parameters);
            }

            return result;
        }
    }
}
