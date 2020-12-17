using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsApp
{
    class _02_Program
    {
        static void Main(string[] args)
        {
            _02_Program_UI ui = new _02_Program_UI();   // know that the Program is the source and the ui is the container name, which is lowercase
            ui.Run();                                       // The Run method will not work until it is initalized in the program ui class

        }
    }
}
