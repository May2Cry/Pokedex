using Pokedex.Controller;
using Pokedex.Models;
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
    public partial class Form1 : Form
    {
        ApiPokemonRequest api = new ApiPokemonRequest();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void CargarDatos()
        {
            flowLayoutPanel1.Controls.Clear();
            PokeLista PokeL = new PokeLista();


            PokeL = api.ObtenerLista();

            foreach (var items in PokeL.result)
            {
                flowLayoutPanel1.Controls.Add(new PokeViews(items.name, items.getImage()));
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
