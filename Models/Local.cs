namespace FriendlyPetAPI.Models
{
    public class Local
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public int CategoriaId { get; set; }
        public bool AceitaPet { get; set; }
        public string? Descricao { get; set; }

        public Categoria? Categoria { get; set; }
    }
}