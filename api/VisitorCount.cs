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
using api;

namespace Resume.Function
{
    public static class VisitorCount
    {
       [FunctionName("VisitorCount")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"resumepage", collectionName: "visitorCount",
                ConnectionStringSetting = "CloudResume", Id = "visitorCount", PartitionKey = "id")] Counter counter,
                [CosmosDB(databaseName:"resumepage", collectionName: "visitorCount",
                ConnectionStringSetting = "CloudResume", Id = "visitorCount", PartitionKey = "id")] out Counter updatedCounter,
            ILogger log)
        {

            log.LogInformation("VisitorCount was triggered.");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
