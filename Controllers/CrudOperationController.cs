using System;
using System.Threading.Tasks;
using crud__operation.CommonLayer.Model;
using crud__operation.ServiceLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud__operation.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        //Constructor based Dependency Injection
        public readonly ICrudOperationSL _crudOperationSL;
        public CrudOperationController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
        }
        [EnableCors]
        [HttpPost]
        [Route("CreateRecord")]

        public async Task <IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }
        [HttpGet]
        [Route("ReadRecord")]
        public async Task <IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null;
            try
            {
                response= await _crudOperationSL.ReadRecord();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpPut]
        [Route("api/UpdateRecord")]
        public async Task<IActionResult> UpdateRecord( UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/DeleteRecord")]
        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.DeleteRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
