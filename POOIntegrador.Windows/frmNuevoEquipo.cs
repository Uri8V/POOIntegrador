using POOIntegrador.Datos;
using POOIntegrador.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOIntegrador.Windows
{
    public partial class frmNuevoEquipo : Form
    {
        public frmNuevoEquipo()
        {
            InitializeComponent();
        }
        private List<Persona> lista;
        private void frmNuevoEquipo_Load(object sender, EventArgs e)
        {
            lista = new List<Persona>();
            lista = ManejadorArchivoSecuencial.LeerDatos("NuevoEquipo.txt");
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, item);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, Persona item)
        {
            r.Cells[0].Value = $"{item.Apellido.ToUpper()}, {item.Nombre}";
            if (item.GetType() == typeof(DirectorTecnico))
            {
                r.Cells[1].Value = "No tiene Camiseta";
                r.Cells[2].Value = "False";
                r.Cells[3].Value = Tipo.Tecnico.ToString();
            }
            else if (item.GetType() == typeof(Jugador))
            {
                r.Cells[1].Value = ((Jugador)item).GetNumero().ToString();
                r.Cells[2].Value = ((Jugador)item).GetEsCapitan().ToString();
                r.Cells[3].Value = Tipo.Jugador.ToString();
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridView1.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridView1);
            return r;
        }
    }
}
