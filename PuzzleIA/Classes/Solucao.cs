namespace PuzzleIA
{
    public class Solucao
    {
        public NoSolucao inicio;
        public NoSolucao fim;

        public Solucao()
        {
            inicio = null;
            fim = null;
        }

        public void insere(int [,]estado)
        {
            NoSolucao nova = new NoSolucao(estado, inicio, null);
            if (inicio == null)
                inicio = fim = nova;
            else
            {
                inicio.setAnt(nova);
                inicio = nova;
            }
        }

        public NoSolucao remove()
        {
            NoSolucao aux = null;
            if (inicio != null)
            {
                aux = inicio;
                if (inicio == fim)
                {
                    inicio = null;
                    fim = null;
                }
                else
                {
                    inicio.getProx().setAnt(null);
                    inicio = inicio.getProx();
                }
            }
            return aux;
        }

        public int QtdNos()
        {
            int i = 0;
            NoSolucao aux = inicio;
            while (aux != null)
            {
                i++;
                aux = inicio.getProx();
            }
            return i;
        }

        public bool isEmpty()
        {
            return inicio == null;
        }
    }
}