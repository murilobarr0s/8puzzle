namespace PuzzleIA
{
    public class NoSolucao
    {
        public int[,] info;
        public NoSolucao prox;
        public NoSolucao ant;

        public NoSolucao(int[,] info, NoSolucao prox, NoSolucao ant)
        {
            this.info = info;
            this.prox = prox;
            this.ant = ant;
        }

        public int[,] getInfo()
        {
            return info;
        }

        public void setInfo(int[,] info)
        {
            this.info = info;
        }

        public NoSolucao getProx()
        {
            return prox;
        }

        public void setProx(NoSolucao prox)
        {
            this.prox = prox;
        }

        public NoSolucao getAnt()
        {
            return ant;
        }

        public void setAnt(NoSolucao ant)
        {
            this.ant = ant;
        }
    }
}
