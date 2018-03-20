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
    public partial class RegisterForm : Form
    {
        public readonly Uri ApiUrl = new Uri("http://localhost:54886");
        string URI = "http://localhost:54886/api/AppUser/RegisterUser";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private async void RegisterUser()
        {
            AppUser projectType = new AppUser() { AppUsername = txtUsername.Text, password= txtPassword.Text };

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
