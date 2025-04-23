using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace EmailService.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            string recipient = RecipientTextBox.Text;
            string body = BodyTextBox.Text;

            if (string.IsNullOrEmpty(recipient) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please enter recipient and message.");
                return;
            }

            var request = new
            {
                recipient,
                subject = "Test Email from WPF",
                body
            };

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5000/api/email/send", content);

                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Email sent successfully!");
                else
                    MessageBox.Show("Failed to send email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}