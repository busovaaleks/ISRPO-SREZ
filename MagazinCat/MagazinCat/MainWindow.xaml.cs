using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MagazinCat.Models;

namespace MagazinCat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string URI = $"https://localhost:7100/api/Sale";
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "param1", tbDateStart.Text }, { "param2", tbDateEnd.Text } };
            FormUrlEncodedContent encodedContent = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await client.PostAsync(URI, encodedContent);
            response.EnsureSuccessStatusCode();
            string json = response.Content.ReadAsStringAsync().Result;
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(json);
            lv.ItemsSource = sales;

        }
    }
}
