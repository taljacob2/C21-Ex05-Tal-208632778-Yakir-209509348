using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;

namespace C21_Ex02_01.Com.Team.Database.Impl
{
    public class GameDatabaseImpl : IGameDatabase
    {
        public GameDatabaseImpl(Board i_Board, Players i_Players)
        {
            GameDatabaseImpl.Board = i_Board;
            GameDatabaseImpl.Players = i_Players;
        }

        public GameDatabaseImpl() {}

        private static Board Board { get; set; }

        private static Players Players { get; set; }


        public Board GetRefBoard()
        {
            return Board;
        }

        public Players GetRefPlayers()
        {
            return Players;
        }
    }
}
