using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class NumberFinder
    {

        public static void FindNumber(int number, int low, int high, string indentAmt)
        {

            var mid = (low + high) / 2;
            Debug.Print(indentAmt);
            Debug.Print(mid.ToString());

            if (number == mid)
            {
                Debug.Print(" a");
            }
            else
            {
                if (number < mid)
                {
                    Debug.Print(" b");
                    FindNumber(number, low, mid, indentAmt + " ");
                }
                else
                {
                    Debug.Print(" c");
                    FindNumber(number, mid + 1, high, indentAmt + " ");
                }
            }

            Debug.Print("d");

        }




    }
}
