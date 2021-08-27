using System;

namespace C21_Ex02_01.Com.Team.Database.Board.ColumnHeader
{
    public class ColumnHeader
    {
        public ColumnHeader(byte i_ColumnNumber)
        {
            ColumnNumber = i_ColumnNumber;
        }

        public byte ColumnNumber { get; }

        public event EventHandler ColumnFilledUp;

        protected virtual void OnColumnFilledUp()
        {
            ColumnFilledUp?.Invoke(this, EventArgs.Empty);
        }

        public void ColumnFull()
        {
            OnColumnFilledUp();
        }
    }
}
