using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ficha_FII_Fiagro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dgvResultados.Rows.Add(12);
            preencherGridMes();
            preencherResultadoLiquidoMes();
            preencherResultadoNegativoAteoMesAnterior();
            preencherBaseDeCalculoDoImposto();
            preencherPrejuizoaCompensar();
            preencherAliquotaDoImposto();
            preencherImpostoDevido();
            preencherSaldoImpostoRetidoMesesAnteriores();
            preencherImpostoRetidoNoMes();
            preencherImpostoaCompensar();
            preencherImpostoaPagar();
            preencherImpostoPago();


            //bloqueios 

            bloquearResultadoNegativoMesAnterior();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void preencherGridMes()
        {
            DateTime data = DateTime.Parse("01/01/" + DateTime.Now.ToShortDateString().Substring(6, 4));

            CultureInfo cultura = new CultureInfo("pt-BR");

            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português
                string nomeDoMes = data.ToString("MMMM", cultura).Substring(0,3).ToUpper();
                dgvResultados.Rows[i].Cells[0].Value = nomeDoMes;

                data = data.AddMonths(1);
            }
        }

        public void preencherResultadoLiquidoMes()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português
               
                dgvResultados.Rows[i].Cells[1].Value = "0,00";

            }
        }

        public void preencherResultadoNegativoAteoMesAnterior()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[2].Value = "0,00";

            }
        }

        public void preencherBaseDeCalculoDoImposto()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[3].Value = "0,00";

            }
        }

        public void preencherPrejuizoaCompensar()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[4].Value = "0,00";

            }
        }

        public void preencherAliquotaDoImposto()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[5].Value = "20,00";

            }
        }

        public void preencherImpostoDevido()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[6].Value = "0,00";

            }
        }

        public void preencherSaldoImpostoRetidoMesesAnteriores()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[7].Value = "0,00";

            }
        }
        public void preencherImpostoRetidoNoMes()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[8].Value = "0,00";

            }
        }

        public void preencherImpostoaCompensar()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[9].Value = "0,00";

            }
        }

        public void preencherImpostoaPagar()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[10].Value = "0,00";

            }
        }

        public void preencherImpostoPago()
        {
            int numeroDeLinhas = dgvResultados.Rows.Count;

            for (int i = 0; i < numeroDeLinhas && i < 12; i++)
            {
                // Obter o nome do mês em português

                dgvResultados.Rows[i].Cells[11].Value = "0,00";

            }
        }

        public void calcularResultadoNegativoAcumulado()
        {
            // Supondo que o DataGridView seja chamado dgvResultados e as colunas 2 e 3 sejam a 1ª e 2ª colunas, respectivamente

            // Inicialize o resultado negativo acumulado com o valor da primeira linha da coluna 3
            decimal resultadoNegativoAcumulado = Convert.ToDecimal(dgvResultados.Rows[0].Cells[2].Value);

            // Loop através das linhas do DataGridView a partir da segunda linha
            for (int i = 0; i < dgvResultados.Rows.Count-1; i++)
            {
                dgvResultados.Rows[i].Cells[3].Value = "0";

                // Obtenha o valor da coluna 1 (resultado líquido do mês anterior)
                if(i == 0)
                {
                    decimal resultadoNegativoMesAnterior = Convert.ToDecimal(dgvResultados.Rows[i].Cells[2].Value);
                }
                else
                {
                    decimal resultadoNegativoMesAnterior = Convert.ToDecimal(dgvResultados.Rows[i - 1].Cells[2].Value);
                }
                

                // Obtenha o valor da coluna 2 (resultado líquido do mês)
                decimal resultadoLiquidoMes = Convert.ToDecimal(dgvResultados.Rows[i].Cells[1].Value);

                if(resultadoLiquidoMes < 0)
                {
                    resultadoLiquidoMes = Math.Abs(resultadoLiquidoMes);

                    // Calcule o resultado negativo acumulado até o mês anterior (coluna 3)
                    dgvResultados.Rows[i].Cells[2].Value = resultadoNegativoAcumulado;

                    // Atualize o resultado negativo acumulado para incluir o resultado líquido do mês atual
                    resultadoNegativoAcumulado = resultadoNegativoAcumulado + resultadoLiquidoMes;
                }
                else
                {
                    resultadoLiquidoMes = Math.Abs(resultadoLiquidoMes);

                    // Calcule o resultado negativo acumulado até o mês anterior (coluna 3)
                    dgvResultados.Rows[i].Cells[2].Value = resultadoNegativoAcumulado;

                    // Atualize o resultado negativo acumulado para incluir o resultado líquido do mês atual
                    resultadoNegativoAcumulado = Math.Abs(resultadoNegativoAcumulado) - resultadoLiquidoMes;


                    if(resultadoNegativoAcumulado < 0 )
                    {
                        dgvResultados.Rows[i].Cells[3].Value = Math.Abs(resultadoNegativoAcumulado);
                        resultadoNegativoAcumulado = 0;
                    }
                   
                }
                // Use Math.Abs para obter o valor absoluto do resultado líquido do mês
                
            }

        }

        public void bloquearResultadoNegativoMesAnterior()
        {
            for (int i = 1; i < dgvResultados.Rows.Count; i++)
            {
                dgvResultados.Rows[i].Cells[2].ReadOnly = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcularResultadoNegativoAcumulado();
        }
    }
}
