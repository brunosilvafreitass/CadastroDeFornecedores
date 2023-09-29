using Microsoft.EntityFrameworkCore;
using CadastroDeFornecedores.Models;

namespace CadastroDeFornecedores.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options) 
        {
            
        }

        public DbSet<FornecedorModel> Fornecedor { get; set; }
    }
}
