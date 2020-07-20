using System;
using System.Windows.Forms;

namespace PuzzleIA
{
    public partial class Form1 : Form
    {
        Fila fila;
        Fechados fechados;
        Solucao solucao;
        int movimentos = 0;
        int[,] pos = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        int[,] EstadoFinalDesejado = new int[3, 3];
        long tempoInicio, tempoFim, tempoDaBusca, tempoMinutos, tempoSegundos;
        System.DateTime moment = new System.DateTime();// 1999, 1, 13, 3, 57, 32, 11);
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "")
            {
                btn2.Text = btn1.Text;
                btn1.Text = "";
            }
            if(btn4.Text == "")
            {
                btn4.Text = btn1.Text;
                btn1.Text = "";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "")
            {
                btn1.Text = btn2.Text;
                btn2.Text = "";
            }
            if (btn3.Text == "")
            {
                btn3.Text = btn2.Text;
                btn2.Text = "";
            }
            if (btn5.Text == "")
            {
                btn5.Text = btn2.Text;
                btn2.Text = "";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "")
            {
                btn2.Text = btn3.Text;
                btn3.Text = "";
            }
            if (btn6.Text == "")
            {
                btn6.Text = btn3.Text;
                btn3.Text = "";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "")
            {
                btn1.Text = btn4.Text;
                btn4.Text = "";
            }
            if (btn5.Text == "")
            {
                btn5.Text = btn4.Text;
                btn4.Text = "";
            }
            if (btn7.Text == "")
            {
                btn7.Text = btn4.Text;
                btn4.Text = "";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "")
            {
                btn2.Text = btn5.Text;
                btn5.Text = "";
            }
            if (btn4.Text == "")
            {
                btn4.Text = btn5.Text;
                btn5.Text = "";
            }
            if (btn6.Text == "")
            {
                btn6.Text = btn5.Text;
                btn5.Text = "";
            }
            if (btn8.Text == "")
            {
                btn8.Text = btn5.Text;
                btn5.Text = "";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "")
            {
                btn3.Text = btn6.Text;
                btn6.Text = "";
            }
            if (btn9.Text == "")
            {
                btn9.Text = btn6.Text;
                btn6.Text = "";
            }
            if (btn5.Text == "")
            {
                btn5.Text = btn6.Text;
                btn6.Text = "";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn4.Text == "")
            {
                btn4.Text = btn7.Text;
                btn7.Text = "";
            }
            if (btn8.Text == "")
            {
                btn8.Text = btn7.Text;
                btn7.Text = "";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn7.Text == "")
            {
                btn7.Text = btn8.Text;
                btn8.Text = "";
            }
            if (btn9.Text == "")
            {
                btn9.Text = btn8.Text;
                btn8.Text = "";
            }
            if (btn5.Text == "")
            {
                btn5.Text = btn8.Text;
                btn8.Text = "";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn6.Text == "")
            {
                btn6.Text = btn9.Text;
                btn9.Text = "";
            }
            if (btn8.Text == "")
            {
                btn8.Text = btn9.Text;
                btn9.Text = "";
            }
        }
       
        private int[,] inicializa()
        {
            int[,] pos = new int[3, 3];
            int cont = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pos[i, j] = cont;
                    cont++;
                }
            }
            pos[2, 2] = 0;
            return pos;
        }
        public int[] buscaZero(int[,] pos)
        {
            int[,] p = pos;
            int[] xy = new int[11];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (p[i, j] == 0)
                    {
                        xy[0] = i;
                        xy[1] = j;
                        return xy;
                    }
                }
            }
            return xy;
        }
        public int[] vizinhos(int[,] pos)
        {
            int[] bu = new int[11];
            int x, y;
            bu = buscaZero(pos);
            x = bu[0];
            y = bu[1];
            bu[9] = x;
            bu[10] = y;

            if (x == 0 && y == 0)
            {
                bu[0] = 2;
                bu[1] = 0;
                bu[2] = 1;
                bu[3] = 1;
                bu[4] = 0;
            }
            if (x == 0 && y == 1)
            {
                bu[0] = 3;
                bu[1] = 1;
                bu[2] = 1;
                bu[3] = 0;
                bu[4] = 2;
                bu[5] = 0;
                bu[6] = 0;
            }
            if (x == 0 && y == 2)
            {
                bu[0] = 2;
                bu[1] = 0;
                bu[2] = 1;
                bu[3] = 1;
                bu[4] = 2;
            }
            if (x == 1 && y == 0)
            {
                bu[0] = 3;
                bu[1] = 1;
                bu[2] = 1;
                bu[3] = 2;
                bu[4] = 0;
                bu[5] = 0;
                bu[6] = 0;
            }
            if (x == 1 && y == 1)
            {
                bu[0] = 4;
                bu[1] = 1;
                bu[2] = 0;
                bu[3] = 2;
                bu[4] = 1;
                bu[5] = 1;
                bu[6] = 2;
                bu[7] = 0;
                bu[8] = 1;
            }
            if (x == 1 && y == 2)
            {
                bu[0] = 3;
                bu[1] = 0;
                bu[2] = 2;
                bu[3] = 2;
                bu[4] = 2;
                bu[5] = 1;
                bu[6] = 1;
            }
            if (x == 2 && y == 0)
            {
                bu[0] = 2;
                bu[1] = 1;
                bu[2] = 0;
                bu[3] = 2;
                bu[4] = 1;
            }
            if (x == 2 && y == 1)
            {
                bu[0] = 3;
                bu[1] = 2;
                bu[2] = 0;
                bu[3] = 2;
                bu[4] = 2;
                bu[5] = 1;
                bu[6] = 1;
            }
            if (x == 2 && y == 2)
            {
                bu[0] = 2;
                bu[1] = 1;
                bu[2] = 2;
                bu[3] = 2;
                bu[4] = 1;
            }
            return bu;
        }
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void embaralhar()
        {
            int movi = 0, valor, v1, v2, aux;
            int[,] pAux, tAux;
            int[] p;
            int[,] pos = new int[3, 3];
            pos = inicializa(); pAux = pos; tAux = pos;

            while (movi <= 30)
            {
                p = vizinhos(pos);
                valor = RandomNumber(1, p[0] + 1);

                if (valor == 1)
                {
                    v1 = tAux[p[9], p[10]];
                    v2 = pAux[p[1], p[2]];
                    aux = v1;
                    tAux[p[9], p[10]] = v2;
                    pAux[p[1], p[2]] = aux;
                }
                if (valor == 2)
                {
                    v1 = tAux[p[9], p[10]];
                    v2 = pAux[p[3], p[4]];
                    aux = v1;
                    tAux[p[9], p[10]] = v2;
                    pAux[p[3], p[4]] = aux;
                }
                if (valor == 3)
                {
                    v1 = tAux[p[9], p[10]];
                    v2 = pAux[p[5], p[6]];
                    aux = v1;
                    tAux[p[9], p[10]] = v2;
                    pAux[p[5], p[6]] = aux;
                }
                if (valor == 4)
                {
                    v1 = tAux[p[9], p[10]];
                    v2 = pAux[p[7], p[8]];
                    aux = v1;
                    tAux[p[9], p[10]] = v2;
                    pAux[p[7], p[8]] = aux;
                }
                movi++;
                valor = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btn1.Text = pAux[0, 0].ToString();
                    btn2.Text = pAux[0, 1].ToString();
                    btn3.Text = pAux[0, 2].ToString();
                    btn4.Text = pAux[1, 0].ToString();
                    btn5.Text = pAux[1, 1].ToString();
                    btn6.Text = pAux[1, 2].ToString();
                    btn7.Text = pAux[2, 0].ToString();
                    btn8.Text = pAux[2, 1].ToString();
                    btn9.Text = pAux[2, 2].ToString();
                }
            }
        }

        public void difinirEstado(int pos)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    EstadoFinalDesejado[i, j] = this.pos[i, j];
                }
        }


        public void buscarSolucao(char tipo)
        {
            fila = new Fila();
            fechados = new Fechados();
            solucao = new Solucao();
            int profMax = 30;
            tempoInicio = moment.Millisecond;

            if (tipo == 'A')
            {
                No no = new No(pos, null, 0, 0, 0, 0);
                no.SetHeuristica(no.calcularHeuristica(0, EstadoFinalDesejado, no.getEstado()));
                no.setPrioridade(no.GetHeuristica());
                fila.InsereFim(no);
                busca('A', profMax);
            }
            else//Busca Profundidade
            {
                No no = new No(pos, 0, null);
                fila.InsereFim(no);
                busca('B', profMax);
            }
        }

        public void busca(char tipo, int profMax)
        {
            No no = new No(); int[,] est; int profund;
            while (!fila.IsEmpty())
            {
                if (tipo == 'A')
                {
                    no = fila.Dequeue();
                    fechados.Insere(no);
                }
                else//Busca Profundidade
                {
                    no = fila.Pop();
                }
                est = no.getEstado();
                profund = no.getProfundidade();
                if (!comparaEstados(est, EstadoFinalDesejado))
                {
                    if (profund < profMax)
                    {
                        profund++;
                        descobreFilhos(no, profund);
                    }
                }
                else
                {
                    tempoFim = moment.Millisecond;
                    tempoDaBusca = tempoFim - tempoInicio;
                    tempoMinutos = (tempoDaBusca / 60000) % 60;
                    tempoSegundos = (tempoDaBusca / 1000) % 60;
                    String tempo = "";
                    if (tempoMinutos > 0)
                        tempo = "tempo " + tempoMinutos + " minutos";
                    else if (tempoSegundos > 0)
                        tempo = "tempo " + tempoSegundos + " segundos";
                    else
                        tempo = "tempo " + tempoDaBusca + " milisegundos";

                    movimentos = 0;
                    
                    solucao.insere(no.getEstado());
                    movimentos++;
                    while (no.getPai() != null)
                    {
                        no = no.getPai();
                        solucao.insere(no.getEstado());
                        movimentos++;
                    }
                    MessageBox.Show(null, "Solução Encontrada!\n" + tempo + "\n"
                            + "Movimentos: " + movimentos, "Informação",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }
        }

        public void descobreFilhos(No no, int profund)
        {
            int l = 0, c = 0;
            bool achou = false;
            while (!achou && l <= 2)
            {
                c = 0;
                while (!achou && c <= 2)
                {
                    if (no.GetEstado(l, c).Equals(0))
                        achou = true;
                    if (!achou)
                        c++;
                }
                if (!achou)
                    l++;
            }
            if (l > 0)
                criaNoFilho(no, profund, l, c, l - 1, c);
            if (l < 2)
                criaNoFilho(no, profund, l, c, l + 1, c);
            if (c > 0)
                criaNoFilho(no, profund, l, c, l, c - 1);
            if (c < 2)
                criaNoFilho(no, profund, l, c, l, c + 1);
        }
        public void criaNoFilho(No pai, int profund, int lo, int co, int ld, int cd)
        {
            No filho, no; int[,] estado; int aux;

            estado = copiaEstado(pai.getEstado());
            aux = estado[lo, co];
            estado[lo, co] = estado[ld, cd];
            estado[ld, cd] = aux;

            if (!fechados.Busca(estado))
            {
                filho = new No();
                filho.SetCusto(pai.GetCusto() + 1);
                filho.SetHeuristica(filho.calcularHeuristica(0, EstadoFinalDesejado, estado));
                filho.setPrioridade(filho.GetCusto() + filho.GetHeuristica());
                filho.setPai(pai);
                filho.SetEstado(estado);
                filho.setProfundidade(profund);
                no = fila.Busca(estado);
                if (no != null)
                {
                    if (no.GetCusto() > filho.GetCusto())
                    {
                        fila.RemoveAntigo(no);
                        fila.Enqueue(filho);
                    }
                }
                else
                    fila.Enqueue(filho);
            }
        }
        public int[,] copiaEstado(int[,] estado)
        {
            int[,] est = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    est[i, j] = estado[i, j];
            return est;
        }

        public bool comparaEstados(int[,] estado, int[,] estadofinal)
        {
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                {
                    if (!estado[l, c].Equals(estadofinal[l, c]))
                        return false;
                }
            return true;
        }

        private void btnEmbaralha_Click(object sender, EventArgs e)
        {
            int cont = 0;
            do
            {
                embaralhar();
                cont++;
            } while (cont < 5);
        }

        private void btnBruta_Click(object sender, EventArgs e)
        {
            buscarSolucao('B');
        }

        private void btnHeuristica_Click(object sender, EventArgs e)
        {
            buscarSolucao('A');
        }

    }
    
}

