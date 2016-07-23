using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HelloDapper.Models;
using Dapper;
using System.Data.SqlClient;
using System.Transactions;

namespace HelloDapper.Service
{
    public interface IFruitService
    {
        Task<IEnumerable<FruitDto>> FruitQuery();
        Task<FruitDto> FruitQuery(string Name);
        void FruitInsert(List<FruitDto> fruitDtoList);
        void FruitUpdate(List<FruitDto> fruitDtoList);

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

        public async Task<FruitDto> FruitQuery(string Name)
        {
            string sqlText = "SELECT * FROM Fruit WHERE Name=@Name";
            using (var conn = new SqlConnection(connStr))
            {
                return (await conn.QueryAsync<FruitDto>(sqlText, new { Name = Name })).FirstOrDefault();
            }
        }

        public void FruitInsert(List<FruitDto> fruitDtoList)
        {
            string sqlText = @"INSERT INTO Fruit(Name,Price,Color,Code,StoreCode) 
                    VALUES(@Name,@Price,@Color,@Code,@StoreCode)";
            using (var conn = new SqlConnection(connStr))
            using (var tran = new TransactionScope())
            {
                conn.Execute(sqlText, fruitDtoList);
                tran.Complete();
            }
        }

        public void FruitUpdate(List<FruitDto> fruitDtoList)
        {
            string sqlText = @"UPDATE Fruit SET Name=@Name,Price=@Price
                    ,Color=@Color,Code=@Code,StoreCode=@StoreCode
                    WHERE Name=@Name";
            using (var conn = new SqlConnection(connStr))
            using (var tran = new TransactionScope())
            {
                conn.Execute(sqlText, fruitDtoList);
                tran.Complete();
            }
        }
    }
}