namespace ChessLOGIC
{
    public class Direction
    {
        //Basics directions
        public readonly static Direction North = new Direction(-1, 0);
        public readonly static Direction South = new Direction(1, 0);
        public readonly static Direction East  = new Direction(0, 1);
        public readonly static Direction West = new Direction(0, -1);
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;
        public readonly static Direction SouthWest = South + West;
        public readonly static Direction SouthEast = South + East;

        public int ColumnValue {  get; }
        public int RowValue {  get; }

        public  Direction(int rowValue ,int columnValue )
        {
            ColumnValue = columnValue;
            RowValue = rowValue;
        }
        //Sum
        public static  Direction operator +(Direction a, Direction b)
        {
            return new Direction(a.RowValue + b.RowValue , a.ColumnValue + b.ColumnValue);
        }

        //Multiplier for scale

        public static Direction operator *(int scalar , Direction a)
        {
            return new Direction(scalar * a.RowValue , scalar * a.ColumnValue);
        }
        

    }
}
