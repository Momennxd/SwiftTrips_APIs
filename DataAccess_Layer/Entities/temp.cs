using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities
{
    public class temp
    {
        public static DataTable ExecGetAllPeople()
        {
            var dataTable = new DataTable();

            using (var dbContext = new AppDbContext()) // Replace with your actual DbContext class
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "GetPeople"; // Replace with your stored procedure name
                    command.CommandType = CommandType.StoredProcedure;

                    dbContext.Database.OpenConnection();
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }

                
            }

            return dataTable;
        }


    }
}
