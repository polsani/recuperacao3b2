using AgendaContatos.Dominio;
using AgendaContatos.Models;
using AgendaContatos.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AgendaContatos.Controllers
{
    public class ContatoController : Controller
    {
        private ContatoService _service;

        public ContatoController()
        {
            _service = new ContatoService();
        }

        // GET: Contato
        public ActionResult Index()
        {
            List<ContatoViewModel> contatos = ContatoViewModel.ConverterTodosDeDominioParaViewModel(_service.ConsultaTodos());
            return View(contatos);
        }

        public RedirectToRouteResult Apagar(int id)
        {
            _service.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ContatoViewModel tipoContato = ContatoViewModel.ConverterDeDominioParaViewModel(_service.Consulta(id));
            return View(tipoContato);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public RedirectToRouteResult Salvar(ContatoViewModel contato)
        {
            Contato contatoDominio = _service.Consulta(contato.Codigo);

            if (contatoDominio != null)
            {
                _service.Alterar(contato.ConverterParaDominio());
            }
            else
            {
                _service.Inserir(contato.ConverterParaDominio());
            }

            return RedirectToAction("Index");
        }
    }
}