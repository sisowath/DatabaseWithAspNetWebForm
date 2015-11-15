using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common; // IMPORTANT pour utiliser DbProviderFactory
using MySql.Data.MySqlClient; // IMPORTANT pour utiliser MySQL avec PhpMyAdmin
using System.Data; // IMPORTANT pour utiliser CommandType

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private List<Produit> uneListeDeProduits = new List<Produit>();
        private int indice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=magasin");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM produit";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id = 0;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    double prixUnitaire = 0;
                    String designation = dbrdr["designation"].ToString();
                    Double.TryParse(dbrdr["prixUnitaire"].ToString(), out prixUnitaire);
                    int quantiteEnStock = 0;
                    int.TryParse(dbrdr["quantiteEnStock"].ToString(), out quantiteEnStock);
                    uneListeDeProduits.Add(new Produit(id, designation, prixUnitaire, quantiteEnStock));
                }
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
                txtDesignation.ReadOnly = true;
                txtPrixUnitaire.ReadOnly = true;
                txtQuantiteEnStock.ReadOnly = true;
            }
            cnx.Close();
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            if (indice != 0)
            {
                lblNumero.Text = uneListeDeProduits[0].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[0].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[0].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[0].QuantiteEnStock.ToString();
            }
            lblMessage.Text = indice.ToString() + " :: " + uneListeDeProduits.Count;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (indice > 0)
            {
                indice--;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            lblMessage.Text = indice.ToString() + " :: " + uneListeDeProduits.Count;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (indice < uneListeDeProduits.Count-1)
            {
                indice++;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            lblMessage.Text = indice.ToString() + " :: " + uneListeDeProduits.Count;
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            if (indice < uneListeDeProduits.Count-1)
            {
                indice = uneListeDeProduits.Count-1;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            lblMessage.Text = indice.ToString() + " :: " + uneListeDeProduits.Count;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=magasin");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "DELETE FROM produit WHERE id=" + lblNumero.Text;
            // Requêtes paramétrées
            cmd.CommandText = "DELETE FROM produit WHERE id = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", lblNumero.Text);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read()) {}
                lblMessage.Text = "BRAVO ! La suppression a réussi.";
            }
            cnx.Close();
        }
    }
}