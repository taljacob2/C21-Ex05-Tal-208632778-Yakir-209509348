namespace C21_Ex02_01.Team.Engine.Database.Players.Player.AI
{
    /// <summary>
    ///     Interface for AIs.
    /// </summary>
    public interface IAI
    {
        /// <summary>
        ///     Function which must be implemented by the AI.
        /// </summary>
        /// <param name="i_CurrentPlayer"></param>
        /// <param name="i_Board"></param>
        /// <returns>The column index which is the best move.</returns>
        byte GetBestMove(Player i_CurrentPlayer, Board.Board i_Board);
    }
}
