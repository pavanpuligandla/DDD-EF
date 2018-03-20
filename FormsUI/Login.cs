using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class Login : Form
    {
        public readonly Uri ApiUrl = new Uri("http://localhost:54886");
        string URI = "http://localhost:54886/api/AppUser/RegisterUser";
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private async void ValidateLogin()
        {
            AppUser projectType = new AppUser() { AppUsername = txtLogin.Text, password = txtPassword.Text };

            using (var client = new HttpClient())
            {
                var serializedUser = JsonConvert.SerializeObject(projectType);
                var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("User registered successfully");
                }
            }
        }
    }
}
