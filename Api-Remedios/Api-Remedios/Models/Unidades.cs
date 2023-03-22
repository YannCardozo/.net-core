using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using FluentValidation;
using FluentValidation.Results;

namespace Api_Remedios.Models
{
    public class Unidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }


    public class Unidades_Validador : AbstractValidator<Unidades>
    {

        public Unidades_Validador()
        {
            RuleFor(x => x.Id)
                    //se estiver preenchido 0 , not empty retorna como vazio
                    .NotNull().WithMessage("Id da Unidade precisa ser preenchido.");
            RuleFor(x => x.Nome)
                    //.NotNull().WithMessage("Nome do Usuario precisa ser preenchido")
                    .NotEmpty().WithMessage("Nome da Unidade nao pode estar em branco.")
                    .Length(4, 30).WithMessage("O nome da Unidade deve ter pelo menos 4 letras e maximo de 30 caracteres.")
                    .Matches("^[a-zA-Z ]+$").WithMessage("Nome da Unidade deve ter apenas letras.");



        }
    }


}
