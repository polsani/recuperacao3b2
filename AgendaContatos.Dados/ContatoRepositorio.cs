using AgendaContatos.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AgendaContatos.Dados
{
    public class ContatoRepositorio
    {
        private string _connectionString = "Server=localhost;Database=agendacontatos;Uid=root;Pwd=;";
        private TipoContatoRepositorio _tipoContatoRepositorio;

        public ContatoRepositorio()
        {
            _tipoContatoRepositorio = new TipoContatoRepositorio();
        }

        public List<Contato> ConsultaTodos()
        {
            List<Contato> retornoConsulta = new List<Contato>();

            string comandoSQL = "SELECT * FROM Contato;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new Contato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Nome = dr["Nome"].ToString(),
                    Telefone = dr["Telefone"].ToString(),
                    TipoContato = _tipoContatoRepositorio.Consulta(Convert.ToInt32(dr["CodigoTipoContato"]))
                });
            }

            return retornoConsulta;
        }

        public int Inserir(Contato contato)
        {
            int codigoGerado = 0;

            string comandoSQL = "Insert into Contato (Codigo, Nome, Telefone, CodigoTipoContato) values (@Codigo, @Nome, @Telefone, @TipoContato);";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", contato.Codigo);
            comando.Parameters.AddWithValue("@Nome", contato.Nome);
            comando.Parameters.AddWithValue("@Telefone", contato.Telefone);
            comando.Parameters.AddWithValue("@TipoContato", contato.TipoContato.Codigo);

            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(Codigo) from Contato", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }

            return codigoGerado;
        }

        public void Alterar(Contato contato)
        {
            string comandoSQL = "Update Contato set Nome=@Nome, Telefone=@Telefone, TipoContato=@TipoContato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Nome", contato.Nome);
            comando.Parameters.AddWithValue("@Telefone", contato.Telefone);
            comando.Parameters.AddWithValue("@TipoContato", contato.TipoContato.Codigo);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Apagar(int codigoContato)
        {
            string comandoSQL = "Delete from Contato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public Contato Consulta(int codigoContato)
        {
            Contato retornoConsulta = null;

            string comandoSQL = "SELECT * FROM Contato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection(_connectionString);
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoContato);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta = new Contato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Nome = dr["Nome"].ToString(),
                    Telefone = dr["Telefone"].ToString(),
                    TipoContato = _tipoContatoRepositorio.Consulta(Convert.ToInt32(dr["CodigoTipoContato"]))
                };
            }

            return retornoConsulta;
        }
    }
}
