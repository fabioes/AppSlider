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
    public class DesignTimeDbContextFactory /*: IDesignTimeDbContextFactory<Context>*/
    {
        
        //public Context CreateDbContext(string[] args)
        //{
            
        //    //var builder = new DbContextOptionsBuilder<Context>();
        //    //builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)                  
        //    //       .UseMySql("Server=localhost;User Id=root;Password=1234;Database=midiafone;Connection Reset=false");
        //    //return new Context(builder.Options);
           
        //}
    }
}
