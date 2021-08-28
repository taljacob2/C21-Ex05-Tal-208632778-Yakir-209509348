using C21_Ex02_01.Com.Team.Entity.Players.Player;

namespace C21_Ex02_01.Com.Team.Controller
{
    public interface IGameController
    {
        void PostChooseColumnAsHumanPlayer(byte i_ChosenColumnIndex,
            out Player o_WinnerPlayer, out bool o_IsGameOver);

        void PostChooseColumnAsComputerPlayerIfExists(out Player o_WinnerPlayer,
            out bool o_IsGameOver);

        void NewGame();

        void Forfeit(out Player o_WinnerPlayer);
    }
}
