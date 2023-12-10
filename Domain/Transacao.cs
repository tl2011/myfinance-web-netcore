using Microsoft.EntityFrameworkCore;

namespace myfinance_web_netcore.Domain
{
    public class Transacao 
    {
        public int? Id { get; set;}
        public string Historico { get; set;}
        public string Tipo { get; set;}
        public decimal Valor { get; set;}
        public int PlanoContaId { get; set;}
        public DateTime Data { get; set;}
        public PlanoConta PlanoConta { get; set;}

    }
}