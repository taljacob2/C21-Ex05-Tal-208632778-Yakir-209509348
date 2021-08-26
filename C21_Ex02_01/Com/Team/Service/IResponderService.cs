#region

using C21_Ex02_01.Com.Team.Database.Players;
using C21_Ex02_01.Com.Team.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Com.Team.Service
{
    public interface IResponderService
    {
        void PrintBoard();

        void PrintWinner(Player i_WinnerPlayer);

        void PrintScores(Players i_Players);

        void PrintMessage(string i_Message);

        void PrintTie();
    }
}
