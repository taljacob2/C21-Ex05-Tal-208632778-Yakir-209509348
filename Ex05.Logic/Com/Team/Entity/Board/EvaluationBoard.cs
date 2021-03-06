using C21_Ex02_01.Com.Team.Entity.Board.Matrix.Wrapper;

namespace C21_Ex02_01.Com.Team.Entity.Board
{
    public class EvaluationBoard
    {
        private readonly byte r_Cols;
        private readonly int r_MaxNumOfTurnsForAPlayer;
        private readonly byte r_Rows;

        public EvaluationBoard(byte i_Rows, byte i_Cols)
        {
            r_Rows = i_Rows;
            r_Cols = i_Cols;
            int numOfTurns = i_Rows * i_Cols;
            r_MaxNumOfTurnsForAPlayer = numOfTurns / 2;
        }

        public int[,] Matrix { get; } =
        {
            {1, 1, 2, 3, 5, 3, 2, 1, 1},
            {1, 3, 4, 5, 7, 5, 4, 3, 1},
            {2, 4, 6, 8, 10, 8, 6, 4, 2},
            {3, 5, 8, 11, 13, 11, 8, 5, 3},
            {4, 5, 8, 11, 13, 11, 8, 5, 4},
            {3, 4, 6, 8, 10, 8, 6, 4, 3},
            {2, 3, 4, 5, 7, 5, 4, 3, 2},
            {1, 1, 2, 3, 5, 3, 2, 1, 1}
        };

        private double calculateColumnValue(int i_J, ref double io_CurrentValue,
            int i_MaximumValue)
        {
            if (i_J <= r_Cols / 2 - 1)
            {
                io_CurrentValue +=
                    (double) i_J / (r_Cols / 2 - 1) * i_MaximumValue;
            }
            else
            {
                io_CurrentValue += i_MaximumValue *
                                   ((r_Cols / 2 - 1) / (double) i_J);
            }

            return io_CurrentValue;
        }

        private double calculateRowValue(int i_I, ref double io_CurrentValue,
            int i_MaximumValue)
        {
            if (i_I <= r_Rows / 2 - 1)
            {
                io_CurrentValue +=
                    (double) i_I / (r_Rows / 2 - 1) * i_MaximumValue;
            }
            else
            {
                io_CurrentValue += i_MaximumValue *
                                   ((r_Rows / 2 - 1) / (double) i_I);
            }

            return io_CurrentValue;
        }

        public override string ToString()
        {
            return MatrixWrapper<int>.MatrixToString(Matrix, r_Rows,
                r_Cols);
        }
    }
}
