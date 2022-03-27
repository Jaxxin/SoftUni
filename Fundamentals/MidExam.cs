using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //HuntingGames();
            //Numbers();
            PhoneShop();

        }

        private static void HuntingGames()
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double totalWater = (days * players) * waterPerDay;
            double totalFood = (days * players) * foodPerDay;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;
                if (groupEnergy <= 0) { break; }
                if (i % 2 == 0) { groupEnergy = groupEnergy + (groupEnergy * 0.05); totalWater = totalWater - (totalWater * 0.30); }
                if (i % 3 == 0) { totalFood -= totalFood / players; groupEnergy = groupEnergy + (groupEnergy * 0.10); }
            }
            if (groupEnergy > 0) { Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!"); }
            else { Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water."); }
        }

        private static void Numbers()
        {
            var inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            var commands = Console.ReadLine();

            while (commands != "Finish")
            {
                string[] num = commands.Split();

                if (num[0] == "Add") { var digit = int.Parse(num[1]);    inputList.Add(digit); }
                else if (num[0] == "Remove"){ var digit = int.Parse(num[1]); inputList.Remove(digit); }
                else if (num[0] == "Replace")
                {
                    var value = int.Parse(num[1]); var replacment = int.Parse(num[2]);
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (inputList[i] == value)
                        {
                            inputList[i] = replacment;
                            break;
                        }
                    }
                }
                else if (num[0] == "Collapse")
                {
                    var value = int.Parse(num[1]);
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (inputList[i] < value)
                        {
                            inputList.Remove(inputList[i]);
                            i = -1;
                        }
                    }
                }
                commands = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", inputList));


        }

        private static void PhoneShop()
        {
            List<string> phones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                var input = Console.ReadLine(); if (input == "End"){ break; }

                string[] parts = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                if (command == "Add")
                {
                    string phone = parts[1];
                    if (phones.Contains(phone)) { continue; } else { phones.Add(phone); }
                }
                else if (command == "Remove")
                {
                    string phone = parts[1]; if (phones.Contains(phone)) { phones.Remove(phone); } else { continue; }
                }
                else if (command == "Bonus phone")
                {
                    string[] newParts = parts[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string oldPhone = newParts[0]; string newPhone = newParts[1];

                    for (int i = 0; i < phones.Count; i++)
                    {
                        if (phones[i] == oldPhone) {  int index = i;  phones.Insert(index + 1, newPhone); }
                    }
                }
                else
                {
                    string phone = parts[1];
                    if (phones.Contains(phone)) { phones.Remove(phone);  phones.Add(phone); } else { continue; }
                }}
            Console.WriteLine(string.Join(", ", phones));
        }
        //

    }
}