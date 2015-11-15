using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Produit
    {
            // attribut(s)
        private int id;
        private String designation;
        private double prixUnitaire;
        private int quantiteEnStock;
            // methode(s)
        // constructeur(s)
        public Produit(int id, String designation, double prixUnitaire, int quantiteEnStock)
        {
            this.id = id;
            this.designation = designation;
            this.prixUnitaire = prixUnitaire;
            this.quantiteEnStock = quantiteEnStock;
        }
        public Produit() : this(1, "no designation", 0, 0) {}
        // propriétés en lecture et en écriture
        public int Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                    this.id = value;
            }
        }
        public String Designation
        {
            get { return this.designation; }
            set
            {
                if (this.designation != value)
                    this.designation = value;
            }
        }
        public double PrixUnitaire
        {
            get { return this.prixUnitaire; }
            set
            {
                if (this.prixUnitaire != value)
                    this.prixUnitaire = value;
            }
        }
        public int QuantiteEnStock
        {
            get { return this.quantiteEnStock; }
            set
            {
                if (this.quantiteEnStock != value)
                    this.quantiteEnStock = value;
            }
        }
        // autre(s)
        public override string ToString()
        {
            return id + " :: " + designation + " :: " + prixUnitaire + " :: " + quantiteEnStock;
        }
    }
}