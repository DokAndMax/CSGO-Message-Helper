namespace CSGO_Message_Helper.Interfaces
{
    internal interface IMessageGenerator
    {
        string GetConsoleCommand(IChatTokens chatTokens, IPlayerParams playerParams);
        string GetTemplateToken(IGameParams gameParams);
    }
}
