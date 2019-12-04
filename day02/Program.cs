using System;
using System.IO;
using System.Linq;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@Directory.GetCurrentDirectory() + "/input/part1");

            int[] intcode = text.Split(',').Select(ch => Int32.Parse(ch)).ToArray();

            int[] backup = intcode;
            Random r = new Random();
            // int[] intcode = {1,1,1,4,99,5,6,0,99};

            int noun = 23;
            int verb = 47;

            // while (noun <= 99)
            // {
            //     verb = 0;
            //     while (verb <= 99)
            //     {

            //         intcode = backup;
            
            

                    intcode[1] = noun;
                    intcode[2] = verb;


                    for (int i = 0; i < intcode.Length; i++)
                    {
                        // Oppcode 1 add [i+1] and [i+2] store at [i+3]
                        if (intcode[i] == 1)
                        {
                            int a = intcode[i + 1];
                            int b = intcode[i + 2];
                            int c = intcode[i + 3];

                            if (a <= intcode.Length && b <= intcode.Length && c <= intcode.Length)
                            {
                                intcode[c] = intcode[a] + intcode[b];
                            }
                            i += 3;

                        }
                        // Oppcode 2 multiply [i+1] and [i+2] store at [i+3]
                        else if (intcode[i] == 2 && intcode.Length >= i + 3)
                        {
                            int a = intcode[i + 1];
                            int b = intcode[i + 2];
                            int c = intcode[i + 3];

                            // Console.WriteLine("a: {0},b: {1},c: {2}, i: {3}", a, b, c, i);
                            if (a  >= 0 && a < intcode.Length && b  >= 0 && b < intcode.Length && c  >= 0 && c < intcode.Length)
                            {
                                intcode[c] = intcode[a] * intcode[b];
                            }
                            i += 3;
                        }
                        // Halt program
                        else if (intcode[i] == 99)
                        {

                            Console.WriteLine("noun: {0}, verb: {1}, answer: {2}, output: {3}", noun, verb, noun * 100 + verb, intcode[0]);
                            break;
                        }

                    }
            
            //         verb++;
            //     }

            //     noun++;
            // }

            // foreach (var c in intcode)
            // {
            //     Console.Write("{0},", c);
            // }

            // Console.WriteLine("noun: {0}, verb: {1}, answer: {2}", noun, verb, noun * 100 + verb);
        }
    }
}
