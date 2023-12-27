using System.Text;

namespace TextComparision;

public class CTextCompare
{
    /// <summary>
    /// This array is used to contain the original word after splitting
    /// </summary>
    private string[] AOriginal { get; set; }

    /// <summary>
    /// This array is used to contain the revised word after splitting
    /// </summary>
    private string[] ARevised { get; set; }


    /// <summary>
    /// Used when checking if the user when to check sensitive case
    /// </summary>
    private bool IsSensitive { get; set; } = false;

    /// <summary>
    /// This is the variable used when a word in the original sentence does not match a word in the revised sentence.
    /// It will check the next word in the consecutive revised sentence corresponding to the number of times given by this variable
    /// </summary>
    private int NAlternativeWords { get; set; } = 2;


    /// <summary>
    /// when using this constructor to create a new constant of ctextcompare
    /// the isSensitive is
    /// the nNalternativewords = 1
    /// by default
    /// </summary>
    public CTextCompare(string originalSentence, string revisedSentence)
    {
        this.AOriginal = originalSentence.Split(' ');
        this.ARevised = revisedSentence.Split(' ');
    }

    // This is another constructor, with 2 more parameters which are isSensitive for checking Sensitive case and nAlternativeWords
    public CTextCompare(string originalSentence, string revisedSentence, bool isSensitive, int nAlternativeWords)
    {
        this.AOriginal = originalSentence.Split(' ');
        this.ARevised = revisedSentence.Split(' ');
        this.IsSensitive = isSensitive;
        this.NAlternativeWords = nAlternativeWords;
    }



    private bool IsMatched(string word1, string word2)
    {
        return IsSensitive ? word1.Equals(word2) : word1.Equals(word2, StringComparison.OrdinalIgnoreCase);
    }

    public List<CWord> CompareIt()
    {
        
        var resultList = new List<CWord>();

        // This is the index of Original Array
        var i = 0;
        
        // This is the index of Revised Array
        var j = 0;
        while (i < AOriginal.Length && j < ARevised.Length)
        {

            // Check if aOriginal[i], aRevised[j] are equal.
            // If they are equal, "Coloring" aOriginal[i] word.
            if (IsMatched(AOriginal[i], ARevised[j]))
            {
                resultList.Add(new CWord(AOriginal[i], ColoringEnum.Correction));
                i++;
                j++;
            }

            // If returned false, It gonna check the n (NAlternativeWords) words by increasing to the right of the revised sentence.
            else
            {
                // If there is alternative match found it gonna be true. But by default, it is false
                var alternativeMatch = false;

                // This variable is used as an index for looping to n (NAlternativeWords) times to find the desired word
                var k = 1;
                for (; k <= NAlternativeWords && (j + k) < ARevised.Length; k++)
                {
                    // Check if not matched, then continue
                    if (!IsMatched(AOriginal[i], ARevised[j + k])) continue;

                    // if it is true, the alternativeMatch change to true
                    alternativeMatch = true;
                    break;
                }

                // If the alternativeMatch is true, we will process to add words into result
                if (alternativeMatch)
                {
                    for (var addedCount = 0; addedCount < k; addedCount++)
                    {
                        resultList.Add(new CWord(ARevised[j + addedCount], ColoringEnum.Added));
                    }
                    resultList.Add(new CWord(AOriginal[i], ColoringEnum.Correction));
                    i++;

                    // We will not check the added words again from the Revised Array, so increasing the index of Revised Array to the index where the desired word by one
                    j = j + k + 1;
                }

                //If not, we will add the value of Original Array into 
                else
                {
                    resultList.Add(new CWord(AOriginal[i], ColoringEnum.Deleted));
                    i++;
                }
            }
        }

        return resultList;
    }

    public static void ToConsole(List<CWord> resultList)
    {
        var stringBuilder = new StringBuilder();

        foreach (var word in resultList)
        {
            stringBuilder.Append("{ ");
            stringBuilder.Append(word.Word);
            stringBuilder.Append(", {");
            stringBuilder.Append(word.Color);
            stringBuilder.Append("} },\n");
        }


        if (stringBuilder.Length > 0)
        {
            stringBuilder.Length -= 2;
        }

        Console.WriteLine(stringBuilder);
    }
}