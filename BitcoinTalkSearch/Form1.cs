using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;



namespace BitcoinTalkSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://bitcointalk.org/index.php?action=search;advanced");

            String keyword = txtKeyword.Text;
            String days = txtDays.Text;
            String sortBy = "Most recent topics first";


            try
            {

                //driver.FindElement(By.Name("search")).SendKeys(keyword);

                IWebElement bodyArea = driver.FindElement(By.Id("bodyarea"));
                bodyArea.FindElement(By.Name("search")).SendKeys(keyword);
                bodyArea.FindElement(By.Id("subject_only")).Click();
                bodyArea.FindElement(By.Name("maxage")).Clear();
                bodyArea.FindElement(By.Name("maxage")).SendKeys(days);

                IWebElement dropdown = bodyArea.FindElement(By.Name("sort"));
                SelectElement dropClick = new SelectElement(dropdown);
                dropClick.SelectByText(sortBy);

                bodyArea.FindElement(By.Id("check_all")).Click();
                bodyArea.FindElement(By.Id("exandBoardsIcon")).Click();
                bodyArea.FindElement(By.Id("brd159")).Click();

                bodyArea.FindElement(By.Name("submit")).Click();

            } catch (Exception ex) {
                MessageBox.Show("Selenium was unable to locate an element on the page.");
            }

        }

    }
}
