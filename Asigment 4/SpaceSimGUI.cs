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
                Console.WriteLine(obj.Name);
            }
            formGraphics.Dispose();
        }

        // Draws a parsed space object
        //TODO maybe parse type instead of the whole object?
        private void DrawSpaceObject(System.Drawing.Graphics formGraphics, SpaceSim.SpaceObject drawObject)
        {
            int centerX = GetAbsoluteX(drawObject);
            int centerY = GetAbsoluteY(drawObject);
            double objRadius = drawObject.logObjectRadius;

            //Create and select apropriat brush
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
            // else if(drawObject is SpaceSim.Moon){myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);}

            //Rectangle(X,y,width,height)
            Rectangle rect = new Rectangle((int)(centerX - objRadius / 2), (int)(centerY - objRadius / 2), (int)objRadius, (int)objRadius);
            //Draw a circle in specified rectangle
            formGraphics.FillEllipse(myBrush, rect);

            myBrush.Dispose();

            /* _thePanel.Location = new Point(this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
             * this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
             * _thePanel.Anchor = AnchorStyles.None;
             */
        }

        // Finds objects on screen x position
        public int GetAbsoluteX(SpaceSim.SpaceObject obj)
        {
            if(obj is SpaceSim.Star)
            { // if object is star: return center of drawing space
                return DisplayPanel.Width / 2;
            }
            else
            { //Otherwise get the position of the parrent object and ad it to it's own. 
                return GetAbsoluteX(obj.Orbits) + (int)obj.xPos;
            }
        }

        // Finds objects on screen y position
        public int GetAbsoluteY(SpaceSim.SpaceObject obj)
        {
            if (obj is SpaceSim.Star)
            {// if object is star: return center of drawing space
                return DisplayPanel.Height / 2;
            }
            else
            {//Otherwise get the position of the parrent object and ad it to it's own. 
                return GetAbsoluteY(obj.Orbits) + (int)obj.yPos;
            }
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
