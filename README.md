# RiverTechDemo


## Solution Setup & Test Execution

### Overview

The solution implemented for this demo contains 2 projects; one called RiverTechDemo and the other called TestSuite. The RiverTechDemo project contains the
classes calling the API for the API Testing Exercise and classes for controlling the web interface for the UI Automated Testing. The TestSuite project contains
the test classes to test the API and User interface for *saucedemo.com*.

![image](https://user-images.githubusercontent.com/23236705/170435839-6fe92178-efe2-4249-9ce0-50e3f1018cad.png)

### Test Execution

- Open the solution in Visual Studio
- Open the Test Explorer window

![image](https://user-images.githubusercontent.com/23236705/170468228-6df8ae58-fd75-41ec-8482-412a3ba4deea.png)
- Click on *Run All Tests* button to execute all tests

## API Tests

### Problem
This exercise will evaluate if the candidate can integrate an HTTP client service to call an API. It will then verify that he can model and read the
response from the API and assert that response has the expected values by using assertions. This exercise should be completed using c# and related libraries.
CALL: *https://jsonplaceholder.typicode.com/users/1*

### Solution
For this exercise, a class called *APIHelper* was created to call the API. An class called *UserModel* was also created to model the response returned by the api call.
A class *ApiTests* was created to verify the api calls being made. There are total of 5 tests were created:

- TestDataIsCorrect:  
This test simulates the api call *https://jsonplaceholder.typicode.com/users/1* returning the expected values. It is then asserted 
that the values are identical by comparing the JSON repsonse with a JSON object with expected values.
          
- TestDataIsIncorrect  
This test simulates the api call *https://jsonplaceholder.typicode.com/users/2* returning different values than the expected values. It is then asserted 
that the values are not identical by comparing the JSON repsonse with a JSON object with expected values.
        
- TestStatusCodeIsSuccessful  
This test simulates the api call *https://jsonplaceholder.typicode.com/users/1* returning a successful response call. It is then asserted 
that the response returned should be *HttpStatusCode.OK*.

- TestStatusCodeIsUnSuccessful  
This test simulates the api call *https://jsonplaceholder.typicode.com/users/0* returning an unsuccessful response call 404 Not Found. It is then asserted 
that the response returned should be *HttpStatusCode.NotFound*.

- TestCallApiUsingPostAsync  
This test simulates the api call *https://jsonplaceholder.typicode.com/users/1* by using **POST** instead of **GET**. The will return an unsuccessful response. 
It is then asserted that the response returned should be *HttpStatusCode.NotFound*.


## UI Automation Tests

### Problem
This exercise will test that the candidate can implement a UI test scenario by using the selenium webdriver .net library and using the chrome driver as a browser. 
The candidate is expected to access the below mentioned web app navigate through it and assert the mentioned values and steps have been completed correctly.
Scenario:
- Open: https://www.saucedemo.com/
- Login using the following credentials: standard_user / secret_sauce
- Add the “Sauce Labs Fleece Jacket” item to the cart.
- Select the cart and assert that the item is present then click checkout.
- Input firstname, lastname and postcode (use any fake info) then click continue.
- Assert that page has the following values:
  - Item total 49.99
  - Tax 4.00
  - Total 53.99
- Click finish and verify that order has been dispatched (it is up to you on how to verify this).

### Solution
For this exercise, a class called *PageFunctions* was created to perform UI operations on the sauceDemo site. A class *UITests* was created to verify the operations
done on the site. There are total of 5 tests were created:

- TestSuccessfulLogin
This test was created to assert that the user successfully logged in using the credential "standard_user", "secret_sauce".

![image](https://user-images.githubusercontent.com/23236705/170473753-1757bbad-47e3-492d-aa86-8bfc707ba44b.png)

![image](https://user-images.githubusercontent.com/23236705/170473784-277a9104-e00c-419d-b217-b7f762ef5ee6.png)

- TestAddToCartIcon
This test was created to assert that the cart icon (top right corner) will increment the number of items in the cart when the “Sauce Labs Fleece Jacket” was
added to the basket.

![image](https://user-images.githubusercontent.com/23236705/170473856-78b6d212-1b08-4e38-b0bf-cbde7d5de634.png)

- TestItemAddedToCart
This test was created to assert that when the “Sauce Labs Fleece Jacket” was added to the basket, when the cart is opened, the item should be present in the list.

![image](https://user-images.githubusercontent.com/23236705/170473900-cdbcde20-6897-491e-badc-0fe39c21b8df.png)

- TestCheckOutDetails
This test was created to assert that when the user is loggedin and the item is added to the cart successfully, when the checkout details are filled in, the correct
amounts should be displayed.

![image](https://user-images.githubusercontent.com/23236705/170473971-ba56ce2a-9c1e-4cc4-9c33-2907178b616d.png)

![image](https://user-images.githubusercontent.com/23236705/170474018-b5f044f7-dd71-4637-adca-195d1c9397f7.png)

- TestCheckoutConfirmationMessage
This test was created to assert that when the user is loggedin, the item is added to the cart successfully and the checkout details are filled in, when the proceed
button is clicked, a confirmation message should be displayed that the item has been dispached. 

![image](https://user-images.githubusercontent.com/23236705/170474110-8993d9ee-770f-4a73-9e11-fb1eeece941c.png)

## LightBDD Framework Integration 

LightBDD framework was also added to the solution. Two test classes were created; one to test the API test scenarios called *ApiLightBDDTests* and another 
to test the UI test scenarios called *UiLightBDDTests*.

API Test Scenarios:

- APICorrectDataCall
- APIInCorrectDataCall
- APISuccessfulStatusCode
- APIUnSuccessfulStatusCode
- APICallUsingPost

UI Test Scenarios:

- SuccessfulLogin
- AddItemToCart
- ProceedToCheckout
- OrderItem



