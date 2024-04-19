namespace CarAuction.WebApp.Models
{
    public class ApiCallException : Exception
    {
        public string[] ErrorMessages { get; set; }
    }
}
