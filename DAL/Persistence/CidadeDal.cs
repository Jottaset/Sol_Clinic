using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
using System.Data;

namespace DAL.Persistence
{
    public class CidadeDal : Conexao
    {

        public void Salvar(Cidade cidade)
        {
            try
            {

                var sql = "INSERT INTO cidade(idEstado, descricao, dtCadastro)" +
                          "VALUES(@idEstado, @descricao, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idEstado", cidade.IdEstado);
                command.Parameters.AddWithValue("@descricao", cidade.Descricao);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.ToString());
            }
            finally
            {

            }
        }


        public DataTable ListarPorNome(string Descricao)
        {
            try
            {

                var sql = "SELECT * FROM cidade WHERE Descricao LIKE '%" + Descricao + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("idCidade");
                dataTable.Columns.Add("cidade");
                dataTable.Columns.Add("estado");
                dataTable.Columns.Add("siglaEstado");

                while (dataReader.Read())
                {
                    Cidade cidade = new Cidade();
                    EstadoDal estadoDal = new EstadoDal();

                    cidade.Id = Convert.ToInt32(dataReader["id"]);
                    cidade.IdEstado = Convert.ToInt32(dataReader["idEstado"]);
                    cidade.Estado = estadoDal.PesquisarPorId(cidade.IdEstado);
                    cidade.Descricao = dataReader["Descricao"].ToString();

                    dataTable.Rows.Add(cidade.Id, cidade.Descricao, cidade.Estado.Nome, cidade.Estado.Sigla);

                    //dataTable.Add(cidade);

                }

                //DataTable dataTable = new DataTable();


              //  foreach(var cidade in dataTable)
              //  {

              //      dataTable.Rows.Add(cidade.Id, cidade.Descricao, cidade.Estado.Nome, cidade.Estado.Sigla);

              //  }

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

        public List<Cidade> Listar()
        {
            try
            {

                var sql = "SELECT * FROM cidade";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Cidade> listaCidade = new List<Cidade>();

                while (dataReader.Read())
                {
                    Cidade cidade = new Cidade();

                    cidade.Id = Convert.ToInt32(dataReader["id"]);
                    cidade.Descricao = dataReader["descricao"].ToString();
                    //cidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaCidade.Add(cidade);

                }
                return listaCidade;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }

            public Cidade PesquisarPorId(int id)
            {
            try
            {
                var sql = "SELECT * FROM cidade WHERE id = @id";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();

                Cidade cidade = new Cidade();

                if (dataReader.Read())
                {
                    cidade.Id = Convert.ToInt32(dataReader["id"]);
                    cidade.Descricao = dataReader["Descricao"].ToString();

                }
                return cidade;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao consultar Cidade " + erro.ToString());
            }
            finally
            {
            }
        }

        public CidadeDal()
        {
        }
    }
}
