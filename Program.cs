using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CounterStrike2D
{
    internal class Program
    { 

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Title = "Counter Strike 2D";

            Level level = new Level();

            Console.SetWindowSize(Level.Map.GetLength(1) + 1, Level.Map.GetLength(0) + 1);
            level.Play();
            

            //Console.Read();

        }
    }
}
