using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HelloDapper.Models;
using Dapper;
using System.Data.SqlClient;

namespace HelloDapper.Service
{
    public interface IFruitService
    {
        Task<IEnumerable< FruitDto>> FruitQuery();
    }
    public class FruitService : IFruitService
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public async Task<IEnumerable<FruitDto>> FruitQuery()
        {
            string sqlText = "SELECT * FROM Fruit";
            using (var conn = new SqlConnection(connStr))
            {
                return await conn.QueryAsync<FruitDto>(sqlText);
            }
        }
    }
}