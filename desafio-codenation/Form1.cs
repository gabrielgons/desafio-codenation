using Newtonsoft.Json;
using QuickType;
using RestSharp;
using System;
using System.IO;
using System.Windows.Forms;

namespace desafio_codenation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            var criptografiaDeJulioCesar = JsonConvert.DeserializeObject<CriptografiaDeJulioCesar>(GetCriptografiaFromCodenation());
            SalvarArquivo(criptografiaDeJulioCesar);

            criptografiaDeJulioCesar.Decifrado = new DescriptografadorDeJulioCesar(criptografiaDeJulioCesar.NumeroCasas, criptografiaDeJulioCesar.Cifrado).Descriptografar();
            SalvarArquivo(criptografiaDeJulioCesar);

            criptografiaDeJulioCesar.ResumoCriptografico = new CriptografadorSha1().Criptografar(criptografiaDeJulioCesar.Decifrado);
            SalvarArquivo(criptografiaDeJulioCesar);

            EnviarResultadoParaCodeNation(criptografiaDeJulioCesar);
        }

        private void SalvarArquivo(CriptografiaDeJulioCesar criptografiaDeJulioCesar)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(criptografiaDeJulioCesar);

            File.WriteAllText(Path.Combine(docPath, "answer.json"), json);
        }

        private string GetCriptografiaFromCodenation()
        {
            var client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=b4ea1876be7e7130a01aa19d77960887a8e88510");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        private void EnviarResultadoParaCodeNation(CriptografiaDeJulioCesar criptografiaDeJulioCesar)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=b4ea1876be7e7130a01aa19d77960887a8e88510");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "multipart/form-data");
            request.AddFile("answer", Path.Combine(docPath, "answer.json"),"answer.json");
            request.AlwaysMultipartFormData = true;


            IRestResponse response = client.Execute(request);
        }
    }
}
