using C21_Ex02_01.Com.Team.Entity.Players.Player;

namespace C21_Ex02_01.Com.Team.Repository
{
    public interface IGameRepository
    {
        Player GetNotCurrentPlayer();

        bool IsVictory();

        void IncreaseScoreOfPlayerOne();
        
        void IncreaseScoreOfPlayerTwo();

        void ResetScoresOfPlayers();

        /// <summary />
        /// <returns>The winner player.</returns>
        Player Forfeit();
    }
}
