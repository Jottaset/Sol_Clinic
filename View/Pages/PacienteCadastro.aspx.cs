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

    public partial class PacienteCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bindCidades();
        }

        public void btnCadastrarPaciente(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();
                paciente.Nome = nome.Text;
                paciente.IdCidade = Int32.Parse(idCidade.SelectedValue);

                PacienteDal pacienteDal = new PacienteDal();
                pacienteDal.Salvar(paciente);

                nome.Text = "";
                idCidade.Text = "";

                string msg = "Paciente " + paciente.Nome +
                             ", Cadastrada com Sucesso,";

                lblMensagem.Attributes.CssStyle.Add("color", "green");

                lblMensagem.Text = msg;

                //Thread.Sleep(5000);

                //Response.Redirect("/Pages/PacienteCadastro.aspx");

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindCidades()
        {
            CidadeDal cidadeDal = new CidadeDal();
            List<Cidade> listaCidade = new List<Cidade>();

            listaCidade = cidadeDal.Listar();

            foreach (var cidade in listaCidade)
            {
                idCidade.Items.Insert(0, new ListItem(cidade.Descricao, cidade.Id.ToString()));

            }



        }


    }

}
