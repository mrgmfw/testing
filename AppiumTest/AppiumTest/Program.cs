using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium.Android.Interfaces;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System.IO;
using OpenQA.Selenium.Appium.Android.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumTest
{
    class Program
    {
        [TestFixture()]
        public class ProgramTest
        {

            private AppiumDriver<AppiumWebElement> driver;

            [OneTimeSetUp]
            public void beforeAll()
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                // tablet:4103eb24548b602f vs:169.254.190.187:5555 avd: emulator-5554
                capabilities.SetCapability("deviceName", "emulator-5554");
                capabilities.SetCapability("platformName", "Android");
                capabilities.SetCapability("app", "/Users/michaelbryant/testing/testing/ionicapp/testapp/platforms/android/build/outputs/apk/android-debug.apk");
                //capabilities.SetCapability("chromedriverExecutable", "C:\\Users\\Mrwav\\Documents\\Visual Studio 2015\\Projects\\AppiumTest\\AppiumTest\\bin\\Debug\\chromedriver.exe");
                 driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            }

            [OneTimeTearDown]
            public void afterAll()
            {
                // shutdown
                driver.Quit();
            }

            [Test()]
            public void AppiumDriverMethodsTestCase()
            {
                string randomBase = "abcdef";
                string randomOne = "";
                string randomTwo = "";
                
                for (int i=0; i < 8; i++)
                {
                  int seed = new Random(DateTime.Now.Millisecond).Next(0, 1000) + i;
                  randomOne += randomBase.ToCharArray()[new Random(seed).Next(0, 5)];
                  seed = new Random(DateTime.Now.Millisecond).Next(0, 1000) * i;
                  randomTwo += randomBase.ToCharArray()[new Random(seed).Next(0, 5)];
                }
                
                WebDriverWait waitController = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                
                waitController.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("android.widget.EditText")));
                
                ReadOnlyCollection<AppiumWebElement> editTexts = driver.FindElementsByClassName("android.widget.EditText");
                
                foreach (AppiumWebElement editText in editTexts)
                {
                  if (editText.GetAttribute("contentDescription") == "Text Input: ")
                  {
                    editText.SendKeys(randomOne);
                  }
                  else if (editText.GetAttribute("contentDescription") == "Text Area: ")
                  {
                    editText.SendKeys(randomTwo);
                  }
                }
                
                ReadOnlyCollection<AppiumWebElement> buttons = driver.FindElementsByClassName("android.widget.Button");
                
                foreach (AppiumWebElement button in buttons)
                {
                  if (button.GetAttribute("contentDescription") == "CLICK ME ")
                  {
                    button.Click();
                  }
                }
                
                ReadOnlyCollection<AppiumWebElement> dialogs = driver.FindElementsByClassName("android.view.View");
                
                foreach (AppiumWebElement dialog in dialogs)
                {
                  if (dialog.GetAttribute("contentDescription") == randomOne+randomTwo)
                  {
                    Console.WriteLine("Dialog text matches random strings");
                  }
                }
                
                buttons = driver.FindElementsByClassName("android.widget.Button");
                
                foreach (AppiumWebElement button in buttons)
                {
                  if (button.GetAttribute("contentDescription") == "OK ")
                  {
                    button.Click();
                  }
                }
                
                ReadOnlyCollection<AppiumWebElement> tabs = driver.FindElementsByClassName("android.view.View");
                
                foreach (AppiumWebElement tab in tabs)
                {
                  if (tab.GetAttribute("contentDescription") == "information circleAbout " || tab.GetAttribute("contentDescription") == "contactsContact ")
                  {
                    tab.Click();
                    Thread.Sleep(1000);
                  }
                }
                
                
            }
        }
    }
}
