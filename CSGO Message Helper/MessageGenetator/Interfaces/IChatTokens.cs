namespace CSGO_Message_Helper.Interfaces
{
    internal interface IChatTokens
    {
        string Language { get; }
        string RadioMessageToken { get; }
        string TemplateToken { get; }
        string LocationToken { get; }
    }
}
