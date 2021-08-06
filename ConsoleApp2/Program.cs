using System;

namespace ConsoleApp2
{
    class Program
    {
        static string[,] _list = new string[,] { { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } };

        static void Main(string[] args)
        {
            bool tic_tac_toe = true;
            Console.WriteLine("  --------------\n" +
                              "    Welcome To  \n" +
                              "   Tic Tac Toe! \n" +
                              "  --------------\n");

            while (tic_tac_toe)
            {
                Console.WriteLine("would you like to play? (yes, no): ");
                string _string = Console.ReadLine();
                if(_string == "yes")
                {
                    Game();
                }
                else if(_string == "no")
                {
                    Console.WriteLine("\n\n  --------------\n" +
                                      "Thanks for playing\n" +
                                      "   Tic Tac Toe! \n" +
                                      "  --------------\n");

                    tic_tac_toe = false;
                }
            }
        }

        static void Game()
        {
            _list = new string[,] { { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } };
            bool game = true;
            bool x_turn = true;
            int score = 0;

            Console.WriteLine("\nenter a value between 1-9 for a position on the board: \n\n");

            while (game == true)
            {
                if (score == 8)
                {
                    game = false;
                }

                Disp();
                Console.WriteLine("\nPosition: ");
                try
                {
                    if (x_turn == true)
                    {
                        while (x_turn)
                        {
                            int awns = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("");

                            try
                            {
                                if (_list[(int)MathF.Floor(awns / 3.5F), (int)(2 - 2 * (awns % 1.5))] == "-")
                                {
                                    _list[(int)MathF.Floor(awns / 3.5F), (int)(2 - 2 * (awns % 1.5))] = "X";
                                    x_turn = false;
                                }
                                else
                                {
                                    score--;
                                    break;
                                }
                            }
                            catch (System.IndexOutOfRangeException)
                            {
                                Console.WriteLine("\nerror : Position is not on the board\n");
                                score--;
                                break;
                            }
                        }
                    }
                    else
                    {
                        while (!x_turn)
                        {
                            int awns = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("");

                            try
                            {
                                if (_list[(int)MathF.Floor(awns / 3.5F), (int)(2 - 2 * (awns % 1.5))] == "-")
                                {
                                    _list[(int)MathF.Floor(awns / 3.5F), (int)(2 - 2 * (awns % 1.5))] = "O";
                                    x_turn = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nThat spot is already taken by " +
                                        _list[(int)MathF.Floor(awns / 3.5F), (int)(2 - 2 * (awns % 1.5))] +
                                        "\nTry again:\n");
                                    score--;
                                    break;
                                }
                            }
                            catch (System.IndexOutOfRangeException)
                            {
                                Console.WriteLine("\nerror : Position is not on the board\n");
                                score--;
                                break;
                            }
                        }
                    }

                    score++;

                    if(Rules(_list) == 0)
                    {
                        Console.WriteLine("X has won!");
                        game = false;
                    }
                    else if(Rules(_list) == 1)
                    {
                        Console.WriteLine("O has won!\n");
                        game = false;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("error : System.FormatException\nTry again: \n");
                }
            }
            if(Rules(_list) == 2)
            {
                Console.WriteLine("\nIt was a tie\n");
            }
            Disp();
        }

        static int Rules(string[,] _list)
        {
            bool x_win = false;
            bool o_win = false;
            
            if((_list[0, 2] == "X" && _list[1, 1] == "X" && _list[2, 0] == "X")||
               (_list[0, 0] == "X" && _list[1, 1] == "X" && _list[2, 2] == "X")||
               (_list[0, 0] == "X" && _list[0, 1] == "X" && _list[0, 2] == "X")||
               (_list[1, 0] == "X" && _list[1, 1] == "X" && _list[1, 2] == "X")||
               (_list[2, 0] == "X" && _list[2, 1] == "X" && _list[2, 2] == "X")||
               (_list[0, 0] == "X" && _list[1, 0] == "X" && _list[2, 0] == "X")||
               (_list[0, 1] == "X" && _list[1, 1] == "X" && _list[2, 1] == "X")||
               (_list[0, 2] == "X" && _list[1, 2] == "X" && _list[2, 2] == "X"))
            {
                x_win = true;
            }

            else if((_list[0, 2] == "O" && _list[1, 1] == "O" && _list[2, 0] == "O")||
                    (_list[0, 0] == "O" && _list[1, 1] == "O" && _list[2, 2] == "O")||
                    (_list[0, 0] == "O" && _list[0, 1] == "O" && _list[0, 2] == "O")||
                    (_list[1, 0] == "O" && _list[1, 1] == "O" && _list[1, 2] == "O")||
                    (_list[2, 0] == "O" && _list[2, 1] == "O" && _list[2, 2] == "O")||
                    (_list[0, 0] == "O" && _list[1, 0] == "O" && _list[2, 0] == "O")||
                    (_list[0, 1] == "O" && _list[1, 1] == "O" && _list[2, 1] == "O")||
                    (_list[0, 2] == "O" && _list[1, 2] == "O" && _list[2, 2] == "O"))
            {
                o_win = true;
            }

            if (x_win)
            {
                return 0;
            }
            else if(o_win)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        static void Disp()
        {
            string space = " | ";
            
            Console.WriteLine(" " + _list[0, 0] + space + _list[0, 1] + space + _list[0, 2] + "    1 | 2 | 3");
            Console.WriteLine(" ---------" +                                                  "    ---------");
            Console.WriteLine(" " + _list[1, 0] + space + _list[1, 1] + space + _list[1, 2] + "    4 | 5 | 6");
            Console.WriteLine(" ---------" +                                                  "    ---------");
            Console.WriteLine(" " + _list[2, 0] + space + _list[2, 1] + space + _list[2, 2] + "    7 | 8 | 9");
            Console.WriteLine("\n");
        }
    }
}
