using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace Menu
{
    class Program
    {
        static List<string> proprietarios = new List<string>();
        static List<string> cpfs = new List<string>();
        static List<double> saldo = new List<double>();
        static int option;
        static int OpcoesParaVerificarConta;


        //Função principal
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------- Seja bem vindo ao Banco XP ---------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();


            Console.Write("Olá, informe o seu nome: ");
            string name = Console.ReadLine();

            Console.WriteLine($"\n{name}, bem vindo ao Banco XP!");
            Console.WriteLine($"\nEscolha uma das opções fornecidas abaixo:");
            Console.WriteLine();

            do
            {
                MostrarOpcoes();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CriarNovoUsuario();
                        break;
                    case 2:
                        DeletarUsuario();
                        break;
                    case 3:
                        MostrarTodosUsuarios();
                        break;
                    case 4:
                        MostrarOpcoesdoUsuario();
                        break;

                }
            } while (option != 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------  Obrigado! ---------------------------------- ");
            Console.ResetColor();
        }

        //Função com as opções
        static void MostrarOpcoes()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("1 - Cadastrar um novo usuário");
            Console.ResetColor();

            Console.WriteLine("2 - Deletar um usuário");
            Console.ResetColor();

            Console.WriteLine("3 - Mostrar todas as contas registradas");
            Console.ResetColor();

            Console.WriteLine("4 - Conta do usuário");
            Console.ResetColor();

            Console.WriteLine("0 - Sair do programa");
            Console.WriteLine();

            Console.Write("Digite a opção desejada: ");
        }

        static void ErrorMessageInput()
        {
            Console.WriteLine("------------------------ O VALOR INFORMADO NÃO É VÁLIDO ------------------------");
        }

        //OPÇÃO 1 - Criando um novo usuário
        static void CriarNovoUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Digite o nome do proprietário: ");
            string proprietario = Console.ReadLine();
            proprietarios.Add(proprietario);


            Console.Write("Digite o CPF (Apenas os números): ");
            string cpf = Console.ReadLine();
            cpfs.Add(cpf);

            Console.Write("Digite o seu saldo inicial: R$");
            double saldoInicial = double.Parse(Console.ReadLine());
            saldo.Add(saldoInicial);

            Console.Write("Deseja confirmar o cadastro? (s/n) ");
            string confirmacao = Console.ReadLine().ToLower();

            if (confirmacao == "n")
            {
                proprietarios.RemoveAt(proprietarios.Count - 1);
                cpfs.RemoveAt(cpfs.Count - 1);
                saldo.RemoveAt(saldo.Count - 1);
                Console.WriteLine("O cadastro foi cancelado com sucesso");
            }
            Console.WriteLine("O usuário foi cadastrado com sucesso!");
        }

        //OPÇÃO 2 - Deletando o usuário
        static void DeletarUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Informe o CPF do proproetário: ");
            string CPFParaDeletar = Console.ReadLine();

            int IndiceParaEncontrar = cpfs.IndexOf(CPFParaDeletar);

            if (IndiceParaEncontrar == -1)
            {
                Console.WriteLine();
                ErrorMessageInput();
            }
            else
            {
                proprietarios.RemoveAt(IndiceParaEncontrar);
                cpfs.RemoveAt(IndiceParaEncontrar);
                saldo.RemoveAt(IndiceParaEncontrar);

                Console.WriteLine();
                Console.WriteLine("O usuário foi deletado com sucesso!");
            }
            Console.ResetColor();

        }

        //OPÇÃO 3 - Mostrar todas as contas registradas
        static void MostrarTodosUsuarios()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            int IndiceDaLista = proprietarios.Count();
            Console.WriteLine($"Total de contas registradas no sistema: {IndiceDaLista} ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            for (int i = 0; i < IndiceDaLista; i++)
            {
                Console.WriteLine($"     {proprietarios[i]}");
                Console.WriteLine($"     {cpfs[i]}");
                Console.WriteLine($"     {saldo[i]}");
                Console.WriteLine("----------------------------------------------------------------------------");

            }
            Console.ResetColor();
        }


        //OPÇÃO 6 - Conta corrente do usuário
        static void MostrarOpcoesdoUsuario()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  1 - Sacar  ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  2 - Depositar  ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  3 - Transferir  ");
                Console.ResetColor();

                Console.WriteLine("  0 - Deseja encerrar o programa   ");
                OpcoesParaVerificarConta = int.Parse(Console.ReadLine());

                switch (OpcoesParaVerificarConta)
                {
                    case 1:
                        sacar();
                        break;
                    case 2:
                        depositar();
                        break;
                    case 3:
                        transferir();
                        break;
                }
            } while (OpcoesParaVerificarConta != 0);
            Console.WriteLine("Encerrado o procedimento realizado na conta do usuário.");
        }

        //1 - sacar
        static void sacar()
        {
            Console.Write("Insira seu CPF para prosseguir a ação: ");
            string RetirarCPF = Console.ReadLine();

            int IndiceParaEncontrar = cpfs.IndexOf(RetirarCPF);
            if (IndiceParaEncontrar == -1)
            {
                Console.WriteLine("O CPF informado é inválido.");
            }
            else
            {
                Console.Write("Informe o valor que deseja sacar: R$");
                double ValorParaRetirar = double.Parse(Console.ReadLine());
                string TentarNovamenteOuNao;

                while (true)
                {
                    if (ValorParaRetirar > saldo[IndiceParaEncontrar])
                    {
                        Console.WriteLine("Não há saldo o sulficiente");
                        Console.WriteLine("Você gostaria de tentar outro valor? (s/n) ");
                        TentarNovamenteOuNao = Console.ReadLine();
                    }
                    else
                    {
                        saldo[IndiceParaEncontrar] -= ValorParaRetirar;
                        Console.WriteLine($"O valor foi sacado com sucesso");
                        Console.WriteLine($"O seu saldo atual é de: R${saldo[IndiceParaEncontrar]:F2}");
                        TentarNovamenteOuNao = "n";
                    }
                    if (TentarNovamenteOuNao == "s")
                    {
                        Console.Write("Informe o valor desejado: R$");
                        ValorParaRetirar = double.Parse(Console.ReadLine().ToLower());
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        //2 - depositar
        static void depositar()
        {
            Console.Write("Insira o seu CPF para continuar: ");
            string CPFDeposito = Console.ReadLine();

            int IndiceParaEncontrar = cpfs.IndexOf(CPFDeposito);
            if (IndiceParaEncontrar == -1)
            {
                Console.WriteLine("O CPF informado está inválido.");
            }
            else
            {
                Console.Write("Informe o valor: R$");
                double ValorParaDepositar = double.Parse(Console.ReadLine());
                string TentarNovamenteOuNao;

                while (true)
                {
                    if (ValorParaDepositar > saldo[IndiceParaEncontrar])
                    {
                        Console.WriteLine("Não há saldo o sulficiente");
                        Console.WriteLine("Gostaria de tentar outro valor? (s/n) ");
                        TentarNovamenteOuNao = Console.ReadLine();
                    }
                    else
                    {
                        saldo[IndiceParaEncontrar] += ValorParaDepositar;
                        Console.WriteLine($"Depositado com sucesso");
                        Console.WriteLine($"O seu saldo atual é de: R${saldo[IndiceParaEncontrar]:F2}");
                        TentarNovamenteOuNao = "n";
                    }
                    if (TentarNovamenteOuNao == "s")
                    {
                        Console.Write("Informe o valor desejado: R$");
                        ValorParaDepositar = double.Parse(Console.ReadLine().ToLower());
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        //3 - transferir
        static void transferir()
        {
            Console.Write("Insira o seu CPF para continuar: ");
            string CPFParaTransferencia = Console.ReadLine();
            int IndicedoUsuario1 = cpfs.IndexOf(CPFParaTransferencia);
            if (IndicedoUsuario1 == -1)
            {
                Console.WriteLine("O CPF informado está inválido.");
            }
            else
            {
                Console.Write("Insira o CPF do Receptor: ");
                string CPFParaTransferencia2 = Console.ReadLine();
                int IndicedoUsuario2 = cpfs.IndexOf(CPFParaTransferencia2);
                if (IndicedoUsuario2 == -1)
                {
                    Console.WriteLine("O usuario informado não foi localizado");
                }

                Console.Write("Qual o valor desejado: R$");
                double ValorParaTransferencia = double.Parse(Console.ReadLine());
                string TentarNovamenteOuNao;

                while (true)
                {
                    if (ValorParaTransferencia > saldo[IndicedoUsuario1])
                    {
                        Console.WriteLine("Não há saldo o sulficiente");
                        Console.WriteLine("Gostaria de tentar outro valor? (s/n) ");
                        TentarNovamenteOuNao = Console.ReadLine().ToLower();
                    }
                    else
                    {
                        saldo[IndicedoUsuario1] -= ValorParaTransferencia;
                        saldo[IndicedoUsuario2] += ValorParaTransferencia;
                        Console.WriteLine($"Transferido com sucesso");
                        Console.WriteLine($"O seu saldo atual é de: R${saldo[IndicedoUsuario1]:F2}");
                        Console.WriteLine($"O saldo atual do (a) {proprietarios[IndicedoUsuario2]} corresponde a R${saldo[IndicedoUsuario2]:F2}");
                        TentarNovamenteOuNao = "n";
                    }
                    if (TentarNovamenteOuNao == "s")
                    {
                        Console.Write("Informe o valor desejado: R$");
                        ValorParaTransferencia = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}

