using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;

namespace C21_Ex02_01.Com.Team.Database
{
    public class Database
    {
        public Database(Board i_Board, Players i_Players)
        {
            Board = i_Board;
            Players = i_Players;
        }

        public Board Board { get; }

        public Players Players { get; }
    }
}
