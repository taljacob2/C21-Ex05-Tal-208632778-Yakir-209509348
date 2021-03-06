#region

using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;
using C21_Ex02_01.Com.Team.Entity.Players.Player;

#endregion

namespace C21_Ex02_01.Com.Team.Service.Impl
{
    public class GameServiceImpl : IGameService
    {
        private readonly Board r_Board = GameControllerImpl.Database.Board;

        private readonly Players
            r_Players = GameControllerImpl.Database.Players;

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
            else if (r_Board.IsVictory())
            {
                Player nonCurrentPlayer = r_Players.GetNotCurrentPlayer();
                returnValue = nonCurrentPlayer;
                nonCurrentPlayer.Score++;
                nonCurrentPlayer.ScoreModified();
            }

            return returnValue;
        }

        public void SetTie()
        {
            Player playerOne = r_Players.GetPlayerOne();
            Player playerTwo = r_Players.GetPlayerTwo();
            playerOne.Score++;
            playerOne.ScoreModified();
            playerTwo.Score++;
            playerTwo.ScoreModified();
        }

        public void Forfeit(out Player o_WinnerPlayer)
        {
            o_WinnerPlayer = r_Players.GetNotCurrentPlayer();
            setWinnerPlayer(o_WinnerPlayer);
            ResetForfeitAndWinner();
        }

        public void ResetForfeitAndWinner()
        {
            foreach (Player player in r_Players)
            {
                player.ChosenColumnIndex = 0;
            }

            WinnerPlayer = null;
        }

        private void setWinnerPlayer(Player io_Player)
        {
            WinnerPlayer = io_Player;
            WinnerPlayer.Score++;
            WinnerPlayer.ScoreModified();
        }
    }
}
