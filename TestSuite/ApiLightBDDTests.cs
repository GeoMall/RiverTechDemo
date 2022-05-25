using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiverTechDemo;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestSuite
{
    [TestClass]
    [Label("APILightBDDTests")]
    public partial class ApiLightBDDTests
    {
        [AssemblyInitialize]
        public static void Setup(TestContext testContext) { LightBddScope.Initialize(); }
        [AssemblyCleanup]
        public static void Cleanup() { LightBddScope.Cleanup(); }

        [Scenario]
        [Label("Correct API Call")]
        public void APICorrectDataCall() 
        {
            Runner.RunScenario(
                Given_the_API_is_called,
                Then_the_correct_data_should_be_returned
                );
        }


        [Scenario]
        [Label("API Call Different Input")]
        public void APIInCorrectDataCall()
        {
            Runner.RunScenario(
                Given_the_API_with_different_inputs_is_called,
                Then_different_data_should_be_returned
                );
        }


        [Scenario]
        [Label("API Call Successful Status Code")]
        public void APISuccessfulStatusCode()
        {
            Runner.RunScenario(
                Given_the_API_is_called_to_retrieve_status_code,
                Then_successful_status_code_should_be_returned
                );
        }

        [Scenario]
        [Label("API Call UnSuccessful Status Code")]
        public void APIUnSuccessfulStatusCode()
        {
            Runner.RunScenario(
                Given_the_API_is_called_to_retrieve_status_code_with_incorrect_url,
                Then_unsuccessful_status_code_should_be_returned
                );
        }

        [Scenario]
        [Label("API Call Using Post HTTP Verb")]
        public void APICallUsingPost()
        {
            Runner.RunScenario(
                Given_the_API_is_called_with_Post_http_verb,
                Then_unsuccessful_status_code_should_be_returned
                );
        }


    }


    public partial class ApiLightBDDTests : FeatureFixture
    {

        ApiHelper helper;
        UserModel mockModel;
        Task<UserModel> userModel;
        Task<HttpResponseMessage> response;
        Exception exc;

        [TestInitialize]
        public void TestInitialize()
        {
            helper = new ApiHelper();
            helper.InitializeClient();
            mockModel = new
                UserModel(1, "Leanne Graham", "Bret", "Sincere@april.biz", "hildegard.org", "1-770-736-8031 x56442",
                        new UserAddressModel("Kulas Light", "Apt. 556", "Gwenborough", "92998-3874",
                             new UserAddressGeoModel(-37.3159, 81.1496)
                         ),
                        new UserCompanyModel("Romaguera-Crona", "Multi-layered client-server neural-net", "harness real-time e-markets"));

        }

        //Scenario Correct API Call

        public void Given_the_API_is_called()
        {
            userModel = helper.CallApiUsingGet("1");
        }

        public void Then_the_correct_data_should_be_returned()
        {
            var exp = JsonConvert.SerializeObject(mockModel);
            var actual = JsonConvert.SerializeObject(userModel.Result);

            Assert.AreEqual(exp, actual);
        }

       
        //Scenario API Call Different Input

        public void Given_the_API_with_different_inputs_is_called()
        {
            userModel = helper.CallApiUsingGet("2");
        }

        public void Then_different_data_should_be_returned()
        {
            var exp = JsonConvert.SerializeObject(mockModel);
            var actual = JsonConvert.SerializeObject(userModel.Result);

            Assert.AreNotEqual(exp, actual);
        }

       
        //Scenario API Call Successful Status Code

        public void Given_the_API_is_called_to_retrieve_status_code()
        {
            response = helper.GetApiResponseStatus(1);
        }

        public void Then_successful_status_code_should_be_returned()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
        }

       
        //Scenario API Call UnSuccessful Status Code

        public void Given_the_API_is_called_to_retrieve_status_code_with_incorrect_url()
        {
            response = helper.GetApiResponseStatus(0);
        }

        public void Then_unsuccessful_status_code_should_be_returned()
        {
            Assert.AreEqual(HttpStatusCode.NotFound, response.Result.StatusCode);
        }


        //Scenario API Call Using Post HTTP Verb
        public void Given_the_API_is_called_with_Post_http_verb()
        {
            try
            {
                response = helper.CallApiUsingPost2("1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Assert.AreEqual(ex.Message, "Not Found");
                exc = ex;
            }
        }


    }
}
