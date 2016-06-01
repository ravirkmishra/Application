using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElevatorApplication;


namespace ElevatorApplication
{
    public partial class ElevatorFloorMgmt : System.Web.UI.Page
    {
        //static int requestCompleted = 0;
        //static int currentposition = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                MovementAndPositionTracker obj = new MovementAndPositionTracker();
                obj.currentPosition = GetSetFloorPosition();
                obj.destinationFloor = 0;
            }

            //Mapping Number of second required to the called floor

            if (!MainScriptManager.IsInAsyncPostBack)
            {
                SetTime(0);
                if (Session["CurrentPosition"] !=null && Session["RequestFrom"] != null)
                {
                    if (Session["CurrentPosition"].ToString() == Session["RequestFrom"].ToString())
                    {
                        AddSecondsOnReachingDestination();
                    }
                }
               
               
            }
        }

        private void AddSecondsOnReachingDestination()
        {
            if (!MainScriptManager.IsInAsyncPostBack)
            {
                Session["timeout"] = DateTime.Now.AddSeconds(int.Parse(GlobalEnums.defaulTime) + 3).ToString();
                trInsideButton.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void SetTime(int timeMultiplier)
        {
            if (!MainScriptManager.IsInAsyncPostBack)
            {
                Session["timeout"] = DateTime.Now.AddSeconds(int.Parse(GlobalEnums.defaulTime) * timeMultiplier+2).ToString();
            }

        }

        private int GetSetFloorPosition()
        {
            lblFloorPosition.Text = ((int)GlobalEnums.Floor.ZerothFloor).ToString() + GlobalEnums.defaulFloor;
            trInsideButton.Visible = false;

            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.currentPosition = 0;
            Session["CurrentPosition"] = obj.currentPosition;
            Session["InitialPosition"] = 0;
            Session["requestCompleted"] = 0;
            return obj.currentPosition;
            //tdDown.Visible = false;
        }

        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            lblTimeTaken.Text = "Processing completed";
        }


        //0 -down , 1- Up
        protected void imgbtnDownArrow4_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(4, 0, previousTime, imgbtnDownArrow4);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnUpArrow3_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(3, 1, previousTime, imgbtnUpArrow3);
            imgbtnUpArrow3.Enabled = false;
        }

        protected void imgbtnDownArrow3_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(3, 0, previousTime, imgbtnDownArrow3);
            imgbtnDownArrow3.Enabled = false;
        }

        protected void imgbtnUpArrow2_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(2, 1, previousTime, imgbtnUpArrow2);
            imgbtnUpArrow2.Enabled = false;
        }

        protected void imgbtnDownArrow2_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(2, 0, previousTime, imgbtnDownArrow2);
            imgbtnDownArrow2.Enabled = false;
        }

        protected void imgbtnUpArrow1_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(1, 1, previousTime, imgbtnUpArrow1);
            imgbtnUpArrow1.Enabled = false;
        }

        protected void imgbtnDownArrow1_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(1, 0, previousTime, imgbtnDownArrow1);
            imgbtnDownArrow1.Enabled = false;
        }

        protected void imgbtnUpArrow0_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            //System.Threading.Thread.Sleep(2000);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            DoWork(0, 1, previousTime, imgbtnUpArrow0);
            imgbtnUpArrow0.Enabled = false;
        }
        protected void timer1_tick(object sender, EventArgs e)
        {
            if (0 > DateTime.Compare(DateTime.Now, DateTime.Parse(Session["timeout"].ToString())))
            {
                int timerunning = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds);
                MovementAndPositionTracker obj = new MovementAndPositionTracker();
                Dictionary<int, int> myDictionary = (Dictionary<int, int>)Session["CurrentReqQ"];

                Session["RequestFrom"] = myDictionary.ElementAt(0).Key;
                int currentPosition = (int)Session["CurrentPosition"];
                int requestCompleted = (int)Session["requestCompleted"];
                //Setting the Floor Position Dynamically while Moving
                //we have to stop in middle if there are other request while going on the way
                

                if (myDictionary.Count == 1)
                {
                    int timerunning1 = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds);
                    lblFloorPosition.Text = obj.CheckFloorPosition(ref currentPosition, (int)Session["RequestFrom"], timerunning1, ref requestCompleted);
                    Session["CurrentPosition"] = currentPosition;
                    Session["requestCompleted"] = requestCompleted;

                    if ((int)Session["CurrentPosition"] == (int)Session["RequestFrom"])
                    {
                        //trInsideButton.Visible = true;
                        if (Session["LastFloorPosition"] == null)
                        {
                            trInsideButton.Visible = true;
                        }

                        if (Session["LastFloorPosition"] != null)
                        {
                            int localCurrentpos = Convert.ToInt32(Session["CurrentPosition"]);
                            int localLastpos = Convert.ToInt32(Session["LastFloorPosition"]);
                            if (localCurrentpos > localLastpos)
                            {
                                trInsideButton.Visible = false;
                                Session.Remove("LastFloorPosition");
                            }
                        }

                        if (trInsideButton.Visible == true)
                        {
                            timer1.Enabled = false;
                        }
                    }
                    else
                    {
                        trInsideButton.Visible = false;
                    }

                   
                }
                else if (myDictionary.Count > 1)
                {
                    //get all collection for more than currentposition
                    var preRequestQ = myDictionary.Where(s => s.Key > (int)Session["InitialPosition"]);

                    // 0- Down and 1- Up
                    int directionofMovement = (int)Session["Direction"];

                    //get max floor value
                    int maxfloorrequest = Convert.ToInt32(myDictionary.OrderByDescending(s => s.Key).First().Key);

                    // for Up movement 
                    if (directionofMovement == 1)
                    {
                        if ((int)Session["CurrentPosition"] == (int)Session["RequestFrom"])
                        {
                           
                            if (Session["LastFloorPosition"] == null)
                            {
                                trInsideButton.Visible = true;
                            }

                            if (Session["LastFloorPosition"] != null)
                            {
                                int localCurrentpos = Convert.ToInt32(Session["CurrentPosition"]);
                                int localLastpos = Convert.ToInt32(Session["LastFloorPosition"]);
                                if (localCurrentpos > localLastpos)
                                {
                                    trInsideButton.Visible = false;
                                    Session.Remove("LastFloorPosition");
                                }
                            }

                            if (trInsideButton.Visible == true)
                            {
                                timer1.Enabled = false;
                            }

                            //Now take the Input for floor to go
                            //Start the timer hare again
                        }
                        else
                        {
                            foreach (KeyValuePair<int, int> item in preRequestQ)
                            {
                                if ((int)Session["CurrentPosition"] == item.Key)
                                {
                                    if (Session["LastFloorPosition"] == null)
                                    {
                                        trInsideButton.Visible = true;
                                    }

                                    if (Session["LastFloorPosition"] != null)
                                    {
                                        int localCurrentpos = Convert.ToInt32(Session["CurrentPosition"]);
                                        int localLastpos = Convert.ToInt32(Session["LastFloorPosition"]);
                                        if (localCurrentpos > localLastpos)
                                        {
                                            trInsideButton.Visible = false;
                                            Session.Remove("LastFloorPosition");
                                        }
                                    }

                                    if (trInsideButton.Visible == true)
                                    {
                                        timer1.Enabled = false;
                                    }
                                }
                            }
                        }
                        int timerunning2 = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds);
                        lblFloorPosition.Text = obj.CheckFloorPosition(ref currentPosition, (int)Session["RequestFrom"], timerunning2, ref requestCompleted);
                        Session["CurrentPosition"] = currentPosition;
                        Session["requestCompleted"] = requestCompleted;
                    }
                    //for Down movement
                    else if (directionofMovement == 0)
                    {

                    }

                }

                if (timerunning < 10)
                {
                    lblTimeTaken.Text = "0" + timerunning.ToString() + " Seconds";
                }
                else
                {
                    lblTimeTaken.Text = timerunning.ToString() + " Seconds";
                }

            }
            else
            {
                lblTimeTaken.Text = "00 " + "Seconds";
            }
        }
        public void DoWork(int floorNo, int directiondesired, int previousTime, Control ctrl)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            Dictionary<int, int> requestQ = new Dictionary<int, int>();
            requestQ.Add(floorNo, directiondesired);
            obj.destinationFloor = floorNo;

            Session["PostReqQ"] = null;


            if (Session["CurrentReqQ"] != null)
            {
                Dictionary<int, int> myDictionary = (Dictionary<int, int>)Session["CurrentReqQ"];
                obj.CurrentRequestQueue = myDictionary;
                obj.CurrentRequestQueue.Add(floorNo, directiondesired);
                Session["CurrentReqQ"] = obj.CurrentRequestQueue;
            }
            else
            {
                obj.CurrentRequestQueue = requestQ;
                Session["CurrentReqQ"] = obj.CurrentRequestQueue;
            }

            if (obj.CurrentRequestQueue.Count > 1)
            {
                SetPreviousTime(previousTime, ctrl);
            }
            else
            {
                int timeMultiplier = obj.GetTimeMultiplier(obj.destinationFloor, obj.currentPosition);
                SetTime(timeMultiplier);
                timer1.Enabled = true;
            }

            MainScriptManager.RegisterAsyncPostBackControl(ctrl);

            Session["CalledFirst"] = obj.CurrentRequestQueue.ElementAt(0).Key;
            SetDirectionAndCalling((int)Session["CalledFirst"]);
            Session["InputTaken"] = false;
        }

        private void SetDirectionAndCalling(int calledFirst)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();

            Session["InitialDirection"] = obj.CheckDirection(calledFirst, (int)Session["CurrentPosition"]);
            Session["Direction"] = (Session["InitialDirection"]).ToString() == "Up" ? 1 : 0;
            lblCalledFrom.Text = (Session["CalledFirst"]).ToString() + " Floor";
            lblDirection.Text = (string)Session["InitialDirection"];
        }

        public void SetPreviousTime(int previousTime, Control ctrl)
        {
            System.Threading.Thread.Sleep(2000);

            if (!MainScriptManager.IsInAsyncPostBack)
            {
                Session["timeout"] = DateTime.Now.AddSeconds(previousTime + 2).ToString();
                timer1.Enabled = true;
            }
            if (trInsideButton.Visible == true)
            {
                Session["timeout"] = DateTime.Now.AddSeconds(previousTime + 3).ToString();
                trInsideButton.Visible = false;
                Session["InputTaken"] = true;
                timer1.Enabled = true;
            }
        }

        public void ResetCurrentPositionAndRequestCompleted(int reqCompleted)
        {
            switch (reqCompleted)
            {
                case 0:
                    Session["requestCompleted"] = Session["requestCompleted"];
                    Session["CurrentPosition"] = Session["CurrentPosition"];
                    break;
                case 1:
                    Session["requestCompleted"] = (int)Session["requestCompleted"] - 1;
                    Session["CurrentPosition"] = (int)Session["CurrentPosition"] - 1;
                    break;
                case 2:
                    Session["requestCompleted"] = (int)Session["requestCompleted"] - 2;
                    Session["CurrentPosition"] = (int)Session["CurrentPosition"] - 2;
                    break;
                case 3:
                    Session["requestCompleted"] = (int)Session["requestCompleted"] - 3;
                    Session["CurrentPosition"] = (int)Session["CurrentPosition"] - 3;
                    break;
                case 4:
                    Session["requestCompleted"] = (int)Session["requestCompleted"] - 4;
                    Session["CurrentPosition"] = (int)Session["CurrentPosition"] - 4;
                    break;

            }

        }

        #region Taking Input Section
        protected void imgbtn0thFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor0thfloor = new Dictionary<int, int>();
            reqFor0thfloor.Add(0, 1);
            Session["LastFloorPosition"] = (int)Session["CurrentPosition"];
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            SetPreviousTime(previousTime, imgbtn0thFloor);
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn0thFloor);
            AddCurrentUpRequests(reqFor0thfloor);
        }



        protected void imgbtn1stFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor1stfloor = new Dictionary<int, int>();
            //Button pressed while going up
            reqFor1stfloor.Add(1, 1);
            int lastposition = (int)Session["CurrentPosition"];
            Session["LastFloorPosition"] = lastposition;
            AddCurrentUpRequests(reqFor1stfloor);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            SetPreviousTime(previousTime, imgbtn1stFloor);
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn1stFloor);

        }

        protected void imgbtn2ndFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor2ndfloor = new Dictionary<int, int>();
            reqFor2ndfloor.Add(2, 1);
            int lastposition = (int)Session["CurrentPosition"];
            Session["LastFloorPosition"] = lastposition;
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            AddCurrentUpRequests(reqFor2ndfloor);
            SetPreviousTime(previousTime, imgbtn2ndFloor);
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn2ndFloor);

        }

        protected void imgbtn3rdFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor3rdfloor = new Dictionary<int, int>();
            reqFor3rdfloor.Add(3, 1);
            int lastposition = (int)Session["CurrentPosition"];
            Session["LastFloorPosition"] = lastposition;
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            AddCurrentUpRequests(reqFor3rdfloor);
            SetPreviousTime(previousTime, imgbtn3rdFloor);
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn3rdFloor);

        }

        protected void imgbtn4thFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor4thfloor = new Dictionary<int, int>();
            reqFor4thfloor.Add(4, 1);
            int lastposition = (int)Session["CurrentPosition"];
            Session["LastFloorPosition"] = lastposition;
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            AddCurrentUpRequests(reqFor4thfloor);
            SetPreviousTime(previousTime, imgbtn4thFloor);
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn4thFloor);

        }

        #endregion
        private void AddCurrentUpRequests(Dictionary<int, int> reqForAnyfloor)
        {
            if (Session["CurrentRequestUp"] != null)
            {
                Dictionary<int, int> temp = new Dictionary<int, int>();
                temp = (Dictionary<int, int>)Session["CurrentRequestUp"];

                if (!temp.Keys.Contains(reqForAnyfloor.Keys.First()))
                {
                    reqForAnyfloor.ToList().ForEach(x => temp.Add(x.Key, x.Value));
                }
               
                Session["CurrentRequestUp"] = temp;
            }
            else
            {
                Session["CurrentRequestUp"] = reqForAnyfloor;
            }
        }
    }
}