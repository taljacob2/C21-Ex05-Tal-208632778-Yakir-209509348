#region

using System;
using System.Collections.Generic;
using C21_Ex02_01.Com.Team.Controller.Impl;

#endregion

namespace C21_Ex02_01.Com.Team.Entity.Players.Player
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            byte numberOfColumns = gameDatabaseImpl.Board.Cols;
            List<byte> listOfIndexesOfNotFullColumns =F

            chooseColumnAndTryToInsert(listOfIndexesOfNotFullColumns, gameDatabaseImpl);
        }

        private void chooseColumnAndTryToInsert(
            List<byte> i_ListOfIndexesOfNotFullColumns, Database.Impl.GameDatabaseImpl i_GameDatabaseImpl)
        {
            ChooseColumnAsComputerPlayer(this, i_ListOfIndexesOfNotFullColumns);
            try
            {
                // Thread.Sleep(300); // Add delay for realism.
                i_GameDatabaseImpl.Board.InsertCoin(ChosenColumnIndex, Char);
            }
            catch (Exception)
            {
                i_ListOfIndexesOfNotFullColumns.Remove(ChosenColumnIndex);
                chooseColumnAndTryToInsert(i_ListOfIndexesOfNotFullColumns,
                    i_GameDatabaseImpl);
            }
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

        private static List<byte> initializeListOfIndexesOfNotFullColumns(
            byte i_NumberOfColumns)
        {
            List<byte> listOfIndexesOfNotFullColumns = new List<byte>();
            for (byte i = 0; i < i_NumberOfColumns; i++)
            {
                listOfIndexesOfNotFullColumns.Add(i);
            }

            return listOfIndexesOfNotFullColumns;
        }
    }
}
