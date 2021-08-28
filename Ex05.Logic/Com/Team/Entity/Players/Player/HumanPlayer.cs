#region

using System;
using C21_Ex02_01.Com.Team.Controller.Impl;

#endregion

namespace C21_Ex02_01.Com.Team.Entity.Players.Player
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
            Database.Database database = GameControllerImpl.Database;
            if (ChosenColumnIndex == k_QuitSignal)
            {
                // Database Update.
                GameControllerImpl.GameService.Forfeit(out Player
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
