#region

using System;
using System.Collections.Generic;
using C21_Ex02_01.Com.Team.Controller.Impl;

#endregion

namespace C21_Ex02_01.Com.Team.Database.Players.Player
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            Database database = GameControllerImpl.Database;
            byte numberOfColumns = database.Board.Cols;
            List<byte> listOfIndexesOfNotFullColumns =
                initializeListOfIndexesOfNotFullColumns(numberOfColumns);

            chooseColumnAndTryToInsert(listOfIndexesOfNotFullColumns, database);
        }

        private void chooseColumnAndTryToInsert(
            List<byte> i_ListOfIndexesOfNotFullColumns, Database i_Database)
        {
            chooseColumnAsComputerPlayer(this, i_ListOfIndexesOfNotFullColumns);
            try
            {
                // Thread.Sleep(300); // Add delay for realism.
                i_Database.Board.InsertCoin(ChosenColumnIndex, Char);
            }
            catch (Exception)
            {
                i_ListOfIndexesOfNotFullColumns.Remove(ChosenColumnIndex);
                chooseColumnAndTryToInsert(i_ListOfIndexesOfNotFullColumns,
                    i_Database);
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
        private void chooseColumnAsComputerPlayer(
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
