using FluentValidation;


namespace Api_Remedios.Models
{
	public class Cep
	{
		public int Id { get; set; }
		public string cep { get; set; }
		public string cidade { get; set; }
		public string logradouro { get; set; }
		public string bairro { get; set; }
		public int numero { get; set; }
		public string uf { get; set; }

	}

	public class Cep_Validador : AbstractValidator<Cep>
	{
		public Cep_Validador()
		{
			RuleFor(x => x.Id)
						//se estiver preenchido 0 , not empty retorna como vazio
						.NotNull().WithMessage("Id do cep precisa ser preenchido.");
			RuleFor(x => x.cep)
						.NotNull().WithMessage("Cep precisa ser preenchido.")
						.NotEmpty().WithMessage("Cep nao pode estar em branco.")
						.Length(8, 8).WithMessage("Cep deve ter 8 numeros.")
						.Matches("^[0-9]+$").WithMessage("Cep não deve ter simbolos especiais.");
			RuleFor(x => x.cidade)
						.NotEmpty().WithMessage("Cidade nao pode estar em branco.")
						.Length(5, 30).WithMessage("Cidade deve ter pelo menos 5 letras e maximo de 30 letras.")
						.Matches("^[a-zA-Z ]+$").WithMessage("Cidade deve conter apenas letras");
			RuleFor(x => x.logradouro)
						 .NotEmpty().WithMessage("Logradouro nao pode estar em branco.")
						 .Length(7, 8).WithMessage("Logradouro deve ter pelo menos 7 numeros e maximo de 30.")
						 .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Logradouro deve conter apenas letras e numeros.");
			RuleFor(x => x.bairro)
						 .NotEmpty().WithMessage("bairro nao pode estar em branco.")
						 .Length(7, 30).WithMessage("bairro deve ter pelo menos 7 numeros e maximo de 30.")
						 .Matches("^[a-zA-Z0-9 ]+$").WithMessage("bairro pode conter apenas letras e numeros.");
			//RuleFor(x => x.numero)
			//
			RuleFor(x => x.uf)
						 .NotEmpty().WithMessage("UF nao pode estar em branco.")
						 .Length(2, 2).WithMessage("UF deve conter apenas letras.")
						 .Matches("^[a-zA-Z]+$").WithMessage("UF deve conter apenas letras.");
		}
	}


}
