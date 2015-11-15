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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Produit> uneListeDeProduits = new List<Produit>();
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=magasin");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM produit ORDER BY id";
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
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text = "<table border=\"1px solid black\"";
                for (int i = 0; i < uneListeDeProduits.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeProduits[i].Id + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeProduits[i].Designation + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeProduits[i].PrixUnitaire + " $</td>";
                    chaineHtml.Text += "<td>" + uneListeDeProduits[i].QuantiteEnStock + " $</td>";
                    chaineHtml.Text += "</tr>";
                }
                localPlaceHolder.Controls.Add(chaineHtml);
            }
            cnx.Close();
        }
    }
}