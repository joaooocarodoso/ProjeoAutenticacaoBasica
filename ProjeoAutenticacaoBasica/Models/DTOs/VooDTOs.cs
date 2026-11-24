namespace ProjeoAutenticacaoBasica.Models.DTOs
{
    public class VooDTOs
    {
    }

    public class CriarVooDTO
    {
        public string Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }

    public class ResumoVooDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Trajeto { get; set; }
    }

    public class PassageiroNoVooDTO
    {
        public string Nome { get; set; }
        public string Assento { get; set; }
    }

    public class VooManifestoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Trajeto { get; set; }
        public List<PassageiroNoVooDTO> Passageiro { get; set; }
    }
}
