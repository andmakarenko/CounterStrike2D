using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;


class Enemy : IMovable
{
    public int X;
    public int Y;
    readonly Player player;

    public Enemy(Player player)
    {
        X = Level.Map.GetLength(1) - 3;
        Y = 3;
        this.player = player;
    }

    public void ShowIcon()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write('$');
        Console.ForegroundColor = ConsoleColor.Black;
    }

    public void Move() 
    {
        var finder = new ShortestPathFinder(Level.Map);
        List<Tuple<int, int>> path = new List<Tuple<int, int>>();


        while (true)
        {
            Tuple<int, int> Enemy = new Tuple<int, int>(Y, X);
            Tuple<int, int> Player = new Tuple<int, int>(player.Y, player.X);
        
        
            path = finder.FindShortestPath(Enemy, Player);


            foreach (var pathItem in path)
            {
                if (!IsVisible(Level.Map, (Y, X), (player.Y, player.X)))
                {
                    Y += pathItem.Item1 - Y;
                    X += pathItem.Item2 - X;
                    Thread.Sleep(100);
                }
            }
            
        }


        //Random rand = new Random();
        //int x;
        //
        //while (true)
        //{
        //    x = rand.Next(1, 10);
        //    if (x >= 1 && x <= 4)
        //    {
        //        if (Level.IsWalkable(X, Y-1))
        //        {
        //            Y--;
        //        }
        //        Thread.Sleep(200);
        //    }
        //    else if (x == 5)
        //    {
        //        if (Level.IsWalkable(X + 1, Y))
        //        {
        //            X++;
        //        }
        //        Thread.Sleep(200);
        //    }
        //    else if (x == 6)
        //    {
        //        if (Level.IsWalkable(X, Y + 1))
        //        {
        //            Y++;
        //        }
        //        Thread.Sleep(200);
        //    }
        //    else
        //    {
        //        if (Level.IsWalkable(X - 1, Y))
        //        {
        //            X--;
        //        }
        //        Thread.Sleep(200);
        //    }
        //}
    }

    private bool IsVisible(char[,] Map, (int, int) player, (int , int) target)
    {
        var screenWidth = Map.GetLength(1);
        var Fov = Math.PI * 2;
        int playerX = player.Item2;
        int playerY = player.Item1;
        int depth = 28;

        for (int x = 0; x < screenWidth; x++)
        {
            double RayAngle = Fov / 2 - x * Fov / screenWidth;

            double rayX = Math.Sin(RayAngle);
            double rayY = Math.Cos(RayAngle);

            double distanceToWall = 0;
            bool hitWall = false;

            while (!hitWall && distanceToWall < depth)
            {
                distanceToWall += 0.1;

                int testX = (int)(playerX + rayX * distanceToWall);
                int testY = (int)(playerY + rayY * distanceToWall);

                if (testX < 0 || testX >= depth + playerX || testY < 0 || testY >= depth + playerY)
                {
                    hitWall = true;
                    distanceToWall = depth;
                }
                else
                {
                    try
                    {
                        char TestCell = Map[testY, testX];

                        if (TestCell == '#')
                        {
                            hitWall = true;
                        }
                        else if (testY == target.Item1 && testX == target.Item2)
                        {
                            return true;
                        }
                        //Map[testY, testX] = '+';
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
            }
        }
        return false;
    }
}
