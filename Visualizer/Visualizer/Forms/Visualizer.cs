 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Visualizer.Drawing;
using Visualizer.Parser;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;
using Visualizer.Repo;

namespace Visualizer
{
    public partial class Visualizer : Form
    {
        private IDrawer drawer;

        private Graphics graphics;
        void Init()
        {
            inited = true;
            drawer = Repository.Instance.GetInstance<IDrawer>();
            var parser = Repository.Instance.GetInstance<IFinalParser>();
            graphics = pictureBox1.CreateGraphics();
            drawer.graphics = graphics;
            drawer.Initialize(parser.GetTicks());
            drawer.DrawMap(parser.Map);
        }
        public Visualizer()
        {
            inited = false;
            InitializeComponent();
        }
        private int tickNumber = 0;
        private bool inited;
        private void Visualizer_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!inited)
                Init();
            drawer.DrawTick(tickNumber);
            tickNumber++;
        }
    }
}
