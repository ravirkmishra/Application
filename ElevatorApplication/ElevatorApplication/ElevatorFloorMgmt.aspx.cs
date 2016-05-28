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

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                SetFloorPosition();
                SetTime();
            }
        }

        private void SetTime()
        {
            lblTimeTaken.Text = GlobalEnums.defaulTime;
        }

        private void SetFloorPosition()
        {
            lblFloorPosition.Text = ((int)GlobalEnums.Floor.FirstFloor).ToString() + GlobalEnums.defaulFloor;
            trInsideButton.Visible = false;

            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.currentPosition = 0;
            //tdDown.Visible = false;
        }

        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            lblTimeTaken.Text = "Processing completed";
        }

        private int DetectButtonClicked(string btnId)
        {
            int floorPressed = 1;
            btnId = "";
            switch (btnId)
            {
                case "imgbtn1stFloor":
                    floorPressed = 1;
                    break;
                case "imgbtn2ndFloor":
                    floorPressed = 2;
                    break;
                case "imgbtn3rdFloor":
                    floorPressed = 3;
                    break;
                case "imgbtn4thFloor":
                    floorPressed = 4;
                    break;
                case "imgbtn5thFloor":
                    floorPressed = 5;
                    break;
                default:
                    break;
            }
            return floorPressed;
        }

        protected void imgbtnDownArrow4_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(4, 0);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnUpArrow3_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(3, 1);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnDownArrow3_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(3, 0);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnUpArrow2_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(2, 1);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnDownArrow2_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(2, 0);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnUpArrow1_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(1, 1);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnDownArrow1_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(1, 0);
            imgbtnDownArrow4.Enabled = false;
        }

        protected void imgbtnUpArrow0_Click(object sender, ImageClickEventArgs e)
        {
            MovementAndPositionTracker obj = new MovementAndPositionTracker();
            obj.CurrentRequestQueue.Add(0, 1);
            imgbtnDownArrow4.Enabled = false;
        }

    }
}