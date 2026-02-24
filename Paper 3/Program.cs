static List<long> fibonacci(long n)
{
    List<long> fibo = new List<long>() { 1, 2 };
    while (true)
    {
        long newNum = fibo[fibo.Count - 1] + fibo[fibo.Count - 2];
        if (newNum > n) break;
        fibo.Add(newNum);
    }
    return fibo;
}

static List<long> Question1(long n)
{
    List<long> answers = new List<long>();
    while (n > 0)
    {
        var fibo = fibonacci(n);
        long largestFibo = fibo[fibo.Count - 1];
        answers.Add(largestFibo);
        n -= largestFibo;
    }
    return answers;
}

foreach (var ans in Question1(100))
{
    Console.Write($"{ans} ");
}


//q1b. 832040
//q1c. 49 C 3 = 18424
//q1d. 


static int Question2(List<string> initalStacks, List<string> FinalStacks)
{
    if (initalStacks.SequenceEqual(FinalStacks)) return 0;

    string startState = string.Join("|", initalStacks);
    string targetState = string.Join("|", FinalStacks);

    Queue<(string state, int moves)> q = new();
    HashSet<string> visited = new();

    q.Enqueue((startState, 0));
    visited.Add(startState);

    static string MoveStacks(string state, int fromPin, int toPin)
    {
        List<string> stacks = state.Split('|').ToList();

        if (stacks[fromPin] == "0") return null;

        string crate = stacks[fromPin].Last().ToString();
        stacks[fromPin] = stacks[fromPin].Length == 1 ? "0" : stacks[fromPin][..^1];

        if (stacks[toPin] == "0") stacks[toPin] = crate;
        else stacks[toPin] += crate;

        return string.Join("|", stacks);
    }

    while (q.Count > 0)
    {
        var (CurrentState, moveCount) = q.Dequeue();
        if (CurrentState == targetState) return moveCount;

        for (int from = 0; from < 4; from++)
        {
            for (int to = 0; to < 4; to++)
            {
                if (from == to) continue;

                string nextState = MoveStacks(CurrentState, from, to);
                if (nextState != null && !visited.Contains(nextState))
                {
                    visited.Add(nextState);
                    q.Enqueue((nextState, moveCount + 1));
                }
            }
        }
    }

    return -1;
}


List<string> initial = new List<string> { "12", "0", "3", "4" };
List<string> final = new List<string> { "1", "32", "4", "0" };
Console.WriteLine(Question2(initial, final));