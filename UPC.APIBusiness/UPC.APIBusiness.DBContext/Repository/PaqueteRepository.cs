using Dapper;
using DBContext;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UPC.APIBusiness.DBContext.Interface;
using UPC.APIBusiness.DBEntity.Model;

namespace UPC.APIBusiness.DBContext.Repository
{
    public class PaqueteRepository : BaseRepository, IPaqueteRepository
    {
        public EntityBaseResponse GetPaquetes()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var habitaciones = new List<EntityPaquete>();
                    const string sql = "usp_ListarPaquetes";

                    habitaciones = db.Query<EntityPaquete>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (habitaciones.Count > 0)
                    {
                        var habitacionRepo = new HabitacionRepository();

                        foreach (var pro in habitaciones)
                        {
                            pro.habitaciones = habitacionRepo.GetHabitacionesXPaquete(pro.idpaquete);
                        }

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

        public EntityBaseResponse GetPaquete(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var paquete = new EntityPaquete();

                    const string sql = "usp_ObtenerPaquete";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPAQUETE", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    paquete = db.Query<EntityPaquete>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (paquete != null)
                    {
                        var habitacionRepo = new HabitacionRepository();
                        paquete.habitaciones = habitacionRepo.GetHabitacionesXPaquete(paquete.idpaquete);

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = paquete;
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
