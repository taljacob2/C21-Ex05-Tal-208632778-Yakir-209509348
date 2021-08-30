using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;

namespace C21_Ex02_01.Com.Team.Database
{
    public interface IGameDatabase
    {
        Board GetRefBoard();

        Players GetRefPlayers();
    }
}
