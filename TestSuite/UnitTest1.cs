using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiverTechDemo;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RiverTechDemoTests
{
    [TestClass]
    public class ApiHelperTest
    {

        ApiHelper helper;

        [TestInitialize]
        public void TestInitialize()
        {
            helper = new ApiHelper();
            helper.InitializeClient();
        }

        [TestMethod]
        public void TestDataIsCorrect()
        {
            var userModel = helper.CallApi(1);
            UserModel mockModel = new 
                UserModel(1, "Leanne Graham", "Bret", "Sincere@april.biz", "hildegard.org", "1-770-736-8031 x56442", 
                        new UserAddressModel("Kulas Light", "Apt. 556", "Gwenborough", "92998-3874",
                             new UserAddressGeoModel(-37.3159, 81.1496)
                         ), 
                        new UserCompanyModel("Romaguera-Crona", "Multi-layered client-server neural-net", "harness real-time e-markets"));


            var actual = JsonConvert.SerializeObject(userModel.Result);
            var exp = JsonConvert.SerializeObject(mockModel);
            Assert.AreEqual(exp, actual);
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
    }
}
