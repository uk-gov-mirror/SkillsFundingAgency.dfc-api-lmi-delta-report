﻿using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using DFC.Api.Lmi.Delta.Report.Models;
using DFC.Swagger.Standard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using SwaggerIgnoreAttribute = DFC.Swagger.Standard.Annotations.SwaggerIgnoreAttribute;

namespace DFC.Api.Lmi.Delta.Report.Functions
{
    [ExcludeFromCodeCoverage]
    public class ApiDefinition
    {
        private const string SwaggerJsonRoute = "swagger/json";
        private const string SwaggerUiRoute = "swagger/ui";
        private const string ApiDefinitionDescription = "National Careers Service LMI Delta Reports API is a RESTful API that provides a simple and consistent approach to reporting deltas of LMI data.";
        private const string ApiVersion = "0.1.0";

        private readonly ISwaggerDocumentGenerator swaggerDocumentGenerator;
        private readonly EnvironmentValues environmentValues;

        public ApiDefinition(ISwaggerDocumentGenerator swaggerDocumentGenerator, EnvironmentValues environmentValues)
        {
            this.swaggerDocumentGenerator = swaggerDocumentGenerator;
            this.environmentValues = environmentValues;
        }

        [SwaggerIgnore]
        [FunctionName("SwaggerUI")]
        public static Task<HttpResponseMessage> SwaggerUi(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = SwaggerUiRoute)]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, SwaggerJsonRoute));
        }

        [SwaggerIgnore]
        [FunctionName("SwaggerJson")]
        public async Task<IActionResult> SwaggerJson([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = SwaggerJsonRoute)] HttpRequest request)
        {
            var apiSuffix = environmentValues.EnvironmentNameApiSuffix;
            var apiTitle = "LMI Delta Reports API " + apiSuffix;
            var swaggerDoc = await Task.FromResult(swaggerDocumentGenerator.GenerateSwaggerDocument(
                request,
                apiTitle,
                ApiDefinitionDescription,
                SwaggerJsonRoute,
                ApiVersion,
                Assembly.GetExecutingAssembly(),
                false,
                false,
                "/"))
                .ConfigureAwait(false);

            return new OkObjectResult(swaggerDoc);
        }
    }
}
