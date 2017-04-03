# testing


*Appium Testing*

Prerequisites
Appium, Nunit

* The test is a compiled C# assembly that is ran by Nunit()
* The source for the test is located in AppiumTest and can be built in Xamarin or Visual Studio for Mac
* The binary for the test, AppiumTest.dll, is located in AppiumTest/AppiumTest/bin/(Debug or Release)
* I’ve included a config file for Appium to run this test on Android

Test Steps:
1. The test populates a text input and textarea with two random strings
2. The test clicks the button
3. An alert pops up with the two input strings concatenated
4. The concatenated string is validated(currently there is no error condition)
5. The alert is closed
6. The test clicks on the other two tabs with a one second delay
7. Test output is saved as a Testresult.xml in the Nunit xml format which can be integrated with Jenkins



*Test App*

* The test app is located in ionicapp/testapp