using SistemaGuincho.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGuincho.Domain.Produtos
{
    public class Pneu : PneuAbstrato
    {
        public Pneu(int aro, int quantidade) : base(aro, quantidade) { }
    }
}
