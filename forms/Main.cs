using System;
using koifishy.forms.panelForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace koifishy.forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        
        private void Main_Load(object sender, EventArgs e) {
            LoadPanel(new mainPanel());
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }




        /// <summary>
        /// window handle draging
        /// </summary>
        bool dragging;
        Point offset;

        private void windowHandle_MouseUp(object sender, MouseEventArgs e)
        {
            //In the MouseUp event handler, we set dragging to false to indicate that the drag operation has ended.
            dragging = false;
        }

        private void windowHandle_MouseMove(object sender, MouseEventArgs e)
        {
            //In the MouseMove event handler, we check if dragging is true. If it is, we calculate the current position of the mouse cursor on the screen using PointToScreen(e.Location).
            //Then, we update the form's location by subtracting the offset from the current position.
            if (dragging)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - offset.X, currentScreenPosition.Y - offset.Y);

            }
        }

        private void windowHandle_MouseDown(object sender, MouseEventArgs e)
        {
            //In the MouseDown event handler, we store the starting point of the drag operation in the offset variable.
            //We use e.Location to get the coordinates relative to the panel.
            dragging = true;
            offset = e.Location;
        }
        public Task LoadPanel(object form) {
            if (this.panelWindow.Controls.Count > 0)
                this.panelWindow.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelWindow.Controls.Add(f);
            this.panelWindow.Tag = f;
            f.Show();
            GC.Collect();
            return Task.CompletedTask;
        }


    }
}
