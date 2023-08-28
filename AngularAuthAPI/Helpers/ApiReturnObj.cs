namespace PHubApi.Helpers
{
    public class ApiReturnObj
    {
        public dynamic ApiData { get; set; }
        public string Message { get; set; }
        public bool IsExecute { get; set; }
        public bool IsExecuted { get; set; }
        public dynamic Data { get; set; }
        public int TotalRecord { get; set; }
        public string MessageCode { get; set; }
        public dynamic Info { get; set; }
    }
}
