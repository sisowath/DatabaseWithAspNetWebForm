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
    public partial class WebForm3 : System.Web.UI.Page
    {
        private List<Produit> uneListeDeProduits = new List<Produit>();
        private int indice;

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
                    String designation = dbrdr["designation"].ToString();
                    double prixUnitaire = 0;
                    Double.TryParse(dbrdr["prixUnitaire"].ToString(), out prixUnitaire);
                    int quantiteEnStock = 0;
                    int.TryParse(dbrdr["quantiteEnStock"].ToString(), out quantiteEnStock);
                    uneListeDeProduits.Add(new Produit(id, designation, prixUnitaire, quantiteEnStock));
                }
                indice = 0;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
                HdnIndice.Value = indice.ToString();

                //source de : https://msdn.microsoft.com/en-us/library/system.web.httpcontext.session(v=vs.110).aspx
                Session["indice"] = indice;
                Session["uneListeDeProduits"] = uneListeDeProduits;

                if (IsPostBack)
                {
                    if (Request.QueryString["inputDesignation"] != null)
                        txtDesignation.Text = Request.QueryString["inputDesignation"];
                }
            }
            cnx.Close();

            // source de : http://www.dotnetperls.com/querystring
            if (Request.QueryString["parameter"] != null)
            {
                String valeur = Request.QueryString["parameter"];
                lblMessage.Text = "parameter = " + valeur;
                if ("samnang".Equals(valeur))
                {
                    Response.Redirect("/Webform3.aspx?Bonjour Samnang");// source de : https://msdn.microsoft.com/en-us/library/540y83hx.aspx
                }
            }            
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            indice = (int)Session["indice"];
            uneListeDeProduits = (List<Produit>)Session["uneListeDeProduits"];
            if (indice != 0)
            {
                indice = 0;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            Session["indice"] = indice;
            Session["uneListeDeProduits"] = uneListeDeProduits;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            indice = (int)Session["indice"];
            uneListeDeProduits = (List<Produit>)Session["uneListeDeProduits"];
            if (indice > 0)
            {
                indice--;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            Session["indice"] = indice;
            Session["uneListeDeProduits"] = uneListeDeProduits;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            indice = (int)Session["indice"];
            uneListeDeProduits = (List<Produit>)Session["uneListeDeProduits"];
            if (indice < uneListeDeProduits.Count)
            {
                indice++;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            Session["indice"] = indice;
            Session["uneListeDeProduits"] = uneListeDeProduits;
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            indice = (int)Session["indice"];
            uneListeDeProduits = (List<Produit>)Session["uneListeDeProduits"];
            if (indice < uneListeDeProduits.Count-1)
            {
                indice = uneListeDeProduits.Count-1;
                lblNumero.Text = uneListeDeProduits[indice].Id.ToString();
                txtDesignation.Text = uneListeDeProduits[indice].Designation;
                txtPrixUnitaire.Text = uneListeDeProduits[indice].PrixUnitaire.ToString();
                txtQuantiteEnStock.Text = uneListeDeProduits[indice].QuantiteEnStock.ToString();
            }
            Session["indice"] = indice;
            Session["uneListeDeProduits"] = uneListeDeProduits;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=magasin");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            /*
            cmd.CommandText = "UPDATE produit SET designation = '" + txtDesignation.Text +
                                "', prixUnitaire = " + txtPrixUnitaire.Text +
                                ", quantiteEnStock = " + txtQuantiteEnStock.Text +
                                " WHERE id = " + lblNumero.Text;
            */
            // Requêtes paramétrées
            
            cmd.CommandText = "UPDATE produit SET designation = @designation, " +
                                "prixUnitaire = @prixUnitaire, " +
                                "quantiteEnStock = @quantiteEnStock " +
                                "WHERE id = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@designation", txtDesignation.Text);
            cmd.Parameters.AddWithValue("@prixUnitaire", txtPrixUnitaire.Text);
            cmd.Parameters.AddWithValue("@quantiteEnStock", txtQuantiteEnStock.Text);
            cmd.Parameters.AddWithValue("@id", lblNumero.Text);
            
            lblMessage.Text = txtDesignation.Text + txtPrixUnitaire.Text + txtQuantiteEnStock.Text + lblNumero.Text;
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read()) {}
                lblMessage.Text = "<h1>BRAVO ! La mise à jour a réussi.</h1>";                
            }
            cnx.Close();
        }

        protected void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            //txtDesignation.Text = txtDesignation.Text.Trim();
            lblMessage.Text = txtDesignation.Text;
        }

        protected void txtPrixUnitaire_TextChanged(object sender, EventArgs e)
        {
            //txtPrixUnitaire.Text = txtPrixUnitaire.Text.Trim();
            lblMessage.Text = txtPrixUnitaire.Text;
        }

        protected void txtQuantiteEnStock_TextChanged(object sender, EventArgs e)
        {
            //txtQuantiteEnStock.Text = txtQuantiteEnStock.Text.Trim();
            lblMessage.Text = txtQuantiteEnStock.Text;
        }
    }
}