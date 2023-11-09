using System;
using System.Collections.Generic;
using System.Text;
using TextComparision;

public class CTextCompare
{
    private string[] aOriginal;
    private string[] aRevised;
    private bool isSensitive = false;
    private int nAlternativeWords = 1;

    public CTextCompare(string originalSentence, string revisedSentence)
    {
        this.aOriginal = originalSentence.Split(' ');
        this.aRevised = revisedSentence.Split(' ');
    }

    public string[] AOriginal
    {
        get { return aOriginal; }
        set { aOriginal = value; }
    }

    public string[] ARevised
    {
        get { return aRevised; }
        set { aRevised = value; }
    }

    public bool IsSensitive
    {
        get { return isSensitive; }
        set { isSensitive = value; }
    }

    public int NAlternativeWords
    {
        get { return nAlternativeWords; }
        set { nAlternativeWords = value; }
    }

    private bool IsMatched(string word1, string word2)
    {
        if (isSensitive)
        {
            return word1.Equals(word2);
        }
        else
        {
            return word1.Equals(word2, StringComparison.OrdinalIgnoreCase);
        }
    }

    public string CompareIt()
    {
        List<CWord> result = new List<CWord>();
        int i = 0;
        int j = 0;
        while (i < aOriginal.Length && j < aRevised.Length)
        {
            // Check if aOriginal[i], aRevised[j] are equal.
            // If they are equal, "Coloring" aOriginal[i] word.
            if (IsMatched(aOriginal[i], aRevised[j]))
            {
                result.Add(new CWord(aOriginal[i], CColoring.CORRECTION));
                i++;
                j++;
            }
            else
            {
                bool alternativeMatch = false;
                int k = 1;
                for (; k <= nAlternativeWords && (j + k) < aRevised.Length; k++)
                {
                    if (IsMatched(aOriginal[i], aRevised[j + k]))
                    {
                        alternativeMatch = true;
                        break;
                    }
                }

                if (alternativeMatch)
                {
                    for (int addedCount = 0; addedCount < k; addedCount++)
                    {
                        result.Add(new CWord(aRevised[j + addedCount], CColoring.ADDED));
                    }
                    result.Add(new CWord(aOriginal[i], CColoring.CORRECTION));
                    i++;
                    j = j + k + 1;
                }
                else
                {
                    result.Add(new CWord(aOriginal[i], CColoring.DELETED));
                    i++;
                }
            }
        }

        StringBuilder stringBuilder = new StringBuilder();

        foreach (CWord word in result)
        {
            stringBuilder.Append("{ ");
            stringBuilder.Append(word.Word);
            stringBuilder.Append(", {");
            stringBuilder.Append(word.Color);
            stringBuilder.Append("} },\n");
        }

        // Remove the trailing comma and newline
        if (stringBuilder.Length > 0)
        {
            stringBuilder.Length -= 2;
        }

        return stringBuilder.ToString();
    }
}