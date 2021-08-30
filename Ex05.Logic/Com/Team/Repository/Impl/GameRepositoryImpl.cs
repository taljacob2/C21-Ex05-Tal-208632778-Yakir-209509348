using C21_Ex02_01.Com.Team.Database;
using C21_Ex02_01.Com.Team.Database.Impl;
using C21_Ex02_01.Com.Team.Entity.Players;
using C21_Ex02_01.Com.Team.Entity.Players.Player;

namespace C21_Ex02_01.Com.Team.Repository.Impl
{
    public class GameRepositoryImpl : IGameRepository
    {
        public IGameDatabase GameDatabase { get; private set; } =
            new GameDatabaseImpl();

        public Player GetNotCurrentPlayer()
        {
            return GameDatabase.GetRefPlayers().GetNotCurrentPlayer();
        }

        public Player GetCurrentPlayer()
        {
            return GameDatabase.GetRefPlayers().GetCurrentPlayer();
        }

        public bool IsVictory()
        {
            return GameDatabase.GetRefBoard().IsVictory();
        }

        public void ResetScoresOfPlayers()
        {
            foreach (Player player in GameDatabase.GetRefPlayers())
            {
                player.ChosenColumnIndex = 0;
            }
        }

        public void SwitchCurrentPlayerTurn()
        {
            GameDatabase.GetRefPlayers().SwitchCurrentPlayerTurn();
        }

        public void SetCurrentPlayer(eID i_PlayerID)
        {
            GameDatabase.GetRefPlayers().SetCurrentPlayer(i_PlayerID);
        }

        public void ResetBoard()
        {
            GameDatabase.GetRefBoard().ResetBoard();
        }

        public Player GetRefPlayerOne()
        {
            return GameDatabase.GetRefPlayers().GetPlayerOne();
        }

        public Player GetRefPlayerTwo()
        {
            return GameDatabase.GetRefPlayers().GetPlayerTwo();
        }

        public bool IsFull()
        {
            return GameDatabase.GetRefBoard().IsFull();
        }
    }
}
