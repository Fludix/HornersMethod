// 2024 © Fludix
// Created on 29th November 2024 at 03:34 PM. Finished programming and testing it at 29th November 2024 at 06:42 PM.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;

namespace HornersMethod
{
    internal class Program
    {
        #region Embedded Soundeffects
        public static void Correct()
        {
            Assembly Resources = Assembly.GetExecutingAssembly();
            Stream s2 = Resources.GetManifestResourceStream("HornersMethod.true.wav");
            System.Media.SoundPlayer ZeroPointFound = new System.Media.SoundPlayer(s2);
            ZeroPointFound.Play();
        }

        public static void False()
        {
            Assembly Resources = Assembly.GetExecutingAssembly();
            Stream s1 = Resources.GetManifestResourceStream("HornersMethod.false.wav");
            System.Media.SoundPlayer NoZeroPointFound = new System.Media.SoundPlayer(s1);
            NoZeroPointFound.Play();
        }
        #endregion

        class Horner
        {
            #region Properties
            public int _degree;
            public int _coefficientCounter;
            public double[] _coefficients;
            public int _guessedZeroPoint;
            public int _resultHorner;
            #endregion

            #region Methods
            // The degree of the polynomial equation is read in there:
            public void ReadingDegree()
            {
                Console.WriteLine("What is the degree of the polynomial equation? (1 ~ 10): ");
                _degree = Int32.Parse(Console.ReadLine());

                if (_degree > 10)
                {
                    Console.Clear();
                    Console.WriteLine("You have exceeded the maximum number of degrees! Maximum of only 10!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                else
                {
                    Console.Clear();
                    _coefficientCounter = _degree + 1;
                }
            }

            // All coefficient values are listed there:
            public double[] CountingCoefficients()
            {
                Console.Clear();
                List<double> List = new List<double> { };

                int i = 0;
                while (i < _coefficientCounter)
                {
                    if (i == 0)
                    {
                        Console.WriteLine($"What is the coefficient for a_{i}?: ");
                    }
                    else
                    {
                        Console.WriteLine($"What is the coefficient for a_{i}x^{i}?: ");
                    }

                    double AddCoefficient = Double.Parse(Console.ReadLine());

                    Console.Clear();
                    List.Add(AddCoefficient);
                    i++;
                }
                _coefficients = List.ToArray();
                return _coefficients;
            }

            // The whole Horner's Method calculation
            public double HornersMethod()
            {
                Console.Clear();
                Console.WriteLine("Guess a zero point: ");
                _guessedZeroPoint = Int32.Parse(Console.ReadLine());

                double Calculation = 0;
                for (int i = 0; i < _coefficients.Count(); i++)
                {
                    Calculation += _coefficients[i] * Math.Pow(_guessedZeroPoint, i);
                }

                if (Calculation == 0)
                {
                    Console.Clear();
                    Correct();
                }

                else if (Calculation >= 1 || Calculation < 0)
                {
                    Console.Clear();
                    False();
                    Console.WriteLine("*BUZZER* No zero point found!");
                    Console.WriteLine($"The result is: {Calculation}");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Calculation = _resultHorner;
                return 0;
            }
            #endregion
        }

        static void Main(string[] args)
        {
            #region Program
            // Instantiate object
            Horner HornersMethod = new Horner();

            // Call methods
            HornersMethod.ReadingDegree();
            HornersMethod.CountingCoefficients();
            double foundZeroPoint = HornersMethod.HornersMethod();

            // Indicate the results
            Console.WriteLine($"The zero point is: f({HornersMethod._guessedZeroPoint}) = {HornersMethod._resultHorner}");
            Console.ReadKey();
            Console.Clear();
            #endregion
        }
    }
}