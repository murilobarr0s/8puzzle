namespace PuzzleIA
{
    public class Fila
    {
        public No inicio; 

        public Fila()
        {
            inicio = null;
        }

        public No GetInicio()
        {
            return inicio;
        }

        public void SetInicio(No inicio)
        {
            this.inicio = inicio;
        }

        public void Enqueue(No no)
        {
            No aux, ant;
            no.setProx(null);
            if (inicio == null)
                inicio = no;
            else
            {
                if (no.GetPrioridade() < inicio.GetPrioridade())
                {
                    no.setProx(inicio);
                    inicio = no;
                }
                else
                {
                    aux = inicio;
                    ant = aux;
                    while (aux.getProx() != null && no.GetPrioridade() >= aux.GetPrioridade())
                    {
                        ant = aux;
                        aux = aux.getProx();
                    }
                    if (aux.getProx() == null && no.GetPrioridade() >= aux.GetPrioridade())
                    {
                        aux.setProx(no);
                        no.setAnt(aux);
                    }
                    else
                    {
                        no.setProx(aux);
                        no.setAnt(ant);
                        ant.setProx(no);
                        aux.setAnt(no);
                    }
                }
            }
        }

        public void InsereFim(No no)
        {
            No aux;
            no.setProx(null);
            if (inicio == null)
                inicio = no;
            else
            {
                aux = inicio;
                while (aux.getProx() != null && no.GetPrioridade() >= aux.GetPrioridade())
                    aux = aux.getProx();
                no.setAnt(aux);
                aux.setProx(no);
            }
        }

        public No Dequeue()
        {
            No aux = null;
            if (inicio != null)
            {
                aux = inicio;
                if (inicio.getProx() != null)
                {
                    inicio.getProx().setAnt(null);
                    inicio = inicio.getProx();
                }
                else
                {
                    inicio = null;
                }
            }
            return aux;
        }

        public No Pop()
        {

            No no = inicio;
            No ant = inicio;
            if (!IsEmpty())
            {

                while (no.getProx() != null)
                {
                    ant = no;
                    no = no.getProx();
                }

                if (no == inicio)
                {
                    inicio = null;
                }
                else
                {
                    ant.setProx(null);
                }

            }
            return no;
        }

        public bool ComparaEstados(int[,] estado1, int[,] estado2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (!estado1[i,j].Equals(estado2[i,j]))
                        return false;
            return true;
        }

        public No Busca(int[,] estado)
        {
            No aux = inicio;
            while (aux != null && !ComparaEstados(aux.getEstado(), estado))
                aux = aux.getProx();
            if (aux != null && ComparaEstados(aux.getEstado(), estado))
                return aux;
            return null;
        }

        public void RemoveAntigo(No no)
        {
            if (no != null)
            {
                if (no == inicio)
                {
                    if (inicio != null)
                        if (inicio.getProx() != null)
                        {
                            inicio.getProx().setAnt(null);
                            inicio = inicio.getProx();
                        }
                        else
                            inicio = null;
                }
                else
                {
                    if (no.getProx() != null)
                    {
                        no.getAnt().setProx(no.getProx());
                        no.getProx().setAnt(no.getAnt());
                    }
                    else
                        no.getAnt().setProx(null);
                }
            }
        }

        public bool IsEmpty()
        {
            return inicio == null;
        }
    }
}
