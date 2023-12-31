using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class MainMenu
    {
        public static void Menu()
        {
            for (; ; )
            {
                Console.Clear();
                writeLogo();
                Say("1", "Start Game");
                Say("2", "info");
                Say("3", "Exit");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    game();
                }
                if (option == "2")
                {
                    infoO();
                }
                if (option == "3")
                {
                    Exitt();
                }
                else
                {

                    Console.WriteLine("Error Please Choose the right option");
                    Thread.Sleep(1500);
                }

            }

        }
        public static void game()
        {
            string jiji;
        Start:;
            Console.WriteLine("Start?");
            _ = Console.ReadLine();


            Console.Clear();
            const int fieldLength = 50, fieldWidth = 15;
            const char fieldTile = '#';
            string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

            const int racketlength = fieldWidth / 4;
            const char aegisTile = '|';

            int leftracketHeight = 0;
            int rightracketHeight = 0;

            int ballX = fieldLength / 2;
            int ballY = fieldWidth / 2;
            const char ballTile = 'O';

            bool isballGoingDown = true;
            bool isballGoingRight = true;

            int leftplayerpoints = 0;
            int rightplayerpoints = 0;

            int scoreboardX = fieldLength / 2 - 2;
            int scoreboardY = fieldWidth + 3;



            while (true)
            {


                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidth);
                Console.WriteLine(line);

                for (int i = 0; i < racketlength; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + leftracketHeight);
                    Console.WriteLine(aegisTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1 + rightracketHeight);
                    Console.WriteLine(aegisTile);
                }

                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(ballTile);
                    Thread.Sleep(80);

                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(' ');

                    if (isballGoingDown)
                    {
                        ballY++;
                    }
                    else
                    {
                        ballY--;
                    }
                    if (isballGoingRight)
                    {
                        ballX++;
                    }
                    else
                    {
                        ballX--;
                    }

                    if (ballY == 1 || ballY == fieldWidth - 1)
                    {
                        isballGoingDown = !isballGoingDown;
                    }
                    if (ballX == 1)
                    {
                        if (ballY >= leftracketHeight + 1 && ballY <= leftracketHeight + racketlength)
                        {
                            isballGoingRight = !isballGoingRight;
                        }
                        else
                        {
                            rightplayerpoints++;
                            ballY = fieldWidth / 2;
                            ballX = fieldLength / 2;
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftplayerpoints} |  {rightplayerpoints}");

                            if (rightplayerpoints == 3)
                            {

                                goto outer;
                            }
                        }
                    }
                    if (ballX == fieldLength - 2)
                    {
                        if (ballY >= rightracketHeight + 1 && ballY <= rightracketHeight + racketlength)
                        {
                            isballGoingRight = !isballGoingRight;
                        }
                        else
                        {
                            leftplayerpoints++;
                            ballY = fieldWidth / 2;
                            ballX = fieldLength / 2;
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftplayerpoints} |  {rightplayerpoints}");

                            if (leftplayerpoints == 3)
                            {

                                goto outer;

                            }

                        }
                    }

                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (rightracketHeight > 0)
                        {
                            rightracketHeight--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (rightracketHeight < fieldWidth - racketlength - 1)
                        {
                            rightracketHeight++;
                        }
                        break;
                    case ConsoleKey.W:
                        if (leftracketHeight > 0)
                        {
                            leftracketHeight--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (leftracketHeight < fieldWidth - racketlength - 1)
                        {
                            leftracketHeight++;
                        }
                        break;

                }
                for (int i = 1; i < fieldWidth; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(fieldLength - 1, i);
                    Console.WriteLine(" ");
                }
            }
        outer:;

            Console.SetCursorPosition(0, 16);

            if (rightracketHeight == 3)
            {
                if (rightracketHeight == 3)
                {
                    Console.WriteLine("Do you want to go back to menu? Press Y ");
                    jiji = Console.ReadLine();
                    if (jiji == "Y")
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Press Y ");
                    }
                }
                Console.WriteLine("Right Player Wins");
                goto Start;



            }
            else
            {
                Console.WriteLine("Left Player Wins");
                goto Start;

            }



        }
        public static void Say(string prefix, string message)
        {
            Console.Write("[");
            Console.Write(prefix);
            Console.WriteLine("]" + message);
        }



        public static void writeLogo()
        {
            string logo = @"
██████   ██████  ███    ██  ██████       ██████   █████  ███    ███ ███████ 
██   ██ ██    ██ ████   ██ ██           ██       ██   ██ ████  ████ ██      
██████  ██    ██ ██ ██  ██ ██   ███     ██   ███ ███████ ██ ████ ██ █████   
██      ██    ██ ██  ██ ██ ██    ██     ██    ██ ██   ██ ██  ██  ██ ██      
██       ██████  ██   ████  ██████       ██████  ██   ██ ██      ██ ███████ 
                                                                            
                                                                            ";
            Console.WriteLine(logo);

        }
        public static void Exitt()
        {
            System.Environment.Exit(0);
        }
        public static void infoO()
        {
            string inuman;
            Console.Clear();
            Console.WriteLine(" ======================================================================================================================= ");
            Console.WriteLine(" Pong is one of the first computer games that ever created, this simple \"tennis like\" game features two paddles and a ball, the goal is to defeat your opponent by being the first one to gain10 point, a player gets a point once the opponent misses a ball. The game can be played with two human players, or one player against a computer controlled paddle. The game was originally developed by Allan Alcorn and released in 1972 by Atari corporations. Soon, Pong became a huge success, and became the first commercially successful game, on 1975, Atari release a home edition of Pong (the first version was played on Arcade machines) which sold 150,000 units. Today, the Pong Game is considered to be the game which started the video games industry, as it proved that the video games market can produce significant revenues.\r\n\r\nNolan Bushnell founded Atari at 1972 in order to create games and ideas and license them to other companies for mass production. Pong was actually a training exercise for one of Atari's employees - Allan Alcorn, once it was finished, Nolan made few adjustments in order to make the game more interesting (like changing the ball's return angle) and added simple sound effects. The first Pong Arcade machine was installed on a local bar, and it was so successful that Atari decided to produce and sell the game by themselves, rather then licensing it to other companies. In 1973 the company finally got a line of credit from Wells Fargo and started an assembly line, by the end of the year, Pong arcade machines were shipped to location all over the U.S. as well as to other countries.\r\nSimilar to other famous games such as Pacman and Tetris, Pong became one of the symbols of computer gaming.\r\n\r\nAtari sold more then 35000 Pong machines, this figure is only about one third of the total number of Pong machines that were sold globally, since many Pong clones appeared shortly after the debut of the original Atari Pong game. The way Atari chose to compete with the Pong Game clones was to produce more innovative games such as \"Double Pong\" which was a pong game with four players, two in every side and a bigger screen.\r\n\r\n ");
            Console.WriteLine(" =======================================================================================================================  ");
            Console.WriteLine("Press (G) to go back to menu");
            inuman = Console.ReadLine();

            while (inuman == "G") ;
            Menu();

            Thread.Sleep(1000000000);
        }
    }
}