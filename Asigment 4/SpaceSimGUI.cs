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
        public SolarSim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Astronomy ast = new Astronomy();
            ast.DrawObjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }


        private void DrawSpaceObject(SpaceSim.SpaceObject drawObject)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            System.Drawing.Graphics formGraphics;
            formGraphics = DisplayPanel.CreateGraphics();

            int radius = 200;
            //Rectangle(X,y,width,height)
            formGraphics.FillEllipse(myBrush, new Rectangle((DisplayPanel.Width / 2) - radius / 2, (DisplayPanel.Height / 2) - radius / 2, radius, radius));
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
    }
}
