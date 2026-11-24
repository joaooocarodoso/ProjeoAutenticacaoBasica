namespace ProjeoAutenticacaoBasica.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public string Assento { get; set; }
        public int PassageiroId { get; set; }
        public int VooId { get; set; }

        public Passageiro? Passageiro { get; set; }
        public Voo? Voo { get; set; }
    }
}

