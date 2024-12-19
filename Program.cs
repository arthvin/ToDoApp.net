using System;
using System.Collections.Generic;

namespace ToDoApp
{
    class Program
    {
        static List<string> tarefas = new List<string>();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("====== Aplicação de Tarefas ======");
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Listar Tarefas");
                Console.WriteLine("3. Editar Tarefa");
                Console.WriteLine("4. Excluir Tarefa");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        ListarTarefas();
                        break;
                    case "3":
                        EditarTarefa();
                        break;
                    case "4":
                        ExcluirTarefa();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AdicionarTarefa()
        {
            Console.Clear();
            Console.Write("Digite a descrição da tarefa: ");
            string tarefa = Console.ReadLine();
            tarefas.Add(tarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!");
            Console.ReadKey();
        }

        static void ListarTarefas()
        {
            Console.Clear();
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
            }
            else
            {
                Console.WriteLine("==== Lista de Tarefas ====");
                for (int i = 0; i < tarefas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tarefas[i]}");
                }
            }
            Console.ReadKey();
        }

        static void EditarTarefa()
        {
            Console.Clear();
            ListarTarefas();

            Console.Write("Digite o número da tarefa que deseja editar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tarefas.Count)
            {
                Console.Write("Digite a nova descrição da tarefa: ");
                tarefas[indice - 1] = Console.ReadLine();
                Console.WriteLine("Tarefa editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
            Console.ReadKey();
        }

        static void ExcluirTarefa()
        {
            Console.Clear();
            ListarTarefas();

            Console.Write("Digite o número da tarefa que deseja excluir: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tarefas.Count)
            {
                tarefas.RemoveAt(indice - 1);
                Console.WriteLine("Tarefa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
            Console.ReadKey();
        }
    }
}
