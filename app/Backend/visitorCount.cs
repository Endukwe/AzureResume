using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Routing;
using Company.Function;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("visitorcountfn")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"resumepage", collectionName: "visitorcount",
                ConnectionStringSetting = "nresumepagecosmosdb_DOCUMENTDB", Id ="1", PartitionKey ="Id")] Count count,
                [CosmosDB(databaseName:"resumepage", collectionName: "visitorcount",
                ConnectionStringSetting = "nresumepagecosmosdb_DOCUMENTDB", Id = "1", PartitionKey = "Id")] out Count UpdatedCount,
            ILogger log)
        {

            log.LogInformation("GetResumeCounter was triggered.");

            UpdatedCount = count;
            UpdatedCount.count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(count);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}