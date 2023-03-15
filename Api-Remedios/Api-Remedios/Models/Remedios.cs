namespace Api_Remedios.Models
{

    /*

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
         public string Codigo_ANS {get;set;}
         public DateTime Data_lote { get; set; }
         public string Vaga_lote { get; set; }
         public DateTime Data_deposito { get; set; }
         public Tipo Tipo_remedio { get; set; }
         public Classificacao Cor { get; set; }
         public DateTime Hora_Cadastro { get; set; }
         public string Img_Remedio { get; set; }
         public string? Link_Bula { get; set; }


     }
    */
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
        public string Vaga_lote { get; set; }
        public DateTime Data_deposito { get; set; }
        public Tipo Tipo_remedio { get; set; }
        public Classificacao Cor { get; set; }
        public DateTime Hora_Cadastro { get; set; }
        public string Img_Remedio { get; set; }
        public string? Link_Bula { get; set; }
        public Regiao Nome_Regiao { get; set; }
        public Unidades Nome_Unidade { get; set; }

    }
}
