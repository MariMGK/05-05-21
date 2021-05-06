using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class db
    {
        SqlConnection con;
        public db()
        {
            var config = GetConfig();
            con = new SqlConnection(config.GetSection("Data").GetSection("ConnectionString").Value);
        }


        private IConfigurationRoot GetConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public DataSet Getrecord()
        {
            SqlCommand com = new SqlCommand("Sp_Department", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
    }

}
