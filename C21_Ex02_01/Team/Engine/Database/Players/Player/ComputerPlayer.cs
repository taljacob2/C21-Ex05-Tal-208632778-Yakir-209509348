#region

using System;
using System.Collections.Generic;
using System.Threading;
using C21_Ex02_01.Team.Engine.Service;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player
{
    public class ComputerPlayer : Player
    {
        private readonly IRequesterService r_RequesterService =
            Engine.RequesterService;

        public ComputerPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            Database database = Engine.Database;
            byte numberOfColumns = database.Board.Cols;
            List<byte> listOfIndexesOfNotFullColumns =
                initializeListOfIndexesOfNotFullColumns(numberOfColumns);

            chooseColumnAndTryToInsert(listOfIndexesOfNotFullColumns, database);
        }

        private void chooseColumnAndTryToInsert(
            List<byte> i_ListOfIndexesOfNotFullColumns, Database i_Database)
        {
            r_RequesterService.ChooseColumnAsComputerPlayer(this,
                i_ListOfIndexesOfNotFullColumns);
            try
            {
                Thread.Sleep(300); // Add delay for realism.
                i_Database.Board.InsertCoin(ChosenColumnIndex, Char);
            }
            catch (Exception)
            {
                i_ListOfIndexesOfNotFullColumns.Remove(ChosenColumnIndex);
                chooseColumnAndTryToInsert(i_ListOfIndexesOfNotFullColumns,
                    i_Database);
            }
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
