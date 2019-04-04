﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // Cryptage

namespace WindowsForm
{
    public partial class Inscription : Form
    {
        private List<Utilisateur> lesUtilisateurs;
        public Inscription(List<Utilisateur> lesUtilisateurs)
        {
            this.lesUtilisateurs = lesUtilisateurs;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MdpTextBox.Text == CMdpTextBox.Text)
            {
                if (String.IsNullOrWhiteSpace(NomTextBox.Text) || String.IsNullOrWhiteSpace(PrenomTextBox.Text) || String.IsNullOrWhiteSpace(MdpTextBox.Text)){
                    MessageBox.Show("Veuillez rentrez des valeurs valide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Utilisateur unUtilisateur = new Utilisateur(LoginTextBox.Text, Hash256(MdpTextBox.Text), NomTextBox.Text, PrenomTextBox.Text, 0, false);
                    lesUtilisateurs.Add(unUtilisateur);
                    MessageBox.Show("Inscription réussi", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Les mots de passe ne correspondent pas", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Inscription_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Permet le Hash d'une chaine de caractère
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public string Hash256(string rawData)
        {
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
