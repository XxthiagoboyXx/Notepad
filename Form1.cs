using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void btSalvarArquivo(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog(); //chama a janela que mostra o diretorio

        }

        private void SalvarOk(object sender, CancelEventArgs e) //quando a pessoa clica em salvar no diálogo do windows
        {
            string caminho = saveFileDialog1.FileName; //pega o nome e diretorio do arquivo digitado pelo usario na janela do windows
            File.WriteAllText(caminho, txbJanela.Text); //Escrever todo o texto selecionado em um diretorio
        }

        private void btSair(object sender, EventArgs e)
        {   
            Close(); //fecha o Form
        }

        private void btSobre(object sender, EventArgs e) // Função para mostrar informações sobre o desenvolvedor
        {
            MessageBox.Show("Desenvolvido por Auba Developer"); //cria uma mensage box e a exibe
        }


        private void btAbrir(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //tipo de arquivo aceito pelo app
            openFileDialog1.ShowDialog(); //quando clica no botao abrir do programa criado, inicia uma janela de dialogo do windows

        }

        private void btAbirJanela(object sender, CancelEventArgs e) //janela de diretorio do windows
        {
            string caminho = openFileDialog1.FileName; //quando o usuario clica em abrir na janela do windows
            string[] linhas = File.ReadAllLines(caminho); //percorre as linhas do arquivo e salva o conteúdo em uma array de string

            if (txbJanela.TextLength > 0)
            {
                txbJanela.Text = "";
            }

            foreach(string line in linhas)
            {
                txbJanela.AppendText(line); //para cada linha no array, insere a liha na janela do usuário.
                txbJanela.AppendText(Environment.NewLine); //quebra de linha
                
            }   

        }

        private void chkBloquearAlteracao(object sender, EventArgs e) //o que fazer qundo a checkbox é alterada
        {
            txbJanela.ReadOnly = !txbJanela.ReadOnly; //altera se o texto pode ou não ser alterado.
        }
    }
}
