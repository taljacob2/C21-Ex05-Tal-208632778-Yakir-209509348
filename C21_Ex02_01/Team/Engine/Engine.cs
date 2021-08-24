#region

using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.Engine.Service;
using C21_Ex02_01.Team.Engine.Service.Impl;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        static Engine()
        {
            // Caution: `ResponderService` MUST be defined HERE:
            ResponderService = new ResponderServiceImpl();
        }

        public Engine()
        {
            // Caution: the order here is important:
            RequesterService = new RequesterServiceImpl();
            RequesterService.ConstructEngine(); // UI Request.
            ActuatorService = new ActuatorServiceImpl();
        }

        public static Database.Database Database { get; set; }

        public static IRequesterService RequesterService { get; private set; }

        public static IResponderService ResponderService { get; }

        public static IActuatorService ActuatorService { get; private set; }

        public void RunGame()
        {
            bool continuePlay;
            do
            {
                Database.Players.SwitchCurrentPlayerTurn(Database.Players
                    .GetPlayerTwo());
                Database.Board.ResetBoard();
                whileRunGame();
                continuePlay = RequesterService.RequestNewGame();
            } while (continuePlay);
        }

        private void whileRunGame()
        {
            while (true)
            {
                ResponderService.PrintBoard();

                if (Database.Board.IsFull())
                {
                    // It is a TIE.
                    setTie();
                    break;
                }

                Database.Players.PlayTurn();
                Database.Players.SwitchCurrentPlayerTurn(Database.Players
                    .GetCurrentPlayer());

                if (!isWinnerPlayerHandled())
                {
                    continue;
                }

                // Winner found, and was handled.
                return;
            }
        }

        private static void resetForfeitAndWinner()
        {
            ActuatorService.ResetForfeitAndWinner(); // Database Update.
        }

        private void setTie()
        {
            ActuatorService.SetTie(); // Database Update.
            ResponderService.PrintTie(); // UI Response.
            ResponderService.PrintScores(Database.Players); // UI Response.
        }

        private static bool isWinnerPlayerHandled()
        {
            bool returnValue = true;

            // Check for algorithm WIN here:
            Player winnerPlayer =
                ActuatorService.GetWinnerPlayer(); // Database Update.

            if (winnerPlayer == null)
            {
                returnValue = false;
            }
            else
            {
                // Winner Found. Handle it.
                printWinResponse(winnerPlayer);
                resetForfeitAndWinner(); // Database Update.
            }

            return returnValue;
        }

        private static void printWinResponse(Player i_WinnerPlayer)
        {
            ResponderService.PrintBoard(); // UI Response.
            ResponderService.PrintWinner(i_WinnerPlayer); // UI Response.
            ResponderService.PrintScores(Database.Players); // UI Response.
        }
    }
}
