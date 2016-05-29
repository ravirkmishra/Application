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
            }
        }

        private void SetTime(int timeMultiplier)
        {
            if (!MainScriptManager.IsInAsyncPostBack)
            {
                Session["timeout"] = DateTime.Now.AddSeconds(int.Parse(GlobalEnums.defaulTime) * timeMultiplier).ToString();
            }

        }

        private int GetSetFloorPosition()
        {
            lblFloorPosition.Text = ((int)GlobalEnums.Floor.FirstFloor).ToString() + GlobalEnums.defaulFloor;
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
                    lblFloorPosition.Text = obj.CheckFloorPosition(ref currentPosition, (int)Session["RequestFrom"], timerunning1,ref requestCompleted);
                    Session["CurrentPosition"] = currentPosition;
                    Session["requestCompleted"] = requestCompleted;
                }
                else if(myDictionary.Count > 1)
                {
                    //get all collection for more than currentposition
                    var preRequestQ = myDictionary.Where(s => s.Key > (int)Session["InitialPosition"]);
                   
                    // 0- Down and 1- Up
                    int directionofMovement = (int)Session["Directon"];

                    //get max floor value
                    int maxfloorrequest  = Convert.ToInt32(myDictionary.OrderByDescending(s => s.Key).First().Key);

                    // for Up movement 
                    if (directionofMovement == 1)
                    {
                        int timerunning2 = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds);
                        lblFloorPosition.Text = obj.CheckFloorPosition(ref currentPosition, (int)Session["RequestFrom"], timerunning2, ref requestCompleted);
                        Session["CurrentPosition"] = currentPosition;
                        Session["requestCompleted"] = requestCompleted;
                       
                        if (Session["CurrentPosition"].ToString() == Session["RequestFrom"].ToString())
                        {
                            //Stop timer at RequestFrom floor - i.e. first request
                            trInsideButton.Visible = true;
                           
                           
                            //Now take the Input for floor to go
                            //Start the timer hare again
                        }
                        else
                        {
                            foreach (KeyValuePair<int,int> item in preRequestQ)
                            {
                                if ((int)Session["CurrentPosition"] == item.Key)
                                {
                                  
                                    trInsideButton.Visible = true;
                                }
                            }
                        }
                    }
                    //for Down movement
                    else if(directionofMovement == 0)
                    {

                    }
                    

                    int timerunning1 = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds);
                    lblFloorPosition.Text = obj.CheckFloorPosition(ref currentPosition, (int)Session["RequestFrom"], timerunning1, ref requestCompleted);
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
        }

        private void SetDirectionAndCalling(int calledFirst)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();

            Session["InitialDirection"] = obj.CheckDirction(calledFirst, (int)Session["CurrentPosition"]);
            Session["Directon"] = (Session["InitialDirection"]).ToString() == "Up" ? 1 : 0; 
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
        }

        #region Taking Input Section
        protected void imgbtn1stFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor1stfloor = new Dictionary<int, int>();
            reqFor1stfloor.Add(1, 0);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn1stFloor);
            SetPreviousTime(previousTime, imgbtn1stFloor);
            
        }

        protected void imgbtn2ndFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor1stfloor = new Dictionary<int, int>();
            reqFor1stfloor.Add(2, 0);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn2ndFloor);
            SetPreviousTime(previousTime, imgbtn2ndFloor);
           
        }

        protected void imgbtn3rdFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor1stfloor = new Dictionary<int, int>();
            reqFor1stfloor.Add(3, 0);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn3rdFloor);
            SetPreviousTime(previousTime, imgbtn3rdFloor);
            
        }

        protected void imgbtn4thFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor1stfloor = new Dictionary<int, int>();
            reqFor1stfloor.Add(4, 0);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn4thFloor);
            SetPreviousTime(previousTime, imgbtn4thFloor);
           
        }

        protected void imgbtn5thFloor_Click(object sender, ImageClickEventArgs e)
        {
            timer1.Enabled = false;
            Dictionary<int, int> reqFor1stfloor = new Dictionary<int, int>();
            reqFor1stfloor.Add(5, 0);
            int previousTime = int.Parse(lblTimeTaken.Text.Remove(2, 8));
            MainScriptManager.RegisterAsyncPostBackControl(imgbtn5thFloor);
            SetPreviousTime(previousTime, imgbtn5thFloor);
           
        }

        #endregion

        
    }
}