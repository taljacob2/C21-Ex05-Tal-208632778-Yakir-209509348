using C21_Ex02_01.Com.Team.Database.Players.Player;

namespace C21_Ex02_01.Com.Team.Controller
{
    public interface IGameController
    {
        void PostChooseColumnAsHumanPlayer(byte i_ChosenColumnIndex,
            out Player o_WinnerPlayer, out bool o_IsGameOver);
    }
}
