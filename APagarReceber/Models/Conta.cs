using System.ComponentModel.DataAnnotations;

namespace APagarReceber.Models
{
    public enum TipoCaixa { Dinheiro = 0, ContaCorrente = 1, Investimento = 2}

    public class Conta
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Descricao { get; set; }
        public TipoCaixa Caixa { get; set; } = TipoCaixa.Dinheiro; 
        public bool Ativo { get; set; } = true;

        public ICollection<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
    }
}
