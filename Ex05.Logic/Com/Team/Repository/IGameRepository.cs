using C21_Ex02_01.Com.Team.Entity.Players.Player;

namespace C21_Ex02_01.Com.Team.Repository
{
    public interface IGameRepository
    {
        Player GetNotCurrentPlayer();

        Player GetCurrentPlayer();
        
        bool IsVictory();

        void ResetScoresOfPlayers();

        void SwitchCurrentPlayerTurn();
        
        void SetCurrentPlayer(eID i_PlayerID);
        
        void ResetBoard();
        
        Player GetRefPlayerOne();
        
        Player GetRefPlayerTwo();

        bool IsFull();
        
    }
}
