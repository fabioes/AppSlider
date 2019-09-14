using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        
        public Context CreateDbContext(string[] args)
        {

            //IConfigurationRoot configuration = new ConfigurationBuilder().S
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //var builder = new DbContextOptionsBuilder<Context>();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //builder.UseSqlServer(connectionString);
            //return new Context(builder.Options);
            
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseLazyLoadingProxies()
                   //.UseMySql("Server=mysql.odoias.com.br;User Id=odoias08;Password=midiafone2121;Database=odoias08;Connection Reset=false");
                   .UseMySql("Server=localhost;User Id=root;Password=1234;Database=midiafone;Connection Reset=false");
            return new Context(builder.Options);
           
        }
    }
}
