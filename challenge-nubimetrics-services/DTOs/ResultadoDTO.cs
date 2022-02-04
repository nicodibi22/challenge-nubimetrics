namespace challenge_nubimetrics_services.DTOs
{
    public class ResultadoDTO
    {
        public string Id { get; set; }
        public string Site_Id { get; set; }
        public string Title { get; set; }
        public VendedorDTO Seller { get; set; }
        public double Price { get; set; }
        public string Permalink { get; set; }
    }
}