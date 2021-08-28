#region

using C21_Ex02_01.Com.Team.Entity.Players.Player;

#endregion

namespace C21_Ex02_01.Com.Team.Entity.Players
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
