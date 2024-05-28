using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ_12
{
    internal class Program
    {
        static Dictionary<string, int> CountWordFrequency(string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string pattern = @"\w+";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                string word = match.Value.ToLower();
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }
        static Dictionary<string, string> englishRussianDictionary = new Dictionary<string, string>
    {
        {"United States", "Соединенные Штаты Америки"},
        {"Russia", "Россия"},
        {"China", "Китай"},
        {"Japan", "Япония"},
        {"Germany", "Германия"},
        {"France", "Франция"},
        {"United Kingdom", "Великобритания"},
        {"Italy", "Италия"},
        {"Canada", "Канада"},
        {"Spain", "Испания"}
    };

        static Dictionary<string, string> russianEnglishDictionary = new Dictionary<string, string>();
        public class Point<T>
        {
            public T X { get; set; }
            public T Y { get; set; }

            public Point(T x, T y)
            {
                X = x;
                Y = y;
            }
        }


        public class Line<T>
        {
            public Point<T> Point1 { get; set; }
            public Point<T> Point2 { get; set; }

            public Line(Point<T> point1, Point<T> point2)
            {
                Point1 = point1;
                Point2 = point2;
            }

            public Line(T x1, T y1, T x2, T y2)
            {
                Point1 = new Point<T>(x1, y1);
                Point2 = new Point<T>(x2, y2);
            }

            public override string ToString()
            {
                return $"Line: ({Point1.X}, {Point1.Y}) -> ({Point2.X}, {Point2.Y})";
            }
        }

        public class Point2D<T>
        {
            public T X { get; set; }
            public T Y { get; set; }

            public Point2D(T x, T y)
            {
                X = x;
                Y = y;
            }
        }


        public class Point3D : Point2D<int>
        {
            public int Z { get; set; }

            public Point3D(int x, int y, int z) : base(x, y)
            {
                Z = z;
            }

            public override string ToString()
            {
                return $"({X}, {Y}, {Z})";
            }
        }
        static void Main(string[] args)
        {
            foreach (KeyValuePair<string, string> pair in englishRussianDictionary)
            {
                russianEnglishDictionary[pair.Value] = pair.Key;
            }

            while (true)
            {
                Console.WriteLine("\nВыберите направление перевода:");
                Console.WriteLine("1. Английский -> Русский");
                Console.WriteLine("2. Русский -> Английский");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите английское название страны: ");
                    string englishCountry = Console.ReadLine();

                    if (englishRussianDictionary.ContainsKey(englishCountry))
                    {
                        Console.WriteLine("Русское название: " + englishRussianDictionary[englishCountry]);
                    }
                    else
                    {
                        Console.WriteLine("Страна не найдена в словаре.");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Введите русское название страны: ");
                    string russianCountry = Console.ReadLine();

                    if (russianEnglishDictionary.ContainsKey(russianCountry))
                    {
                        Console.WriteLine("Английское название: " + russianEnglishDictionary[russianCountry]);
                    }
                    else
                    {
                        Console.WriteLine("Страна не найдена в словаре.");
                    }
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                }

            }

            Point3D point = new Point3D(2, 3, 4);


            Console.WriteLine(point.ToString());

            Console.ReadLine();

            Line<int> line1 = new Line<int>(new Point<int>(1, 2), new Point<int>(3, 4));
            Line<double> line2 = new Line<double>(2.5, 3.7, 5.1, 6.3);

            Console.WriteLine(line1.ToString());
            Console.WriteLine(line2.ToString());


            string text = "This is a sample text. This is another sample text.";
            Dictionary<string, int> wordCount = CountWordFrequency(text);

            foreach (KeyValuePair<string, int> pair in wordCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            Console.ReadLine();
        }
    }
}
