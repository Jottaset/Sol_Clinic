using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class EstadoLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //EstadoDal estadoDal = new EstadoDal();
            //gridListaEstado.DataSource = estadoDal.Listar();
            //gridListaEstado.DataBind();

        }



        public void btnPesquisarEstado(object sender, EventArgs e)
        {
            string nomeEstado = nome.Text;
            EstadoDal estadoDal = new EstadoDal();

            gridListaEstado.DataSource = estadoDal.ListarPorNome(nomeEstado);
            gridListaEstado.DataBind();


        }




    }
}