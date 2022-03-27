using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Final_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hogwarts();
            //EasterEggs();
            Followers();  

        }

        private static void Hogwarts() // start hogwarts
        {

            string spell = Console.ReadLine().ToLower();
            string currSpell = spell;
            string cmd;

            while ((cmd = Console.ReadLine()) != "Abracadabra")
            {
                string[] input = cmd.Split();
                string commandName = input[0];

                switch (commandName.ToLower())
                {
                    case "abjuration":
                        string result = currSpell.ToUpper();
                        currSpell = result;
                        Console.WriteLine(currSpell);
                        break;
                    case "necromancy":
                        string result2 = currSpell.ToLower();
                        currSpell = result2;
                        Console.WriteLine(currSpell);
                        break;
                    case "illusion":
                        int index = int.Parse(input[1]);
                        char letter = char.Parse(input[2]);
                        if (index > currSpell.Length - 1 || index < 0)
                        {
                            Console.WriteLine("The spell was too weak.");
                        }
                        else
                        {
                            char oldChar = currSpell[index];
                            currSpell = currSpell.Replace(oldChar, letter);
                            Console.WriteLine("Done!");
                        }
                        break;
                    case "divination":
                        string firstSubstring = input[1];
                        string secondSubstring = input[2];
                        int indexOfFirstSubstring = currSpell.IndexOf(firstSubstring);
                        if (indexOfFirstSubstring == -1)
                        {
                            break;
                        }
                        else
                        {
                            while (indexOfFirstSubstring != -1)
                            {
                                currSpell = currSpell.Remove(indexOfFirstSubstring, firstSubstring.Length);
                                currSpell = currSpell.Insert(indexOfFirstSubstring, secondSubstring);
                                indexOfFirstSubstring = currSpell.IndexOf(firstSubstring);
                            }
                            Console.WriteLine(currSpell);
                        }
                        break;
                    case "alteration":
                        string subStringToRemove = input[1];
                        int index1 = currSpell.IndexOf(subStringToRemove);
                        if (index1 == -1)
                        {
                            break;
                        }
                        else
                        {
                            currSpell = currSpell.Remove(index1, subStringToRemove.Length);
                            Console.WriteLine(currSpell);
                        }
                        break;
                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }
            }
        } // End Hogwarts


        private static void EasterEggs() // Start Easter Eggs
        {
            string input = Console.ReadLine();
            Regex rule = new Regex(@"(@|#)([a-z]{3,})(@|#)[^a-z0-9]*/\d{1,}/");

            foreach (Match match in rule.Matches(input)) {
                string colorMatch = Regex.Match(match.ToString(), @"(@|#)([a-z]{3,})(@|#)").ToString();
                string color = colorMatch.Substring(1, colorMatch.Length - 2);
                string amountMatch = Regex.Match(match.ToString(), @"/\d{1,}/").ToString();
                int amount = Convert.ToInt32(amountMatch.Substring(1, amountMatch.Length - 2));
                Console.WriteLine($"You found {amount} {color} eggs!");
            }

        } // End Easter Eggs

        private static void Followers() // Start Followers
        {
            Dictionary<string, int[]> followers = new Dictionary<string, int[]>();

            string command = Console.ReadLine();

            while (command != "Log out")
            {
                string[] split = command.Split(": ");
                if (command.Contains("New follower"))
                {
                    if (!followers.ContainsKey(split[1]))
                    {
                        followers.Add(split[1], new int[2]);
                    }
                }
                else if (command.Contains("Like"))
                {
                    int likes = int.Parse(split[2]);
                    if (!followers.ContainsKey(split[1]))
                    {
                        followers.Add(split[1], new int[2] { likes, 0 });
                    }
                    else
                    {
                        followers[split[1]][0] += likes;
                    }
                }
                else if (command.Contains("Comment"))
                {
                    if (!followers.ContainsKey(split[1]))
                    {
                        followers.Add(split[1], new int[2] { 0, 1 });
                    }
                    else
                    {
                        followers[split[1]][1] += 1;
                    }
                }
                else if (command.Contains("Blocked"))
                {
                    if (followers.ContainsKey(split[1]))
                    {
                        followers.Remove(split[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{split[1]} doesn't exist.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");

            followers = followers.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var follower in followers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value[0] + follower.Value[1]}");
            }


        } // End Followers






    }
}
