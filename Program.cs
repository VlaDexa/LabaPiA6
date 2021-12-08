using System;
using System.Linq;
using static System.Console;

namespace LabaPiA6
{
    class Program
    {
        static void Main()
        {
            FirstOne();
            WriteLine();
        }

            struct Contestant
        {
            private readonly string surname;
            private readonly string community;
            public readonly double length_1;
            public readonly double length_2;

            public Contestant(string surname, string community, double length_1, double length_2)
            {
                this.surname = surname;
                this.community = community;
                this.length_1 = length_1;
                this.length_2 = length_2;
            }

            public override string ToString()
            {
                return string.Format("{0} | {1} | {2} | {3}", surname, community, length_1, length_2) ;
            }
        }

        static private void FirstOne()
        {
            Contestant[] contestants = {
                new Contestant("Белов", "Легница", 2.4, 2.8),
                new Contestant("Цветков", "Ичан", 2.2, 2.2),
                new Contestant("Дубова", "Клуж", 2.1, 1.5)
            };
            contestants.OrderBy((el) => el.length_1 + el.length_2);
            WriteLine("Фамилия | Общество | Первый прыжок | Второй прыжок");
            foreach (var contestant in contestants)
                WriteLine("{0}", contestant);
        }
    }
}
