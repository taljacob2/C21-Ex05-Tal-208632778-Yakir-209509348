#region

using C21_Ex02_01.Com.Team.Database;
using C21_Ex02_01.Com.Team.Entity.Players.Player;
using C21_Ex02_01.Com.Team.Service;

#endregion

namespace C21_Ex02_01.Com.Team.Controller.Impl
{
    public class GameControllerImpl : IGameController
    {
        public static Database.Impl.GameDatabaseImpl GameDatabaseImpl { get; set; }

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
            GameService.PlayTurnWithCurrentPlayer(i_ChosenColumnIndex);
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
            if (!GameService.IsComputerPlayerExistsAndPlayed())
            {
                o_WinnerPlayer = null;
                o_IsGameOver = false;
                return;
            }

            checkWinAndTie(out o_WinnerPlayer, out o_IsGameOver);
        }
        
        private void checkWinAndTie(out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            GameService.SwitchCurrentPlayerTurn();
            o_WinnerPlayer = getWinnerPlayer();
            o_IsGameOver = o_WinnerPlayer != null;
            if (!o_IsGameOver)
            {
                o_IsGameOver = isTie();
            }
        }

        public void NewGame()
        {
            GameService.SetCurrentPlayer(eID.One);
            GameService.ResetBoard();
        }

        public void Forfeit(out Player o_WinnerPlayer)
        {
            GameService.Forfeit(out o_WinnerPlayer);
        }

        private static void resetForfeitAndWinner()
        {
            GameService.ResetScoresAndWinner(); // Database Update.
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

        private bool isTie()
        {
            bool returnValue = GameService.IsFull();

            if (returnValue)
            {
                // It is a TIE.
                setTie();
            }

            return returnValue;
        }
        
    }
}
