using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeEstudantes
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Criar um objeto da classe "MeuBancoDedados"
            MeuBancoDeDados meuBancoDeDados = new MeuBancoDeDados();

            MySqlDataAdapter meuAdaptadorSql = new MySqlDataAdapter();
            DataTable tabelaDeDados = new DataTable();
            MySqlCommand comandosql = new MySqlCommand("SELECT * FROM `estudantes` WHERE `nome_de_usuário`=@usuario AND `senha`= @senha", meuBancoDeDados.getConexao);

            comandosql.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = textBoxUsuario.Text;
            comandosql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBoxSenha.Text;

            meuAdaptadorSql.SelectCommand = comandosql;
            
            meuAdaptadorSql.Fill(tabelaDeDados);

            if(tabelaDeDados.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}
