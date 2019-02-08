using System;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class CidadeLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //CidadeDal cidadeDal = new CidadeDal();
            //gridListaCidade.DataSource = cidadeDal.Listar();
            //gridListaCidade.DataBind();

        }

        public void btnPesquisarCidade(object sender, EventArgs e)
        {
            string descricaoCidade = descricao.Text;

            CidadeDal cidadeDal = new CidadeDal();

            gridListaCidade.DataSource = cidadeDal.ListarPorNome(descricaoCidade);
            gridListaCidade.DataBind();
        }
    }
}
