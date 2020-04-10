using System;
using System.Collections.Generic;
using System.Linq;
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

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Selenium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IWebDriver web;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sel_brouser()
        {
            ChromeOptions options = new ChromeOptions();
            string str = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            options.AddArgument(string.Format("user-data-dir={0}",
                str + "\\AppData\\Local\\Google\\Chrome\\User Data"));
            //options.AddArgument(string.Format("user-data-dir={0}", 
            //"C:\\%USERNAME%\\AppData\\Local\\Google\\Chrome\\User Data"));
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            web = new ChromeDriver(driverService, options);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            sel_brouser();
            web.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            try
            {
                web.Navigate().GoToUrl("https://web.whatsapp.com/");
                //web.FindElement(By.CssSelector("_")).Click();


            }
            catch (Exception)
            {

                LOG.AppendText("Ошибка. Не удалось перейти по URL" + Environment.NewLine);
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

                  //В каком браузере будет работать наш бот, если лиса,

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //web.Navigate().GoToUrl("https://web.whatsapp.com/");
                var mass = web.FindElements(By.CssSelector("span"));

                foreach (var m in mass)
                {
                    int index = m.Text.CompareTo("Кванториум (педагоги)");
                    if (index ==0)
                    {
                        m.Click();
                    }
                }

            }
            catch (Exception)
            {

                LOG.AppendText("Ошибка. Не удалось перейти по URL" + Environment.NewLine);
            }
        }
    }
}
