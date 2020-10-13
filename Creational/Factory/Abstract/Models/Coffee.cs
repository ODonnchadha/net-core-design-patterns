﻿using Creational.Factory.Abstract.Interfaces;

namespace Creational.Factory.Abstract.Models
{
    internal class Coffee : IBeverage
    {
        private int amount;
        public Coffee(int amount) => this.amount = amount;
        public string Consume() => $"{amount} {this.GetType().Name}";
    }
}
