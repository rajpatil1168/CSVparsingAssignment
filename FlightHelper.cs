using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace HappyFlight
{
    class FlightHelper
    {
        public static void IsSucecssfunction(bool issucess)
        {
            if (issucess)
                Console.WriteLine("PROGRAM SUCCESSFULLY EXECUTED\n\n");
            else
                Console.WriteLine("\n PROGRAM NOT* SUCCESSFULLY EXECUTED\n\n");
        }

        public static void GetInfo(out bool oneway, out bool roundtrip, out string fromCityCode, out string toCityCode, out DateTime departuredate, out DateTime returndate, out string nameclass, out uint numberofAdults, out uint numberofChildren, out uint numberofInfants)
        {
            Console.WriteLine("\n________________________________________________________________________________________________________________");
            string ch;
            string classnumber;
            do
            {
                Console.WriteLine("Enter Which TripType you want: \nOneWay: Press 1\nRoundTrip: Press 2:");
                ch = Console.ReadLine();
            } while (!(String.Equals(ch, "1") || String.Equals(ch, "2")));

            if (String.Equals(ch, "1"))
            {
                oneway = true;
                roundtrip = false;
            }
            else
            {
                oneway = false;
                roundtrip = true;
            }
            Console.WriteLine("\n________________________________________________________________________________________________________________");






            Console.WriteLine("\n\nPress Code(1/2/3/4) From** which city/airport you want departure:[more than 3 character]");
            Console.WriteLine("\n1.Mumbai   2.Delhi   3.Kolkata   4.NewYork   5.Abu Dhabi");
            do
            {
                Console.WriteLine("Enter Which City you want correctly :: ");
                fromCityCode = Console.ReadLine();
            } while (!(String.Equals(fromCityCode, "1") || String.Equals(fromCityCode, "2") || String.Equals(fromCityCode, "3") || String.Equals(fromCityCode, "4") || String.Equals(fromCityCode, "5")));

            Console.WriteLine("\n\nPress Code(1/2/3/4) To** which city/airport you want departure:[more than 3 character]");
            Console.WriteLine("\n1.Mumbai   2.Delhi   3.Kolkata   4.NewYork   5.Abu Dhabi");
            do
            {
                Console.WriteLine("Enter Which City you want correctly :: ");
                toCityCode = Console.ReadLine();
            } while (!(String.Equals(toCityCode, fromCityCode) || String.Equals(toCityCode, "1") || String.Equals(toCityCode, "2") || String.Equals(toCityCode, "3") || String.Equals(toCityCode, "4") || String.Equals(fromCityCode, "5")));
            Console.WriteLine("\n________________________________________________________________________________________________________________\n");







            Console.Write("\nEnter DEPARTURE** date and time of flight (e.g. '{0}'  (24hr clock)):\n ", DateTime.Now);
            //DateTime inputtedDateTime = DateTime.Parse(Console.ReadLine());
            while (!(DateTime.TryParse(Console.ReadLine(), out departuredate) && departuredate.Date >= DateTime.Now))
                Console.Write("The value must be in proper type:(e.g. 10/22/1987), try again:");
            Console.WriteLine(departuredate);
            returndate = DateTime.Today.AddDays(-1);

            if (roundtrip)
            {
                Console.Write("\nEnter RETURN** date and time of flight (e.g. 10/22/1987) & must be after {0}: \n", departuredate.Date);
                //DateTime inputtedDateTime = DateTime.Parse(Console.ReadLine());
                while (!(DateTime.TryParse(Console.ReadLine(), out returndate) && departuredate < returndate))
                    Console.Write("The value must be in proper type:(e.g. 10/22/1987)& after{0}, try again:", departuredate);
                Console.WriteLine(returndate);

            }
            Console.WriteLine("\n________________________________________________________________________________________________________________\n");





            do
            {
                Console.Write("Enter Class number(1/2/3/4): 1.Economy     2.Premium Economy      3.Business      4.First\n ");
                classnumber = Console.ReadLine();
            } while (!(String.Equals(classnumber, "1") || String.Equals(classnumber, "2") || String.Equals(classnumber, "3") || String.Equals(classnumber, "4")));
            if (String.Equals(classnumber, "1"))
            {
                nameclass = "Economy";
            }
            else if (String.Equals(classnumber, "2"))
            {
                nameclass = "Premium Economy";
            }
            else if (String.Equals(classnumber, "3"))
            {
                nameclass = "Business";
            }
            else
            {
                nameclass = "First";
            }
            Console.WriteLine("\n________________________________________________________________________________________________________________\n");





            Console.Write("Enter Number of ADULTS: \n ");
            while (!(UInt32.TryParse(Console.ReadLine(), out numberofAdults) && numberofAdults <= 9))
                Console.Write("The value must be of positive integer type, try again:\n");

            Console.Write("Enter Number of Children: \n ");
            while (!(UInt32.TryParse(Console.ReadLine(), out numberofChildren) && ( numberofChildren) <= 6))
                Console.Write("The value must be of positive integer type & <{0}, try again :\n", 6);

            Console.Write("Enter Number of Infants: \n ");
            while (!(UInt32.TryParse(Console.ReadLine(), out numberofInfants) && numberofInfants <= 6))
                Console.Write("The value must be of positive integer type & <={0}, try again:\n", 6);
            Console.WriteLine("\n________________________________________________________________________________________________________________");
            Console.WriteLine("\n________________________________________________________________________________________________________________\n");


        }

        public static bool OpenUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(1000);
                if (driver.PageSource.Contains("Sign In"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FAILURE::URL did not load/valid: " + Global.test_url);
                return false;
            }
        }

        public static bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                if (driver.FindElement(by) != null)
                {
                    driver.FindElement(by);
                    return true;
                }
                else
                {
                    Console.WriteLine("IsELEMENT={0}   -->>> is NULL !", by);
                    throw new TestException("IsElementPresent did not load");
                }

            }
            catch (NoSuchElementException)
            {
                throw new TestException("IsElementPresent did not load");
            }
        }

        public static void ClickIfPresent(By by, IWebDriver driver)
        {
            try
            {
                if (IsElementPresent(by, driver))
                {
                    //do if exists
                    driver.FindElement(by).Click();
                }
                else
                {
                    //do if does not exists
                    Console.WriteLine("NOT CLICKED {0} ", by);
                    throw new TestException("ClickIfPresent did not load");
                }
            }
            catch
            {
                throw new TestException("ClickIfPresent did not load");
            }
        }

        public static void SendKeysIfPresent(By by, IWebDriver driver, string sendkeys)
        {
            try
            {
                if (IsElementPresent(by, driver))
                {
                    //do if exists
                    //driver.FindElement(by).Clear();
                    Console.WriteLine("Check ");

                    driver.FindElement(by).SendKeys(sendkeys);
                }
                else
                {
                    //do if does not exists
                    Console.WriteLine("NOT CLICKED {0} ", by);
                    throw new TestException("SendKeysIfPresent did not load");
                }
            }
            catch
            {
                throw new TestException("SendKeysIfPresent did not load");
            }
        }


        public static bool TravolookLogin(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1000);
                string phone = "9423270662";
                string password = "Ready2wrkNVIDIA";

                //ClickIfPresent(By.XPath("//p[text() = 'Your trips']"), driver);
                ClickIfPresent(By.XPath("//a[@id='getSignIn']"), driver);
                Thread.Sleep(3000);

                driver.SwitchTo().ParentFrame();
                IWebDriver X = driver.SwitchTo().Frame(driver.FindElement(By.Id("login-register")));
                X.FindElement(By.Id("user_phone")).SendKeys("9423270662");
                Console.WriteLine("\nUser 'Phone Number' Inserted Sucessfully");
                Thread.Sleep(1000);

                SendKeysIfPresent(By.XPath("//input[@id='password']"), driver, password);
                Console.WriteLine("\nUser 'Password' Inserted Sucessfully");
                Thread.Sleep(1000);

                ClickIfPresent(By.XPath("//button[@id='login-btn']"), driver);
                Console.WriteLine("\n'Login Button'Pressed Sucessfully");


                Thread.Sleep(500);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("FAILURE: {0}:FlightLogin did not load.");
                return false;
            }

        }


        public static string setCity(string CityCode)
        {
            string CityName;
            if (String.Equals(CityCode, "1"))
            {
                CityName = "Mumbai";
            }
            else if (String.Equals(CityCode, "2"))
            {
                CityName = "Delhi";
            }
            else if (String.Equals(CityCode, "3"))
            {
                CityName = "Kolkata";
            }
            else if (String.Equals(CityCode, "4"))
            {
                CityName = "Kolkata";
            }
            else
            {
                CityName = "Abu Dhabi";
            }
            return CityName;
        }


        //public static IWebElement SetAttribute(this IWebElement element, string name, string value)
        //{

        //    IWebElement targetElement = element;
        //    IWrapsDriver wrapsDriver = targetElement as IWrapsDriver;
        //    if (wrapsDriver == null)
        //    {
        //        var wrapsElement = element as IWrapsElement;
        //        if (wrapsElement == null)
        //        {
        //            throw new InvalidOperationException("webElement does not implement either IWrapsDriver or IWrapsElement");
        //        }

        //        targetElement = wrapsElement.WrappedElement;
        //        wrapsDriver = targetElement as IWrapsDriver;
        //        if (wrapsDriver == null)
        //        {
        //            throw new InvalidOperationException("webElement wraps another IWebElement, but the wrapped element does not implement IWrapsDriver");
        //        }
        //    }

        //    var driver = wrapsDriver.WrappedDriver;
        //    var jsExecutor = (IJavaScriptExecutor)driver;
        //    jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", element, name, value);

        //    return element;
        //}


        public static void InsertSearch(IWebDriver driver, bool oneway, bool roundtrip, string fromCityCode, string toCityCode, DateTime departuredate, DateTime returndate, string nameclass, uint numberofAdults, uint numberofChildren, uint numberofInfants)
        {
            string fromCityName = string.Empty, toCityName = string.Empty;
            try
            {
                Thread.Sleep(2000);
                fromCityName = setCity(fromCityCode);
                toCityName = setCity(toCityCode);
                ClickIfPresent(By.XPath("//a[@data-role='flight']"), driver);
                ClickIfPresent(By.XPath(" //button[@id='search_flights']"), driver);

                ////*[@id="returnDate"]
                //var jsExecutor = (IJavaScriptExecutor)driver;
                //jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", driver.FindElement(By.Id("returnDate")), "value", "2021-09-06");

                //input[@id='R_date']
                SendKeysIfPresent(By.Id("R_date"), driver, "Wed, 08 Sep 2021");
                Thread.Sleep(7000);

                if (oneway)
                {
                    ClickIfPresent(By.XPath("//*[@id='searchForm']/div[1]/nav/ul/li[1]/label/strong"), driver);
                }
                if (roundtrip)
                {
                    ClickIfPresent(By.XPath("//*[@id='searchForm']/div[1]/nav/ul/li[2]/label/strong"), driver);
                }


                //SendKeysIfPresent(By.Id("D_city"), driver, fromCityName);
                //SendKeysIfPresent(By.Id("A_city"), driver, toCityName);

                //driver.FindElement(By.XPath("//input[@id='D_city']").SendKeys(fromCityName);

                //driver.FindElement(By.ClassName("js-cityName")).SendKeys(fromCityName);

                //ClickIfPresent(By.Id("D_city"), driver);


                //SendKeysIfPresent(By.Id("D_city"), driver, fromCityName);
                //SendKeysIfPresent(By.Id("A_city"), driver, toCityName);

                //*[@id="ui-datepicker-div"]/div[1]/table/tbody/tr[2]/td[4]/a     8sept
                //*[@id="ui-datepicker-div"]/div[1]/table/tbody/tr[2]/td[5]/a     9sept
                //*[@id="ui-datepicker-div"]/div[1]/table/tbody/tr[2]/td[6]/a     10sept

                //*[@id="chose-person"]
                //var driver1 = ((IWrapsDriver)By.Id("From")).WrappedDriver;
                //var jsExecutor = (IJavaScriptExecutor)driver;
                //jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", driver.FindElement(By.Id("From")), "value", "PNQ");
                ////jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", By.Id("From"), "value", "PNQ");
                //IWebElement ele = SetAttribute(driver.FindElement(By.Id("From")), "value", "PNQ");
                Console.WriteLine("\n'Chnge'Pressed Sucessfully");






            }
            catch (Exception e)
            {
                Console.WriteLine("FAILURE::Insertsearch did not load.{0}", e);
                throw new TestException("Insertsearch did not load.");
            }












        }
    }
}
