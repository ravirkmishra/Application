using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ElevatorApplication
{
    interface IMovementAndPosTracker
    {
        int currentPosition { get; set; }
        Dictionary<int, int> CurrentRequestQueue { get; set; }
        Dictionary<int, int> postRequestQueue { get; set; }
        int destinationFloor { get; set; }
    }
}
