using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APagarReceber.Models
{
    public enum EstadoLancamento { 
        [Display(Name = "Previsto")] 
        Previsto = 0, 
        [Display(Name = "Realizado")] 
        Realizado = 1, 
        [Display(Name = "Conciliado")]
        Conciliado = 2, 
        [Display(Name = "Cancelado")] 
        Cancelado = 9}

    public class Lancamento
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal Valor { get; set; } = decimal.Zero;
        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }
        [MaxLength(200)]
        [DisplayName("Observação")]
        public string? Observacao { get; set; }
        public Conta? Conta { get; set; }
        [DisplayName("Conta")]
        public int? ContaId { get; set; }
        public EstadoLancamento Estado { get; set; } = EstadoLancamento.Previsto;
    }

}
