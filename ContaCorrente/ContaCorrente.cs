using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente {
    internal class ContaCorrente {

        public decimal saldo;
        public int numero,limite;
        public bool ehEspecial;
        static public int i = 0;
        public Movimentacoes[] movimentacoes;

        public void Depositar(decimal quantia) {
            saldo += quantia;
            Movimentacoes movimentacao = new Movimentacoes();
            movimentacao.valor = quantia;
            movimentacao.tipo = "Crédito";
            movimentacao.descricao = $"Crédito de R$ {quantia}";

            movimentacoes[i] = movimentacao;
            i++;
        }
        public bool Sacar(decimal quantia) {
            if (quantia > saldo + limite) {
                return false;
            }  if (quantia < saldo + limite) {
                saldo -= quantia;
                Movimentacoes movimentacao = new Movimentacoes();
                movimentacao.valor = quantia;
                movimentacao.tipo = "Débito";
                movimentacao.descricao = $"Débito de R$ {quantia}";
                
                movimentacoes[i] = movimentacao;
                i++;
            }
            return true;
        }
        public void TransferirPara(ContaCorrente contaDestino,decimal quantia) {
            Sacar(quantia);
            contaDestino.Depositar(quantia);
            i++;
        }
        public void VisualizarSaldo() {
            Console.WriteLine("Saldo atual: " + saldo);
        }
        public void ExibirExtrato() {
            Console.WriteLine($"Número da conta: {numero}");
            Console.WriteLine($"Movimentações: ");
            foreach (Movimentacoes movimentacao in movimentacoes) {
                if(movimentacao != null) {
                    Console.WriteLine(movimentacao.descricao);
                }
            }
            Console.WriteLine($"Saldo Atual: {saldo} + {limite}");

        }

    }
}
