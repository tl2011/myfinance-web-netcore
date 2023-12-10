using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public interface ITransacaoService
    {
        IEnumerable<TransacaoModel> ListarTransacoes();
        void Salvar(TransacaoModel model);

        TransacaoModel RetornarRegistro(int id);
        void Excluir (int id);
        
    }
}