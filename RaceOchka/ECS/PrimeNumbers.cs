using System.Collections;

namespace RaceOchka.ECS;

class PrimeNumbers : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        int current = 2;

        while (true)
        {
            if (IsPrime(current))
            {
                yield return current;
            }
            current++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
