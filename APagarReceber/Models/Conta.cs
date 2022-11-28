using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APagarReceber.Models
{
    public enum TipoCaixa { 
        [Display(Name = "Dinheiro")] 
        Dinheiro = 0,
        [Display(Name = "Conta Corrente")]
        ContaCorrente = 1,
        [Display(Name = "Investimento")]
        Investimento = 2}

    public class Conta
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }
        public TipoCaixa Caixa { get; set; } = TipoCaixa.Dinheiro; 
        public bool Ativo { get; set; } = true;

        public ICollection<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
    }
}
