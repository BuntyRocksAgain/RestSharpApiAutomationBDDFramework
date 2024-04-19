using APIAutomationBDD.API_Mapings.Responses;
using APIAutomationBDD.API_Methods;
using APIAutomationBDD.Utility.CreateUserPayload;
using AventStack.ExtentReports.Gherkin.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.StepDefinitions
{
    [Binding]
    public class CreateNewUser
    {
        private string? NAME;
        private string? JOB;
        private RestResponse? responseStatusCode;
        private HttpStatusCode statusCode;

        [Given(@"user with name ""([^""]*)""")]
        public void GivenUserWithName(string name)
        {
            PayloadCreatorforUserCreation payloadCreate = new PayloadCreatorforUserCreation();
            NAME = payloadCreate.SetName(name);
            Console.WriteLine(payloadCreate);
        }

        [When(@"user with job ""([^""]*)""")]
        public void WhenUserWithJob(string job)
        {
            PayloadCreatorforUserCreation payloadCreate = new PayloadCreatorforUserCreation();
            JOB = payloadCreate.SetJob(job);
            Console.WriteLine(payloadCreate);

        }

        [When(@"user send request to createuser by sending URL as ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserSendRequestToCreateuserBySendingURLAsAnd(string URL, object payload)
        {
            PayloadCreatorforUserCreation payloadCreate = new PayloadCreatorforUserCreation();
            var JsonPayload = payloadCreate.createPayload(NAME!, JOB!);
            var createUser = new CreateUserMethod();
            responseStatusCode = createUser.UserCreationResponse(URL, JsonPayload);
            var content = responseStatusCode.Content;
            var users = JsonConvert.DeserializeObject<CreateUserResponseMapping>(content!);          
        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            statusCode = responseStatusCode!.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(201, code);
            Assert.AreEqual(NAME, "Raj");
            Assert.AreEqual(JOB, "leader");
        }

    }
}
