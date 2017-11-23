namespace AgendaContatos.Dominio
{
    public class Contato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public TipoContato TipoContato { get; set; }
    }
}
