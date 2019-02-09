using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using DAL.Persistence;
using System.Collections.Generic;
using System.Data;

namespace DAL.Persistence
{
    public class PacienteDal : Conexao
    {

        public void Salvar(Paciente paciente)
        {
            try
            {
               
                var sql = "INSERT INTO paciente(id, nome, dtCadastro)" +
                          "VALUES(@id, @nome, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", paciente.Id);
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

        public DataTable ListarPorNome(string Nome)
        {
            try
            {

                var sql = "SELECT * FROM paciente WHERE nome LIKE '%" + Nome + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Id_Paciente");
                dataTable.Columns.Add("Nome");
                dataTable.Columns.Add("Cidade");
               
                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();
                    CidadeDal cidade = new CidadeDal();
                    EstadoDal estadoDal = new EstadoDal();

                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.Nome = dataReader["Nome"].ToString();
                    paciente.IdCidade = Convert.ToInt32(dataReader["idCidade"]);
                    paciente.Cidade = cidade.PesquisarPorId(paciente.IdCidade);

                    dataTable.Rows.Add(paciente.Id, paciente.Nome, paciente.Cidade.Descricao);

                }


                return dataTable;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
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
