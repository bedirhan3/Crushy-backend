namespace Crushy.Dtos;

public class MatchInfoDTO
{
    public int OpponentId { get; set; }
    public int OpponentAge { get; set; }
    public double OpponentLatitude { get; set; }
    public double OpponentLongitude { get; set; }
    public double Distance { get; set; }
    public double MatchScore { get; set; }
    public int MatchPhase { get; set; }
    public string MatchCriteria { get; set; }
}