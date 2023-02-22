using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper
{
    internal class MessageGenerator : IConsoleCommand
    {
        private readonly ILanguage language;
        public MessageGenerator(ILanguage language)
        {
            this.language = language;
        }

        public string ConsoleCommand => GetConsoleCommand();

        private string GetChatLine()
        {
            return language.Template.Replace("%s1", language.Nickname)
                        .Replace("%s3", language.Location)
                        .Replace("%s2", language.Message);
        }

        private string GetConsoleCommand()
        {
            /*
             * 
             * \x0004 - символ нового рядка
             * \x202D - LEFT-TO-RIGHT OVERRIDE
             * \x202E - RIGHT-TO-LEFT OVERRIDE
             * \x202С - POP DIRECTIONAL FORMATTING CODE
             * 
             */
            return $"playerchatwheel CW.NeedDecoy " +
                $"\"{language.RadioMessage}\x0004" +
                $"\x202E\x202D{GetChatLine()}" +
                $"\x202C{language.Color} ●\x202C";
        }
    }
}
