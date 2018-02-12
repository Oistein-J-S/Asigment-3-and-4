using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asignment_3;

namespace Asigment_4
{
    public partial class SolarSim : Form
    {
        Astronomy ast;

        public SolarSim()
        {
            InitializeComponent();
            ast = new Astronomy();
        }

        //Prints objects in cmd
        private void button1_Click(object sender, EventArgs e)
        {
            ast.DrawObjects();
        }

        //Draws objects in window
        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();
            foreach (SpaceSim.SpaceObject obj in ast.SolarSystem)
            {
                DrawSpaceObject(formGraphics, obj);
            }
            formGraphics.Dispose();
        }

        // Draws a parsed space object
        //TODO maybe parse type instead of the whole object?
        private void DrawSpaceObject(System.Drawing.Graphics formGraphics, SpaceSim.SpaceObject drawObject)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            if (drawObject is SpaceSim.Star)
            {
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            }
            else if(drawObject is SpaceSim.Planet)
            {
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            }
            else if(drawObject is SpaceSim.DwarfPlanet)
            {
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
            }
            else if(drawObject is SpaceSim.Moon)
            {
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            }

            int centerX = GetAbsoluteX(drawObject);
            int centerY = GetAbsoluteY(drawObject);
            double objRadius = drawObject.logObjectRadius;

            //Rectangle(X,y,width,height)
            Rectangle rect = new Rectangle((int)(centerX - objRadius / 2), (int)(centerY - objRadius / 2), (int)objRadius, (int)objRadius);
            formGraphics.FillEllipse(myBrush, rect);

            myBrush.Dispose();

            /* 
             * _thePanel.Location = new Point(
    this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
    this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
_thePanel.Anchor = AnchorStyles.None;
             * 
             */
        }

        // Finds window centre x axis
        public int GetAbsoluteX(SpaceSim.SpaceObject obj)
        {
            if(obj is SpaceSim.Star)
            {
                return DisplayPanel.Width / 2;
            }
            else
            {
                return GetAbsoluteX(obj.Orbits) + (int)obj.xPos;
            }
        }

        // Finds window centre y axis
        public int GetAbsoluteY(SpaceSim.SpaceObject obj)
        {
            if (obj is SpaceSim.Star)
            {
                return DisplayPanel.Height / 2;
            }
            else
            {
                return GetAbsoluteY(obj.Orbits) + (int)obj.yPos;
            }
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ast.DrawObjects();
        }

        private void drawSolarSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();
            foreach (SpaceSim.SpaceObject obj in ast.SolarSystem)
            {
                DrawSpaceObject(formGraphics, obj);
            }
            formGraphics.Dispose();
        }

        private void SolarSim_Resize(object sender, EventArgs e)
        {
            //TODO draw out into "drawSystem" method?
            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();
            formGraphics.Clear(System.Drawing.Color.White);
            foreach (SpaceSim.SpaceObject obj in ast.SolarSystem)
            {
                DrawSpaceObject(formGraphics, obj);
            }
            formGraphics.Dispose();
        }
    }
}
