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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            List<Produit> uneListeDeProduits = new List<Produit>();
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=magasin");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            /*
            cmd.CommandText = "INSERT INTO produit(designation, prixUnitaire, quantiteEnStock) "
                            +"VALUES ('" + txtDesignation.Text + "'," + txtPrixUnitaire.Text + "," + txtQuantiteEnStock.Text + ")";
            */
            // Requêtes paramétrées
            cmd.CommandText = "INSERT INTO produit(designation, prixUnitaire, quantiteEnStock) "
                            + "VALUES (@designation, @prixUnitaire, @quantiteEnStock)";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@designation", txtDesignation.Text);
            cmd.Parameters.AddWithValue("@prixUnitaire", txtPrixUnitaire.Text);
            cmd.Parameters.AddWithValue("@quantiteEnStock", txtQuantiteEnStock.Text);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read()) {}
                lblMessage.Text = "BRAVO ! L'insertion a réussi.";
            }
            cnx.Close();
        }
    }
}