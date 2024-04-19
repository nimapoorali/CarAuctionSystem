namespace CarAuction.WebApp.Models
{
    public class CleanResult
    {
        public bool IsSuccess { get; set; }
        public IReadOnlyList<string> Successes { get; set; }
        public bool IsFailed { get; set; }
        public IReadOnlyList<string> Errors { get; set; }
    }

    public class CleanResult<T> : CleanResult
    {
        public CleanResult() : base()
        {
        }
        public T? Value { get; set; }
    }
}
