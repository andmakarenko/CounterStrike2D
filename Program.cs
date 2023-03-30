using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CounterStrike2D
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetWindowSize(150, 28);
            Console.Title = "Counter Strike 2D";
            
            
            Level level = new Level();
            level.Play();


            Console.Read();

        }
    }
}
