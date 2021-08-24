namespace C21_Ex02_01.Team.Engine.Database
{
    public class Database
    {
        public Database(Board.Board i_Board, Players.Players i_Players)
        {
            Board = i_Board;
            Players = i_Players;
        }

        public Board.Board Board { get; }

        public Players.Players Players { get; }
    }
}
