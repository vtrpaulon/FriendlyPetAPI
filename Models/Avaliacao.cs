namespace FriendlyPetAPI.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }

        public Local Local { get; set; }
    }
}