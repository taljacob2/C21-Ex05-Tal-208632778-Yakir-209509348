#region

using System;
using System.Collections.Generic;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;
using C21_Ex02_01.Com.Team.Entity.Players.Player;
using C21_Ex02_01.Com.Team.Repository;
using C21_Ex02_01.Com.Team.Repository.Impl;

#endregion

namespace C21_Ex02_01.Com.Team.Service.Impl
{
    public class GameServiceImpl : IGameService
    {
        public IGameRepository GameRepository { get; private set; } =
            new GameRepositoryImpl();

        // private readonly Board r_Board =
        //     GameControllerImpl.GameDatabaseImpl.Board;
        //
        // private readonly Players
        //     r_Players = GameControllerImpl.GameDatabaseImpl.Players;

        public Player WinnerPlayer { get; set; }

        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        /// </summary>
        /// <returns>`Winner-Player` if exists. Else, returns `null`.</returns>
        public Player GetWinnerPlayer()
        {
            Player returnValue = null;

            if (WinnerPlayer != null)
            {
                returnValue = WinnerPlayer;
            }
            else if (GameRepository.IsVictory())
            {
                returnValue = GameRepository.GetNotCurrentPlayer();
                increaseScoreOfPlayer(returnValue);
            }

            return returnValue;
        }

        public void SetTie()
        {
            increaseScoreOfPlayer(GameRepository.GetRefPlayerOne());
            increaseScoreOfPlayer(GameRepository.GetRefPlayerTwo());
        }

        public void Forfeit(out Player o_WinnerPlayer)
        {
            o_WinnerPlayer = GameRepository.GetNotCurrentPlayer();
            increaseScoreOfPlayer(o_WinnerPlayer);
            GameRepository.ResetScoresOfPlayers();
        }

        public void ResetScoresAndWinner()
        {
            GameRepository.ResetScoresOfPlayers();
            WinnerPlayer = null;
        }

        public void SwitchCurrentPlayerTurn()
        {
            GameRepository.SwitchCurrentPlayerTurn();
        }

        public void SetCurrentPlayer(eID i_PlayerID)
        {
            GameRepository.SetCurrentPlayer(i_PlayerID);
        }

        public void ResetBoard()
        {
            GameRepository.ResetBoard();
        }

        public bool IsFull()
        {
            return GameRepository.IsFull();
        }

        private static void increaseScoreOfPlayer(Player io_Player)
        {
            io_Player.Score++;
            io_Player.ScoreModified();
        }

        public void PlayTurnWithCurrentPlayer(byte i_ChosenColumnIndex)
        {
            Player currentPlayer = GameRepository.GetCurrentPlayer();
            currentPlayer.ChosenColumnIndex = i_ChosenColumnIndex;
            currentPlayer.PlayTurn();
        }

        private void playTurn(Player i_Player)
        {
            if (i_Player is HumanPlayer humanPlayer)
            {
                chooseColumnAndTryToInsert(humanPlayer,
                    GameRepository.GetValidMoves());
            }
            else if (i_Player is ComputerPlayer computerPlayer)
            {
                chooseColumnAndTryToInsert(computerPlayer,
                    GameRepository.GetValidMoves());
            }
        }

        private void chooseColumnAndTryToInsert(
            ComputerPlayer io_ComputerPlayer,
            List<byte> i_ListValidMovesIndexes)
        {
            chooseRandomColumn(io_ComputerPlayer, i_ListValidMovesIndexes);
            try
            {
                // Thread.Sleep(300); // Add delay for realism.
                GameRepository.InsertCoin(io_ComputerPlayer.ChosenColumnIndex,
                    io_ComputerPlayer.Char);
            }
            catch (Exception)
            {
                // ignored. Always works.
            }
        }

        private void chooseRandomColumn(Player io_Player,
            List<byte> i_ListValidMovesIndexes)
        {
            Random random = new Random();
            int randomIndex =
                random.Next(i_ListValidMovesIndexes.Count);
            io_Player.ChosenColumnIndex =
                i_ListValidMovesIndexes[(byte) randomIndex];
        }

        public bool IsComputerPlayerExistsAndPlayed()
        {
            bool returnValue = true;
            Player currentPlayer = GameRepository.GetCurrentPlayer();

            if (currentPlayer is ComputerPlayer)
            {
                currentPlayer.PlayTurn();
            }
            else
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
