namespace PuzzleIA
{
    public class Fechados
    {
        public No inicio;

        public Fechados()
        {
            inicio = null;
        }

        public void Insere(No no)
        {
            if (inicio == null)
                inicio = no;
            else
            {
                inicio.setAnt(no);
                no.setProx(inicio);
                inicio = no;
            }
        }

        public bool ComparaEstados(int[,] estado1, int[,] estado2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (!estado1[i,j].Equals(estado2[i,j]))
                        return false;
            return true;
        }

        public bool Busca(int[,] estado)
        {
            No aux = inicio;
            while (aux != null && ComparaEstados(aux.getEstado(), estado))
                aux = aux.getProx();
            if (aux != null && ComparaEstados(aux.getEstado(), estado))
                return true;
            return false;
        }
    }
}