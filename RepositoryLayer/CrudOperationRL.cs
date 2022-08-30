using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using crud__operation.CommonLayer.Model;
using Microsoft.Extensions.Configuration;

namespace crud__operation.RepositoryLayer
{
    public class CrudOperationRL : ICrudOperationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }

            public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "succesful";
            try
            {
                string SqlQuery = "Insert  Into CrudOperationTable(UserName , Age) values (@UserName , @Age)";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery ,_sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "unsuccesful";
                    }
                   
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSuccess= true;
            response.Message = "Response Successfully established";
            try
            {
                string SqlQuery = "Delete from CrudOperationTable where id=@id";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType= System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Unsuccessful";
                    }
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;


        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess= true;
            response.Message = "succesful";
            try
            {
                string sqlQuery = "Select Username , Age from CrudOperationTable;";
                using (SqlCommand sqlCommand = new SqlCommand (sqlQuery ,_sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                   

                    _sqlConnection.Open();
                    using(SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while(await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.UserName = sqlDataReader[name: "UserName" ] != DBNull.Value ? sqlDataReader[ name: "UserName"].ToString() : null;
                                dbData.Age = sqlDataReader[name: "Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Age"]) : 0;
                                response.readRecordData.Add(dbData);

                            }

                        }
                    }
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "unsuccesful";
                    }
                    


                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();
            response.IsSuccess = true;
            response.Message = "succesful";

            try
            {
                string SqlQuery = "Update CrudOperationTable Set UserName =@UserName , Age = @Age where Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.Username);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue("@Id", request.id);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "not succesful";
                    }



                }
            }
            catch(Exception Ex)
            {
                response.IsSuccess = false;
                response.Message = Ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }
    }
}
