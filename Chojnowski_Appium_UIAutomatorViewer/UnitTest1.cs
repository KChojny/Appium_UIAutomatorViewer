using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;

namespace Chojnowski_Appium_UIAutomatorViewer
{
    [TestClass]
    public class UnitTest1
    {
        AndroidDriver<AppiumWebElement>? driver;

        IWebElement plus, minus, divide, multiply, equals, point;
        IWebElement[] digits = new IWebElement[10];



        [TestInitialize]
        public void BeforeTest()
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");

            driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);

            plus = (IWebElement)driver.FindElementByAccessibilityId("plus");
            minus = (IWebElement)driver.FindElementByAccessibilityId("minus");
            divide = (IWebElement)driver.FindElementByAccessibilityId("divide");
            multiply = (IWebElement)driver.FindElementByAccessibilityId("multiply");
            equals = (IWebElement)driver.FindElementByAccessibilityId("equals");
            point = (IWebElement)driver.FindElementByAccessibilityId("point");

            digits[0] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_0");
            digits[1] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_1");
            digits[2] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_2");
            digits[3] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_3");
            digits[4] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_4");
            digits[5] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_5");
            digits[6] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_6");
            digits[7] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_7");
            digits[8] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_8");
            digits[9] = (IWebElement)driver.FindElementById("com.google.android.calculator:id/digit_9");
        }

        // 2+2*2-2/2 = 5
        [TestMethod]
        public void TestMethod1()
        {
            Clear();
            
            digits[2].Click();
            plus.Click();
            digits[2].Click();
            multiply.Click();
            digits[2].Click();
            minus.Click();
            digits[2].Click();
            divide.Click();
            digits[2].Click();
            equals.Click();
            
            string result = Result();
            string expected = "5";
            Assert.AreEqual(expected, result);
        }

        // 123*456+789/100-12345 = 43750.89
        [TestMethod]
        public void TestMethod2()
        {
            Clear();
            
            digits[1].Click();
            digits[2].Click();
            digits[3].Click();
            multiply.Click();
            digits[4].Click();
            digits[5].Click();
            digits[6].Click();
            plus.Click();
            digits[7].Click();
            digits[8].Click();
            digits[9].Click();
            divide.Click();
            digits[1].Click();
            digits[0].Click();
            digits[0].Click();
            minus.Click();
            digits[1].Click();
            digits[2].Click();
            digits[3].Click();
            digits[4].Click();
            digits[5].Click();
            equals.Click();
            
            string result = Result();
            string expected = "43750.89";
            Assert.AreEqual(expected, result);
        }

        private void Clear()
        {
            IWebElement clear = (IWebElement)driver.FindElementById("com.google.android.calculator:id/clr");
            clear.Click();
        }

        private string Result()
        {
            IWebElement result = (IWebElement)driver.FindElementById("com.google.android.calculator:id/result_final");
            return result.Text;
        }
    }
}