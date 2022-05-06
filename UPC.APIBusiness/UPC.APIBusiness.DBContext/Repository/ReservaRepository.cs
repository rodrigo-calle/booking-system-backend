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
                    p.Add(name: "@IDHABITACION", value: reserva.idhabitacion, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDUSUARIO", value: reserva.idusuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NINOS", value: reserva.ninos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@ADULTOS", value: reserva.adultos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: reserva.precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA", value: reserva.fecha, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@DIAS", value: reserva.dias, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityReserva>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idreserva = p.Get<int>("@IDRESERVA");

                    if (idreserva > 0)
                    {
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
