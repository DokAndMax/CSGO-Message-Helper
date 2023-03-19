using CSGO_Message_Helper.Interfaces;

namespace CSGO_Message_Helper
{
    internal class MessageGenerator : IMessageGenerator
    {
        private readonly ICTLocalizator localizator;

        public MessageGenerator(ICTLocalizator localizator)
        {
            this.localizator = localizator;
        }

        public string GetConsoleCommand(IChatTokens chatTokens, IPlayerParams playerParams)
        {
            IChatParams chatParams = localizator.LocalizeChatTokens(chatTokens);

            string chatLine = chatParams.Template.Replace("%s1", playerParams.Nickname)
                        .Replace("%s3", chatParams.Location)
                        .Replace("%s2", playerParams.Message);

            /*
             * 
             * \x0004 - символ нового рядка
             * \x202D - LEFT-TO-RIGHT OVERRIDE
             * \x202E - RIGHT-TO-LEFT OVERRIDE
             * \x202С - POP DIRECTIONAL FORMATTING CODE
             * 
             */
            return $"playerchatwheel CW.NeedDecoy " +
                $"\"{chatParams.RadioMessage}\x2029" +
                $"\x202E\x202D{chatLine}" +
                $"\x202C{playerParams.csColor} ●\x202C\"";
        }

        public string GetTemplateToken(IGameParams gameParams)
        {
            string result = "Cstrike_Chat";
            if (gameParams.IsCounterTerrorists) result += "_CT";
            else if (gameParams.IsTerrorists) result += "_T";
            else if (gameParams.IsAll) result += "_All";

            if (gameParams.IsDead) result += "_Dead";
            else if (gameParams.IsLocation && !gameParams.IsAll) result += "_Loc";

            if (gameParams.IsAll && result.Contains("All_"))
                result = result.Replace("All_", "All");

            return result;
        }
    }
}
