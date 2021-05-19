using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGuincho.Domain.Produtos
{
    public class Guincho : GuinchoAbstrato
    {
        public Guincho(Porte porte, Status status) : base(porte, status) { }
    }
}
