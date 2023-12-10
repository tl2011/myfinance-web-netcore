using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infraestrutura;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;

        private readonly IPlanoContaService _planoContaService;
        private readonly IMapper _mapper;

        public TransacaoService(
            MyFinanceDbContext myFinanceDbContext,
            IPlanoContaService planoContaService,
            IMapper mapper)
            
        {
            _myFinanceDbContext = myFinanceDbContext; 
            _planoContaService = planoContaService;
            _mapper = mapper; 
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First();
            _myFinanceDbContext.Transacao.Attach(item);
            _myFinanceDbContext.Transacao.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public IEnumerable<TransacaoModel> ListarTransacoes()
        {
            var listaTransacao = _myFinanceDbContext.Transacao.ToList(); 
            var lista = _mapper.Map<IEnumerable<TransacaoModel>>(listaTransacao);
            return lista;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First(); 
            var lista = _mapper.Map<TransacaoModel>(item);
            return lista;
        }

        public void Salvar(TransacaoModel model)
        {
            var tipoTransacao = _planoContaService.RetornarRegistro(model.PlanoContaId).Tipo;
            
            var instancia = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor= model.Valor,
                PlanoContaId = model.PlanoContaId,
                Tipo = tipoTransacao
            };

            if (instancia.Id == null)
            {
                _myFinanceDbContext.Transacao.Add(instancia);
            }
            else
            {            
            _myFinanceDbContext.Transacao.Attach(instancia);
            _myFinanceDbContext.Entry(instancia).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }

    }
}