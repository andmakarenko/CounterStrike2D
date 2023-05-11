using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


interface IMovable
{
    void Move();
}


class Player : IMovable
{ 

    public int X;
    public int Y;

    public Player()
    {
        X = 3;
        Y = 3;
    }

    public Player(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void ShowIcon()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write('@');
        Console.ForegroundColor = ConsoleColor.Black;
    }

    public void Move()
    {

        ConsoleKey key;
        while (true)
        {
            while (Console.KeyAvailable) // reading key and moving the player in corresponding direcion
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.W)
                {
                    if (Level.IsWalkable(X, Y - 1))
                        Y--;
                }
                else if (key == ConsoleKey.A)
                {
                    if (Level.IsWalkable(X - 1, Y))
                        X--;
                }
                else if (key == ConsoleKey.S)
                {
                    if (Level.IsWalkable(X, Y + 1))
                        Y++;
                }
                else if (key == ConsoleKey.D)
                {
                    if (Level.IsWalkable(X + 1, Y))
                        X++;
                }
            }
        }
    }
    
}

    
