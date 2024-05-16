//Console.WriteLine("Hello, World!");

class StringSearch
{
    static int indices;
    static void Main(string[] args)
    {
        string scannedpre = "On the internet, many people use a search engine to look up information. ";
        scannedpre += "These search engines, like Google, Bing, and Yahoo, search almost the entire internet ";
        scannedpre += "to return information based on whatever a user searches for. These engines do a lot of ";
        scannedpre += "behind-the-scene work in order to find the most relevant information it can possibly find, ";
        scannedpre += "but the most simple means of search engines looking for information is by using string-search ";
        scannedpre += "algorithms. These algorithms will take a string and go through another string in order to find ";
        scannedpre += "the index of the string or return if it doesn’t show up. There have been many string-search ";
        scannedpre += "algorithms made to solve this problem, including Rabin-Karp, Knuth-Morris-Pratt, and plain ";
        scannedpre += "brute force. These all will do the job and search for a given string, however, the Boyer-Moore ";
        scannedpre += "string-search algorithm is the algorithm that is used the most when programs need to run a ";
        scannedpre += "string-search.";

        char[] scanned = scannedpre.ToCharArray();

        indices = 0;

        Console.WriteLine(scanned.Length);
        
        string targetpre = "forc";
        char[] target = targetpre.ToCharArray();
        int indexFound = IndexOf(scanned, target);
        Console.WriteLine(target.Length + " length pattern visits " + indices);

        indices = 0;
        targetpre = "force";
        char[] target2 = targetpre.ToCharArray();
        indexFound = IndexOf(scanned, target2);
        Console.WriteLine(target2.Length + " length pattern visits " + indices);

        indices = 0;
        targetpre = "force. These";
        char[] target3 = targetpre.ToCharArray();
        indexFound = IndexOf(scanned, target3);
        Console.WriteLine(target3.Length + " length pattern visits " + indices);

        indices = 0;
        targetpre = "force. These all will do the job and search for a given string,";
        char[] target4 = targetpre.ToCharArray();
        indexFound = IndexOf(scanned, target4);
        Console.WriteLine(target4.Length + " length pattern visits " + indices);

        indices = 0;
        targetpre = "force. These all will do the job and search for a given string, however, the Boyer-Moore string-search algorithm is the algorithm that is used the most when programs need to run a";
        char[] target5 = targetpre.ToCharArray();
        indexFound = IndexOf(scanned, target5);
        Console.WriteLine(target5.Length + " length pattern visits " + indices);

        //char[] scanned = { 'a', 'n', 'p', 'a', 'n', 'n', 'm', 'a', 'n' };

        /*
        char[] target = { 'z' };
        int indexFound = IndexOf(scanned, target);
        Console.WriteLine(target.Length + " length pattern visits " + indices);

        
        indices = 0;
        char[] target2 = { 'z', 'q' };
        indexFound = IndexOf(scanned, target2);
        Console.WriteLine(target2.Length + " length pattern visits " + indices);

        indices = 0;
        char[] target5 = { 'z', 'q', 'z', 'q', 'z' };
        indexFound = IndexOf(scanned, target5);
        Console.WriteLine(target5.Length + " length pattern visits " + indices);

        indices = 0;
        char[] target10 = { 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q' };
        indexFound = IndexOf(scanned, target10);
        Console.WriteLine(target10.Length + " length pattern visits " + indices);

        indices = 0;
        char[] target20 = { 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q' };
        indexFound = IndexOf(scanned, target20);
        Console.WriteLine(target20.Length + " length pattern visits " + indices);

        indices = 0;
        char[] target50 = { 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q' };
        indexFound = IndexOf(scanned, target50);
        Console.WriteLine(target50.Length + " length pattern visits " + indices);

        indices = 0;
        char[] target100 = { 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q',
            'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q', 'z', 'q' };
        indexFound = IndexOf(scanned, target100);
        Console.WriteLine(target100.Length + " length pattern visits " + indices);
        */

        //Console.WriteLine(indexFound);
    }

    public static int IndexOf(char[] scanned, char[] target)
    {
        if(target.Length == 0)
        {
            return 0;
        }
        int[] charTable = MakeCharTable(target);
        int[] offsetTable = MakeOffsetTable(target);
        for (int i = target.Length - 1, j; i < scanned.Length;)
        {
            for (j = target.Length - 1; target[j] == scanned[i]; --i, --j)
            {
                if (j == 0)
                {
                    return i;
                }
            }
            indices++;
            i += Math.Max(offsetTable[target.Length - 1 - j], charTable[scanned[i]]);
        }

        return -1;
    }

    private static int[] MakeCharTable(char[] target)
    {
        int alphabetSize = Char.MaxValue + 1;
        int[] table = new int[alphabetSize];
        for(int i = 0; i < table.Length; ++i)
        {
            table[i] = target.Length;
        }
        for(int i=0; i < target.Length; ++i)
        {
            table[target[i]] = target.Length - 1 - i;
        }
        return table;
    }

    private static int[] MakeOffsetTable(char[] target)
    {
        int[] table = new int[target.Length];
        int lastPrefixPosition = target.Length;
        for(int i = target.Length; i > 0; --i)
        {
            if(IsPrefix(target, i))
            {
                lastPrefixPosition = i;
            }
            table[target.Length - i] = lastPrefixPosition - i + target.Length;
        }
        for (int i = 0; i < target.Length - 1; ++i)
        {
            int slen = SuffixLength(target, i);
            table[slen] = target.Length - 1 - i + slen;
        }
        return table;
    }

    private static Boolean IsPrefix(char[] target, int p)
    {
        int j = 0;
        for (int i = p; i < target.Length; ++i){
            ++j;
            if (target[i] != target[j])
            {
                return false;
            }
        }
        return true;
    }

    private static int SuffixLength(char[] target, int p)
    {
        int len = 0;
        int j = target.Length - 1;
        for (int i = p; i >= 0 && target[i] == target[j]; --i)
        {
            --j;
            len += 1;
        }
        return len;
    }
}