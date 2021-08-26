using C21_Ex02_01.Com.Team.Misc;

namespace C21_Ex02_01.Com.Team.Database.Board.Coin
{
    public struct Coordinate
    {
        public byte X { get; }

        public byte Y { get; }

        public Coordinate(byte i_X, byte i_Y)
        {
            X = i_X;
            Y = i_Y;
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
