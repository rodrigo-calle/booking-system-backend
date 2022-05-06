using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class HabitacionRepository : BaseRepository,IHabitacionRepository
    {
        public EntityBaseResponse GetHabitaciones()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var habitaciones = new List<EntityHabitacion>();
                    const string sql = "usp_ListarHabitaciones";

                    habitaciones = db.Query<EntityHabitacion>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (habitaciones.Count > 0)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = habitaciones;
                    }
                    else
                    {
                        response.isSuccess = false;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = ex.Message;
                response.data = null;
            }

            return response;
        }
    }
}