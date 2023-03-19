namespace CSGO_Message_Helper.Interfaces
{
    internal interface IGameParams
    {
        bool IsDead { get; set; }
        bool IsLocation { get; set; }
        bool IsCounterTerrorists { get; set; }
        bool IsTerrorists { get; set; }
        bool IsAll { get; set; }
    }
}
