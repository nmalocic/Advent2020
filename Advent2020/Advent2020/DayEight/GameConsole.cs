using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2020.DayEight
{
    public class GameConsole
    {
        string inputPath = @"DayEight\input.txt";
        string[] commands;

        public GameConsole()
        {
            commands = File.ReadAllLines(inputPath);
        }

        public int ExecuteCommands()
        {
            int accumulator = 0;
            Dictionary<int, string> executedCommands = new Dictionary<int, string>();
            for(int i=0; i < commands.Length; i++)
            {
                string commandText = commands[i];

                if (executedCommands.ContainsKey(i))
                {
                    return accumulator;
                }

                executedCommands.Add(i, commandText);

                string command = commandText.Split(" ")[0];
                string action = commandText.Split(" ")[1];
                string operation = action.Substring(0, 1);
                int value = int.Parse(action.Substring(1));

                if (command.Equals("acc")) {
                    if (operation.Equals( "-"))
                    {
                        accumulator -= value;
                    } else
                    {
                        accumulator += value;
                    }

                } else if (command.Equals("jmp"))
                {
                    if (operation.Equals("-"))
                    {
                        i -= value + 1;
                    } else
                    {
                        i += value -1;
                    }
                }

            }

            return accumulator;
        }

        public int ChangeCommand()
        {
            int accumulator = 0;
            Dictionary<int, string> executedCommands = new Dictionary<int, string>();
            Dictionary<int, string> changedCommands = new Dictionary<int, string>();
            bool noChangesInThisPass = true;
            int changedIndex = -1;
            int i;
            for (i = 0; i < commands.Length; i++)
            {
                string commandText = commands[i];

                if (executedCommands.ContainsKey(i))
                {
                    accumulator = 0;
                    i = -1;
                    changedIndex = -1;
                    executedCommands = new Dictionary<int, string>();
                    noChangesInThisPass = true;
                }
                else
                {
                    executedCommands.Add(i, commandText);
                    string command = commandText.Split(" ")[0];
                    string action = commandText.Split(" ")[1];
                    string operation = action.Substring(0, 1);
                    int value = int.Parse(action.Substring(1));

                    if (noChangesInThisPass && !changedCommands.ContainsKey(i))
                    {
                        // change command
                        if (command.Equals("nop") || command.Equals("jmp"))
                        {
                            changedCommands.Add(i, commandText);
                            noChangesInThisPass = !noChangesInThisPass;
                            changedIndex = i;
                            if (command.Equals("nop"))
                            {
                                command = "jmp";
                            }
                            else
                            {
                                command = "nop";
                            }
                        }
                    }

                    if (command.Equals("acc"))
                    {
                        if (operation.Equals("-"))
                        {
                            accumulator -= value;
                        }
                        else
                        {
                            accumulator += value;
                        }

                    }
                    else if (command.Equals("jmp"))
                    {
                        if (operation.Equals("-"))
                        {
                            i -= value + 1;
                        }
                        else
                        {
                            i += value - 1;
                        }
                    }
                }

            }

            return accumulator;
        }
    }
}
