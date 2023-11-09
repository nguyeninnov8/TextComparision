namespace TextComparision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str1 = "The room is too small";
            String str2 = "rooms room are is to too small";
            CTextCompare tc = new CTextCompare(str1, str2);
            Console.WriteLine(tc.CompareIt());
        }
    }
}