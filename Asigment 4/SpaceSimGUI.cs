using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceSim;


using Asignment_3;

namespace Asigment_4
{
    public partial class SolarSim : Form
    {
        Astronomy ast;
        private int _ticks;
        private bool started;


        public SolarSim()
        {
            InitializeComponent();
            ast = new Astronomy();
            started = false;
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
                //Console.WriteLine(obj.Name);
            }
            formGraphics.Dispose();
        }

        private void drawOrbit(Graphics formGraphics, SpaceObject drawObject)
        {
            if (drawObject is SpaceSim.Planet || drawObject is SpaceSim.DwarfPlanet)
            {
                float objRadius = (float)drawObject.ModifiedOrbitalRadius;
                float centerX = (float)(DisplayPanel.Width / 2);
                float centerY = (float)(DisplayPanel.Height / 2);
                // Rectangle ellipseRect = new Rectangle((int)(centerX - objRadius), (int)(centerY - objRadius), (int) (centerX + objRadius), (int) (centerY + objRadius));
                Pen p = new Pen(new SolidBrush(Color.Black));
                formGraphics.DrawEllipse(p, (centerX - objRadius), (centerY - objRadius), (objRadius * 2), (objRadius * 2));
            }
            
        }

        private void drawObjectsAndOrbits(Graphics formGraphics, SpaceObject drawObject)
        {
            drawOrbit(formGraphics, drawObject);
            DrawSpaceObject(formGraphics, drawObject);
        }

        private void SolarSim_Resize(object sender, EventArgs e)
        {
            //TODO draw out into "drawSystem" method?
            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();
            formGraphics.Clear(System.Drawing.Color.White);
            foreach (SpaceSim.SpaceObject obj in ast.SolarSystem)
            {
                drawObjectsAndOrbits(formGraphics, obj);
            }
            formGraphics.Dispose();
        }

        // Draws a parsed space object
        //TODO maybe parse type instead of the whole object?
        private void DrawSpaceObject(System.Drawing.Graphics formGraphics, SpaceSim.SpaceObject drawObject)
        {
            int centerX = GetAbsoluteX(drawObject);
            int centerY = GetAbsoluteY(drawObject);
            double objRadius = drawObject.LogObjectRadius;

            //Create and select apropriat brush
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            if (drawObject is SpaceSim.Star)
            {
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            }
            else if (drawObject is SpaceSim.Planet)
            {
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            }
            else if (drawObject is SpaceSim.DwarfPlanet)
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

            System.Drawing.SolidBrush ellipseBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Rectangle ellipse = new Rectangle((int)(centerX - objRadius / 2), (int)(centerY - objRadius / 2), (int)objRadius, (int)objRadius);
            Pen p = new Pen(ellipseBrush);
            formGraphics.DrawEllipse(p, ellipse);
            p.Dispose();
            ellipseBrush.Dispose();
        }



        // Finds objects on screen x position
        public int GetAbsoluteX(SpaceSim.SpaceObject obj)
        {
            if (obj is SpaceSim.Star)
            { // if object is star: return center of drawing space
                return DisplayPanel.Width / 2;
            }
            else
            { //Otherwise get the position of the parrent object and ad it to it's own. 
                return GetAbsoluteX(obj.Orbits) + (int)obj.XPosScaled;
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
                return GetAbsoluteY(obj.Orbits) + (int)obj.YPosScaled;
            }
        }

        //WHat is this?
        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            SpaceTimeController stc = new SpaceTimeController();
        }

        private void startSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                timer1.Start();
                started = true;
                startSimulationToolStripMenuItem.Text = "Stop";

            }
            else
            {
                timer1.Stop();
                _ticks = 0;
                LabelDayCounter.Text = _ticks.ToString();
                started = false;
                startSimulationToolStripMenuItem.Text = "Start simulation";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();
            formGraphics.Clear(Color.LightGray);
            foreach (SpaceSim.SpaceObject obj in ast.SolarSystem)
            {
                obj.CalculatePosition(_ticks);
                drawObjectsAndOrbits(formGraphics, obj);
                //Console.WriteLine(obj.Name);
            }
            formGraphics.Dispose();
            _ticks++;
            LabelDayCounter.Text = _ticks.ToString();


        }
    }
}
