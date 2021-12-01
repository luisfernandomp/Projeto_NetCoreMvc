using AppMvcBasica.Models;
using DevIo.Business.Interfaces;
using DevIo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {

        }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores
                    .AsNoTracking()
                    .Include(c => c.Endereco)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores
                            .AsNoTracking()
                            .Include(p => p.Produtos)
                            .Include(e => e.Endereco)
                            .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
