using FluentValidation;
using OperacaoBancaria.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace OperacaoBancaria.Domain.ContaCorrente.Model
{
    public class ContaCorrente : Entity<ContaCorrente>
    {
        public ContaCorrente()
        {

        }

        public long NumeroConta { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public List<Lancamentos.Model.Lancamentos> Lancamentos { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidarCpf();
            ValidarNumeroConta();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do cliente precisa ter entre 2 e 100 caracteres");
        }

        private void ValidarCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF do cliente precisa ser fornecido")
                .MaximumLength(11).WithMessage("O CPF do cliente precisa ter no máximo 11 caracteres");
        }

        private void ValidarNumeroConta()
        {
            RuleFor(c => c.NumeroConta)
                .NotNull().WithMessage("O Numero da Conta precisa ser fornecido")
                .GreaterThan(0).WithMessage("O Numero da Conta inválido");
        }

        public static class ContaCorrenteFactory
        {
            public static ContaCorrente NovoConta(string nome, string cpf, long numeroConta)
            {
                var novaConta = new ContaCorrente
                {
                    NumeroConta = new Random().Next(1000, 5000),
                    Cpf = cpf,
                    Nome = nome
                };

                return novaConta;
            }
        }
    }
}
