namespace Api_Remedios.Models
{

    public enum Classificacao
    {
        Livre,
        Amarela,
        Vermelha,
        Preta

    }



    public class Remedios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        // public Classificacao Cor { get; set; }
        public string? Descricao { get; set; }
        public DateTime Hora_Cadastro { get; set; }
        public string? Link_Bula { get; set; }


    }

}
