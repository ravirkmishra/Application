using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorApplication
{
    public class MovementAndPositionTracker: IMovementAndPosTracker
    {
        private int currentPos;
        private Dictionary<int, int> CurrentReqQ;
        private Dictionary<int, int> PostReqQ;
        public int currentPosition
        {
            get
            {
                return currentPos;
            }

            set
            {
                currentPos = value;
            }
        }

        public Dictionary<int, int> CurrentRequestQueue
        {
            get
            {
                return CurrentReqQ;
            }

            set
            {
                CurrentReqQ = value;
            }
        }

        public Dictionary<int, int> postRequestQueue
        {
            get
            {
                return PostReqQ;
            }

            set
            {
                PostReqQ = value;
            }
        }
    }
}