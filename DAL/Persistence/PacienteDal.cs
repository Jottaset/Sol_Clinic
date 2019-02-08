using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class PacienteDal : Conexao
    {

        public void Salvar(Paciente paciente)
        {
            try
            {
               
                var sql = "INSERT INTO paciente(idCidade, nome, dtCadastro)" +
                          "VALUES(@idCidade, @nome, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCidade", paciente.IdCidade);
                command.Parameters.AddWithValue("@nome", paciente.Nome);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado do Paciente " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }

        public List<Paciente> Listar()
        {
            try
            {
               
                var sql = "SELECT * FROM paciente";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Paciente> listaPaciente = new List<Paciente>();

                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.Nome = dataReader["nome"].ToString();
                    paciente.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaPaciente.Add(paciente);

                }
                return listaPaciente;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar pacientes" + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }

        public PacienteDal()
        {
        }
    }
}
