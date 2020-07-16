using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OperacaoBancaria.Application.ViewModels
{
    public class RegistrarContaCorrenteViewModel
    {
        public RegistrarContaCorrenteViewModel()
        {
            Id = Guid.NewGuid();
            NumeroConta = new Random().Next(1000, 5000);
        }

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        [JsonIgnore]
        public long NumeroConta { get; set; }
    }
}
