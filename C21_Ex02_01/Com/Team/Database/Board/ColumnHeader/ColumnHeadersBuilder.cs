namespace C21_Ex02_01.Com.Team.Database.Board.ColumnHeader
{
    public class ColumnHeadersBuilder
    {
        public Board Board { get; }

        public ColumnHeadersBuilder(Board i_Board)
        {
            Board = i_Board;
        }

        public ColumnHeader[] Build()
        {
            ColumnHeader[] columnHeaders = new ColumnHeader[Board.Cols];
            for (byte i = 1; i <= columnHeaders.Length; i++)
            {
                columnHeaders[i - 1] = new ColumnHeader(i);
            }

            return columnHeaders;
        }
        
    }
}
