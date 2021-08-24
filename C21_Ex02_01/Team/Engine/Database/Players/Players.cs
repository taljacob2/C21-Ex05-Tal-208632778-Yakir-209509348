#region

using System;
using System.Collections;
using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.Misc;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players
{
    /// <summary>
    ///     This is a wrapper class for a group of <see cref="Player" />s.
    ///     <remarks> Implements <see cref="IEnumerable" />, thus iterable.</remarks>
    /// </summary>
    public class Players : IEnumerable
    {
        public const char k_PlayerOneChar = 'O'; // Set arbitrarily.
        public const char k_PlayerTwoChar = 'X'; // Set arbitrarily.

        private const byte k_NumberOfPlayers = 2;

        private readonly PlayersGetterNestedService r_PlayersGetterNestedService
            = new PlayersGetterNestedService();

        public Players(Settings i_Settings)
        {
            Settings = i_Settings;
            initializePlayers();
        }

        // Set arbitrarily the starting player.
        private static eID CurrentPlayerTurn { get; set; } = eID.One;

        private Settings Settings { get; }

        // IEnumerable Member  
        public IEnumerator GetEnumerator()
        {
            return r_PlayersGetterNestedService.GetEnumerator();
        }

        private void initializePlayers()
        {
            switch (Settings.OpponentType)
            {
                case eType.Human:
                    r_PlayersGetterNestedService.GetRefPlayerTwo() =
                        new HumanPlayer(
                            eID.Two,
                            k_PlayerTwoChar);
                    break;
                case eType.Computer:
                    r_PlayersGetterNestedService.GetRefPlayerTwo() =
                        new ComputerPlayer(
                            eID.Two,
                            k_PlayerTwoChar);
                    break;
                case eType.AI:
                    r_PlayersGetterNestedService.GetRefPlayerTwo() =
                        new AIPlayer(
                            eID.Two,
                            k_PlayerTwoChar);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            r_PlayersGetterNestedService.GetRefPlayerOne() = new HumanPlayer(
                eID.One,
                k_PlayerOneChar);
        }

        public void PlayTurn()
        {
            Player.Player currentPlayer = GetCurrentPlayer();
            currentPlayer.PlayTurn();
        }

        public Player.Player GetCurrentPlayer()
        {
            return r_PlayersGetterNestedService.GetCurrentPlayer();
        }

        public Player.Player GetNotCurrentPlayer()
        {
            Player.Player current = GetCurrentPlayer();
            Player.Player nonCurrentPlayer = current == GetPlayerOne()
                ? GetPlayerTwo()
                : GetPlayerOne();
            return nonCurrentPlayer;
        }

        public void SwitchCurrentPlayerTurn(
            Player.Player i_CurrentPlayingPlayer)
        {
            switch (i_CurrentPlayingPlayer.ID)
            {
                case eID.One:
                    CurrentPlayerTurn = eID.Two;
                    break;
                case eID.Two:
                    CurrentPlayerTurn = eID.One;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Player.Player GetPlayerOne()
        {
            return r_PlayersGetterNestedService.GetRefPlayerOne();
        }

        public Player.Player GetPlayerTwo()
        {
            return r_PlayersGetterNestedService.GetRefPlayerTwo();
        }

        private class PlayersGetterNestedService : IEnumerable
        {
            /// <summary>
            ///     Places a <see cref="HumanPlayer" /> as the first player,
            ///     and <i>may</i> place a <see cref="HumanPlayer" /> or a
            ///     <see cref="ComputerPlayer" /> as the second player.
            ///     <remarks> Implements <see cref="IEnumerable" />, thus iterable.</remarks>
            /// </summary>
            private Player.Player[] Players { get; } =
                new Player.Player[k_NumberOfPlayers];

            // IEnumerable Member
            public IEnumerator GetEnumerator()
            {
                return EnumeratorGetter.GetEnumerator(Players);
            }

            internal ref Player.Player GetRefPlayerOne()
            {
                return ref Players[(byte) eID.One];
            }

            /// <summary />
            /// <returns>Note: May return a <see cref="ComputerPlayer" /></returns>
            internal ref Player.Player GetRefPlayerTwo()
            {
                return ref Players[(byte) eID.Two];
            }

            internal ref Player.Player GetCurrentPlayer()
            {
                return ref Players[(byte) CurrentPlayerTurn];
            }
        }
    }
}
