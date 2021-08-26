#region

using System;
using C21_Ex02_01.Com.Team.Service;

#endregion

namespace C21_Ex02_01.Com.Team.Database.Players.Player
{
    public class HumanPlayer : Player
    {
        public const byte k_QuitSignal = 255;

        public HumanPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            chooseColumnAndTryToInsert();
        }

        private void chooseColumnAndTryToInsert()
        {
            // r_RequesterService.ChooseColumnAsHumanPlayer(this); // UI Request.
            Database database = Controller.Impl.GameControllerImpl.Database;
            if (ChosenColumnIndex == k_QuitSignal)
            {
                // Database Update.
                Controller.Impl.GameControllerImpl.ActuatorService.Forfeit(out Player
                    winnerPlayer);
                return;
            }

            try
            {
                database.Board.InsertCoin(ChosenColumnIndex, Char);
            }
            catch (Exception) {}
        }
    }
}
