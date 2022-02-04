namespace challenge_nubimetrics_services.DTOs
{
    public class PaginacionDTO
    {
        public int Total { get; set; }
        public int Primary_Results { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}