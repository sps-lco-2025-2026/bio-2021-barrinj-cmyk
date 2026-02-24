using System.Diagnostics;

// Q1 - create a class based on the data given 

DownPat dp = new DownPat("DE", "C");
dp.Calculate();

// test the output 
Debug.Assert(dp.First == "NO");
Debug.Assert(dp.Second == "YES");
Debug.Assert(dp.Combined == "YES");


public class DownPat
{
    public string S1 { get; }
    public string S2 { get; }

    public string First { get; private set; }
    public string Second { get; private set; }
    public string Combined { get; private set; }

    public DownPat(string s1, string s2)
    {
        S1 = s1;
        S2 = s2;
    }

    public void Calculate()
    {
        First = IsPat(S1) ? "YES" : "NO";
        Second = IsPat(S2) ? "YES" : "NO";
        Combined = IsPat(S1 + S2) ? "YES" : "NO";
        Console.WriteLine($"{First}\n{Second}\n{Combined}");
    }

    private bool IsPat(string s)
    {
        if (s.Length == 1) return true;

        for (int i = 1; i < s.Length; i++)
        {
            string left = s.Substring(0, i);
            string right = s.Substring(i);

            string revLeft = Reverse(left);
            string revRight = Reverse(right);

            if (IsPat(revLeft) && IsPat(revRight))
            {
                if (left.All(c => c > right.Max()))
                    return true;
            }
        }

        return false;
    }

    private string Reverse(string s) =>
        new string(s.Reverse().ToArray());
}

//1b. - 4 
//1c. - 24! = 6.204484e+23

//Q2 - Window Cleaner
public class WindowDressing
{
    Dictionary<string, int> cache = new Dictionary<string, int>();
    Queue<string> queue = new Queue<string>();
    public int maxLength { get; }
    public string add(string s)
    {
        if (s.Length == 0) return "A";
        if (s.Length == maxLength) return s;
        int highest = 0;
        char[] chars = s.ToCharArray();
        foreach (char c in chars)
        {
            int ascii = (int)c;
            if (ascii > highest)
            {
                highest = ascii;
            }
        }
        return s + (char)(highest + 1);
    }
    public string rotate(string s)
    {
        if (s.Length < 2) return s;
        return s.Substring(1) + s[0];
    }
    public string swap(string s)
    {
        if (s.Length < 2) return s;
        return s[1] + s[0] + s.Substring(2);
    }
    public WindowDressing(string finalString)
    {
        maxLength = finalString.Length;
        cache.Add(add(""), 1);
        cache.Add(add("A"), 2);
        queue.Enqueue(add(""));
        queue.Enqueue(add("A"));
        
    }
}



static string IntList(int start, int digit)
{
    for (int i = 0; i < digit; i++)
    {
        
    }
}