namespace CSGO_Message_Helper.Interfaces
{
    internal interface ICTLocalizator
    {
        IChatParams LocalizeChatTokens(IChatTokens chatTokens);
    }
}