using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Written by Shawn Stark, fall 2009 */

namespace Chap5.a1_colors
{
    class addColor
    {
        static void Main(string[] args)
        {
            myColor c1 = new myColor("red");
            myColor c2 = new myColor("green");
            myColor c3 = new myColor("blue");
			
			Console.ForegroundColor = (c1 & c2).theColor;

            Console.WriteLine("red & green");

            Console.ForegroundColor = ((c1 & c2) & c3).theColor;

            Console.WriteLine("red & green & blue");
			
			Console.ForegroundColor = (c1 & c3).theColor;

            Console.WriteLine("red & blue");
			
			Console.ForegroundColor = (c2 & c3).theColor;

            Console.WriteLine("green & blue");
			
			myColor holdCol = new myColor();
			holdCol = (c1 & c2); 
			
			Console.ForegroundColor = ((c3) & (c1 & c2)).theColor;

            Console.WriteLine("demonstrate a logical miscalculation \n blue & red & green");
			
			Console.ForegroundColor = ((c1 & c2) & c3).theColor;
			
			Console.WriteLine("typeof Operator used on color struct:  "+typeof(myColor));
			
			Console.WriteLine("sizeof Operator used on double:  "+sizeof(double));
			Console.WriteLine("sizeof Operator used on char:  "+sizeof(char));
			Console.WriteLine("sizeof Operator used on int:  "+sizeof(int));
			Console.WriteLine("sizeof Operator used on long:  "+sizeof(long));
			Console.WriteLine("sizeof Operator used on float:  "+sizeof(float));
			Console.WriteLine("sizeof Operator used on byte:  "+sizeof(byte));
        }

        public struct myColor
        {
            public ConsoleColor theColor;
            public myColor(string color)
            {
                theColor = new System.ConsoleColor();
                if (color == "red")
                    theColor = System.ConsoleColor.Red;
                if (color == "green")
                    theColor = System.ConsoleColor.Green;
                if (color == "blue")
                    theColor = System.ConsoleColor.Blue;

            }
            public static myColor operator &(myColor c1, myColor c2)
            {
                myColor result = new myColor("blue");
                //All combinations that equal white
                if (c1.theColor == ConsoleColor.Magenta && c2.theColor == ConsoleColor.Green || c2.theColor == ConsoleColor.Magenta && c1.theColor == ConsoleColor.Green || c1.theColor == ConsoleColor.Yellow && c2.theColor == ConsoleColor.Blue)
                {
                    result.theColor = System.ConsoleColor.White;
                }
                //All combinations that equal yellow
                else if (c1.theColor == ConsoleColor.Red && c2.theColor == ConsoleColor.Green || c2.theColor == ConsoleColor.Red && c1.theColor == ConsoleColor.Green)
                {
                    result.theColor = ConsoleColor.Yellow;
                }
                //All combinations that equal green
                else if (c1.theColor == ConsoleColor.Blue && c2.theColor == ConsoleColor.Yellow || c1.theColor == ConsoleColor.Blue && c2.theColor == ConsoleColor.Yellow)
                {
                    result.theColor = ConsoleColor.Green;
                }

                //All combinations that equal magenta  aka purple
                else if (c1.theColor == ConsoleColor.Blue && c2.theColor == ConsoleColor.Red || c2.theColor == ConsoleColor.Blue && c1.theColor == ConsoleColor.Red)
                {
                    result.theColor = ConsoleColor.Magenta;
                }
                //All other combinations equal gray
                else
                {
                    result.theColor = ConsoleColor.Gray;
                }

                return result;

            }
        }
	}
}