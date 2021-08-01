namespace HP.Documents.resumepage.app.Backend
{
    public class visitorCount
    {
        [FunctionName("visitorcountfn")]
public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "count/id/1")]
    HttpRequest req,
    [CosmosDB(
                databaseName: "resumepage",
                collectionName: "visitorcount",
                ConnectionStringSetting = "Cosmosdbconnection",
                Id = "1",
                PartitionKey = "id")] Count count,
            ILogger log)
    [CosmosDB(
                databaseName: "resumepage",
                collectionName: "visitorcount",
                ConnectionStringSetting = "Cosmosdbconnection")]out Count Updatedcount, ILogger log)
                {
                     log.LogInformation("visitorcountfn was triggered.");

            updatedCount = count;
            updatedCount.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8)
            };
                }
    }
}