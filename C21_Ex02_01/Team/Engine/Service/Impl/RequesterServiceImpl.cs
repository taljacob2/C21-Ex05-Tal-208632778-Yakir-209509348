#region

using System;
using System.Collections.Generic;
using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class RequesterServiceImpl : IRequesterService
    {
        private readonly ConsoleUI.Requester r_Requester;

        public RequesterServiceImpl()
        {
            // UI: Choose from which platform to construct the Engine:
            r_Requester = new ConsoleUI.Requester();
        }

        public bool RequestNewGame()
        {
            return r_Requester.RequestNewGame();
        }

        public void ConstructEngine()
        {
            r_Requester.RequestAndConstructEngine();
        }

        public void ChooseColumnAsHumanPlayer(HumanPlayer io_HumanPlayer)
        {
            r_Requester.RequestChosenColumnHumanPlayer(io_HumanPlayer);
        }

        /// <summary>
        ///     <remarks>
        ///         Implemented in Engine's-side (and not UI-side).
        ///     </remarks>
        /// </summary>
        /// <param name="io_ComputerPlayer" />
        /// <param name="i_ListOfIndexesOfNotFullColumns">
        ///     Each element represents an index of a not-full column.
        /// </param>
        public void ChooseColumnAsComputerPlayer(
            ComputerPlayer io_ComputerPlayer,
            List<byte> i_ListOfIndexesOfNotFullColumns)
        {
            Random random = new Random();
            int randomIndex =
                random.Next(i_ListOfIndexesOfNotFullColumns.Count);
            io_ComputerPlayer.ChosenColumnIndex =
                i_ListOfIndexesOfNotFullColumns[(byte) randomIndex];
        }

        public void ChooseColumnAsAIPlayer(AIPlayer i_AIPlayer,
            List<byte> i_ListOfIndexesOfNotFullColumns)
        {
            throw new NotImplementedException();
        }
    }
}
