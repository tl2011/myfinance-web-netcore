using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infraestrutura;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;
        public PlanoContaService(
            MyFinanceDbContext myFinanceDbContext,
            IMapper mapper)
            
        {
            _myFinanceDbContext = myFinanceDbContext;    
            _mapper = mapper; 
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
            _myFinanceDbContext.PlanoConta.Attach(item);
            _myFinanceDbContext.PlanoConta.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public IEnumerable<PlanoContaModel> ListarPlanoContas()
        {
            var listaPlanoConta= _myFinanceDbContext.PlanoConta.ToList(); 
            var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(listaPlanoConta);
            return lista;
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First(); 
            var lista = _mapper.Map<PlanoContaModel>(item);
            return lista;
        }

        public void Salvar(PlanoContaModel model)
        {
            var instancia = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo,
            };

            if (instancia.Id == null)
            {
                _myFinanceDbContext.PlanoConta.Add(instancia);
            }
            else
            {            
            _myFinanceDbContext.PlanoConta.Attach(instancia);
            _myFinanceDbContext.Entry(instancia).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
    }
}