using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoApp
{
    public class Tarefa
    {
        public string Descricao { get; set; }
        public string Prioridade { get; set; } 
    }

    class Program
    {
        static List<Tarefa> tarefas = new List<Tarefa>();
        const string arquivoTarefas = "tarefas.json";

        static void Main(string[] args)
        {
            CarregarTarefas();

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
                        SalvarTarefas();
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
            string descricao = Console.ReadLine();

            Console.Write("Escolha a prioridade (Baixa, Média, Alta): ");
            string prioridade = Console.ReadLine();

            Tarefa novaTarefa = new Tarefa { Descricao = descricao, Prioridade = prioridade };
            tarefas.Add(novaTarefa);

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
                    var tarefa = tarefas[i];
                    Console.WriteLine($"{i + 1}. {tarefa.Descricao} [Prioridade: {tarefa.Prioridade}]");
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
                tarefas[indice - 1].Descricao = Console.ReadLine();

                Console.Write("Digite a nova prioridade (Baixa, Média, Alta): ");
                tarefas[indice - 1].Prioridade = Console.ReadLine();

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

        static void SalvarTarefas()
        {
            string json = JsonSerializer.Serialize(tarefas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(arquivoTarefas, json);
            Console.WriteLine("Tarefas salvas no arquivo.");
        }

        static void CarregarTarefas()
        {
            if (File.Exists(arquivoTarefas))
            {
            try
            {
                string json = File.ReadAllText(arquivoTarefas);

                if (!string.IsNullOrWhiteSpace(json)) 
                {
                    tarefas = JsonSerializer.Deserialize<List<Tarefa>>(json) ?? new List<Tarefa>();
                }
                else
                {
                    tarefas = new List<Tarefa>(); 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar as tarefas: {ex.Message}");
            tarefas = new List<Tarefa>(); 
        }
            }
        else
            {
                tarefas = new List<Tarefa>(); 
            }
        }

    }
}
