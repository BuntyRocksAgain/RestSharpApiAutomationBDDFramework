using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationBDD.API_Mapings.Responses
{
    public class GetListOfUsers
    {
        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<Datum>? Data { get; set; }
        public Support? Support { get; set; }
    }


    public class Support
    {
        public Uri? Url { get; set; }
        public string? Text { get; set; }
    }

    public class Datum
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public Uri? Avatar { get; set; }

    }

}
