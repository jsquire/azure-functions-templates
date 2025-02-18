using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class CosmosDBTriggerCSharp
    {
        private readonly ILogger _logger;

        public CosmosDBTriggerCSharp(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CosmosDBTriggerCSharp>();
        }

        [Function("CosmosDBTriggerCSharp")]
        public void Run([CosmosDBTrigger(
            databaseName: "DatabaseValue",
            containerName: "CollectionValue",
            Connection = "ConnectionValue",
            LeaseContainerName = "leases")] IReadOnlyList<MyDocument> input)
        {
            if (input != null && input.Count > 0)
            {
                _logger.LogInformation("Documents modified: " + input.Count);
                _logger.LogInformation("First document Id: " + input[0].Id);
            }
        }
    }

    public class MyDocument
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public bool Boolean { get; set; }
    }
}
