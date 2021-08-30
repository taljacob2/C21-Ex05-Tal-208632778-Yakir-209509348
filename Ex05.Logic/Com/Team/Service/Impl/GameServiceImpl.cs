#region

using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;
using C21_Ex02_01.Com.Team.Entity.Players.Player;
using C21_Ex02_01.Com.Team.Repository;
using C21_Ex02_01.Com.Team.Repository.Impl;

#endregion

namespace C21_Ex02_01.Com.Team.Service.Impl
{
    public class GameServiceImpl : IGameService
    {
        public IGameRepository GameRepository { get; private set; } =
            new GameRepositoryImpl();

        // private readonly Board r_Board =
        //     GameControllerImpl.GameDatabaseImpl.Board;
        //
        // private readonly Players
        //     r_Players = GameControllerImpl.GameDatabaseImpl.Players;

        public Player WinnerPlayer { get; set; }

        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        /// </summary>
        /// <returns>`Winner-Player` if exists. Else, returns `null`.</returns>
        public Player GetWinnerPlayer()
        {
            Player returnValue = null;

            if (WinnerPlayer != null)
            {
                returnValue = WinnerPlayer;
            }
            else if (GameRepository.IsVictory())
            {
                Player nonCurrentPlayer = GameRepository.GetNotCurrentPlayer();
                returnValue = nonCurrentPlayer;
                nonCurrentPlayer.Score++;
                nonCurrentPlayer.ScoreModified();
            }

            return returnValue;
        }

        public void SetTie()
        {
            GameRepository.IncreaseScoreOfPlayerOne();
            GameRepository.IncreaseScoreOfPlayerTwo();
        }

        public void Forfeit(out Player o_WinnerPlayer)
        {
            o_WinnerPlayer = GameRepository.Forfeit();
        }

        public void ResetScoresAndWinner()
        {
            GameRepository.ResetScoresOfPlayers();
            WinnerPlayer = null;
        }
    }
}
