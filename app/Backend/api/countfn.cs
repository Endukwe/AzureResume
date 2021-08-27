using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("countfn")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"resumepage", collectionName: "visitorcount",
                ConnectionStringSetting = "nresumepagecosmosdb_DOCUMENTDB", Id ="1", PartitionKey ="1")] Count counter,
                [CosmosDB(databaseName:"resumepage", collectionName: "visitorcount",
                ConnectionStringSetting = "nresumepagecosmosdb_DOCUMENTDB", Id = "1", PartitionKey = "1")] out Count UpdatedCounter,
            ILogger log)
        {

            log.LogInformation("Countfn was triggered.");

            UpdatedCounter=counter;
            
            UpdatedCounter.count += 1;
            

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
