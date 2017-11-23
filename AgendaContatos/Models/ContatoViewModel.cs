using System.Collections.Generic;

namespace AgendaContatos.Models
{
    public class ContatoViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public TipoContatoViewModel TipoContato { get; set; }

        public Dominio.Contato ConverterParaDominio()
        {
            return new Dominio.Contato
            {
                Codigo = this.Codigo,
                Nome = this.Nome,
                Telefone = this.Telefone,
                TipoContato = this.TipoContato.ConverterParaDominio()
            };
        }

        public static List<ContatoViewModel> ConverterTodosDeDominioParaViewModel(List<Dominio.Contato> contatosDominio)
        {
            List<ContatoViewModel> contatosConvertidos = new List<ContatoViewModel>();

            foreach (Dominio.Contato item in contatosDominio)
            {
                contatosConvertidos.Add(new ContatoViewModel
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    Telefone = item.Telefone,
                    TipoContato = TipoContatoViewModel.ConverterDeDominioParaViewModel(item.TipoContato)
                });
            }

            return contatosConvertidos;
        }

        public static ContatoViewModel ConverterDeDominioParaViewModel(Dominio.Contato contatoDominio)
        {
            return new ContatoViewModel
            {
                Codigo = contatoDominio.Codigo,
                Nome = contatoDominio.Nome,
                Telefone = contatoDominio.Telefone,
                TipoContato = TipoContatoViewModel.ConverterDeDominioParaViewModel(contatoDominio.TipoContato)
            };
        }
    }
}