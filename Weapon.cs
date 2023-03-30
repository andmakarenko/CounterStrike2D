using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Weapon
{


    public virtual void fire()
    {
    }
}

class AWP : Weapon
{
    readonly int damage;
    readonly int range;

    public AWP()
    {
        damage = 200;
        range = 150;
    }

    public override void fire()
    {
        //firing logic
    }
}

class M4A1 : Weapon
{
    readonly int damage;
    readonly int range;

    public M4A1()
    {
        damage = 40;
        range = 65;
    }

    public override void fire()
    {
        //firing logic
    }
}

class USP : Weapon
{
    readonly int damage;
    readonly int range;

    public USP()
    {
        damage = 25;
        range = 15;
    }

    public override void fire()
    {
        //firing logic
    }
}

