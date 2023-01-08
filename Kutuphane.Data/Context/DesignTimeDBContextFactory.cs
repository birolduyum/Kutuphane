using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data.Context
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<KutuphaneDbContext>
    {
        public KutuphaneDbContext CreateDbContext(string[] args)
        {
            string connectionString = "";
            var builder = new DbContextOptionsBuilder<KutuphaneDbContext>();
            builder.UseNpgsql(connectionString);
            return new KutuphaneDbContext(builder.Options);
        }
    }
}
