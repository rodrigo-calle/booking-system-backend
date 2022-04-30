using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public EntityBaseResponse GetProject(int id)
        {
            var response = new EntityBaseResponse();
            
            try
            {
                using (var db = GetSqlConnection())
                {
                    var project = new EntityProject();
                    
                    const string sql = "usp_ObtenerProyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    project = db.Query<EntityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if(project != null)
                    {
                        var apartmentRepo = new ApartmentRepository();
                        var imageRepo = new ImageRepository();

                        project.apartments = apartmentRepo.GetApartments(project.idproyecto).data as List<EntityApartment>;
                        project.images = imageRepo.GetImages(project.idproyecto, "P");
                        
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = project;
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

        public EntityBaseResponse GetProjects()
        {
            var response = new EntityBaseResponse();
            
            try
            {
                using (var db = GetSqlConnection())
                {
                    var projects = new List<EntityProject>();
                    const string sql = "usp_ListarProyectos";

                    projects = db.Query<EntityProject>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if(projects.Count > 0)
                    {
                        var imageRepo = new ImageRepository();
                        
                        foreach(var pro in projects)
                        {
                            pro.images = imageRepo.GetImages(pro.idproyecto, "P");
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = projects;
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

        public EntityBaseResponse Insert(EntityProject project)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarProyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NOMBRE", value: project.nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: project.precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: project.direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@UBICACION", value: project.ubicacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@IMAGENNOMBRE", value: project.images.Count > 0 ? project.images[0].nombre : string.Empty, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@IMAGENRUTA", value: project.images.Count > 0 ? project.images[0].ruta : string.Empty, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: project.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idproyecto = p.Get<int>("@IDPROYECTO");
                    
                    if(idproyecto > 0)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = new
                        {
                            id = idproyecto,
                            nombre = project.nombre
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
            catch(Exception ex)
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