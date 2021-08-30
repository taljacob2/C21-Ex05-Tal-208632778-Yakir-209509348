#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool TryPlayTurnAsHumanPlayer(byte i_ChosenColumnIndex)
        {
            Player player = GameRepository.GetCurrentPlayer();
            bool returnValue = false;
            if (player is HumanPlayer)
            {
                playTurnWithGivenColumn(i_ChosenColumnIndex, player);
                returnValue = true;
            }

            return returnValue;
        }

        private void playTurnWithGivenColumn(byte i_ChosenColumnIndex,
            Player io_Player)
        {
            io_Player.ChosenColumnIndex = i_ChosenColumnIndex;
            GameRepository.InsertCoin(i_ChosenColumnIndex, io_Player.Char);
        }

        public bool TryPlayTurnAsComputerPlayer()
        {
            Player player = GameRepository.GetCurrentPlayer();
            bool returnValue = false;

            if (player is ComputerPlayer)
            {
                playTurnWithRandomColumn(player);
                returnValue = true;
            }

            return returnValue;
        }

        private void playTurnWithRandomColumn(Player io_Player)
        {
            chooseRandomColumn(io_Player, GameRepository.GetValidMoves());
            GameRepository.InsertCoin(io_Player.ChosenColumnIndex,
                io_Player.Char);
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

        public byte GetCols()
        {
            return GameRepository.GetCols();
        }

        public byte GetRows()
        {
            return GameRepository.GetRows();
        }
    }
}
