﻿#region

using C21_Ex02_01.Com.Team.Database.Players.Player.AI;

#endregion

namespace C21_Ex02_01.Com.Team.Database.Players.Player
{
    public class AIPlayer : Player
    {
        // Depth of AI calculation here (== difficulty of AI):
        private readonly MinMaxAI r_MinMaxAI = new MinMaxAI(3);

        public AIPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            Database database = Controller.Impl.Engine.Database;

            // Thread.Sleep(300); // Add delay for realism.
            database.Board.InsertCoin(getBestMove(), Char);
        }

        private byte getBestMove()
        {
            return r_MinMaxAI.GetBestMove(this, Controller.Impl.Engine.Database.Board);
        }
    }
}