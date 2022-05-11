﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProjetoMotorÉP
{
    public partial class CriarLogin : Form
    {
        MySqlConnection conexao;

        public string dados;
        public string comando;
        public long CPF;

        public CriarLogin()
        {
            InitializeComponent();

            //conexão com o banco de dados
            conexao = new MySqlConnection("server=localhost;DataBase=NotaConsumidor;Uid=root;password=;");
            try
            {
                conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado!\n\n" + e);
                conexao.Close();
            }//fim da conexão
        }//fim do construtor

        private void CadastroLogin()
        {
            try
            {
                dados = "('" + CPF + "','" + txtbNome.Text + "','" + txtbSenha.Text + "')";

                comando = "INSERT INTO login(CPF, nome, senha) values" + dados;

                MySqlCommand sql = new MySqlCommand(comando, conexao);
                comando = "" + sql.ExecuteNonQuery();
                MessageBox.Show("Cadastro de usuário realizado!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado!" + e);
            }//fim do try catch
        }//fim do método cadastroLogin

        private void textBoxCriarUsuario_TextChanged(object sender, EventArgs e)
        {

        }  
        private void textBoxCriarSenha_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxSenha2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SenhaIncorreta_Click(object sender, EventArgs e)
        {

        }

        private void CPFinco_Click(object sender, EventArgs e)
        {

        }

        private void txtbNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {           
            if(txtbSenha.Text == "" || txtbSenha2.Text == "" || txtbNome.Text == "" || mtbCPF.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");                
            }
            else
            {
                if (txtbSenha.Text == txtbSenha.Text)
                {
                    this.mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Exclui a máscara antes de enviar ao banco
                    CPF = Convert.ToInt64(this.mtbCPF.Text);
                    CadastroLogin();
                }
                else
                {
                    MessageBox.Show("As senhas não são iguais!");
                }              
            }           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 mostrar = new Form1();
            mostrar.Show();
        }

        private void mtbCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
