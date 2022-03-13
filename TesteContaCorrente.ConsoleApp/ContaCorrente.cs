using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        public int numeroDaContaCorrente;
        public decimal saldo;
        public bool ehEspecial;
        public decimal limite;
        public Movimentacoes[] movimentacoes;


        public void Saque(decimal valor)
        {

            if ((saldo + limite) > valor)
            {
                saldo -= valor;
                int posicao = ContadorDeMovimentacoes();
                Movimentacoes movSaque = new Movimentacoes();
                movSaque.valor = valor;
                movSaque.tipo = "Debito";
                movimentacoes[posicao] = movSaque;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: Saque indisponivel devido limite insuficiente!");
                Console.ResetColor();
            }


        }
        public void Deposito(decimal valor)
        {
            int posicao = ContadorDeMovimentacoes();
            saldo += valor;
            Movimentacoes movDeposito = new Movimentacoes();
            movDeposito.valor = valor;
            movDeposito.tipo = "Debito";
            movimentacoes[posicao] = movDeposito;


        }

        public void Transferencia(ContaCorrente Conta, decimal valor)
        {

            if ((saldo + limite) > valor)
            {
                int posicao = ContadorDeMovimentacoes();
                this.saldo -= valor;
                Conta.saldo += valor;
                Movimentacoes movTransfere = new Movimentacoes();
                movTransfere.valor = valor;
                movTransfere.tipo = "Debito";
                movimentacoes[posicao] = movTransfere;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: Transferencia indisponivel devido a saldo ou limite insuficiente!");
                Console.ResetColor();
            }


        }
        public void Extrato()
        {

            string tipoDeConta;
            if (this.ehEspecial == true)
            {
                tipoDeConta = "Espcial";
            }
            else
            {
                tipoDeConta = "Normal";
            }
            Console.WriteLine("_______________________________________EXTRATO:___________________________________________\n");
            Console.WriteLine($"-Numero da conta: {this.numeroDaContaCorrente}\n" +
                $"-Saldo da conta: {this.saldo}\n-Tipo de conta: {tipoDeConta}\n" +
                $"-Limite da conta: {this.limite} ");
            Console.WriteLine("________________________________MOVIMENTAÇÕES DA CONTA:____________________________________\n");
            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (movimentacoes[i] != null)
                {
                    Console.WriteLine($"-Movimentação:\n-Tipo da movimentção: {movimentacoes[i].tipo}\n-Valor da movimentação:{movimentacoes[i].valor}\n");
                    Console.WriteLine("____________________________________________________________________________________\n");
                }
                
            }

        }
        public int ContadorDeMovimentacoes()
        {
            int posicao = -1;
            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (movimentacoes[i] == null)
                {
                    posicao = i;
                }
            }
            return posicao;
        }

    }
    public class Movimentacoes
    {
        public string tipo;
        public decimal valor;
    }

}
