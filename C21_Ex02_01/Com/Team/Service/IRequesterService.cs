#region

using System.Collections.Generic;
using C21_Ex02_01.Com.Team.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Com.Team.Service
{
    public interface IRequesterService
    {
        void ConstructEngine();

        bool RequestNewGame();

        void ChooseColumnAsComputerPlayer(ComputerPlayer io_ComputerPlayer,
            List<byte> i_ListOfIndexesOfNotFullColumns);

        void ChooseColumnAsAIPlayer(AIPlayer i_AIPlayer,
            List<byte> i_ListOfIndexesOfNotFullColumns);
    }
}
