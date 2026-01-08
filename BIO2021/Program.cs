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
