namespace TextComparision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "The room is too small";
            string str2 = "Your rooms room is are to too small";
            CTextCompare tc = new CTextCompare(str1, str2);
            var res = tc.CompareIt();
            CTextCompare.ToConsole(res);
        }
    }
}