using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models;

public class TransacaoModel
{
        public int? Id { get; set;}
        public string Historico { get; set;}
        public string Tipo { get; set;}
        public decimal Valor { get; set;}
        public int PlanoContaId { get; set;}
        public DateTime Data { get; set;}
        public IEnumerable<SelectListItem> PlanoContas { get; set;}
       
}
