#region

using C21_Ex02_01.Com.Team.Entity.Players.Player;
using C21_Ex02_01.Com.Team.Service;

#endregion

namespace C21_Ex02_01.Com.Team.Controller.Impl
{
    public class GameControllerImpl : IGameController
    {
        public static Database.Database Database { get; set; }

        public static IGameService GameService { get; set; }

        /// <summary />
        /// <param name="i_ChosenColumnIndex" />
        /// <param name="o_WinnerPlayer">
        ///     If this is <see langword="null" />
        ///     and <paramref name="o_IsGameOver" /> is <see langword="true" /> then
        ///     it means the game was over with a TIE.
        /// </param>
        /// <param name="o_IsGameOver" />
        public void PostChooseColumnAsHumanPlayer(byte i_ChosenColumnIndex,
            out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            playTurn(i_ChosenColumnIndex);
            checkWinAndTie(out o_WinnerPlayer, out o_IsGameOver);
        }

        /// <summary />
        /// <param name="o_WinnerPlayer">
        ///     If this is <see langword="null" />
        ///     and <paramref name="o_IsGameOver" /> is <see langword="true" /> then
        ///     it means the game was over with a TIE.
        /// </param>
        /// <param name="o_IsGameOver" />
        public void PostChooseColumnAsComputerPlayerIfExists(
            out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            if (!isComputerPlayerExistsAndPlayed())
            {
                o_WinnerPlayer = null;
                o_IsGameOver = false;
                return;
            }

            checkWinAndTie(out o_WinnerPlayer, out o_IsGameOver);
        }
        
        private void checkWinAndTie(out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            Database.Players.SwitchCurrentPlayerTurn(Database.Players
                .GetCurrentPlayer());
            o_WinnerPlayer = getWinnerPlayer();
            o_IsGameOver = o_WinnerPlayer != null;
            if (!o_IsGameOver)
            {
                o_IsGameOver = isTie();
            }
        }

        public void NewGame()
        {
            Database.Players.SwitchCurrentPlayerTurn(Database.Players
                .GetPlayerTwo());
            Database.Board.ResetBoard();
        }

        public void Forfeit(out Player o_WinnerPlayer)
        {
            GameService.Forfeit(out o_WinnerPlayer);
        }

        private static void resetForfeitAndWinner()
        {
            GameService.ResetForfeitAndWinner(); // Database Update.
        }

        private void setTie()
        {
            GameService.SetTie(); // Database Update.
        }

        private static Player getWinnerPlayer()
        {
            // Check for algorithm WIN here:
            Player returnValue =
                GameService.GetWinnerPlayer(); // Database Update.

            if (returnValue != null)
            {
                // Winner Found. Handle it.
                resetForfeitAndWinner(); // Database Update.
            }

            return returnValue;
        }

        private static bool isComputerPlayerExistsAndPlayed()
        {
            bool returnValue = true;
            Player currentPlayer = Database.Players.GetCurrentPlayer();

            if (currentPlayer is ComputerPlayer)
            {
                currentPlayer.PlayTurn();
            }
            else
            {
                returnValue = false;
            }

            return returnValue;
        }

        private bool isTie()
        {
            bool returnValue = Database.Board.IsFull();

            if (returnValue)
            {
                // It is a TIE.
                setTie();
            }

            return returnValue;
        }

        private static void playTurn(byte i_ChosenColumnIndex)
        {
            Player currentPlayer = Database.Players.GetCurrentPlayer();
            currentPlayer.ChosenColumnIndex = i_ChosenColumnIndex;
            currentPlayer.PlayTurn();
        }
    }
}
