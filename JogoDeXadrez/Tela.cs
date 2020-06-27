using System;
using tabuleiro;
using System.Collections.Generic;
using xadrez;

namespace JogoDeXadrez {
    class Tela {
        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: "+partida.turno);
            Console.WriteLine("Aguardando jogada: "+partida.jogadorAtual);
            if (partida.xeque) {
                Console.WriteLine("XEQUE!");
            }
        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: "); 
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Peca x in conjunto) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int i=0;i<tab.linhas; i++){
                Console.Write(8-i + " ");
                for(int j=0; j < tab.colunas; j++) {
                    imprimirPeca(tab.peca(i, j));                                       
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Tabuleiro tab,bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor; //Pega a cor de fundo, no caso aqui PRETO
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; //Cinza escuro
            
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (posicoesPossiveis[i, j]) { // Se a posicao estiver marcada como uma posicao possivel de movimento
                        Console.BackgroundColor = fundoAlterado; //Muda o fundo para cinza escuro
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadres lerPosicaoXadrez() {
            // Le do teclado uma posicao do xadres
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadres(coluna, linha);
        }
        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            }
            else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor; //Cor atual do console, Cinza
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
       
    }
}
