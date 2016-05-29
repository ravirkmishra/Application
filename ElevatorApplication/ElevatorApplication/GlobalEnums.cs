using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorApplication
{
    public class GlobalEnums
    {
        public static string defaulFloor = " Floor";
        public static string defaulTime = "5";
        public static string Seconds = " Seconds";

        public enum Floor
        {
            FirstFloor=1,
            SecondFloor,
            ThirdFloor,
            FourthFloor,
            FifthFloor
        };
        public enum Time
        {
            defaultTime
        };
        public enum timeunit
        {
            unitInSeconds = 3000
        };
       
    }
}