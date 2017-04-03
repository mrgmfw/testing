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
                //driver.SwitchTo().Window("WEBVIEW");
                ReadOnlyCollection<string> contexts = driver.Contexts;
                foreach (string con in contexts)
                {
                    Console.WriteLine("---test---" + con);
                }
                
                driver.FindElement(By.Name("Text Input: ")).SendKeys("asdf");
                driver.FindElement(By.Name("Text Area: ")).SendKeys("asdf");
                driver.FindElement(By.Name("CLICK ME ")).Click();
                
                driver.Context = "WEBVIEW_io.cordova.hellocordova";
                AppiumWebElement alertText = driver.FindElement(By.CssSelector("h3[class='alert-sub-title']"));
                Assert.AreEqual("asdfasdf", alertText.Text);
                
                
                driver.FindElement(By.Name("information circleAbout ")).Click();
                driver.FindElement(By.Name("contactsContact ")).Click();
                
                driver.Context = "WEBVIEW_io.cordova.hellocordova";
                
                AppiumWebElement textInput = driver.FindElement(By.Id("textInput"));
                textInput.SendKeys("Just some text");

                AppiumWebElement button = driver.FindElement(By.Id("btn"));
                button.Click();

                AppiumWebElement showText = driver.FindElement(By.Id("showText"));

                Assert.AreEqual("Mike", showText.Text);

                //AppiumWebElement email = driver.FindElement(By.CssSelector("input[class='app-input email']"));
                //email.SendKeys("mike@abc.com");
                //AppiumWebElement password = driver.FindElement(By.CssSelector("input[class='app-input password']"));
                //password.SendKeys("abc123");
                //IWebElement signinBtn = driver.FindElement(By.CssSelector("div[class='app-button sign-in']"));
                //signinBtn.Click();

                //driver.FindElement(By.CssSelector("div[class='app-button clear']")).Execute(DriverCommand.ClickElement);
                //AppiumWebElement clearBtn = driver.FindElement(By.CssSelector("div[class='app-button clear']"));
                //ReadOnlyCollection<AppiumWebElement> c = driver.FindElements(By.CssSelector("div[data-clickable-class='active']"));
                //foreach (AppiumWebElement a in c)
                //{
                //    a.Click();
                //    Console.WriteLine(a.Text);
                //}
                //clearBtn.SendKeys(Keys.Enter);
                //clearBtn.Click();
                //email.Clear();
                //email.SendKeys("mike@abc.com");
                //string s = driver.PageSource;
                //Console.WriteLine(s);
                //AppiumWebElement email = driver.FindElement(By.CssSelector("input[class='app-input email']"));
                //driver.Context = "NATIVE_APP";
                //email.Tap(1, 50);
                //driver.Keyboard.SendKeys("mike@abc.com");
                //email.SendKeys("mike@abc.com");
                //AppiumWebElement password = driver.FindElement(By.CssSelector("input[class='app-input password']"));
                //password.SendKeys("abc123");
                //AppiumWebElement signin = driver.FindElement(By.CssSelector("div[class='app-button sign-in']"));
                //signin.Click();

                //// Create a wait controller
                //WebDriverWait waitController = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //// Click Add Contact
                //AppiumWebElement addContactButton = driver.FindElementById("com.example.android.contactmanager:id/addContactButton");    //.FindElementById("android:id/text1");  //.FindElementByClassName("android.widget.TextView");          //FindElementsByAndroidUIAutomator("new UiSelector().enabled(true)");
                //addContactButton.Click();

                ////waitController.Until(ExpectedConditions.ElementToBeClickable(By.Name("Contact Name")));

                //// Enter name
                //AppiumWebElement name = driver.FindElement(By.Id("com.example.android.contactmanager:id/contactNameEditText"));
                //name.SendKeys("Mike");

                //// Enter phone number
                //AppiumWebElement phone = driver.FindElement(By.Id("com.example.android.contactmanager:id/contactPhoneEditText"));
                //phone.SendKeys("1112223333");

                //// Change phone contact type
                //AppiumWebElement phoneType = driver.FindElement(By.Id("com.example.android.contactmanager:id/contactPhoneTypeSpinner"));
                //phoneType.Click();
                //AppiumWebElement phoneTypeChoice = driver.FindElement(By.Name("Mobile"));
                //phoneTypeChoice.Click();

                //// Enter email
                //AppiumWebElement email = driver.FindElement(By.Id("com.example.android.contactmanager:id/contactEmailEditText"));
                //email.SendKeys("mike@abc.com");

                //// Change email contact type
                //AppiumWebElement emailType = driver.FindElement(By.Id("com.example.android.contactmanager:id/contactEmailTypeSpinner"));
                //emailType.Click();
                //AppiumWebElement emailTypeChoice = driver.FindElement(By.Name("Work"));
                //emailTypeChoice.Click();

                //// Click the save button
                //AppiumWebElement saveButton = driver.FindElement(By.Name("Save")); //com.example.android.contactmanager:id/contactSaveButton
                //saveButton.Click();

                //// Click show contacts
                //AppiumWebElement showContactsCheckbox = driver.FindElement(By.Id("com.example.android.contactmanager:id/showInvisible"));
                //showContactsCheckbox.Click();

                //// Create collection of contacts
                //ReadOnlyCollection<AppiumWebElement> contactList = driver.FindElements(By.Id("com.example.android.contactmanager:id/contactEntryText"));

                //// Iterate over contacts
                //foreach (AppiumWebElement contact in contactList)
                //{
                //    // Validate Mike contact exist
                //    Assert.AreEqual("Mike", contact.Text);
                //}
            }
        }
    }
}
