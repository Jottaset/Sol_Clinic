using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class EspecialidadePesquisa : System.Web.UI.Page
    {
        public void btnPesquisaPorId(object sender, EventArgs e)
        {

            int id_especialidade = Int32.Parse(idEspecialidade.Text);

            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            Especialidade especialidade = new Especialidade();
            especialidade = especialidadeDal.PesquisarPorId(id_especialidade);

            if (especialidade.Descricao != null)
            {
                descricaoEspecialidade.Text = especialidade.Descricao;
            }
            else
            {
                descricaoEspecialidade.Text = "Especialidade nao encontrada";
                //lblMensagem.Text = "Especialidade nao encontrado";
            }
        }
    }
}
