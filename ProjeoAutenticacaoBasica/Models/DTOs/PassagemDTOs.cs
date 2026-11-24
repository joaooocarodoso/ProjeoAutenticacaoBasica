namespace ProjeoAutenticacaoBasica.Models.DTOs
{
    public class PassagemDTOs
    {
    }

    public class CriarPassagemDTOs
    {
        public int PassageiroId { get; set; }
        public int VooId { get; set; }
        public int AsscentoId { get; set; }
    }
    public class PassagemInfoDTOs
    {
        public int Id { get; set; }
        public string Assento { get; set; }
        public int PassageiroId { get; set; }
        public int VooId { get; set; }
    }
}
