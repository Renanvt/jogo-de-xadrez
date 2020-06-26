using System;
using tabuleiro;
using xadrez;
namespace JogoDeXadrez {
    class Program {
        static void Main(string[] args) {
            PosicaoXadres pos = new PosicaoXadres('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());
            Console.ReadLine();
        }
    }
}
