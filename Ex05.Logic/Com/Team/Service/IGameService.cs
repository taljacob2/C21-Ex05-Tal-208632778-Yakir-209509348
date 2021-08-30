#region

using C21_Ex02_01.Com.Team.Entity.Players.Player;

#endregion

namespace C21_Ex02_01.Com.Team.Service
{
    public interface IGameService
    {
        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        /// </summary>
        /// <returns>Winner player if exists. Else, returns null.</returns>
        Player GetWinnerPlayer();

        void SetTie();

        void Forfeit(out Player o_WinnerPlayer);

        void ResetScoresAndWinner();

        void SwitchCurrentPlayerTurn();
        
        void SetCurrentPlayer(eID i_PlayerID);
        
        void ResetBoard();
    }
}
