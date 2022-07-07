using System.Numerics;

Console.WriteLine(Necklaces(123, 18));

static BigInteger Necklaces(long k, int n)
{
    BigInteger result = 0;
    var factors = GetFactors(n);

    foreach (var factor in factors)
    {
        result += phi(factor.Item1) * BigInteger.Pow(k, factor.Item2);
    }

    return result * 1 / n;
}

static int phi(int value)
{
    var product1 = 1;
    var product2 = 1;
    var primes = GetEvenlyDivisiblePrimes(value);

    foreach (var p in primes)
    {
        product1 *= p - 1; 
        product2 *= p; 
    }

    return value * product1 / product2;
}

static List<(int, int)> GetFactors(int value)
{
    var factors = new List<(int, int)>();
    for (int i = 1; i <= value; i++)
    {
        if (value % i == 0)
            factors.Add((i, value/i));
    }
    return factors;
}

static List<int> GetEvenlyDivisiblePrimes(int value)
{
    var primes = new List<int>();
    for(int i = 1; i <= value; i++)
    {
        if (IsPrime(i) && value % i == 0)
            primes.Add(i);
    }
    return primes;
}

static bool IsPrime(int n)
{
    if (n <= 1)
        return false;

    for (int i = 2; i < n; i++)
        if (n % i == 0)
            return false;

    return true;
}

// https://www.reddit.com/r/dailyprogrammer/comments/g1xrun/20200415_challenge_384_intermediate_necklace/
