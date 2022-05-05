using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class ApartmentRepository : BaseRepository,IApartmentRepository
    {
        public EntityBaseResponse GetApartments()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var apartments = new List<EntityApartment>();
                    const string sql = "usp_Listar_Departamentos";

                    apartments = db.Query<EntityApartment>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if(apartments.Count > 0)
                    {
                        var imageRepo = new ImageRepository();

                        foreach(var apart in apartments)
                        {
                            apart.images = imageRepo.GetImages(apart.iddepartamento, "A");
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = apartments;
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
            catch(Exception ex)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = ex.Message;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse GetApartments(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var apartments = new List<EntityApartment>();
                    const string sql = "usp_Listar_Departamentos_X_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    apartments = db.Query<EntityApartment>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (apartments.Count > 0)
                    {
                        var imageRepo = new ImageRepository();

                        foreach (var apart in apartments)
                        {
                            apart.images = imageRepo.GetImages(apart.iddepartamento, "A");
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = apartments;
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
