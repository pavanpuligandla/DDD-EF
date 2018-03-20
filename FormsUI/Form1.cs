using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using System.Net.Http;
using Newtonsoft.Json;

namespace FormsUI
{
    public partial class Form1 : Form
    {
        public readonly Uri ApiUrl = new Uri("http://localhost:54886");
        string URI = "http://localhost:54886/api/ProjectType/CreateProjectType";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateProjectType();
        }

        private async void CreateProjectType()
        {
            ProjectType projectType = new ProjectType() { ProjectTypeName = txtProjectType.Text, ProjectTypeDescription = txtDescription.Text };

            using (var client = new HttpClient())
            {
                var serializedUser = JsonConvert.SerializeObject(projectType);
                var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Project type created");
                }
            }
        }
    }
}
