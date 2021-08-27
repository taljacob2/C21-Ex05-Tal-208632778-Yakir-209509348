﻿#region

using System;
using System.Runtime.CompilerServices;
using C21_Ex02_01.Com.Team.Database.Board;
using C21_Ex02_01.Com.Team.Database.Players.Player;
using C21_Ex02_01.Com.Team.Service;
using C21_Ex02_01.Com.Team.Service.Impl;

#endregion

namespace C21_Ex02_01.Com.Team.Controller.Impl
{
    public class GameControllerImpl : IGameController
    {
        public static Database.Database Database { get; set; }

        public static IActuatorService ActuatorService { get; set; }

        // public void RunGame()
        // {
        //     bool continuePlay;
        //     do
        //     {
        //         Database.Players.SwitchCurrentPlayerTurn(Database.Players
        //             .GetPlayerTwo());
        //         Database.Board.ResetBoard();
        //
        //         // whileRunGame();
        //         continuePlay = RequesterService.RequestNewGame();
        //     } while (continuePlay);
        // }

        // private void whileRunGame()
        // {
        //     while (true)
        //     {
        //         // ResponderService.PrintBoard();
        //
        //         if (Database.Board.IsFull())
        //         {
        //             // It is a TIE.
        //             setTie();
        //             break;
        //         }
        //
        //         Database.Players.PlayTurn();
        //         Database.Players.SwitchCurrentPlayerTurn(Database.Players
        //             .GetCurrentPlayer());
        //
        //         if (!getWinnerPlayer())
        //         {
        //             continue;
        //         }
        //
        //         // Winner found, and was handled.
        //         return;
        //     }
        // }

        private static void resetForfeitAndWinner()
        {
            ActuatorService.ResetForfeitAndWinner(); // Database Update.
        }

        private void setTie()
        {
            ActuatorService.SetTie(); // Database Update.

            // ResponderService.PrintTie(); // UI Response. // TODO: implement
            // ResponderService.PrintScores(Database
            //     .Players); // UI Response. // TODO: implement
        }

        private static Player getWinnerPlayer()
        {
            // Check for algorithm WIN here:
            Player returnValue =
                ActuatorService.GetWinnerPlayer(); // Database Update.

            if (returnValue != null)
            {
                // Winner Found. Handle it.
                resetForfeitAndWinner(); // Database Update.
            }

            return returnValue;
        }

        /// <summary />
        /// <param name="i_ChosenColumnIndex" />
        /// <param name="o_WinnerPlayer">
        ///     If this is <see langword="null" />
        ///     and <paramref name="o_IsGameOver" /> is <see langword="true" /> then
        ///     it means the game was over with a TIE.
        /// </param>
        /// <param name="o_IsGameOver" />
        public void PostChooseColumnAsHumanPlayer(byte i_ChosenColumnIndex,
            out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            playTurn(i_ChosenColumnIndex);
            Database.Players.SwitchCurrentPlayerTurn(Database.Players
                .GetCurrentPlayer());
            o_WinnerPlayer = getWinnerPlayer();
            o_IsGameOver = isTie() || (o_WinnerPlayer != null);
        }

        /// <summary />
        /// <param name="o_WinnerPlayer">
        ///     If this is <see langword="null" />
        ///     and <paramref name="o_IsGameOver" /> is <see langword="true" /> then
        ///     it means the game was over with a TIE.
        /// </param>
        /// <param name="o_IsGameOver" />
        public void PostChooseColumnAsComputerPlayerIfExists(
            out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            if (!isComputerPlayerExistsAndPlayed())
            {
                o_WinnerPlayer = null;
                o_IsGameOver = false;
                return;
            }

            Database.Players.SwitchCurrentPlayerTurn(Database.Players
                .GetCurrentPlayer());
            o_WinnerPlayer = getWinnerPlayer();
            o_IsGameOver = isTie() || (o_WinnerPlayer != null);
        }

        private static bool isComputerPlayerExistsAndPlayed()
        {
            bool returnValue = true;
            Player currentPlayer = Database.Players.GetCurrentPlayer();

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

        private bool isTie()
        {
            bool returnValue = Database.Board.IsFull();
            
            if (returnValue)
            {
                // It is a TIE.
                setTie();
            }

            return returnValue;
        }

        private static void playTurn(byte i_ChosenColumnIndex)
        {
            Player currentPlayer = Database.Players.GetCurrentPlayer();
            currentPlayer.ChosenColumnIndex = i_ChosenColumnIndex;
            currentPlayer.PlayTurn();
        }

        public void NewGame()
        {
            Database.Players.SwitchCurrentPlayerTurn(Database.Players
                .GetPlayerTwo());
            Database.Board.ResetBoard();
        }

        public void Forfeit(out Player o_WinnerPlayer)
        {
            ActuatorService.Forfeit(out o_WinnerPlayer);
        }
    }
}
