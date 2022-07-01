using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace App_de_Escritorio
{
    public partial class frmBiblioteca : Form
    {
        private List<Libro> listaLibros;
        public frmBiblioteca()
        {
            InitializeComponent();
        }

        private void frmBiblioteca_Load(object sender, EventArgs e)
        {
            cargar();
            ocultarColumnas();
        }
        public void cargar()
        {
            LibroNegocio negocio = new LibroNegocio();
            listaLibros = negocio.listar();
            dgvLibros.DataSource = listaLibros;
            ocultarColumnas();
        }
        public void ocultarColumnas()
        {
            dgvLibros.Columns["UrlTapaLibro"].Visible = false;
            dgvLibros.Columns["IdLibros"].Visible = false;
        }
        public void cargarImagen(string imagen)
        {
            try
            {
                pbxLibros.Load(imagen);
            }
            catch (Exception)
            {

                pbxLibros.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder-1024x683.png");

            }
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow != null)
            {
                Libro seleccionado = (Libro)dgvLibros.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlTapaLibro);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaLibro altaLibro = new frmAltaLibro();
            altaLibro.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Libro objetoSeleccionado;
            objetoSeleccionado = (Libro)dgvLibros.CurrentRow.DataBoundItem;
            frmAltaLibro modificadoLibro = new frmAltaLibro(objetoSeleccionado);
            modificadoLibro.ShowDialog();
            cargar();
        }
    }
}
