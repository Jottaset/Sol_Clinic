using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class EstadoPesquisa : System.Web.UI.Page
    {
        public void btnPesquisaPorId(object sender, EventArgs e)
        {

            int id_estado = Int32.Parse(idEstado.Text);

            EstadoDal estadoDal = new EstadoDal();
            Estado estado = new Estado();
            estado = estadoDal.PesquisarPorId(id_estado);

            if (estado.Nome != null)
            {
                nomeEstado.Text = estado.Nome;
                siglaEstado.Text = estado.Sigla;
            }
            else
            {
                nomeEstado.Text = "Estado nao encontrado";
                siglaEstado.Text = "";
                //lblMensagem.Text = "Estado nao encontrado";
            }
        }
    }
}
