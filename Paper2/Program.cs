using System.Diagnostics;
using System.Runtime.InteropServices;
static string IntList(int start, int digit)
{
    var SB = new System.Text.StringBuilder();
    for (int i = 0; i < digit; i++){SB.Append(start + i);}
    Console.WriteLine(SB.ToString());
    return SB.ToString()[digit-1].ToString();
}
Console.WriteLine(IntList(999,10));
Console.WriteLine(IntList(999,11));
//Q2: 5
//Q3: 111, 112; 198765432, 198765433.



