using System;
using System.Numerics;

namespace Data_Types_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntegerOps();
            SumDigits();
            //Elevator();
            //SumOfChars();
            //PrintRange();
            //Latin();
            //WaterOverflow();
            //BeerKegs();
            //SpiceMustFlow();
            //PokeMon();
            //Snowballs();
        }

        private static void IntegerOps()
        {
            int first, second, third, fourth;

            int.TryParse(Console.ReadLine(), out first);
            int.TryParse(Console.ReadLine(), out second);
            int.TryParse(Console.ReadLine(), out third);
            int.TryParse(Console.ReadLine(), out fourth);

            Console.WriteLine(((first + second) / third) * fourth);

        }

        private static void SumDigits()
        {

            string num = Console.ReadLine();

            int sum = 0;



            for (int i = 0; i < num.Length; i++)
            {
                int current;

                int.TryParse(num[i].ToString(), out current);
                sum += current;

            }

            Console.WriteLine(sum);

        }

        private static void Elevator()
        {

            int n, p, x = 0;

            int.TryParse(Console.ReadLine(), out n);
            int.TryParse(Console.ReadLine(), out p);

            while (n > 0)
            {
                n -= p;
                x++;
            }

            Console.WriteLine(x);
        }

        private static void SumOfChars()
        {
            int inputLines = 0, sum = 0;
            int.TryParse(Console.ReadLine(), out inputLines);

            for (int i = 0; i < inputLines; i++)
            {

                char letter;
                char.TryParse(Console.ReadLine(), out letter);

                sum += (int)letter;

            }

            Console.WriteLine($"The sum equals: {sum}");

        }

        private static void PrintRange()
        {
            int x, y;

            int.TryParse(Console.ReadLine(), out x);
            int.TryParse(Console.ReadLine(), out y);

            for (int i = x; i <= y; i++)
            {

                Console.Write($"{(char)i} ");

            }

        }

        private static void Latin()
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);

            char first = ' ', second = ' ', third = ' ';

            for (int i = 97; i < (97 + n); i++)
            {
                first = (char)i;
                for (int x = 97; x < (97 + n); x++)
                {
                    second = (char)x;
                    for (int y = 97; y < (97 + n); y++)
                    {
                        third = (char)y;
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }

            }
        }


        private static void WaterOverflow()
        {
            int tankVolumeLitres = 255;

            int n = 0, waterQuantity = 0, litresInTank = 0;

            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i < n; i++)
            {
                int.TryParse(Console.ReadLine(), out waterQuantity);



                if (tankVolumeLitres >= waterQuantity)
                {
                    tankVolumeLitres -= waterQuantity;
                    litresInTank += waterQuantity;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(litresInTank);
        }

        private static void BeerKegs()
        {

            int kegs = 0;
            double k, l, cKegVolume = 0, biggestKeg = double.MinValue;
            string j, biggestKegName = "";

            int.TryParse(Console.ReadLine(), out kegs);

            for (int i = 0; i < kegs; i++)
            {

                j = Console.ReadLine();
                double.TryParse(Console.ReadLine(), out k);
                double.TryParse(Console.ReadLine(), out l);

                cKegVolume = Math.PI * Math.Pow(k, 2) * l;

                if (cKegVolume > biggestKeg)
                {
                    biggestKeg = cKegVolume;
                    biggestKegName = j;
                }

            }

            Console.WriteLine(biggestKegName);
        }

        private static void SpiceMustFlow()
        {
            const int exhaustiveConsumptionYield = 26, yieldDropFactor = 10, profitableYieldFactor = 100;

            int startingYield, dayCounter = 0, totalSpice = 0;

            int.TryParse(Console.ReadLine(), out startingYield);

            while (startingYield >= profitableYieldFactor)
            {

                dayCounter++;

                totalSpice += startingYield - exhaustiveConsumptionYield;

                startingYield -= yieldDropFactor;

            }

            if (dayCounter != 0) totalSpice -= exhaustiveConsumptionYield;

            Console.WriteLine(dayCounter);
            Console.WriteLine(totalSpice);
        }

        private static void PokeMon()
        {
            int n, m, y;
            int targetsHit = 0, originalPokePower;

            int.TryParse(Console.ReadLine(), out n);
            int.TryParse(Console.ReadLine(), out m);
            int.TryParse(Console.ReadLine(), out y);

            originalPokePower = n;

            while (n >= m)
            {
                targetsHit++;
                n -= m;
                if ((decimal)n / originalPokePower == 0.5M && y > 0) n /= y;
            }

            Console.WriteLine(n);
            Console.WriteLine(targetsHit);
        }

        private static void SnowBalls()
        {
            int n, snowballSnow = 0, snowballTime = 0, snowballQuality = 0;
            BigInteger snowballValue = 0;
            string result = "";

            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i < n; i++)
            {

                int.TryParse(Console.ReadLine(), out snowballSnow);
                int.TryParse(Console.ReadLine(), out snowballTime);
                int.TryParse(Console.ReadLine(), out snowballQuality);

                BigInteger cSnowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue < cSnowballValue)
                {
                    snowballValue = cSnowballValue;
                    result = $"{snowballSnow} : { snowballTime} = { snowballValue} ({ snowballQuality})";
                }

            }

            Console.WriteLine(result);

        }

        //
    }
}
