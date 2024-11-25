using FrameWorkLayer.Configure;
using FrameWorkLayer.Utilities;
using APITestLayer.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Login.StepDefinitions
{
    [Binding]
    public class APITestStepDefinitions
    {
        private APIUtility apiUtility;
        private readonly ScenarioContext scenarioContext;
        private readonly TestSettings testSettings;
        private readonly LoggerUtility loggerUtility;
        private object requestData;
        public APITestStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            testSettings = (TestSettings)scenarioContext["TestSettings"];
            loggerUtility = LoggerUtility.Instance;
            loggerUtility.SetFile("ConfigLogger.xml");
            loggerUtility.GetLogger<APITestStepDefinitions>();

        }

        [Given(@"I call the API")]
        public void GivenICallTheAPI()
        {
            loggerUtility.LogInfo("Api Started");
            apiUtility = new APIUtility(testSettings.GetUrl);
            scenarioContext["response"] = apiUtility.Get<BreedData>("breeds");
            scenarioContext["status"] = apiUtility.GetStausCode();
            Dictionary<string, string> paramters = new Dictionary<string, string>();
            paramters.Add("Limit", "1");
            scenarioContext["responseWithHeadersAndParameter"] = apiUtility.Get<BreedData>("breeds",paramters);
        }



        [Then(@"I should get the response")]
        public void ThenIShouldGetTheResponse()
        {
            var data = scenarioContext.Get<BreedData>("response");
            int statusCode = (int)scenarioContext["status"];
            Console.WriteLine(statusCode);
            BreedData dataWitHeaderAndParameter = scenarioContext.Get<BreedData>("responseWithHeadersAndParameter");
            Assert.That(statusCode == 200, Is.True);
        }




        [Given(@"I prepare the data to be sent")]
        public void GivenIPrepareTheDataToBeSent()
        {
            requestData = new
            {
                name = "John Doe",
                job = "Developer"
            };

            scenarioContext["requestData"] = requestData;
        }

        [When(@"I send a POST request to the API")]
        public void WhenISendAPOSTRequestToTheAPI()
        {
            apiUtility = new APIUtility(testSettings.PostUrl);
            var (data, StatusCode) = apiUtility.Post<dynamic, object>("/api/users", requestData);

            scenarioContext["response"] = data;
            scenarioContext["statusCode"] = StatusCode;
        }

        [Then(@"I should get a successful response")]
        public void ThenIShouldGetASuccessfulResponse()
        {
            var response = scenarioContext["response"] as dynamic;
            var statusCode = (HttpStatusCode)scenarioContext["statusCode"];

            
            loggerUtility.LogInfo($"Status Code: {statusCode}");
            loggerUtility.LogInfo($"Response Data: {JsonConvert.SerializeObject(response, Formatting.Indented)}");
            if (statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Expected status code 201 or 200, but got {statusCode}");
            }
        }



    }
}