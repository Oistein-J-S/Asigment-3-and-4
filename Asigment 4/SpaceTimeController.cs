using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Asigment_4
{
    public class SpaceTimeController
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();


        //Create timer and subscribe this to an event or delegates.
        public SpaceTimeController() {

            myTimer.Tick += new EventHandler(TimerEventProcessor);

            myTimer.Interval = 5000;
            //myTimer.Start();
        }//END creator


        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //send event to update position here
            //possibly redraw?
        }


        public static void StartAnimation()
        {

        }

    }//END class SpaceTimeController
}//END Assignment_4
