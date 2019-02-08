using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class MedicoDal : Conexao
    {

        public void Salvar(Medico medico)
        {
            try
            {

                var sql = "INSERT INTO medico(nome, idEspecialidade, crm, dtCadastro)" +
                          "VALUES(@nome, @idEspecialidade, @crm, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", medico.Nome);
                command.Parameters.AddWithValue("@idEspecialidade", medico.IdEspecialidade);
                //command.Parameters.AddWithValue("@crm", medico.Crm);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }

        public List<Medico> Listar()
        {
            try
            {

                var sql = "SELECT * FROM medico";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Medico> listaMedico = new List<Medico>();

                while (dataReader.Read())
                {
                    Medico medico = new Medico();

                    medico.Id = Convert.ToInt32(dataReader["id"]);
                    medico.Nome = dataReader["nome"].ToString();


                    listaMedico.Add(medico);
                }

                //listaMedico.Sort();

                return listaMedico;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }

        public MedicoDal()
        {
        }
    }
}