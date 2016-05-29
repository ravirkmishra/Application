using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorApplication
{
    public class MovementAndPositionTracker : IMovementAndPosTracker
    {
        private int currentPos;
        private Dictionary<int, int> CurrentReqQ;
        private Dictionary<int, int> PostReqQ;
        private int destinationfloor;

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
        public int destinationFloor
        {
            get
            {
                return destinationfloor;
            }

            set
            {
                destinationfloor = value;
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
        public int GetTimeMultiplier(int destinationfloor, int currentPosition)
        {
            if (destinationfloor - currentPosition > 0)
            {
                return destinationfloor - currentPosition;
            }
            else
            {
                return currentPosition - destinationfloor;
            }

        }
        public string CheckFloorPosition(ref int currentPosition, int req, int timeremaining,ref int requestCompleted)
        {
            int timebreaks = req - currentPosition;
            if (timebreaks < 0)
            {
                timebreaks = -timebreaks;
            }
           
            int descTime = timebreaks * (int.Parse(GlobalEnums.defaulTime)); // 5*4 = 20 

            if (descTime - timeremaining < 5)
            {
                return currentPosition.ToString() + "-" + (currentPosition + 1) + " Floor";
            }
            if (descTime - timeremaining == 5)
            {
                currentPosition += 1;
                requestCompleted += 1;
                return (currentPosition).ToString() + " Floor";
            }


            if ((descTime - timeremaining) < (5 * (requestCompleted + 1)) && (descTime - timeremaining) > (5 * (requestCompleted)))
            {
                return currentPosition.ToString() + "-" + (currentPosition + 1).ToString() + " Floor";
            }
            if (descTime - timeremaining == 5 * (requestCompleted + 1))
            {
                currentPosition += 1;
                requestCompleted += 1;
                return (currentPosition).ToString() + " Floor";
            }

            else
            {
                return "";
            }
           
        }
        public string CheckDirction(int calledFrom, int CurrentPosition)
        {
            if (calledFrom > CurrentPosition)
            {
                return "Up";
            }
            else
            {
                return "Down";
            }
        }
    }
}
