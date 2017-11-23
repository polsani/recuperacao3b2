using AgendaContatos.Dados;
using AgendaContatos.Dominio;
using System.Collections.Generic;

namespace AgendaContatos.Service
{
    public class ContatoService
    {
        private ContatoRepositorio _repositorio;

        public ContatoService()
        {
            _repositorio = new ContatoRepositorio();
        }

        public List<Contato> ConsultaTodos()
        {
            return _repositorio.ConsultaTodos();
        }

        public int Inserir(Contato contato)
        {
            return _repositorio.Inserir(contato);
        }

        public void Alterar(Contato contato)
        {
            _repositorio.Alterar(contato);
        }

        public void Apagar(int codigoContato)
        {
            _repositorio.Apagar(codigoContato);
        }

        public Contato Consulta(int codigoContato)
        {
            return _repositorio.Consulta(codigoContato);
        }
    }
}
