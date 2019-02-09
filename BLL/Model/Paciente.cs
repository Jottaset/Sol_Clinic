using System;
namespace BLL.Model
{
    public class Paciente
    {

        public int Id { get; set; }
        public int IdCidade { get; set; }
        public Cidade Cidade { get; set; }
        public string Nome { get; set; }
        public string DtCadastro { get; set; }




        public Paciente()
        {
        }
    }
}
