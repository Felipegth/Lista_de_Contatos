using System;


namespace Lista_de_Contatos
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }

        public Contato(int Id, string Nome, string Telefone, string Email, int Idade, DateTime DataCadastro)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Telefone = Telefone;
            this.Email = Email;
            this.Idade = Idade;
            this.DataCadastro = DataCadastro;
        }
    }
}