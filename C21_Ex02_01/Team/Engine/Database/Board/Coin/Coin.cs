namespace C21_Ex02_01.Team.Engine.Database.Board.Coin
{
    public class Coin
    {
        public const char k_EmptyCoin = ' ';

        public Coin(Coordinate i_Coordinate, char i_Char)
        {
            Coordinate = i_Coordinate;
            Char = i_Char;
        }

        public Coordinate Coordinate { get; }

        public char Char { get; set; }

        public override bool Equals(object i_Obj)
        {
            if (ReferenceEquals(null, i_Obj))
            {
                return false;
            }

            if (ReferenceEquals(this, i_Obj))
            {
                return true;
            }

            if (i_Obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Coin) i_Obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable once NonReadonlyMemberInGetHashCode
                return (Coordinate.GetHashCode() * 397) ^ Char.GetHashCode();
            }
        }

        public bool Equals(Coin i_Other)
        {
            return Coordinate.Equals(i_Other.Coordinate) &&
                   Char == i_Other.Char;
        }

        public override string ToString()
        {
            return $"{Char}";
        }

        public bool IsEmpty()
        {
            return Char == k_EmptyCoin;
        }

        public static bool operator ==(Coin i_A, Coin i_B)
        {
            return i_A?.Char == i_B?.Char;
        }

        public static bool operator !=(Coin i_A, Coin i_B)
        {
            return i_A?.Char != i_B?.Char;
        }
    }
}
