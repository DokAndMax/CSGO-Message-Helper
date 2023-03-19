using CSGO_Message_Helper.Interfaces;
using CSGO_Message_Helper.Models;
using Gameloop.Vdf;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CSGO_Message_Helper
{
    internal class LanguageParser : ILocalizator, ICTLocalizator
    {
        public IChatParams LocalizeChatTokens(IChatTokens chatTokens)
        {
            ChatParams chatParams = new ChatParams
            {
                RadioMessage = GetLocaleValue(chatTokens.Language, chatTokens.RadioMessageToken),
                Location = GetLocaleValue(chatTokens.Language, chatTokens.LocationToken),
                Template = GetLocaleValue(chatTokens.Language, chatTokens.TemplateToken)
            };

            return chatParams;
        }
        public string GetLocaleValue(string language, string token)
        {
            string CSGOPath = GetCSGOPath();

            return GetLocaleValue(CSGOPath, language, token);
        }

        private string GetLocaleValue(string CSGOpath, string language, string token)
        {
            Regex conditionalPattern = new Regex(@"\[(?>\!|\$).*\]\r?$",
                RegexOptions.Compiled | RegexOptions.Multiline);

            string localeFilePath = $@"{CSGOpath}\csgo\resource\csgo_{language}.txt";
            string localeFileText = conditionalPattern.Replace(File.ReadAllText(localeFilePath), "");

            var languageConfig = VdfConvert.Deserialize(localeFileText);

            string result = languageConfig.Value["Tokens"]?[token].ToString();
            
            if (result is null)
                throw new Exception("Token not found");
            return result;
        }

        private string GetCSGOPath()
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 730";
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey registryKey = hklm.OpenSubKey(registryPath);

            if(registryKey is null)
                throw new Exception("CSGO is not installed");
            return registryKey.GetValue("InstallLocation") as string;
        }
    }
}
