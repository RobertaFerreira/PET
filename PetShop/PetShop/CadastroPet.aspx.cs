using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PetShop
{
    public partial class CadastroPet : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            ddlTipo.Items.Insert(0, "Selecione o animal");
            ddlTipo.Items.Insert(1, "Gato");
            ddlTipo.Items.Insert(2, "Cachorro");

            ddlVacinacao.Items.Insert(0, "Selecione o histórico");
            ddlVacinacao.Items.Insert(1, "Em dia");
            ddlVacinacao.Items.Insert(2, "Faltando uma");
            ddlVacinacao.Items.Insert(3, "Faltando algumas");

            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["ID"];
                if (string.IsNullOrEmpty(id))
                {
                    btnCadastrar.Text = "Cadastrar";                }
                else
                {
                    btnCadastrar.Text = "Editar";
                    btnCadastrar.Width = 90;
                    

                    int i = Convert.ToInt32(id);
                    Pet p = BuscarPets(i);
                    txtNome.Text = p.Nome;
                    txtRaca.Text = p.Raca;
                    txtIdade.Text = p.Idade.ToString();
                    ddlTipo.SelectedValue = p.Tipo;
                    ddlVacinacao.SelectedValue = p.Vacinacao;
                    txtDonos.Text = p.Donos;
                }
            }
        }

        private Pet BuscarPets(int id)
        {
            Pet p = null;

            StringBuilder sql = new StringBuilder();
            sql.Append(" select Id, Nome, Idade, Raca, Vacinacao, Donos, Tipo ");
            sql.Append(" from Pet ");
            sql.Append(" where Id = @Id ");

            SqlConnection conexao = new SqlConnection();

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\gusta\Documents\Visual Studio 2015\Projects\PetShop\PetShop\Data\PetShop.mdf';Integrated Security=True";

            conexao.ConnectionString = connString;

            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = sql.ToString();
            comando.CommandType = System.Data.CommandType.Text;

            SqlParameter param1 = new SqlParameter("@Id", id);

            comando.Parameters.Add(param1);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                p = new Pet();
                p.Id = Convert.ToInt32(reader["Id"]);
                p.Nome = reader["Nome"].ToString();
                p.Idade = Convert.ToInt32(reader["Idade"]);
                p.Raca = reader["Raca"].ToString();
                p.Tipo = reader["Tipo"].ToString();
                p.Donos = reader["Donos"].ToString();
                p.Vacinacao = reader["Vacinacao"].ToString();
            }

            conexao.Close();

            return p;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            if (string.IsNullOrEmpty(id))
            {
                Cadastrar();
            }
            else
            {
                int i = Convert.ToInt32(id);
                Editar(i);
            }
        }

        private void Editar(int id)
        {
            string mensagem = "";
            string nome = txtNome.Text;
            int idade = Convert.ToInt32(txtIdade.Text);
            string raca = txtRaca.Text;
            string tipo = ddlTipo.SelectedItem.ToString();
            string donos = txtDonos.Text;
            string vacinacao = ddlVacinacao.SelectedItem.ToString();

            SqlConnection conexao = new SqlConnection();

            StringBuilder sb = new StringBuilder();
            sb.Append(" update Pet ");
            sb.Append(" set Nome = @Nome, ");
            sb.Append(" Idade = @Idade, ");
            sb.Append(" Raca = @Raca, ");
            sb.Append(" Tipo = @Tipo, ");
            sb.Append(" Donos = @Donos, ");
            sb.Append(" Vacinacao = @Vacinacao ");
            sb.Append(" where Id = @Id ");

            SqlParameter paramId = new SqlParameter("@Id", id);
            SqlParameter paramNome = new SqlParameter("@Nome", nome);
            SqlParameter paramIdade = new SqlParameter("@Idade", idade);
            SqlParameter paramRaca = new SqlParameter("@Raca", raca);
            SqlParameter paramTipo = new SqlParameter("@Tipo", tipo);
            SqlParameter paramDonos = new SqlParameter("@Donos", donos);
            SqlParameter paramVacinacao = new SqlParameter("@Vacinacao", vacinacao);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = sb.ToString();
            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.Add(paramNome);
            comando.Parameters.Add(paramIdade);
            comando.Parameters.Add(paramRaca);
            comando.Parameters.Add(paramTipo);
            comando.Parameters.Add(paramDonos);
            comando.Parameters.Add(paramVacinacao);
            comando.Parameters.Add(paramId);

            try
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

                mensagem = "Cadastro alterado com sucesso.";

                conexao.Open();
                int qtdRegistroAfetados = comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                mensagem = "Erro de SQL. " + ex.Message;
            }
            catch (ArgumentException ex)
            {
                mensagem = "Erro na connection string. " + ex.Message;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }
            finally
            {
                conexao.Close();
            }

            lblMensagem.Text = mensagem;

        }

        private void Cadastrar()
        {
            string mensagem = "";
            string nome = txtNome.Text;
            int idade = Convert.ToInt32(txtIdade.Text);
            string raca = txtRaca.Text;
            string tipo = ddlTipo.SelectedItem.ToString();
            string donos = txtDonos.Text;
            string vacinacao = ddlVacinacao.SelectedItem.ToString();

            SqlConnection conexao = new SqlConnection();

            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into Pet ");
            sb.Append(" (Nome, Idade, Raca, Tipo, Donos, Vacinacao) ");
            sb.Append(" values ");
            sb.Append(" (@0, @1, @2, @3, @4, @5) ");

            SqlParameter paramNome = new SqlParameter("@0", nome);
            SqlParameter paramIdade = new SqlParameter("@1", idade);
            SqlParameter paramRaca = new SqlParameter("@2", raca);
            SqlParameter paramTipo = new SqlParameter("@3", tipo);
            SqlParameter paramDonos = new SqlParameter("@4", donos);
            SqlParameter paramVacinacao = new SqlParameter("@5", vacinacao);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = sb.ToString();
            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.Add(paramNome);
            comando.Parameters.Add(paramIdade);
            comando.Parameters.Add(paramRaca);
            comando.Parameters.Add(paramTipo);
            comando.Parameters.Add(paramDonos);
            comando.Parameters.Add(paramVacinacao);

            try
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

                mensagem = "Cadastro executado com sucesso.";

                conexao.Open();
                int qtdRegistroAfetados = comando.ExecuteNonQuery();
                Limpar();
            }
            catch (SqlException ex)
            {
                mensagem = "Erro de SQL. " + ex.Message;
            }
            catch (ArgumentException ex)
            {
                mensagem = "Erro na connection string. " + ex.Message;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }
            finally
            {
                conexao.Close();
            }

            lblMensagem.Text = mensagem;

        }

        private void Limpar()
        {
            txtNome.Text = "";
            txtIdade.Text = "";
            txtRaca.Text = "";
            ddlTipo.SelectedIndex = 0;
            ddlVacinacao.SelectedIndex = 0;
            txtDonos.Text = "";
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:49998/ListagemPet.aspx");
        }
    }
}
