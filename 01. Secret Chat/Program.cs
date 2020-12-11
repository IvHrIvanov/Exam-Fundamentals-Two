using System;
using System.Linq;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {

            string chat = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(":|:");

            while (commands[0] != "Reveal")
            {
                StringBuilder sb = new StringBuilder();
                string firstComand = commands[0];
                switch (firstComand)
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        chat = chat.Insert(index, " ");
                        sb.Append(chat);
                        break;
                    case "Reverse":
                        string textReverse = commands[1];
                        if (chat.Contains(textReverse))
                        {
                            int firstIndex = chat.IndexOf(textReverse);
                            string newString = string.Empty;
                            foreach (var item in textReverse.Reverse())
                            {
                                newString += item;
                            }
                            chat = chat.Remove(firstIndex, textReverse.Length);
                            chat = chat.Insert(chat.Length, newString);
                            sb.Append(chat);
                        }
                        else
                        {
                            sb.Append("error");
                        }
                        break;
                    case "ChangeAll":
                        string forReplace = commands[1];
                        string replacedWith = commands[2];
                        chat = chat.Replace(forReplace,replacedWith);
                        sb.Append(chat);
                        break;
                }

                Console.WriteLine(sb);
                commands = Console.ReadLine().Split(":|:");
            }

            Console.WriteLine($"You have a new text message: {chat}");
        }
    }
}