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

    public partial class MedicoCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bindEspecialidades();
        }

        public void btnCadastrarMedico(object sender, EventArgs e)
        {
            try
            {
                Medico medico = new Medico();
                medico.Nome = nome.Text;
                medico.IdEspecialidade = Int32.Parse(idEspecialidade.SelectedValue);

                MedicoDal medicoDal = new MedicoDal();
                medicoDal.Salvar(medico);

                nome.Text = "";
                idEspecialidade.Text = "";

                string msg = "Medico " + medico.Nome +
                             ", Cadastrado com Sucesso,";

                lblMensagem.Attributes.CssStyle.Add("color", "green");

                lblMensagem.Text = msg;


            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindEspecialidades()
        {
            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            List<Especialidade> listaEspecialidade = new List<Especialidade>();

            listaEspecialidade = especialidadeDal.Listar();

            foreach (var especialidade in listaEspecialidade)
            {
                idEspecialidade.Items.Insert(0, new ListItem(especialidade.Descricao, especialidade.Id.ToString()));

            }



        }


    }

}
