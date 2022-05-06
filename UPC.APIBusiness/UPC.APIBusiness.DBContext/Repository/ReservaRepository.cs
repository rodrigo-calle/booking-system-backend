using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class ReservaRepository : BaseRepository, IReservaRepository
    {
        public EntityBaseResponse Insert(EntityReserva reserva)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarReserva";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDRESERVA", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@IDHABITACION", value: reserva.data[0].idhabitacion, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDUSUARIO", value: reserva.data[0].idusuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NINOS", value: reserva.data[0].ninos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@ADULTOS", value: reserva.data[0].adultos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: reserva.data[0].precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA", value: reserva.data[0].fecha, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DIAS", value: reserva.data[0].dias, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityReserva>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idreserva = p.Get<int>("@IDRESERVA");

                    if (idreserva > 0)
                    {

                        if (reserva.data.Count > 1)
                        {
                            for (int i = 1; i <= reserva.data.Count - 1; i++)
                            {

                                const string sql_mod = "usp_UpdateReserva";

                                var p_mod = new DynamicParameters();
                                p_mod.Add(name: "@IDRESERVA", value: idreserva, dbType: DbType.Int32, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@IDHABITACION", value: reserva.data[i].idhabitacion, dbType: DbType.Int32, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@IDUSUARIO", value: reserva.data[i].idusuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@NINOS", value: reserva.data[i].ninos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@ADULTOS", value: reserva.data[i].adultos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@PRECIO", value: reserva.data[i].precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@FECHA", value: reserva.data[i].fecha, dbType: DbType.String, direction: ParameterDirection.Input);
                                p_mod.Add(name: "@DIAS", value: reserva.data[i].dias, dbType: DbType.Int32, direction: ParameterDirection.Input);

                                db.Query<EntityReserva>(
                                        sql: sql_mod,
                                        param: p_mod,
                                        commandType: CommandType.StoredProcedure
                                    ).FirstOrDefault();

                            }
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = new
                        {
                            id = idreserva,
                        };
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

        public EntityBaseResponse Insert(EntityReserva[] reserva)
        {
            throw new NotImplementedException();
        }
    }
}
