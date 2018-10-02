using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jordan_van_Zyl_GADE1B_A1
{
    public partial class Form1 : Form
    {
        // Flag variable and accessor/setting methods to allow for altering the variable
        bool flag;
        public bool Flag { get => flag; set => flag = value; }
        GameEngine ge;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ge = new GameEngine();
            lblMap.Text = ge.updateMap();
            bool flag = false;
            
        }

        // Time counter variable and timer tick method
        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(gameStatus() == true)
            {
                lblMap.Text = ge.updateMap();
                time++;
                lblTime.Text = time.ToString();
                for(int i = 0; i < ge.UnitSize(); i++)
                {
                    cmbUnits.Items.Add(ge.Units(i));
                }
            }
        }

        // Button to start the game
        private void btnStart_Click(object sender, EventArgs e)
        {
            Flag = true;
        }

        // Button to pause the game
        private void btnPause_Click(object sender, EventArgs e)
        {
            Flag = false;
        }

        // Boolean method to return status of the game (paused/unpaused)
        public bool gameStatus()
        {
            bool status = false;
            if(Flag == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return status;
        }

        private void rchUnitInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            rchUnitInfo.Text = cmbUnits.SelectedItem.ToString();
        }
    }
}
