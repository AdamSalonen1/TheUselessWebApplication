using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.Events;

namespace TheUselessWebApplication
{
    internal class DataLayer
    {
        public DataLayer() { }

        /// <summary>
        /// Auto clicking bot for Pop Cat website
        /// </summary>

        public void PopCat()
        {
            WebDriver driver = new ChromeDriver();
            driver.Url = "https://popcat.click/";
            Sleep(2);
            driver.Manage().Window.Maximize();

            PopCatRecursion(driver);

        }

        public void Hacker()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtention", false);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            WebDriver driver = new ChromeDriver(driverService, options);
            driver.Url = "https://hackertyper.net/#";

            SendKeys.SendWait("{F11}");
            driver.FindElement(By.XPath("/html/body/div[3]/div[5]/a")).Click();
            Sleep(1);
            while (true)
            {
                SendKeys.SendWait(ConfigurationManager.AppSettings["error"]);
            }
        }

        /// <summary>
        /// Helper method which makes it so that if you pull up the leaderboard the app doesn't crash, rather it pauses until the leaderboard goes away
        /// </summary>
        /// <param name="driver"></param>
        public static void PopCatRecursion(WebDriver driver)
        {
            try
            {
                while (true)
                {
                    driver.FindElement(By.XPath("/html/body/div/div")).Click();
                }
            }
            catch (Exception ex)
            {
                PopCatRecursion(driver);
            }
        }

        public void CheckboxRace()
        {
            WebDriver driver = new ChromeDriver();
            driver.Url = "https://checkboxrace.com/";
            Sleep(1);

            ///html/body/div[1]/input[1]
            ////html/body/div[1]/input[1]
            ////html/body/div[1]/input[1]
            ////html/body/div[1]/input[2]
            ////html/body/div[1]/input[3]
            ////html/body/div[1]/input[100]

            for (int i = 1; i < 101; i++)
            {
                CheckboxRecursion(i, driver);
            }

        }

        public static void CheckboxRecursion(int i, WebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath($"html/body/div[1]/input[{i}]")).Click();
                System.Threading.Thread.Sleep(45);
            }
            catch(Exception ex)
            {
                Sleep(1);
                CheckboxRecursion(i, driver);
            }
        }

        public void CookieClicker()
        {
            WebDriver driver = new ChromeDriver();
            driver.Url = "https://orteil.dashnet.org/cookieclicker/";
            Sleep(1);
            //driver.Manage().Window.Maximize();

            ClickElement("id", "langSelect-EN", driver);

            while (true)
            {
                ClickElement("id", "bigCookie", driver);

                Console.WriteLine("CSS TEST: " + driver.FindElement(By.Id("product0")).GetCssValue("text"));
                Console.WriteLine("Attribute TEST: " + driver.FindElement(By.Id("product0")).GetAttribute("text"));


                if (driver.FindElement(By.Id("product5")).GetAttribute("class").Contains("enabled"))
                {
                    driver.FindElement(By.Id("product5")).Click();
                }

                if (driver.FindElement(By.Id("product4")).GetAttribute("class").Contains("enabled"))
                {
                    driver.FindElement(By.Id("product4")).Click();
                }

                if (driver.FindElement(By.Id("product3")).GetAttribute("class").Contains("enabled"))
                {
                    driver.FindElement(By.Id("product3")).Click();
                }

                if (driver.FindElement(By.Id("product2")).GetAttribute("class").Contains("enabled"))
                {
                    driver.FindElement(By.Id("product2")).Click();
                }

                if (driver.FindElement(By.Id("product1")).GetAttribute("class").Contains("enabled"))
                {
                    driver.FindElement(By.Id("product1")).Click();
                }

                if (driver.FindElement(By.Id("product0")).GetAttribute("class").Contains("enabled"))
                {
                    driver.FindElement(By.Id("product0")).Click();
                }

                //try { driver.FindElement(By.Id("product0")).Click(); } catch (Exception) { }
            }
        }

        /// <summary>
        /// Helper method which tells the system to wait
        /// </summary>
        /// <param name="i"></param>
        public static void Sleep(int i)
        {
            string sleepString = i + "000";
            System.Threading.Thread.Sleep(Int32.Parse(sleepString));
        }

        public static void ClickElement(string by, string elementName, WebDriver driver)
        {
            if (by.ToLower().Equals("xpath"))
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementName)));
                element.Click();
            }
            else if (by.ToLower().Equals("id"))
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(elementName)));
                element.Click();
            }
            else if (by.ToLower().Equals("name"))
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(elementName)));
                element.Click();
            }
        }
    }


}