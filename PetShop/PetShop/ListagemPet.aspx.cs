using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop
{
    public partial class ListagemPet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["Remover"];
                if (!string.IsNullOrEmpty(id))
                {
                    int i = Convert.ToInt32(id);
                    string mensagem = RemoverPet(i);
                    lblMensagem.Text = mensagem;
                }
            }
            List<Pet> listaPets = BuscarPets();
            if (listaPets != null)
            {
                Repeater1.DataSource = listaPets;
                Repeater1.DataBind();
            }
            else
            {
                if (string.IsNullOrEmpty(lblMensagem.Text))
                {
                    lblMensagem.Text = "&nbsp;&nbsp;Nenhum registro";
                }
                else
                {
                    lblMensagem.Text += "<br />&nbsp;&nbsp;Nenhum registro";
                }
            }
        }

        private List<Pet> BuscarPets()
        {
            List<Pet> pets = null;

            StringBuilder sql = new StringBuilder();
            sql.Append(" Select Id, Nome, Idade, Raca, Vacinacao, Donos, Tipo ");
            sql.Append(" From Pet ");

            SqlConnection conexao = new SqlConnection();

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\gusta\Documents\Visual Studio 2015\Projects\PetShop\PetShop\Data\PetShop.mdf';Integrated Security=True";

            conexao.ConnectionString = connString;

            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = sql.ToString();
            comando.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                pets = new List<Pet>();
                Pet p;

                while (reader.Read())
                {
                    p = new Pet();
                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Nome = reader["Nome"].ToString();
                    p.Idade = Convert.ToInt32(reader["Idade"]);
                    p.Raca = reader["Raca"].ToString();
                    p.Vacinacao = reader["Vacinacao"].ToString();
                    p.Donos = reader["Donos"].ToString();
                    p.Tipo = reader["Tipo"].ToString(); ;

                    pets.Add(p);
                }
            }

            conexao.Close();

            return pets;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Pet pet = (Pet)e.Item.DataItem;

                Label labelDoId = (Label)e.Item.FindControl("lblId");
                Label labelDoNome = (Label)e.Item.FindControl("lblNome");
                Label labelDaIdade = (Label)e.Item.FindControl("lblIdade");
                Label labelDaRaca = (Label)e.Item.FindControl("lblRaca");
                Label labelDaVacinacao = (Label)e.Item.FindControl("lblVacinacao");
                Label labelDosDonos = (Label)e.Item.FindControl("lblDonos");
                Label labelDoTipo = (Label)e.Item.FindControl("lblTipo");

                HyperLink lnkEditar = (HyperLink)e.Item.FindControl("lnkEditar");
                HyperLink lnkExcluir = (HyperLink)e.Item.FindControl("lnkExcluir");

                lnkEditar.NavigateUrl = "~/CadastroPet.aspx?ID=" + pet.Id;
                lnkExcluir.NavigateUrl = "~/ListagemPet.aspx?Remover=" + pet.Id;

                labelDoId.Text = pet.Id.ToString();
                labelDoNome.Text = pet.Nome;
                labelDaIdade.Text = pet.Idade.ToString() + " Ano(s)";
                labelDaRaca.Text = pet.Raca;
                labelDaVacinacao.Text = pet.Vacinacao;
                labelDosDonos.Text = pet.Donos;
                labelDoTipo.Text = pet.Tipo;

            }
        }

        private string RemoverPet(int id)
        {
            string mensagem = "";

            SqlConnection conexao = new SqlConnection();

            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from Pet ");
            sb.Append(" where Id = @Id ");

            SqlParameter paramId = new SqlParameter("@Id", id);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = sb.ToString();
            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.Add(paramId);

            try
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
                conexao.Open();

                comando.ExecuteNonQuery();

                mensagem = "&nbsp;&nbsp;Remoção executada com sucesso.";
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

            return mensagem;
        }
    }
}