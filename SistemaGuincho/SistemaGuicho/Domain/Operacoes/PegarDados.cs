using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;

namespace SistemaGuincho.Domain.Operacoes
{
    class PegarDados : IPegarDados
    {
        public int PegarId()
        {
            Console.Clear();
            Console.Write("Id: ");
            return EntradaUsuarioInteiroPositivo();
        }
        public int PegarAro()
        {
            Console.Clear();
            Console.Write("Aro: ");
            return EntradaUsuarioInteiroPositivo();
        }
        public int PegarQuantidade()
        {
            Console.Clear();
            Console.Write("Quantidade: ");
            return EntradaUsuarioInteiro();
        }
        public string PegarModelo()
        {
            Console.Clear();
            Console.Write("Modelo: ");
            return Console.ReadLine();
        }
        public string PegarPlaca()
        {
            Console.Clear();
            Console.Write("Placa: ");
            return Console.ReadLine();
        }
        public Porte PegarPorte()
        {
        Loop:;
            Console.Clear();
            Console.WriteLine(
                "Porte:\n" +
                "[1] Pequeno\n" +
                "[2] Médio\n" +
                "[3] Grande");
            var entrada = Console.ReadKey().KeyChar.ToString();
            var resultado = int.TryParse(entrada, out int index);

            if (!resultado || resultado && (index <= 0 || index > 3)) { goto Loop; }
            return (Porte)index;
        }
        public Status PegarStatus()
        {
        Loop:;
            Console.Clear();
            Console.WriteLine(
                "Status:\n" +
                "[1] Disponível\n" +
                "[2] Indisponível");
            var entrada = Console.ReadKey().KeyChar.ToString();
            bool resultado = int.TryParse(entrada, out int index);

            if (!resultado || resultado && (index <= 0 || index > 2)) { goto Loop; }
            return (Status)index;
        }
        public VeiculoAbstrato PegarVeiculo()
        {
            return new Veiculo(PegarPorte(), PegarAro(), PegarModelo(), PegarPlaca());
        }
        public GuinchoAbstrato PegarGuincho()
        {
            return new Guincho(PegarPorte(), PegarStatus());
        }

        private int EntradaUsuarioInteiro()
        {
        resetar:;
            var entrada = Console.ReadLine();
            var resultado = int.TryParse(entrada, out var saida);
            if (!resultado) { Console.Write("O valor deve ser um número inteiro: "); goto resetar; }
            return saida;
        }
        private int EntradaUsuarioInteiroPositivo()
        {
        resetar:;
            var entrada = EntradaUsuarioInteiro();
            if (entrada < 0) { Console.Write("O valor deve ser maior ou igual a 0: "); goto resetar; }
            return entrada;
        }
    }
}
