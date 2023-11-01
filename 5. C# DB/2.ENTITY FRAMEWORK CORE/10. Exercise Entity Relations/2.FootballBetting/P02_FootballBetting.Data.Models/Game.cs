using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class Game
{
    public Game()
    {
        PlayersStatistics = new HashSet<PlayerStatistic>();
        Bets = new HashSet<Bet>();
    }



    [Key]
    public int GameId { get; set; }

    [Required]
    public int HomeTeamId { get; set; }

    public virtual Team HomeTeam { get; set; } = null!;

    [Required]
    public int AwayTeamId {  get; set; }

    public virtual Team AwayTeam { get; set; } = null!;

    [Required]
    public int HomeTeamGoals { get; set; }

    [Required]
    public int AwayTeamGoals { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public double HomeTeamBetRate { get; set; }

    [Required]
    public double AwayTeamBetRate { get; set; }

    [Required]
    public double DrawBetRate { get; set; }

    public string? Result {  get; set; }


    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    public virtual ICollection<Bet> Bets { get; set; }


}
