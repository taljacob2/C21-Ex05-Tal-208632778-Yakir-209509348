﻿#region

using C21_Ex02_01.Com.Team.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Com.Team.Database.Players
{
    public class Settings
    {
        public Settings(eType i_OpponentType)
        {
            OpponentType = i_OpponentType;
        }

        public eType OpponentType { get; }
    }
}