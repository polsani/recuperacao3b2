using AgendaContatos.Dominio;
using AgendaContatos.Models;
using AgendaContatos.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AgendaContatos.Controllers
{
    public class TipoContatoController : Controller
    {
        private TipoContatoService _service;

        public TipoContatoController()
        {
            _service = new TipoContatoService();
        }

        // GET: TipoContato
        public ActionResult Index()
        {
            List<TipoContatoViewModel> tiposContato = TipoContatoViewModel.ConverterTodosDeDominioParaViewModel(_service.ConsultaTodos());
            
            return View(tiposContato);
        }

        public RedirectToRouteResult Apagar(int id)
        {
            _service.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            TipoContatoViewModel tipoContato = TipoContatoViewModel.ConverterDeDominioParaViewModel(_service.Consulta(id));
            return View(tipoContato);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public RedirectToRouteResult Salvar(TipoContatoViewModel tipoContato)
        {
            TipoContato tipoContatoDominio = _service.Consulta(tipoContato.Codigo);

            if (tipoContatoDominio != null)
            {
                _service.Alterar(tipoContato.ConverterParaDominio());
            }
            else
            {
                _service.Inserir(tipoContato.ConverterParaDominio());
            }

            return RedirectToAction("Index");
        }
    }
}