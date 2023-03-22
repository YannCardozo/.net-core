using FluentValidation;
using FluentValidation.Results;

namespace Api_Remedios.Models

{
    public class Regiao
    {

        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Regiao_Validador : AbstractValidator<Regiao>
    {

        public Regiao_Validador()
        {
            RuleFor(x => x.Id)
                    //se estiver preenchido 0 , not empty retorna como vazio
                    .NotNull().WithMessage("Id da Regiao precisa ser preenchido.");
            RuleFor(x => x.Nome)
                    //.NotNull().WithMessage("Nome do Usuario precisa ser preenchido")
                    .NotEmpty().WithMessage("Nome da Regiao nao pode estar em branco.")
                    .Length(4, 30).WithMessage("O nome da Regiao deve ter pelo menos 4 letras e maximo de 30 caracteres.")
                    .Matches("^[a-zA-Z ]+$").WithMessage("Nome da Regiao deve ter apenas letras.");



        }
    }
}
