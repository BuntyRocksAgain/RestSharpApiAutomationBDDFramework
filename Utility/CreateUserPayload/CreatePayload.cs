using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationBDD.Utility.CreateUserPayload
{
    public class PayloadCreatorforUserCreation
    {
        private string? name;
        private string? job;

        public string SetName(string name)
        {
            this.name = name;
            return name;
        }

        public string SetJob(string job)
        {
            this.job = job;
            return job;
        }
        public string createPayload(string name, string job)
        {
            var payloadData = new
            {
                name,
                job
            };

            string payloadJson = JsonConvert.SerializeObject(payloadData);

            return payloadJson;
        }
    }

}
