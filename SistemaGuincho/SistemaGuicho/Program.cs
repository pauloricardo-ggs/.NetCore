using Microsoft.Extensions.DependencyInjection;
using SistemaGuincho.Domain;
using SistemaGuincho.Domain.Operacoes;
using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;

namespace SistemaGuincho
{
    class Program
    {
        static Banco Banco = new Banco();
        static PegarDados PegarDados = new PegarDados();
        static OperacoesGuincho OperacoesGuincho = new OperacoesGuincho(PegarDados, Banco);
        static OperacoesPneu OperacoesPneu = new OperacoesPneu(PegarDados, Banco);
        
        static ServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            serviceProvider = new ServiceCollection()
                .AddScoped<IBanco, Banco>()
                .AddScoped<IMenuServico, MenuServico>()
                .AddScoped<IOperacoesGuincho, OperacoesGuincho>()
                .AddScoped<IOperacoesPneu, OperacoesPneu>()
                .AddScoped<IPegarDados, PegarDados>()
                .AddScoped<ISocorro, Socorro>()
                .AddScoped<ITrocaPneu, TrocaPneu>()
                .BuildServiceProvider();
            Loop();
        }

        private static void Loop()
        {
            ImprimirMenu();
            SelecionarMenu();
        }

        private static void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine(
                $"[{(int)Menu.AdicionarGuincho}] Adicionar guincho\n" +
                $"[{(int)Menu.AlterarStatusGuincho}] Alterar status do guincho\n" +
                $"[{(int)Menu.RemoverGuincho}] Remover guincho\n" +
                $"[{(int)Menu.ExibirGuincho}] Exibir guinchos\n" +
                $"[{(int)Menu.AtualizarEstoquePneu}] Atualizar estoque de pneus\n" +
                $"[{(int)Menu.ExibirEstoquePneu}] Exibir estoque de pneus\n" +
                $"[{(int)Menu.IniciarServico}] Iniciar serviço\n" +
                $"[{(int)Menu.Sair}] Sair"
            );
        }

        private static void SelecionarMenu()
        {
            var entrada = Console.ReadKey().KeyChar.ToString();
            bool resultado = int.TryParse(entrada, out int index);
            var Encerrar = false;

            if (!resultado) { goto RetornarAoLoop; }

            Menu menu = (Menu)index;
            Encerrar = ProcessarMenu(menu);

        RetornarAoLoop:;
            if (!Encerrar) { Loop(); }
        }

        private static bool ProcessarMenu(Menu menu)
        {
            switch (menu)
            {
                #region Adicionar Guincho
                case Menu.AdicionarGuincho:
                    OperacoesGuincho.Adicionar();
                    break;
                #endregion

                #region Alterar Status Guincho
                case Menu.AlterarStatusGuincho:
                    var sucesso = OperacoesGuincho.AlterarStatus();
                    Console.Clear();
                    if (!sucesso) { Console.WriteLine("Não foi encontrado um guincho com o id solicitado."); }
                    else { Console.WriteLine("Status alterado com sucesso."); }
                    Console.WriteLine("Pressione qualquer tecla para retornar.");
                    Console.ReadKey();
                    break;
                #endregion

                #region Remover Guincho
                case Menu.RemoverGuincho:
                    OperacoesGuincho.Remover();
                    Console.Clear();
                    Console.WriteLine("Guincho removido com sucesso.\nPressione qualquer tecla para retornar.");
                    Console.ReadKey();
                    break;
                #endregion

                #region Exibir Guincho
                case Menu.ExibirGuincho:
                    Console.Clear();
                    OperacoesGuincho.Exibir();
                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                    Console.ReadKey();
                    break;
                #endregion

                #region Atualizar Estoque Pneus
                case Menu.AtualizarEstoquePneu:
                    OperacoesPneu.AlterarQuantidade();
                    Console.Clear();
                    Console.WriteLine("Estoque atualizado com sucesso.\nPressione qualquer tecla para retornar.");
                    Console.ReadKey();
                    break;
                #endregion

                #region Exibir Estoque Pneus
                case Menu.ExibirEstoquePneu:
                    Console.Clear();
                    OperacoesPneu.Exibir();
                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                    Console.ReadKey();
                    break;
                #endregion

                #region Iniciar Servico
                case Menu.IniciarServico:
                    serviceProvider.GetService<IMenuServico>().Loop();
                    break;
                #endregion

                #region Sair
                case Menu.Sair:
                    return true;
                #endregion
            }
            return false;
        }
    }
}
