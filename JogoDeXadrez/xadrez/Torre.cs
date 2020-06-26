using System.Reflection;
using tabuleiro;
namespace xadrez {
    class Torre : Peca {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        private bool podeMover(Posicao pos) {
            //Testa se a casa está livre ou se tem uma peça adversária
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) { //Enquanto não bater no final do tabuleiro
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { //caso bata na peca adversária
                    break;
                }
                pos.linha = pos.linha - 1; // vai pra próxima posicao acima
              }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) { //Enquanto não bater no final do tabuleiro
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { //caso bata na peca adversária
                    break;
                }
                pos.linha = pos.linha + 1; // vai pra próxima posicao abaixo
            }
            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) { 
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { //caso bata na peca adversária
                    break;
                }
                pos.coluna = pos.coluna+ 1; 
            }
            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { //caso bata na peca adversária
                    break;
                }
                pos.coluna = pos.coluna -1;
            }
            return mat;
        }
        public override string ToString() {
            return "T";
        }
    }
}
