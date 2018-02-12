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
            ast = new Astronomy();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ast.DrawObjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        private void DrawSpaceObject(SpaceSim.SpaceObject drawObject)
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

            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();

            int centerX = GetAbsoluteX(drawObject);
            int centerY = GetAbsoluteY(drawObject);

            double objRadius = drawObject.ObjectRadius;

                //Rectangle(X,y,width,height)
            formGraphics.FillEllipse(myBrush, new Rectangle((int)(centerX - objRadius / 2), (int)(centerY - objRadius / 2), (int)objRadius, (int)objRadius));




            myBrush.Dispose();
            formGraphics.Dispose();

            /*
             * 
             * 
             * _thePanel.Location = new Point(
    this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
    this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
_thePanel.Anchor = AnchorStyles.None;
             * 
             */
        }


        public int GetAbsoluteX(SpaceSim.SpaceObject obj)
        {
            if(obj is SpaceSim.Star)
            {
                return DisplayPanel.Width / 2;
            }
            else
            {
                return GetAbsoluteX(obj.Orbits) + (int)obj.XPos;
            }
        }

        public int GetAbsoluteY(SpaceSim.SpaceObject obj)
        {
            if (obj is SpaceSim.Star)
            {
                return DisplayPanel.Height / 2;
            }
            else
            {
                return GetAbsoluteY(obj.Orbits) + (int)obj.YPos;
            }
        }
    }
}
