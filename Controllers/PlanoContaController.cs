using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;

    private readonly IPlanoContaService _planoContaService;


    public PlanoContaController(
         ILogger<PlanoContaController> logger,
         IPlanoContaService planoContaService)
    {
        _logger = logger;
        _planoContaService = planoContaService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var listaPlanoConta = _planoContaService.ListarPlanoContas();

        ViewBag.ListaPlanoConta = listaPlanoConta;

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
        if (id != null)
        {
            var registro = _planoContaService.RetornarRegistro((int)id);
            return View(registro);
        }
        return View();
    }
    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]

    public IActionResult Cadastro(PlanoContaModel model)
    {
        _planoContaService.Salvar(model);
        return RedirectToAction("Index");
    }
    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _planoContaService.Excluir(id);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}
