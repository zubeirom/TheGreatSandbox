namespace CSharp
{
    public class Static
    {
        private int _count;
        private static int _totalCount;

        public int GetNextValue()
        {
            _count += 1;
            _totalCount += 1;
            return _count;
        }

        public static int TotalCount => _totalCount;
    }
}
