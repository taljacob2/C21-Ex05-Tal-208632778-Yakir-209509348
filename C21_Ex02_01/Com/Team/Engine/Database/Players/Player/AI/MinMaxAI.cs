#region

using System;

#endregion

namespace C21_Ex02_01.Com.Team.Engine.Database.Players.Player.AI
{
    public class MinMaxAI : IAI
    {
        private readonly int r_Depth;

        public MinMaxAI(int i_Depth)
        {
            r_Depth = i_Depth;
        }

        public byte GetBestMove(Player i_CurrentPlayer, Board.Board i_Board)
        {
            byte bestMove = 0;
            double bestScore = double.NegativeInfinity;

            foreach (byte move in i_Board.GetValidMoves())
            {
                Board.Board child = new Board.Board(i_Board); // deep copy.
                child.InsertCoin(move, i_CurrentPlayer.Char);
                double score = minmax(child, r_Depth - 1, i_CurrentPlayer,
                    i_CurrentPlayer);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        private double minmax(Board.Board i_Node, int i_Depth,
            Player i_MaximizingPlayer,
            Player i_CurrentPlayer)
        {
            double returnValue;

            if (i_Depth == 0)
            {
                returnValue = Board.Board.EvaluateBoard(i_Node, i_CurrentPlayer
                    .Char);
            }
            else
            {
                if (i_MaximizingPlayer.Char == i_CurrentPlayer.Char)
                {
                    returnValue = valueOfMaximizingPlayer(i_Node, i_Depth,
                        i_MaximizingPlayer, i_CurrentPlayer);
                }
                else
                {
                    returnValue = valueOfMinimizingPlayer(i_Node, i_Depth,
                        i_MaximizingPlayer, i_CurrentPlayer);
                }
            }

            return returnValue;
        }

        private double valueOfMinimizingPlayer(Board.Board i_Node, int i_Depth,
            Player i_MaximizingPlayer, Player i_CurrentPlayer)
        {
            double value = double.PositiveInfinity;

            foreach (byte move in i_Node.GetValidMoves())
            {
                Board.Board child = new Board.Board(i_Node); // deep copy.
                child.InsertCoin(move, i_CurrentPlayer.Char);

                Player newCurrentPlayer = new HumanPlayer(eID.One,
                    Players.k_PlayerOneChar);
                if (i_CurrentPlayer.ID == eID.One)
                {
                    newCurrentPlayer = new AIPlayer(eID.Two,
                        Players.k_PlayerTwoChar);
                }

                value = Math.Min(value,
                    minmax(child, i_Depth - 1, i_MaximizingPlayer,
                        newCurrentPlayer));
            }

            return value;
        }

        private double valueOfMaximizingPlayer(Board.Board i_Node, int i_Depth,
            Player i_MaximizingPlayer, Player i_CurrentPlayer)
        {
            double value = double.NegativeInfinity;

            foreach (byte move in i_Node.GetValidMoves())
            {
                Board.Board child = new Board.Board(i_Node); // deep copy.
                child.InsertCoin(move, i_CurrentPlayer.Char);

                Player newCurrentPlayer = new HumanPlayer(eID.One,
                    Players.k_PlayerOneChar);
                if (i_CurrentPlayer.ID == eID.One)
                {
                    newCurrentPlayer = new AIPlayer(eID.Two,
                        Players.k_PlayerTwoChar);
                }

                value = Math.Max(value,
                    minmax(child, i_Depth - 1, i_MaximizingPlayer,
                        newCurrentPlayer));
            }

            return value;
        }
    }
}
