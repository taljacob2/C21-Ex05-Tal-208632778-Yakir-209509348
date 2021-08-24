#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using C21_Ex02_01.Team.Engine.Database.Board.Coin;
using C21_Ex02_01.Team.Engine.Database.Board.Matrix.Wrapper;
using C21_Ex02_01.Team.Misc;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public class Board : MatrixWrapper<Coin.Coin>, IBoardActuator
    {
        private const char k_Delimiter = '|';
        private const char k_RowSeparator = '=';

        // TODO: may need to change size
        private static EvaluationBoard s_EvaluationBoard;

        public Board(byte i_Rows, byte i_Cols) : base(i_Rows, i_Cols)
        {
            s_EvaluationBoard = new EvaluationBoard(i_Rows, i_Cols);

            // ResetBoard();
        }

        /// <summary>
        ///     Constructor from another board by deep copy.
        /// </summary>
        /// <param name="i_Board"></param>
        public Board(Board i_Board) : this(i_Board.Rows, i_Board.Cols)
        {
            Matrix = i_Board.Matrix.Copy();
        }

        /// <summary>
        ///     Inserts a Coin into a column, while checking that the column is not full.
        /// </summary>
        /// <param name="i_ColumnIndexToInsertTo">The column to insert the Coin into.</param>
        /// <param name="i_CharCoin">Char of a coin, to insert into the column.</param>
        /// <exception cref="IOException">In case the column is full.</exception>
        public void InsertCoin(byte i_ColumnIndexToInsertTo, char i_CharCoin)
        {
            // Update bottommost empty element in column:
            Coin.Coin emptyElementInColumn =
                getBottommostEmptyElementInColumn(i_ColumnIndexToInsertTo);

            if (emptyElementInColumn != null)
            {
                emptyElementInColumn.Char = i_CharCoin;
            }
            else
            {
                throw new IOException(
                    $"The column `{i_ColumnIndexToInsertTo + 1}` is full.");
            }
        }

        public void ResetBoard()
        {
            fillCoins(Coin.Coin.k_EmptyCoin);
        }

        public bool IsVictory()
        {
            return checkCols() || checkRows() || checkDiagonals();
        }

        // ReSharper disable once MethodTooLong
        public bool IsFull()
        {
            bool returnValue = true;

            // Scans from top to bottom, to increase return value speed.
            for (byte i = 0; i < Rows; i++)
            {
                for (byte j = 0; j < Cols; j++)
                {
                    Coin.Coin currentCoin = Matrix[i, j];
                    if (!currentCoin.IsEmpty())
                    {
                        continue;
                    }

                    returnValue = false;
                    break;
                }

                if (returnValue == false)
                {
                    break;
                }
            }

            return returnValue;
        }

        public List<byte> GetValidMoves()
        {
            List<byte> validMoves = new List<byte>();

            for (byte i = 0; i < Cols; i++)
            {
                if (Matrix[0, i].Char == Coin.Coin.k_EmptyCoin)
                {
                    validMoves.Add(i);
                }
            }

            return validMoves;
        }

        public static void CopyBoardMatrix(Board i_Source, Board i_Destination)
        {
            for (int i = 0; i < i_Source.Rows; i++)
            {
                for (int j = 0; j < i_Source.Cols; j++)
                {
                    i_Destination.Matrix[i, j] = i_Source.Matrix[i, j];
                }
            }
        }

        private void fillCoins(char i_CharToFill)
        {
            for (byte i = 0; i < Rows; i++)
            {
                for (byte j = 0; j < Cols; j++)
                {
                    Matrix[i, j] =
                        new Coin.Coin(new Coordinate(i, j),
                            i_CharToFill);
                }
            }
        }

        private bool checkRows()
        {
            bool foundWiningSequence = false;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols - 3; j++)
                {
                    bool isWiningSequence = Matrix[i, j].IsEmpty() == false
                                            && Matrix[i, j] == Matrix[i, j + 1]
                                            && Matrix[i, j + 1] ==
                                            Matrix[i, j + 2]
                                            && Matrix[i, j + 2] ==
                                            Matrix[i, j + 3];
                    if (isWiningSequence)
                    {
                        foundWiningSequence = true;
                    }
                }

                if (foundWiningSequence)
                {
                    break;
                }
            }

            return foundWiningSequence;
        }

        private bool checkCols()
        {
            bool foundWiningSequence = false;
            for (int i = 0; i < Rows - 3; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    bool winingSequence = Matrix[i, j].IsEmpty() == false
                                          && Matrix[i, j] == Matrix[i + 1, j]
                                          && Matrix[i + 1, j] ==
                                          Matrix[i + 2, j]
                                          && Matrix[i + 2, j] ==
                                          Matrix[i + 3, j];
                    if (winingSequence)
                    {
                        foundWiningSequence = true;
                    }
                }
            }

            return foundWiningSequence;
        }

        private bool checkDiagonalsUp()
        {
            bool foundWiningSequence = false;
            for (int i = 3; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (j >= 3)
                    {
                        bool winingSequence = Matrix[i, j].IsEmpty() == false
                                              && Matrix[i, j] ==
                                              Matrix[i - 1, j - 1]
                                              && Matrix[i - 1, j - 1] ==
                                              Matrix[i - 2, j - 2]
                                              && Matrix[i - 2, j - 2] ==
                                              Matrix[i - 3, j - 3];
                        if (winingSequence)
                        {
                            foundWiningSequence = true;
                        }
                    }

                    if (Cols - 1 - j >= 3)
                    {
                        bool winingSequence = Matrix[i, j].IsEmpty() == false
                                              && Matrix[i, j] ==
                                              Matrix[i - 1, j + 1]
                                              && Matrix[i - 1, j + 1] ==
                                              Matrix[i - 2, j + 2]
                                              && Matrix[i - 2, j + 2] ==
                                              Matrix[i - 3, j + 3];
                        if (winingSequence)
                        {
                            foundWiningSequence = true;
                        }
                    }
                }

                if (foundWiningSequence)
                {
                    break;
                }
            }

            return foundWiningSequence;
        }

        private bool checkDiagonalDown()
        {
            bool foundWiningSequence = false;
            for (int i = 0; i < Rows - 3; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (j >= 3)
                    {
                        bool winingSequence = Matrix[i, j].IsEmpty() == false
                                              && Matrix[i, j] ==
                                              Matrix[i + 1, j - 1]
                                              && Matrix[i + 1, j - 1] ==
                                              Matrix[i + 2, j - 2]
                                              && Matrix[i + 2, j - 2] ==
                                              Matrix[i + 3, j - 3];
                        if (winingSequence)
                        {
                            foundWiningSequence = true;
                        }
                    }

                    if (Cols - 1 - j >= 3)
                    {
                        bool winingSequence = Matrix[i, j].IsEmpty() == false
                                              && Matrix[i, j] ==
                                              Matrix[i + 1, j + 1]
                                              && Matrix[i + 1, j + 1] ==
                                              Matrix[i + 2, j + 2]
                                              && Matrix[i + 2, j + 2] ==
                                              Matrix[i + 3, j + 3];
                        if (winingSequence)
                        {
                            foundWiningSequence = true;
                        }
                    }
                }

                if (foundWiningSequence)
                {
                    break;
                }
            }

            return foundWiningSequence;
        }

        private bool checkDiagonals()
        {
            return checkDiagonalsUp() || checkDiagonalDown();
        }

        /// <summary>
        ///     Returns the bottommost `empty` Coin in the column, if exists.
        ///     (Its `Char` should be <see cref="Coin.k_EmptyCoin" />).
        ///     In case the column is full, the method will return `null`.
        /// </summary>
        /// <param name="i_ColumnIndex">The column to get its bottommost empty element.</param>
        /// <returns>The bottommost empty element in the column.</returns>
        private Coin.Coin getBottommostEmptyElementInColumn(
            byte i_ColumnIndex)
        {
            Coin.Coin returnValue = null;
            Coin.Coin coinInColumn = null;

            // Scans from bottom to top.
            for (int i = Rows - 1; i >= 0; i--)
            {
                coinInColumn = Matrix[i, i_ColumnIndex];
                if (coinInColumn.Char == Coin.Coin.k_EmptyCoin)
                {
                    break;
                }
            }

            Debug.Assert(coinInColumn != null,
                nameof(coinInColumn) + " != null");
            if (coinInColumn.Char == Coin.Coin.k_EmptyCoin)
            {
                returnValue = coinInColumn;
            }

            return returnValue;
        }

        public override string ToString()
        {
            return matrixToString();
        }

        private string matrixToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            RowAppender rowAppender = new RowAppender(this);

            stringBuilder.Append(Environment.NewLine);
            rowAppender.AppendRowOfNumbers(stringBuilder);
            for (byte i = 0; i < Rows; i++)
            {
                rowAppender.AppendRowOfElements(stringBuilder, i);
                rowAppender.AppendRowOfRowSeparators(stringBuilder);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Function to evaluate a board from the given player perspective.
        /// </summary>
        /// <param name="i_Board"></param>
        /// <param name="i_PlayerChar"></param>
        /// <returns></returns>
        public static double EvaluateBoard(Board i_Board, char i_PlayerChar)
        {
            if (i_Board.IsVictory())
            {
                return double.PositiveInfinity;
            }

            double score = 0;
            for (int i = 0; i < i_Board.Rows; i++)
            {
                for (int j = 0; j < i_Board.Cols; j++)
                {
                    if (i_Board.Matrix[i, j].Char != Coin.Coin.k_EmptyCoin)
                    {
                        if (i_Board.Matrix[i, j].Char ==
                            Players.Players.k_PlayerOneChar &&
                            i_PlayerChar == Players.Players.k_PlayerOneChar)
                        {
                            score += s_EvaluationBoard.Matrix[i, j];
                        }
                        else if (i_Board.Matrix[i, j].Char ==
                                 Players.Players.k_PlayerTwoChar &&
                                 i_PlayerChar == Players.Players
                                     .k_PlayerTwoChar)
                        {
                            score += s_EvaluationBoard.Matrix[i, j];
                        }
                    }
                }
            }

            return score;
        }

        private struct RowAppender
        {
            private readonly Board r_Board;

            public RowAppender(Board i_Board)
            {
                r_Board = i_Board;
            }

            public void AppendRowOfElements(StringBuilder io_StringBuilder,
                byte io_CurrentRow)
            {
                for (int j = 0; j < r_Board.Cols; j++)
                {
                    io_StringBuilder.Append(k_Delimiter);
                    io_StringBuilder.Append(k_Space);
                    io_StringBuilder.Append(r_Board.Matrix[io_CurrentRow, j]);
                    io_StringBuilder.Append(k_Space);
                }

                io_StringBuilder.Append(k_Delimiter);
                io_StringBuilder.Append(Environment.NewLine);
            }

            public void AppendRowOfRowSeparators(
                StringBuilder io_StringBuilder)
            {
                for (int j = 0; j < r_Board.Cols; j++)
                {
                    io_StringBuilder.Append(k_RowSeparator);
                    io_StringBuilder.Append(k_RowSeparator);
                    io_StringBuilder.Append(k_RowSeparator);
                    io_StringBuilder.Append(k_RowSeparator);
                }

                io_StringBuilder.Append(k_RowSeparator);
                io_StringBuilder.Append(Environment.NewLine);
            }

            public void AppendRowOfNumbers(StringBuilder io_StringBuilder)
            {
                for (int i = 0; i < r_Board.Cols; i++)
                {
                    io_StringBuilder.Append(k_Space);
                    io_StringBuilder.Append(k_Space);
                    io_StringBuilder.Append(i + 1);
                    io_StringBuilder.Append(k_Space);
                }

                io_StringBuilder.Append(k_Space); // may be redundant
                io_StringBuilder.Append(Environment.NewLine);
            }
        }
    }
}
