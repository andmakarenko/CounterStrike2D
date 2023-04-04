using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

interface IShootable
{
    void Fire();
}


class SRifle : IShootable
{
    readonly int damage;
    readonly int range;

    public SRifle()
    {
        damage = 200;
        range = 150;
    }

    public void Fire()
    {
        
    }
}

class AR : IShootable
{
    readonly int damage;
    readonly int range;

    public AR()
    {
        damage = 40;
        range = 65;
    }

    public void Fire()
    {
        
    }
}

class Pistol : IShootable
{
    readonly int damage;
    readonly int range;

    public Pistol()
    {
        damage = 25;
        range = 15;
    }

    public void Fire()
    {
        
    }
}

