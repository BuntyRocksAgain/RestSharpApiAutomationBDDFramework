using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using APIAutomationBDD.API_Methods;
using APIAutomationBDD.API_Mapings.Responses;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.StepDefinitions
{
    [Binding]
    public class UserGet
    {
        //private GetListOfUsers? response;

        private RestResponse? responseStatusCode;

        private HttpStatusCode statusCode;

        [Given(@"the user send the request with URL as ""([^""]*)""")]
        public void GivenTheUserSendTheRequestWithURLAs(string URL)
        {
            var getUser = new GetUserMethod();
            responseStatusCode = getUser.GetUserListResponse(URL);
            //response = getUser.GetUserListContent(URL);
            var content = responseStatusCode.Content;
            var users = JsonConvert.DeserializeObject<CreateUserResponseMapping>(content!);
        }

        [Then(@"the user should see the success statuscode")]
        public void ThenTheUserShouldSeeTheSuccessStatuscode()
        {
            statusCode = responseStatusCode!.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(200, code);
        }

    }
}
