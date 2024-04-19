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
    public class GetUserMethod
    {
        public RestResponse GetUserListResponse(string URL)
        {
            var restClient = new RestClient(URL);
            var restRequest = new RestRequest(Endpoints.GET_USER, Method.Get);
            //restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            RestResponse response = restClient.Execute(restRequest);
            return response;

        }
    }
}
