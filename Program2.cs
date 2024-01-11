using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG3
{

    internal class Program2
    {

        private static void test()
        {
            switch (Program.CheckValidInput(0, 0)) 
            {
                case 0:
                    Program.StartMenu();
                    break;
            }
        }

    }
}
