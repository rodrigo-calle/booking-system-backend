using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public List<EntityImage> GetImages(int id, string tipo)
        {
            var response = new List<EntityImage>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    string sql = (tipo.Equals("P")) ? "usp_Listar_Images_X_Proyecto" : "usp_Listar_Images_X_Departamento";
                    var p = new DynamicParameters();

                    if (tipo.Equals("P"))
                        p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    else
                        p.Add(name: "@IDDEPARTAMENTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    response = db.Query<EntityImage>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;
        }
    }
}