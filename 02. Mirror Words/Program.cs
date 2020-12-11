using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@{1}|#{1})(?<word>[A-Za-z]{3,})\1{2}(?<mirror>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);
            bool flag = true;
            string text = Console.ReadLine();
            List<string> mirrorWords = new List<string>();
            MatchCollection match = regex.Matches(text);
            if (match.Count > 0)
            {
                Console.WriteLine($"{match.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }
            if (match.Count >= 0)
            {
                foreach (Match item in match)
                {
                    string firstWord = item.Groups[2].Value;
                    string reversWord = string.Empty;
                    string secondWord = item.Groups[3].Value;
                    foreach (var currLetter in secondWord.Reverse())
                    {
                        reversWord += currLetter;

                    }
                    if (firstWord == reversWord)
                    {
                        mirrorWords.Add(firstWord + " " + "<=>" + " " + secondWord);
                        flag = false;
                    }

                }
            }
            if (flag)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }            
        }
    }
}