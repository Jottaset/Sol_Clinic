using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class EspecialidadeDal : Conexao
    {

        public void Salvar(Especialidade especialidade)
        {
            try
            {
                AbrirConexao();
                var sql = "INSERT INTO especialidade(descricao, dtCadastro)" +
                          "VALUES(@descricao, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", especialidade.Descricao);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado da Especialidade" + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Especialidade> Listar()
        {
            try
            {
                AbrirConexao();
                var sql = "SELECT * FROM especialidade";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Especialidade> listaEspecialidade = new List<Especialidade>();

                while (dataReader.Read())
                {
                    Especialidade especialidade = new Especialidade();

                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();
                   

                    listaEspecialidade.Add(especialidade);

                }
                return listaEspecialidade;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar Especialidades " + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }

        public EspecialidadeDal()
        {
        }
    }
}
