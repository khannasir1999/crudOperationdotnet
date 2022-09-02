namespace crud__operation.CommonLayer.Model
{
    public class CreateRecordRequest
    {
        public string UserName { get; set; }
        public string Age { get; set; }

   

    }
    public class CreateRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
