using System;
using System.Collections.Generic;

namespace Lista_de_Contatos
{
    class Program
    {
        private static int opcao;
        private static List<Contato> contatos = new List<Contato>();
        static void Main(string[] args)
        {   
            MostrarOpcoes();
        }

        private static void MostrarOpcoes()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Digite uma opção:");
            Console.WriteLine("Digite 1 para listar os Contatos");
            Console.WriteLine("Digite 2 para remover um Contato");
            Console.WriteLine("Digite 3 para adicionar um Contato");
            Console.WriteLine("Digite 4 para alterar um Contato");
            Console.WriteLine("Digite 5 para Sair");
            Console.WriteLine("**********************************");
            Int32.TryParse(Console.ReadLine().ToString(), out opcao);

            switch (opcao)
            {
                case 1:
                    ListarContatos();
                    MostrarOpcoes();
                    break;
                case 2:
                    Console.WriteLine("Por favor insira o Id do contato que deseja remover:");
                    int itemRemover;
                    Int32.TryParse(Console.ReadLine(), out itemRemover);
                    RemoverContato(itemRemover);
                    MostrarOpcoes();
                    break;
                case 3:
                    AdicionarContato();
                    MostrarOpcoes();
                    break;
                case 4:
                    Console.WriteLine("Por favor insira o Id do contato que deseja alterar:");
                    int itemAlterar;
                    Int32.TryParse(Console.ReadLine(), out itemAlterar);
                    AlterarContato(itemAlterar);
                    MostrarOpcoes();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Por favor digite a opção correta");
                    MostrarOpcoes();
                    break;
            }
        }
        private static void ListarContatos()
        {
            foreach(Contato cont in contatos)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {cont.Id} ");
                Console.WriteLine($"Nome: {cont.Nome} ");
                Console.WriteLine($"Telefone: {cont.Telefone} ");
                Console.WriteLine($"Email: {cont.Email} ");
                Console.WriteLine($"Idade: {cont.Idade} ");
                Console.WriteLine($"DataCadastro: {cont.DataCadastro} ");
            }
            Console.WriteLine("----------------------------------");
        }
        private static void RemoverContato(int Id)
        {
            contatos.Remove(contatos.Find(x => x.Id==Id));
        }

        private static void AdicionarContato()
        {
            int Id;
            int Idade;

            Console.WriteLine("Informe um Número Identificador:");
            Int32.TryParse(Console.ReadLine(), out Id);

            Console.WriteLine("Informe seu Nome:");
            string Nome = Console.ReadLine();

            Console.WriteLine("Informe seu Telefone:");
            string Telefone = Console.ReadLine();

            Console.WriteLine("Informe seu Email:");
            string Email = Console.ReadLine();

            Console.WriteLine("Informe sua Idade:");
            Int32.TryParse(Console.ReadLine(), out Idade);

            contatos.Add(new Contato(Id, Nome, Telefone, Email, Idade, DateTime.Now));
        }

        private static void AlterarContato(int Id)
        {
            if (!contatos.Exists(x => x.Id==Id))
            {
                Console.WriteLine("Este contato não existe!");
                return;
            }

            int Idade;
            Contato contato = contatos.Find(x => x.Id==Id);

            Console.WriteLine("**********************************");
            Console.WriteLine("Escolha o que deseja alterar:");
            Console.WriteLine("Digite 1 para alterar o Nome");
            Console.WriteLine("Digite 2 para alterar o Telefone");
            Console.WriteLine("Digite 3 para alterar o Email");
            Console.WriteLine("Digite 4 para alterar a Idade");
            Console.WriteLine("Digite 5 para retornar ao menu inicial");
            Console.WriteLine("**********************************");
            Int32.TryParse(Console.ReadLine().ToString(), out opcao);

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe seu Nome:");
                    contato.Nome = Console.ReadLine();
                    AlterarContato(Id);
                    break;
                case 2:
                    Console.WriteLine("Informe seu Telefone:");
                    contato.Telefone = Console.ReadLine();
                    AlterarContato(Id);
                    break;
                case 3:
                    Console.WriteLine("Informe seu Email:");
                    contato.Email = Console.ReadLine();
                    AlterarContato(Id);
                    break;
                case 4:
                    Console.WriteLine("Informe sua Idade:");
                    Int32.TryParse(Console.ReadLine(), out Idade);
                    contato.Idade = Idade;
                    AlterarContato(Id);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Por favor digite a opção correta");
                    break;
            }    

            contatos.Remove(contatos.Find(x => x.Id==Id));
            contatos.Add(contato);
        }
    }
}
