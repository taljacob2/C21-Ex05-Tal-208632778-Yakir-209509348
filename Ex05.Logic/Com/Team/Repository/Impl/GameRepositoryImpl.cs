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

        public bool IsVictory()
        {
            return GameDatabase.GetRefBoard().IsVictory();
        }

        public void IncreaseScoreOfPlayerOne()
        {
            Players players = GameDatabase.GetRefPlayers();
            increaseScoreOfPlayer(players.GetPlayerOne());
        }

        public void IncreaseScoreOfPlayerTwo()
        {
            Players players = GameDatabase.GetRefPlayers();
            increaseScoreOfPlayer(players.GetPlayerTwo());
        }

        private static void increaseScoreOfPlayer(Player io_Player)
        {
            io_Player.Score++;
            io_Player.ScoreModified();
        }

        public void ResetScoresOfPlayers()
        {
            foreach (Player player in GameDatabase.GetRefPlayers())
            {
                player.ChosenColumnIndex = 0;
            }
        }

        public Player Forfeit()
        {
            Players players = GameDatabase.GetRefPlayers();
            Player winnerPlayer = players.GetNotCurrentPlayer();
            increaseScoreOfPlayer(winnerPlayer);
            ResetScoresOfPlayers();

            return winnerPlayer;
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
    }
}
