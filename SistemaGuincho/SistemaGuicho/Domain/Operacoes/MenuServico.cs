using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;

namespace SistemaGuincho.Domain.Operacoes
{
    class MenuServico : IMenuServico
    {
        private readonly ITrocaPneu TrocaPneu;
        private readonly ISocorro Socorro;
        private readonly IPegarDados PegarDados;
        private readonly IOperacoesGuincho OperacoesGuincho;
        private readonly IBanco Banco;

        public MenuServico(
            ITrocaPneu TrocaPneu,
            ISocorro Socorro,
            IPegarDados PegarDados,
            IOperacoesGuincho OperacoesGuincho,
            IBanco Banco)
        {
            this.TrocaPneu = TrocaPneu;
            this.Socorro = Socorro;
            this.PegarDados = PegarDados;
            this.OperacoesGuincho = OperacoesGuincho;
            this.Banco = Banco;
        }

        public void Loop()
        {
            ImprimirMenu();
            SelecionarMenu();
        }

        private void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine(
                $"[{(int)MenuOpcaoServico.AcionarGuincho}] Acionar guincho\n" +
                $"[{(int)MenuOpcaoServico.TrocaDePneu}] Troca de pneu\n" +
                $"[{(int)MenuOpcaoServico.Voltar}] Voltar"
            );
        }

        private void SelecionarMenu()
        {
            var entrada = Console.ReadKey().KeyChar.ToString();
            bool resultado = int.TryParse(entrada, out int index);
            var Encerrar = false;

            if (!resultado) { goto RetornarAoLoop; }

            MenuOpcaoServico menu = (MenuOpcaoServico)index;
            Encerrar = ProcessarMenu(menu);

        RetornarAoLoop:;
            if (!Encerrar) { Loop(); }
        }

        private bool ProcessarMenu(MenuOpcaoServico menu)
        {
            Console.Clear();
            switch (menu)
            {
                case MenuOpcaoServico.AcionarGuincho:
                    AcionarGuincho();
                    break;

                case MenuOpcaoServico.TrocaDePneu:
                    TrocarPneu();
                    break;

                case MenuOpcaoServico.Voltar:
                    return true; ;
            }
            return false;
        }

        private void TrocarPneu()
        {
            ImprimirMensagemVeiculo();
            TrocaPneu.RealizarTroca(PegarDados.PegarVeiculo());
            ImprimirMensagemVoltar();
        }

        private void AcionarGuincho()
        {
            ImprimirMensagemVeiculo();
            Socorro.CriarSocorro(PegarDados.PegarVeiculo(), OperacoesGuincho, Banco).RealizarSocorro();
            ImprimirMensagemVoltar();
        }

        private void ImprimirMensagemVeiculo()
        {
            Console.WriteLine("Insira os dados do veículo\nPressione qualquer tecla para prosseguir");
            Console.ReadKey();
        }

        private void ImprimirMensagemVoltar()
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
