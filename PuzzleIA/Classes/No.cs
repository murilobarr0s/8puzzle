using System;

namespace PuzzleIA
{
    public class No
    {
       
        private int[,] estado { get; set; }
        private No pai { get; set; }
        private int profundidade { get; set; }
        private int heuristica { get; set; }
        private int custo { get; set; }
        private int prioridade { get; set; }
        private No prox { get; set; }
        private No ant { get; set; }

        public No(int[,] estado, No pai, int profundidade, int heuristica, int custo, int prioridade)// Contrutor pra A*
        {
            this.estado = estado;
            this.pai = pai;
            this.profundidade = profundidade;
            this.heuristica = heuristica;
            this.custo = custo;
            this.prioridade = prioridade;
            prox = null;
            ant = null;
        }

        public No(int[,] estado, int profundidade, No pai)//Construtor para Busca Profundidade
        {
            this.estado = estado;
            this.pai = pai;
            this.profundidade = profundidade;
        }

        public No()
        {
            prox = null;
            ant = null;
        }

        public No getAnt()
        {
            return ant;
        }

        public void setAnt(No ant)
        {
            this.ant = ant;
        }

        public No getProx()
        {
            return prox;
        }

        public void setProx(No prox)
        {
            this.prox = prox;
        }

        public int getProfundidade()
        {
            return profundidade;
        }

        public void setProfundidade(int profundidade)
        {
            this.profundidade = profundidade;
        }

        public No getPai()
        {
            return pai;
        }

        public void setPai(No pai)
        {
            this.pai = pai;
        }

        public int[,] getEstado()
        {
            return estado;
        }

        public int GetEstado(int l, int c)
        {
            return estado[l,c];
        }

        public void SetEstado(int[,] estado)
        {
            this.estado = estado;
        }

        public int GetHeuristica()
        {
            return heuristica;
        }

        public void SetHeuristica(int heuristica)
        {
            this.heuristica = heuristica;
        }

        public int GetCusto()
        {
            return custo;
        }

        public void SetCusto(int custo)
        {
            this.custo = custo;
        }

        public int GetPrioridade()
        {
            return prioridade;
        }

        public void setPrioridade(int prioridade)
        {
            this.prioridade = prioridade;
        }

        public int calcularHeuristica(int tipo, int[,] EstadoFinalDesejado, int[,] estado)
        {
            int h = 0; 
            float distanciaM;
            int[] lc;
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                {
                    if (!estado[l,c].Equals(EstadoFinalDesejado[l,c]) && !estado[l,c].Equals(0))
                    {
                        if (tipo != 0)
                            h++;
                        else
                        {
                            lc = buscaPosicoesCorretas(estado[l,c], EstadoFinalDesejado);
                            distanciaM = Math.Abs(l - lc[0]) + Math.Abs(c - lc[1]);
                            h += (int)distanciaM;
                        }
                    }
                }
            return h;
        }

        public int[] buscaPosicoesCorretas(int valor, int[,] EstadoFinalDesejado)
        {
            int[] lc = new int[2]; int l = 0, c = 0;
            bool achou = false;
            while (!achou && l <= 2)
            {
                c = 0;
                while (!achou && c <= 2)
                {
                    if (EstadoFinalDesejado[l,c].Equals(valor))
                        achou = true;
                    if (!achou)
                        c++;
                }
                if (!achou)
                    l++;
            }
            lc[0] = l;
            lc[1] = c;
            return lc;
        }
    }
}