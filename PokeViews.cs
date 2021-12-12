using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class PokeViews : UserControl
    {
        public PokeViews(string nombre,Image imagen)
        {
            InitializeComponent();
            this.label1.Text = nombre;
            this.pictureBox1.Image = imagen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
