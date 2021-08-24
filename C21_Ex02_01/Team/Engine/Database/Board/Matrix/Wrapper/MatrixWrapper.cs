#region

using System;
using System.Diagnostics;
using System.Text;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board.Matrix.Wrapper
{
    public class MatrixWrapper<T>
    {
        protected const char k_Space = ' ';

        public MatrixWrapper(byte i_Rows, byte i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
            Matrix = new T[i_Rows, i_Cols];
        }

        protected MatrixWrapper() {}

        public byte Rows { get; }

        public byte Cols { get; }

        /// <summary>
        ///     private for encapsulation and safety of Matrix.
        /// </summary>
        protected T[,] Matrix { get; set; }

        public override string ToString()
        {
            return matrixToString();
        }

        private string matrixToString()
        {
            return MatrixToString(Matrix, Rows, Cols);
        }

        public static string MatrixToString(T[,] i_Matrix, byte i_Rows,
            byte i_Cols)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < i_Rows; i++)
            {
                for (int j = 0; j < i_Cols; j++)
                {
                    stringBuilder.Append(i_Matrix[i, j]);
                    stringBuilder.Append(k_Space);
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public void Fill(T i_ElementToFill)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Matrix[i, j] = i_ElementToFill;
                }
            }
        }

        /// <summary />
        /// <param name="i_Row" />
        /// <param name="i_Col" />
        /// <param name="i_ElementToSet" />
        /// <returns>true on success, false on fail.</returns>
        public bool SetElement(byte i_Row, byte i_Col, T i_ElementToSet)
        {
            bool returnValue = true;

            if (i_Row > Rows)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                returnValue = false;
            }
            else if (i_Col > Cols)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                returnValue = false;
            }

            if (returnValue)
            {
                Matrix[i_Row, i_Col] = i_ElementToSet;
            }

            return returnValue;
        }

        /// <summary />
        /// <param name="i_Row" />
        /// <param name="i_Col" />
        /// <returns>default, when the request is of out of bounds.</returns>
        public T GetElement(byte i_Row, byte i_Col)
        {
            T returnValue = default(T);
            bool fail = false;

            if (i_Row > Rows)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                fail = true;
            }
            else if (i_Col > Cols)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                fail = true;
            }

            return fail ? returnValue : Matrix[i_Row, i_Col];
        }

        private void printOutOfBoundsErrorMessage(byte i_Row, byte i_Col)
        {
            // Print Message.
            Console.Error.WriteLine(
                $"Out of bounds: [{i_Row}, {i_Col}] -> Matrix is: [{Rows}, {Cols}]");

            // Print stack trace info.
            StackTrace stackTrace = new StackTrace(true);
            Console.Error.WriteLine(stackTrace);
        }

        /// <summary />
        /// <param name="i_Column">The column to get its bottommost empty element.</param>
        /// <returns>The bottommost empty element in the column.</returns>
        public T GetBottommostEmptyElementInColumn(byte i_Column)
        {
            T returnElement = default(T);

            // Scans from bottom to top.
            for (int i = Rows - 1; i >= 0; i--)
            {
                returnElement = Matrix[i, i_Column];
                if (returnElement == null)
                {
                    break;
                }
            }

            return returnElement;
        }
    }
}
