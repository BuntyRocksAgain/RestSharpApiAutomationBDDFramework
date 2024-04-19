using APIAutomationBDD.API_Mapings.Requests;
using APIAutomationBDD.API_Mapings.Responses;
using APIAutomationBDD.Utility.APIEndPoints;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationBDD.API_Methods
{
    public class CreateUserMethod
    {
        //string payload = @"{
        //                    ""name"": ""Raj"",
        //                     ""job"": ""leader""
        //                    }";

        // Above code is to create a JSON Payload Manually


        public RestResponse UserCreationResponse(string URL, Object payload)
        {
            var restClient = new RestClient(URL);
            var restRequest = new RestRequest(Endpoints.CREATE_USER, Method.Post);
            //restRequest.AddHeader("Accept", "application/json");
            restRequest.AddBody(payload);
            restRequest.RequestFormat = DataFormat.Json;
            RestResponse response = restClient.Execute(restRequest);
            return response;

            //var content = response.Content;
            //var users = JsonConvert.DeserializeObject<CreateUserResponseMapping>(content!);
            // Above code is to Deserialize the response
        }
    }
}
