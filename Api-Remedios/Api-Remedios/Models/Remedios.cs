using Microsoft.Identity.Client;
using FluentValidation;
using FluentValidation.Results;


namespace Api_Remedios.Models
{

    public enum Classificacao
    {
        Livre,
        Amarela,
        Vermelha,
        Preta

    }
    public enum Tipo
    {
        Fitoterápico,
        Homeopático,
        Similar,
        Genérico,
        Referência,
        Manipulado,
        Outros
    }



    public class Remedios 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Codigo_ANS { get; set; }
        public DateTime Data_lote { get; set; }
        public string? Vaga_lote { get; set; }
        public DateTime Data_deposito { get; set; }
        public Tipo Tipo_remedio { get; set; }
        public Classificacao Cor { get; set; }
        public DateTime Hora_Cadastro { get; set; }
        public string? Img_Remedio { get; set; }
        public string? Link_Bula { get; set; }
        public Regiao? Nome_Regiao { get; set; }
        public Unidades? Nome_Unidade { get; set; }

    }
    public class Remedios_Validador : AbstractValidator<Remedios>
    {
        public Remedios_Validador()
            {
                RuleFor(x => x.Id)
                            //se estiver preenchido 0 , not empty retorna como vazio
                            .NotNull().WithMessage("Id precisa ser preenchido.");
                RuleFor(x => x.Nome)
                            //.NotNull().WithMessage("Nome do Usuario precisa ser preenchido")
                            .NotEmpty().WithMessage("Nome do medicamento nao pode estar em branco.")
                            .Length(4, 30).WithMessage("O nome do medicamento deve ter pelo menos 4 letras e maximo de 30 caracteres.")
                            .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Nome do medicamento nao pode ter simbolos especiais.");
                RuleFor(x => x.Codigo)
                             //.NotNull().WithMessage("LOJAID precisa ser preenchido")
                             //.NotEmpty().WithMessage("LOJAID nao pode estar em branco")
                             .NotNull().WithMessage("Codigo do medicamento precisa ser preenchido.")
                             .NotEmpty().WithMessage("Codigo do medicamento nao pode estar em branco.");
                            //.NotEmpty().WithMessage("Nome do Usuario nao pode estar em branco")
                            //.Length(4, 30).WithMessage("O nome do remedio deve ter pelo menos 4 letras e maximo de 30 caracteres.")
                            //.Matches("^[0-9]+$").WithMessage("Nome do segurado nao pode ter simbolos especiais");
                RuleFor(x => x.Codigo_ANS)
                             .NotNull().WithMessage("Codigo_ANS precisa ser preenchid.o")
                             .NotEmpty().WithMessage("Codigo_ANS do medicamento nao pode estar em branco.")
                             .Length(3, 18).WithMessage("O Codigo_ANS do medicamento deve ter pelo menos 3 letras e maximo de 18 caracteres.")
                             .Matches("^[0-9]+$").WithMessage("Codigo_ANS do medicamento nao pode ter simbolos especiais");
                RuleFor(x => x.Data_lote)
                             .NotNull().WithMessage("Data do lote precisa ser preenchido.")
                             .NotEmpty().WithMessage("Data do lote do medicamento nao pode estar em branco.")
                             .Must(x=> x <= DateTime.Now).WithMessage("Data do lote precisar ter uma data menor que a de agora.");
                RuleFor(x => x.Vaga_lote)
                            //.NotNull().WithMessage("Nome do Usuario precisa ser preenchido")
                            //.NotEmpty().WithMessage("Vaga de armazenamento nao pode estar em branco.")
                            .Length(6, 30).WithMessage("Vaga de armazenamento deve ter pelo menos 6 caracteres e maximo de 30 caracteres.")
                            .Matches("^[a-zA-Z0-9]+$").WithMessage("Vaga de armazenamento nao pode ter simbolos especiais.");
                RuleFor(x => x.Data_deposito)
                             //.NotNull().WithMessage("Data de deposito precisa ser preenchido.")
                             .NotEmpty().WithMessage("Data de deposito do medicamento nao pode estar em branco.")
                             .Must(x => x <= DateTime.Now).WithMessage("Data de deposito precisar ter uma data menor que a de agora.");
                RuleFor(x => x.Tipo_remedio)
                             //.NotNull().WithMessage("Data de deposito precisa ser preenchido.")
                             .NotEmpty().WithMessage("Tipo de remedio nao pode estar em branco.");
                RuleFor(x => x.Cor)
                             //.NotNull().WithMessage("Data de deposito precisa ser preenchido.")
                             .NotEmpty().WithMessage("Tipo de remedio nao pode estar em branco.");
                RuleFor(x => x.Hora_Cadastro)
                             .NotNull().WithMessage("Hora do cadastro precisa ser preenchido.")
                             .NotEmpty().WithMessage("Hora do cadastro nao pode estar em branco.")
                             .Must(x => x <= DateTime.Now).WithMessage("Hora do cadastro precisa ser a hora atual.");
                RuleFor(x => x.Nome_Regiao)
                             .NotNull().WithMessage("Nome da regiao precisa ser preenchido.")
                             .NotEmpty().WithMessage("Nome da regiao nao pode estar em branco.");
                RuleFor(x => x.Nome_Unidade)
                             .NotNull().WithMessage("Nome da unidade precisa ser preenchido.")
                             .NotEmpty().WithMessage("Nome da unidade nao pode estar em branco.");
            



        }
    }
        public class CustomLanguageManager : FluentValidation.Resources.LanguageManager
        {
            public CustomLanguageManager()
            {
                AddTranslation("pt-br", "NotNullValidator", "'{PropertyName}' e necessario.");
            }
        }
}
