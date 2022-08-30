using System.Threading.Tasks;
using crud__operation.CommonLayer.Model;

namespace crud__operation.ServiceLayer
{
    public interface ICrudOperationSL
    {
        Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);
        Task<ReadRecordResponse> ReadRecord();
        Task <UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
        Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);

    }
}
