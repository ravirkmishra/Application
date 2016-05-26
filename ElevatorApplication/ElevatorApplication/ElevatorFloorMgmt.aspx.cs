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
            tdDown.Visible = false;
        }

        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            lblTimeTaken.Text = "Processing completed";
        }

        protected void imgbtnUpArrow_Click(object sender, ImageClickEventArgs e)
        {
            trInsideButton.Visible = true;
            tdDown.Visible = false;
            tdUp.Visible = false;
        }

        protected void imgbtn1stFloor_Click(object sender, ImageClickEventArgs e)
        {
            imgbtn1stFloor.Enabled = false;
            string btnId = imgbtn1stFloor.ID.ToString();
            int floorPressed = 1;
            floorPressed = DetectButtonClicked(btnId);
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

        protected void imgbtn2ndFloor_Click(object sender, ImageClickEventArgs e)
        {
            imgbtn2ndFloor.Enabled = false;
            string btnId = imgbtn2ndFloor.ID.ToString();
            int floorPressed = 1;
            floorPressed = DetectButtonClicked(btnId);
        }

        protected void imgbtn3rdFloor_Click(object sender, ImageClickEventArgs e)
        {
            imgbtn3rdFloor.Enabled = false;
            string btnId = imgbtn3rdFloor.ID.ToString();
            int floorPressed = 1;
            floorPressed = DetectButtonClicked(btnId);
        }

        protected void imgbtn4thFloor_Click(object sender, ImageClickEventArgs e)
        {
            imgbtn4thFloor.Enabled = false;
            string btnId = imgbtn4thFloor.ID.ToString();
            int floorPressed = 1;
            floorPressed = DetectButtonClicked(btnId);
        }

        protected void imgbtn5thFloor_Click(object sender, ImageClickEventArgs e)
        {
            imgbtn5thFloor.Enabled = false;
            string btnId = imgbtn5thFloor.ID.ToString();
            int floorPressed = 1;
            floorPressed = DetectButtonClicked(btnId);
        }

    }
}