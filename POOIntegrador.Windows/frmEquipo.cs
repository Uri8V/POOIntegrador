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
    public partial class frmEquipo : Form
    {
        public frmEquipo()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Repositorio repositorio = new Repositorio();
        private List<Persona> lista;
        private Equipo equipo;
        private DirectorTecnico directora = new DirectorTecnico("Nataly", "Villafañez");
        private void frmEquipo_Load(object sender, EventArgs e)
        {
            equipo= new Equipo("Los Programadores", directora);
            lista = new List<Persona>();
            if (repositorio.GetCantidad() > 0)
            {
                lista = repositorio.GetLista();
                MostrarLista();
            }
        }

        private void MostrarLista()
        {
            dgvDatos.Rows.Clear();
            foreach(var persona in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, persona);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Persona persona)
        {
            r.Cells[0].Value = $"{persona.Apellido.ToUpper()}, {persona.Nombre.ToUpper()}";
            if (persona.GetType() == typeof(DirectorTecnico))
            {
                r.Cells[1].Value = "No tiene Camiseta";
                r.Cells[2].Value = "False";
                r.Cells[3].Value = Tipo.Tecnico.ToString();
            }
            else if (persona.GetType() == typeof(Jugador))
            {
                r.Cells[1].Value = ((Jugador)persona).GetNumero().ToString();
                r.Cells[2].Value = ((Jugador)persona).GetEsCapitan().ToString();
                r.Cells[3].Value=Tipo.Jugador.ToString();
            }
            r.Cells[4].Value = "Agregar";
            r.Tag = persona;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Jugador j;
            var r = dgvDatos.SelectedRows[0];
            string tipo = r.Cells[colTipo.Index].Value.ToString();
            if (tipo == "Tecnico")
            {
                MessageBox.Show($"Ya existe un Director Tecnico y esa es {directora.FichaTecnica()}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                j = (Jugador)r.Tag;
                if (equipo != j)
                {
                    if(equipo + j)
                    {
                        MessageBox.Show("Jugador Agregado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDatos.Rows.Remove(r);
                    }
                    else
                    {
                        MessageBox.Show("El jugador ya ha sido agregado o ya existe un capián en el equipo", "Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ManejadorArchivoSecuencial.Guardar(equipo.GetPersonas(),"NuevoEquipo.txt");
        }

        private void btnMostrarEquipo_Click(object sender, EventArgs e)
        {
            frmNuevoEquipo frm= new frmNuevoEquipo();
            frm.ShowDialog(this);            
        }
    }
}
