using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

class Player
{ 

    public int X;
    public int Y;

    Weapon weapon;

    public Player()
    {
        X = 2;
        Y = 2;
    }

    public Player(int choice)
    {
        X = 2;
        Y = 2;

        switch(choice)
        {
            case 1:
                weapon = new USP();
                break;
            case 2:
                weapon = new M4A1();
                break;
            case 3:
                weapon = new AWP();
                break;
            default:
                Console.WriteLine("Wrong weapon index.");
                weapon = new Weapon();
                break;
        }
    }

    public void Walk(ConsoleKey key)
    {
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

    public void Shoot()
    {

    }

    //public bool EnemyVisible()
    //{
    //    foreach ()
    //}
    //
    //private bool Find(Enemy enemy)
    //{
    //    for (int y = Y, x = X;)
    //
    //
    //
    //    return false;
    //}
}

    
