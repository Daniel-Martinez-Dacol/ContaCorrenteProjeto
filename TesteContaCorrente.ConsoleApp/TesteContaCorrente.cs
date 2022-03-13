using System;

namespace ProjetoContaCorrente.ConsoleApp
{
    internal class TesteContaCorrente
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente();
            ContaCorrente conta2 = new ContaCorrente();

            conta1.numeroDaContaCorrente = 1;
            conta1.saldo = 20000;
            conta1.limite = 10000;
            conta1.ehEspecial = false;
            conta1.movimentacoes = new Movimentacoes[10];
            

            conta2.numeroDaContaCorrente = 2;
            conta2.saldo = 15000;
            conta2.limite = 8000;
            conta2.ehEspecial = false;
            conta2.movimentacoes = new Movimentacoes[10];

            conta1.Saque(1000);
            conta2.Saque(5000);

            conta1.Deposito(3000);
            conta2.Deposito(2000);

            conta1.Transferencia(conta2, 1000);

            conta1.Extrato();
            conta2.Extrato();

            Console.ReadLine();

            Console.Clear();

        }
    }
}
