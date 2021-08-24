#region

using System.Collections.Generic;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public interface IBoardActuator
    {
        void ResetBoard();

        void InsertCoin(byte i_ColumnIndexToInsertTo, char i_CharCoin);

        bool IsVictory();

        bool IsFull();

        /// <summary>
        ///     Function to get the valid moves
        /// </summary>
        /// <returns>list of <see langword="byte" />s with valid columns</returns>
        List<byte> GetValidMoves();
    }
}
