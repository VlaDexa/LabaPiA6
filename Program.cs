using System.Linq;
using System;
using System.Collections.Generic;
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
            FirstThree();
            WriteLine();
            SecondSix();
            WriteLine();
            SecondSeven();
            WriteLine();
            SecondEight();
            WriteLine();
            ThirdSix();
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
            public readonly double Percentage;

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
                new Answer("Бабушка", 0.1),
                new Answer("Дедушка", 0.2),
                new Answer("Сестра", 0.2),
                new Answer("Папа", 0.3),
                new Answer("Внучка", 0.075),
                new Answer("Внук", 0.05),
                new Answer("Прабабушка", 0.025),
                new Answer("Прадедушка", 0.05),
            };
            var list = answers.OrderByDescending((el) => el.Percentage).Take(5);
            WriteLine("Ответ\t|Доля");
            foreach (var item in list)
                WriteLine($"{item}");
        }

        struct Jumper
        {
            private readonly string surname;
            private readonly double[] first;
            private readonly double[] second;
            public double Result { get => (first.Average() + second.Average()) / 2; }

            public Jumper(string surname, double[] first, double[] second)
            {
                this.surname = surname;
                this.first = first;
                this.second = second;
            }

            public override string ToString()
            {
                return $"{surname}\t|{first.Average()}\t|{second.Average()}";
            }
        }

        static private void SecondSix()
        {
            var contestants = new Jumper[5] {
            new Jumper("Сидорова", new double[5]{ 3, 4, 5, 1, 5}, new double[5]{ 1,3,2,3,4}),
            new Jumper("Суркова\t", new double[5]{4,1,3,5,1 }, new double[5]{2,3,4,4,3 }),
            new Jumper("Соколова", new double[5]{3,1,4,2,1 }, new double[5]{4,4,2,2,2 }),
            new Jumper("Спиридонов", new double[5]{2,2,5,5,5 }, new double[5]{3,1,1,2,4 }),
            new Jumper("Жуков\t", new double[5]{2,1,1,1,1 }, new double[5]{2,4,5,2,3 }),
            };
            WriteLine("Фамилия\t\t|Первый\t|Второй");
            foreach (var man in contestants.OrderByDescending(x => x.Result))
                WriteLine(man);
        }

        enum MatchResult
        {
            Lose,
            None,
            Win,
        }

        struct Chesser
        {
            private readonly string surname;
            public readonly double Result;

            public Chesser(string surname, MatchResult[] results)
            {
                this.surname = surname;
                Result = results.Select(x => x switch
                {
                    MatchResult.Win => 1,
                    MatchResult.None => 0.5,
                    MatchResult.Lose => 0,
                    _ => throw new NotImplementedException()
                }).Average();
            }

            public override string ToString()
            {
                return $"{surname}\t|{Result}";
            }
        }

        static private void SecondSeven()
        {
            var chessers = new Chesser[4]{
                new Chesser("Белов", new MatchResult[3]{ (MatchResult)1, 0, (MatchResult)1 }),
                new Chesser("Латышев", new MatchResult[3]{ (MatchResult)1, (MatchResult)2, 0}),
                new Chesser("Лыков", new MatchResult[3]{ (MatchResult)2, (MatchResult)2, 0}),
                new Chesser("Зайцев", new MatchResult[3]{ 0, (MatchResult)2, (MatchResult)1}),
            };
            WriteLine("Фамилия\t|Баллы");
            foreach (var man in chessers.OrderByDescending(x => x.Result))
                WriteLine(man);
        }

        static readonly Random random = new Random();

        struct Hockeyer
        {
            public readonly List<int> Timeouts;

            public Hockeyer(object _ = null)
            {
                var times = new int[]{ 2,5,10 };
                Timeouts = new int[2].Select(_ => times[random.Next(0,3)]).ToList();
            }

            public override string ToString()
            {
                return string.Join(", ", Timeouts);
            }
        }

        static private void SecondEight()
        {
            WriteLine("Штрафы");
            foreach (var hock in new Hockeyer[30].Select(x => new Hockeyer(true)).Where(x => x.Timeouts.All(x => x!=10)).OrderByDescending(x => x.Timeouts.Sum()))
                WriteLine(hock);
        }

        struct SurvAnswer
        {
            public readonly Dictionary<int, string> answers;
            public SurvAnswer(string first, string second, string third)
            {
                answers = new Dictionary<int,string>();
                if (first != null)
                    answers.Add(0, first);
                if (second != null)
                    answers.Add(1, second);
                if (third != null)
                    answers.Add(2, third);
            }
        }
        
        static private void ThirdSix()
        {
            SurvAnswer[] answers = new SurvAnswer[] {
                new SurvAnswer("Собака", "Суицидальность", "Национализм"),
                new SurvAnswer("Муравьи", null, null)
            };
            var dict = new Dictionary<string, int>();
            for (int j = 0; j<3; ++j)
            {
                foreach (var answer in answers)
                    if (answer.answers.ContainsKey(j))
                    {
                        var znach = answer.answers[j];
                        if (dict.ContainsKey(znach))
                            dict[znach] += 1;
                        else
                            dict.Add(znach, 1);
                    }
                var all = dict.Values.Sum();
                var pairs = dict.AsEnumerable().OrderByDescending(x => x.Value).Take(5);
                WriteLine($"Вопрос №{j+1}");
                foreach (var pair in pairs)
                    WriteLine($"{pair.Key}\t{pair.Value / (double)all * 100}%");
                WriteLine();
                dict.Clear();
            }
        }
    }
}
