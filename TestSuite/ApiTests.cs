using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiverTechDemo;
using RiverTechDemo.Models;
using System.Net;


namespace TestSuite
{
    [TestClass]
    public class ApiHelperTest
    {

        ApiHelper helper;
        UserModel mockModel;


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

        [TestMethod]
        public void TestDataIsCorrect()
        {
            var userModel = helper.CallApiUsingGet("1");
            var exp = JsonConvert.SerializeObject(mockModel);
            var actual = JsonConvert.SerializeObject(userModel.Result);
            
            Assert.AreEqual(exp, actual);
        }


        [TestMethod]
        public void TestDataIsIncorrect()
        { 
            var userModel = helper.CallApiUsingGet("2");
            var exp = JsonConvert.SerializeObject(mockModel);
            var actual = JsonConvert.SerializeObject(userModel.Result);

            Assert.AreNotEqual(exp, actual);
        }


        [TestMethod]
        public void TestStatusCodeIsSuccessful()
        {
            var response = helper.GetApiResponseStatus(1);
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [TestMethod]
        public void TestStatusCodeIsUnSuccessful()
        {
            var response = helper.GetApiResponseStatus(0);
            Assert.AreEqual(HttpStatusCode.NotFound, response.Result.StatusCode);

        }

        [TestMethod]
        public void TestCallApiUsingPostAsync()
        {
            var response = helper.CallApiUsingPost("1");
            Assert.AreEqual(HttpStatusCode.NotFound, response.Result.StatusCode);
        }
        
    }
}
