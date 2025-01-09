using Generic_Methods;
using System.Collections.Generic;


namespace Generic_Delegates
{

    public delegate U Action<T, U>(T t, U u);

    public delegate bool Predicate<T>(T t);
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>() {
                 new Account("Eva", 100m),
                 new Account("Ida", 200),
                 new SavingsAccount("Teo", 300m, 5m),
                 new SavingsAccount("Edo", 400m, 5m)
                 };
            decimal total = Accumulate<Account, decimal>(
            accounts,
            (a, s) => a.Balance + s,
            a => a.Balance > 200
            );
            Console.WriteLine(total);
        }

        public static U Accumulate<T, U>(
 IEnumerable<T> collection,
 Action<T, U> action, Predicate<T> match)
        {
            U total = default(U);
            foreach (T a in collection)
                if (match(a))
                    total = action(a, total); // +=
            return total;
        }
    }
}
