using System.Linq;
using System;
using static System.Console;

namespace LabaPiA6
{
    class Program
    {
        static void Main()
        {
            FirstOne();
            WriteLine();
            FirstTwo();
            WriteLine();
        }

        struct Contestant
        {
            private readonly string surname;
            private readonly string community;
            private readonly double length_1;
            private readonly double length_2;

            public Contestant(string surname, string community, double length_1, double length_2)
            {
                this.surname = surname;
                this.community = community;
                this.length_1 = length_1;
                this.length_2 = length_2;
            }

            public double GetLength()
            {
                return length_1 + length_2;
            }

            public override string ToString()
            {
                return string.Format("{0}\t|{1}\t\t|{2}\t\t|{3}", surname, community, length_1, length_2);
            }
        }

        static private void FirstOne()
        {
            Contestant[] contestants = {
                new Contestant("Дубова", "Клуж", 2.1, 1.5),
                new Contestant("Цветков", "Ичан", 2.2, 2.2),
                new Contestant("Белов", "Рат", 2.4, 2.8),
            };
            WriteLine("Фамилия\t|Общество\t|Первый прыжок\t|Второй прыжок");
            foreach (var contestant in contestants.OrderByDescending((el) => el.GetLength()))
                WriteLine("{0}", contestant);
        }

        struct SwimContestant
        {
            private readonly string name;
            private readonly string group;
            private readonly string teacher;
            private readonly double result;

            public SwimContestant(string name, string group, string teacher, double result)
            {
                this.name = name;
                this.group = group;
                this.teacher = teacher;
                this.result = result;
            }

            public bool IsGood()
            {
                return result < 1.45;
            }

            public override string ToString()
            {
                return $"{name}\t|{group}\t|{teacher}\t|{result}\t\t|{(IsGood() ? "Зачёт" : "Незачёт")}";
            }
        }

        static private void FirstTwo()
        {
            SwimContestant[] swimContestants = { 
                new SwimContestant("Ксения", "Шанцю", "Орехова", 1.51),
                new SwimContestant("София", "Ашдод", "Никонов", 1.33),
                new SwimContestant("Нина", "Йена", "Захаров", 1.61),
            };
            WriteLine("Имя\t|Группа\t|Тренер\t\t|Результат\t|Зачёт");
            foreach (var swimContestant in swimContestants)
                WriteLine($"{swimContestant}");
            WriteLine($"{swimContestants.Where(el => el.IsGood()).Count()} человек получил зачёт");
        }

        struct Answer
        {
            private readonly string text;
            public readonly double Percentage { get; }

            public Answer(string text, double percentage)
            {
                this.text = text;
                Percentage = percentage;
            }

            public override string ToString()
            {
                return $"{text}\t|{Percentage}";
            }
        }

        static private void FirstThree()
        {
            Answer[] answers = {
                new Answer();
            };
        }
    }
}
