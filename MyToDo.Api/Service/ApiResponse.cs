namespace MyToDo.Api.Service
{
    public class ApiResponse
    {
        private string message;
        private bool status;
        private object result;

        /*
         * 失败
         */
        public ApiResponse(string message, bool status = false)
        {
            this.message=message;
            this.status=status;
        }


        /*
         * 成功
         */
        public ApiResponse(bool status, object result)
        {
            this.status=status;
            this.result=result;
        }

        public string Message { get => message; set => message=value; }
        public bool Status { get => status; set => status=value; }
        public object Result { get => result; set => result=value; }
    }
}
