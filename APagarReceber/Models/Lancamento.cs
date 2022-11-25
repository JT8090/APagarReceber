using System.ComponentModel.DataAnnotations;

namespace APagarReceber.Models
{
    public enum Estadolancamento { Previsto = 0, Realizado = 1, Canciliado = 2, Cancelado = 9}

    public class Lancamento
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; } = decimal.Zero;
        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }
        [MaxLength(200)]
        public string? Observacao { get; set; }
        [Required]
        public Conta? Conta { get; set; }
        public Estadolancamento Estado { get; set; } = Estadolancamento.Previsto;
    }
}
