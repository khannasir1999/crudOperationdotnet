using System.Threading.Tasks;
using crud__operation.CommonLayer.Model;
using crud__operation.RepositoryLayer;

namespace crud__operation.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        //Constructor based Dependency Injection
        public readonly ICrudOperationRL _crudOperationRL;
        public CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }



        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            return await _crudOperationRL.CreateRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateRecord(request);
        }

       

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudOperationRL.DeleteRecord(request);
        }
    }
}
 