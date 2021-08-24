#region

using System;
using C21_Ex02_01.Team.Engine.Service;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player
{
    public class HumanPlayer : Player
    {
        public const byte k_QuitSignal = 255;

        private readonly IRequesterService r_RequesterService =
            Engine.RequesterService;

        private readonly IResponderService r_ResponderService =
            Engine.ResponderService;

        public HumanPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            chooseColumnAndTryToInsert();
        }

        private void chooseColumnAndTryToInsert()
        {
            r_RequesterService.ChooseColumnAsHumanPlayer(this); // UI Request.
            Database database = Engine.Database;
            if (ChosenColumnIndex == k_QuitSignal)
            {
                Engine.ActuatorService.Forfeit(); // Database Update.
                return;
            }

            try
            {
                database.Board.InsertCoin(ChosenColumnIndex, Char);
            }
            catch (Exception e)
            {
                r_ResponderService.PrintMessage(e.Message); // UI Response.
                chooseColumnAndTryToInsert();
            }
        }
    }
}
