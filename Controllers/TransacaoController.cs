using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;

    private readonly ITransacaoService _transacaoService;

    private readonly IPlanoContaService _planoContaService;

    public TransacaoController(
         ILogger<TransacaoController> logger,
         ITransacaoService transacaoService,
         IPlanoContaService planoContaService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var listaTransacao = _transacaoService.ListarTransacoes();

        ViewBag.ListaTransacao = listaTransacao;

        return View();

        //List<PlanoContaModel> listaPlanoContaModel = new();
        //ViewBag.ListaPlanoConta = listaPlanoContaModel;
        //return View();
    }

    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]

    public IActionResult Cadastro(int? id)
    {
        var transacaoModel = new TransacaoModel();

        if (id != null)
        {
            transacaoModel = _transacaoService.RetornarRegistro((int)id);
            
        }
        var listaPlanoConta = _planoContaService.ListarPlanoContas();
        var planoContaSelectItens= new SelectList(listaPlanoConta, "Id", "Descricao");
        transacaoModel.PlanoContas = planoContaSelectItens;

        return View(transacaoModel);
    }
    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]

    public IActionResult Cadastro(TransacaoModel model)
    {
        _transacaoService.Salvar(model);
        return RedirectToAction("Index");
    }
    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _transacaoService.Excluir(id);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}
