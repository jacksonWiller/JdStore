using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using System;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId
{
    public class ObterProdutoPorIdHandler : IObterProdutoPorIdHandler
    {
        public readonly CatalogoContext _dataContext;

        public ObterProdutoPorIdHandler(CatalogoContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ObterProdutoPorIdResponse> Handle(ObterProdutoPorIdRequest query)
        {
            try
            {
                var produto = await _dataContext.Produtos.FirstOrDefaultAsync(p => p.Id == query.Id);

                return new ObterProdutoPorIdResponse
                {
                    Id = produto.Id,
                    Nome = produto.Name,
                    Valor = produto.Valor,
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
