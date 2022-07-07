using System.Numerics;

// Very Slow
/*

int input;
if (!Int32.TryParse(Console.ReadLine(), out input)) return;

int[] Sequence = BuildSecondSequence(input);
Console.WriteLine(PartitionCount(input, Sequence));

static BigInteger PartitionCount(int n, int[] seq)
{   
    if (n == 1 || n == 0)
        return 1;

    if (n < 0)
        return 0;

    BigInteger sum = 0;
    for (int i = 0; i < n; i++)
    {
            sum += PartitionCount(n - seq[i], seq) * GetSign(i);
    }
    return sum;
}

static int Seq(int pos) => (pos % 2) == 0 ? (pos + 1) : (pos / 2) + 1;

static int GetSign(int index) => (index % 4 == 0 || index % 4 == 1) ? 1 : -1 ;

static int[] BuildSecondSequence(int size)
{
    var seq = new int[size];
    seq[0] = 1;
    for (int i = 1; i < size; i++)
    {
        seq[i] = seq[i - 1] + Seq(i);
    }
    return seq;
}
*/

// Faster
int input;
if (!Int32.TryParse(Console.ReadLine(), out input)) return;

long[] SecondSequence = BuildSecondSequence(input);
BigInteger[] FirstSequence = BuildFirstSequence(SecondSequence, input);

Console.WriteLine(FirstSequence[input]);

static int ThirdSequence(int pos) => (pos % 2) == 0 ? (pos + 1) : (pos / 2) + 1;

static int GetSign(int index) => (index % 4 == 0 || index % 4 == 1) ? 1 : -1 ;

static long[] BuildSecondSequence(int size)
{
    var seq = new long[size];
    seq[0] = 1;
    for (int i = 1; i < size; i++)
    {
        seq[i] = seq[i - 1] + ThirdSequence(i);
    }
    return seq;
}

static BigInteger[] BuildFirstSequence(long[] secondSeq, int size)
{
    var firstSeq = new BigInteger[size + 1];
    firstSeq[0] = 1;
    for (int i = 1; i < firstSeq.Length; i++)
    {
        BigInteger val = 0;
        for (int j = 0; j < secondSeq.Length; j++)
        {
            long index = i - secondSeq[j];
            if (index >= 0)
                val += firstSeq[index] * GetSign(j);
        }
        firstSeq[i] = val;
    }
    return firstSeq;
}

// Question: https://www.reddit.com/r/dailyprogrammer/comments/jfcuz5/20201021_challenge_386_intermediate_partition/
