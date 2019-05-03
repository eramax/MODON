namespace Helpers
{
    public class HijriDateTime
    {
        public int Year
        {
            get;
            set;
        }

        public int Month
        {
            get;
            set;
        }

        public string MonthName
        {
            get;
            set;
        }

        public int Day
        {
            get;
            set;
        }

        public int Hour
        {
            get;
            set;
        }

        public int Minute
        {
            get;
            set;
        }

        public int Second
        {
            get;
            set;
        }

        public string DayName
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year} {Hour}:{Minute}:{Second}";
        }

        public string ToShortString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}
