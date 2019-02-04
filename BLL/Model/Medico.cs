using System;
namespace BLL.Model
{
    public class Medico
    {
        public int Id { get; set; }
        public int IdEspecialidade { get; set; }
        public string Nome { get; set; }
        public string DtCadastro { get; set; }


        public Medico()
        {
        }
    }
}
