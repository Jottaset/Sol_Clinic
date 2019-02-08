using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace View.Pages
{
    public partial class EspecialidadeCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o Cadastro";
        }
        protected void btnCadastrarEspecialidade(object sender, EventArgs e)
        {
            try
            {
                Especialidade especialidade = new Especialidade();
                especialidade.Descricao = descricao.Text;

                EspecialidadeDal especialidadeDal = new EspecialidadeDal();
                especialidadeDal.Salvar(especialidade);

                descricao.Text = "";

                string msg = "Especialidade de " + especialidade.Descricao +
                             ", Cadastrado com Sucesso,";

                lblMensagem.Attributes.CssStyle.Add("color", "green");

                lblMensagem.Text = msg;


            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }
    }
}
