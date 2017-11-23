using System.Collections.Generic;

namespace AgendaContatos.Models
{
    public class TipoContatoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public Dominio.TipoContato ConverterParaDominio()
        {
            return new Dominio.TipoContato
            {
                Codigo = this.Codigo,
                Descricao = this.Descricao
            };
        }

        public static List<TipoContatoViewModel> ConverterTodosDeDominioParaViewModel(List<Dominio.TipoContato> tiposContatoDominio)
        {
            List<TipoContatoViewModel> tiposContatoConvertido = new List<TipoContatoViewModel>();

            foreach (Dominio.TipoContato item in tiposContatoDominio)
            {
                tiposContatoConvertido.Add(new TipoContatoViewModel
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                });
            }

            return tiposContatoConvertido;
        }

        public static TipoContatoViewModel ConverterDeDominioParaViewModel(Dominio.TipoContato tipoContatoDominio)
        {
            return new TipoContatoViewModel
            {
                Codigo = tipoContatoDominio.Codigo,
                Descricao = tipoContatoDominio.Descricao
            };
        }
    }
}