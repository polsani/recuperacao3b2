using AgendaContatos.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AgendaContatos.Dados
{
    public class TipoContatoRepositorio
    {
        private string _connectionString = "Server=localhost;Database=agendacontatos;Uid=root;Pwd=;";

        public List<TipoContato> ConsultaTodos()
        {
            List<TipoContato> retornoConsulta = new List<TipoContato>();

            string comandoSQL = "SELECT * FROM TipoContato;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new TipoContato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Descricao = dr["Descricao"].ToString()
                });
            }

            return retornoConsulta;
        }

        public int Inserir(TipoContato tipoContato)
        {
            int codigoGerado = 0;

            string comandoSQL = "Insert into TipoContato (Codigo, Descricao) values (@Codigo, @Descricao);";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", tipoContato.Codigo);
            comando.Parameters.AddWithValue("@Descricao", tipoContato.Descricao);

            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(Codigo) from TipoContato", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }

            return codigoGerado;
        }

        public void Alterar(TipoContato tipoContato)
        {
            string comandoSQL = "Update TipoContato set Descricao=@Descricao where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Descricao", tipoContato.Descricao);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Apagar(int codigoTipoContato)
        {
            string comandoSQL = "Delete from TipoContato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoTipoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public TipoContato Consulta(int codigoTipoContato)
        {
            TipoContato retornoConsulta = null;

            string comandoSQL = "SELECT * FROM TipoContato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoTipoContato);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta = new TipoContato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Descricao = dr["Descricao"].ToString()
                };
            }

            return retornoConsulta;
        }
    }
}
