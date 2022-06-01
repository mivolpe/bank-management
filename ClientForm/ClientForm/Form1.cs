using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientForm
{
    public partial class Form1 : Form
    {

        HttpClient httpclient = new HttpClient { BaseAddress = new Uri("https://localhost:7177/api/") };
        private Random rand = new Random();
        DataTable dt = new DataTable();


        public Form1()
        {
            InitializeComponent();
            //httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RetrieveToken());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private async Task<Payment> randomPayment()
        {
            Payment payment = new Payment
            {
                amount = rand.Next(50000),
                TransmitterId = rand.Next(1, 50),
                ReceiverId = rand.Next(1, 50),
                DateTime = DateTime.Now,
                freeOrStructuredCommunication = " "
            };
            var rep = await httpclient.PostAsJsonAsync("Payment/makePayment", payment);
            return payment;
        }

        private void dataInGrid(Payment payment, int delais)
        {
            if (dt.Rows.Count == 0)
            {
                dt.Columns.Add("Transmetteur", typeof(int));
                dt.Columns.Add("Montant", typeof(decimal));
                dt.Columns.Add("Receveur", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Communication", typeof(string));
                dt.Columns.Add("Délais en s", typeof(int));
                dt.Rows.Add(payment.TransmitterId, payment.amount, payment.ReceiverId, payment.DateTime, payment.freeOrStructuredCommunication, delais);
            }
            else
            {
                dt.Rows.Add(payment.TransmitterId, payment.amount, payment.ReceiverId, payment.DateTime, payment.freeOrStructuredCommunication, delais);
            }

            dataGridView1.DataSource = dt;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            int delais = rand.Next(1, 5);
            timer1.Interval = delais * 1000;
            dataInGrid(await randomPayment(), delais);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        //public async Task<string> RetrieveToken()
        //{  
        //    var response = await httpclient.PostAsJsonAsync("login", new { email = "sam@hotmail.com", password = "123456" });
        //    response.EnsureSuccessStatusCode();
        //    var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
        //    string token = authResponse?.Token;
           
        //    return token;
        //}
    }
}
