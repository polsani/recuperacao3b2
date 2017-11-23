using AgendaContatos.Dados;
using AgendaContatos.Dominio;
using System.Collections.Generic;

namespace AgendaContatos.Service
{
    public class TipoContatoService
    {
        private TipoContatoRepositorio _repositorio;

        public TipoContatoService()
        {
            _repositorio = new TipoContatoRepositorio();
        }

        public List<TipoContato> ConsultaTodos()
        {
            return _repositorio.ConsultaTodos();
        }

        public int Inserir(TipoContato tipoContato)
        {
            return _repositorio.Inserir(tipoContato);
        }

        public void Alterar(TipoContato tipoContato)
        {
            _repositorio.Alterar(tipoContato);
        }

        public void Apagar(int codigoTipoContato)
        {
            _repositorio.Apagar(codigoTipoContato);
        }

        public TipoContato Consulta(int codigoTipoContato)
        {
            return _repositorio.Consulta(codigoTipoContato);
        }
    }
}
