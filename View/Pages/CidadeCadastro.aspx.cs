using System;
using System.Web;
using System.Web.UI;
using DAL.Persistence;
using BLL.Model;
using System.Threading;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace View.Pages
{

    public partial class CidadeCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bindEstados();
        }

        public void btnCadastrarCidade(object sender, EventArgs e)
        {
            try
            {
                Cidade cidade = new Cidade();
                cidade.Descricao = descricao.Text;
                cidade.IdEstado = Int32.Parse(idEstado.SelectedValue);

                CidadeDal cidadeDal = new CidadeDal();
                cidadeDal.Salvar(cidade);

                descricao.Text = "";
                idEstado.Text = "";

                string msg = "Cidade " + cidade.Descricao +
                             ", Cadastrada com Sucesso,";             

                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");

                Response.Redirect("/Pages/CidadeCadastro.aspx");



            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindEstados()
        {
            EstadoDal estadoDal = new EstadoDal();
            List<Estado> listaEstado = new List<Estado>();

            listaEstado = estadoDal.Listar();
            //idEstado.Items.Clear();
            //idEstado.ClearSelection();

            foreach(var estado in listaEstado)
            {
                idEstado.Items.Insert(0, new ListItem(estado.Nome, estado.Id.ToString()));

            }



        }


    }

}
