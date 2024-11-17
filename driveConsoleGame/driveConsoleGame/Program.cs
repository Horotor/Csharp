using System;
using System.Threading;

namespace labyrinth_game
{
    internal class Program
    {
        class Car
        {
            Map map = new Map();
            public int X { get; set; }
            public int Y { get; set; }

            char[,] car =
            {
                {' ', ' ', ' ', '_', '_', ' ', ' ', ' '},
                {' ', ' ', '|', ' ', ' ', '|', ' ', ' '},
                {' ', '-', '-', '_', '_', '-', '-', ' '},
                {'|', '_', 'O', '_', '_', 'O', '_', '|'}
            };

            public void Clear()
            {
                for (int i = 0; i < car.GetLength(0); i++)
                {
                    Console.SetCursorPosition(Y, X + i);
                    for (int j = 0; j < car.GetLength(1); j++)
                    {
                        Console.Write(' ');
                    }
                }
            }

            public void Print()
            {
                for (int i = 0; i < car.GetLength(0); i++)
                {
                    Console.SetCursorPosition(Y, X + i);
                    for (int j = 0; j < car.GetLength(1); j++)
                    {
                        Console.Write(car[i, j]);
                    }
                }
            }
            public void Drive(Map map, ref int UserX, ref int UserY)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map.GetCell(UserX - 1, UserY) != '-')
                        {
                            UserX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map.GetCell(UserX + 1, UserY) != '-')
                        {
                            UserX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map.GetCell(UserX, UserY - 1) != '-')
                        {
                            UserY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map.GetCell(UserX, UserY + 1) != '-')
                        {
                            UserY++;
                        }
                        break;
                }

                X = UserX;
                Y = UserY;
            }
        }

        class Map
        {
            private Random random = new Random();
            private char[,] map =
            {
                {'_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_'},
            };

            private bool[,] obstacles;

            public Map()
            {
                obstacles = new bool[map.GetLength(0), map.GetLength(1)];
            }

            public char GetCell(int x, int y)
            {
                if (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
                {
                    return map[x, y];
                }
                return ' ';
            }

            public void PrintMap()
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            public bool CheckCollision(int x, int y)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (x + i < map.GetLength(0) && y + j < map.GetLength(1) && obstacles[x + i, y + j])
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public void PlaceObstacles()
            {
                for (int i = 1; i < obstacles.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < obstacles.GetLength(1) - 1; j++)
                    {
                        obstacles[i, j] = obstacles[i, j + 1];
                    }
                }

                for (int i = 1; i < obstacles.GetLength(0) - 1; i++)
                {
                    obstacles[i, obstacles.GetLength(1) - 2] = random.Next(0, 200) < 2;
                }
            }

            public void PrintObstacles()
            {
                for (int i = 1; i < obstacles.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < obstacles.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(obstacles[i, j] ? 'X' : map[i, j]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Car car = new Car();
            Map map = new Map();
            Console.CursorVisible = false;
            int score = 0;
            int userX = 4, userY = 4;
            car.X = userX;
            car.Y = userY;

            map.PrintMap();

            while (true)
            {
                score++;
                if (Console.KeyAvailable)
                {
                    car.Drive(map, ref userX, ref userY);
                }

                map.PlaceObstacles();

                if (map.CheckCollision(userX, userY))
                {
                    Console.Clear();
                    Console.WriteLine("Игра закончена! Вы врезались в препятствие. Ваш счёт: " + score);
                    break;
                }

                map.PrintObstacles();
                car.Print();
                Console.SetCursorPosition(27, 18);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Счёт: " + score);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
            }
        }
    }
}
