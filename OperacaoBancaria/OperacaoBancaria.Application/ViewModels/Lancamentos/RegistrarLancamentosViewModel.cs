using OperacaoBancaria.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OperacaoBancaria.Application.ViewModels.Lancamentos
{
    public class RegistrarLancamentosViewModel
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        public TipoOperacao TipoOperacao { get; set; }

        [Required(ErrorMessage = "O valor é requerido")]
        public decimal Valor { get; set; }
        [JsonIgnore]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "O numero da conta é requerido")]
        public long NumeroConta { get; set; }

        public RegistrarLancamentosViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
