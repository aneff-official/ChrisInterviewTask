using ChrisInterviewTask.Controllers;
using ChrisInterviewTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChrisInterviewTask.Tests
{
	public class UnitTest
	{
		[Fact]
		public async Task PostCodeInfo_Returns_ObjectAsync()
		{
			var dummyArgument = "LS11 7AB";
			var expectedResult = "{\"status\":200,\"result\":{\"postcode\":\"LS11 7AB\",\"quality\":1,\"eastings\":428809,\"northings\":430531,\"country\":\"England\",\"nhs_ha\":\"Yorkshire and the Humber\",\"longitude\":-1.564394,\"latitude\":53.77033,\"european_electoral_region\":\"Yorkshire and The Humber\",\"primary_care_trust\":\"Leeds\",\"region\":\"Yorkshire and The Humber\",\"lsoa\":\"Leeds 090A\",\"msoa\":\"Leeds 090\",\"incode\":\"7AB\",\"outcode\":\"LS11\",\"parliamentary_constituency\":\"Leeds Central\",\"admin_district\":\"Leeds\",\"parish\":\"Leeds, unparished area\",\"admin_county\":null,\"date_of_introduction\":\"198001\",\"admin_ward\":\"Beeston & Holbeck\",\"ced\":null,\"ccg\":\"NHS West Yorkshire\",\"nuts\":\"Leeds\",\"pfa\":\"West Yorkshire\",\"codes\":{\"admin_district\":\"E08000035\",\"admin_county\":\"E99999999\",\"admin_ward\":\"E05012647\",\"parish\":\"E43000276\",\"parliamentary_constituency\":\"E14000777\",\"ccg\":\"E38000225\",\"ccg_id\":\"15F\",\"ced\":\"E99999999\",\"nuts\":\"TLE42\",\"lsoa\":\"E01011315\",\"msoa\":\"E02002419\",\"lau2\":\"E08000035\",\"pfa\":\"E23000010\"}}}";

			IConfiguration config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true)
				.AddEnvironmentVariables()
				.Build();

			IPostCodeService service = new PostCodeService(config);
			var controller = new HomeController(service);
			var actionResult = await controller.PostCodeInfo(dummyArgument);

			var result = actionResult as OkObjectResult;
			var val = result?.Value as string;

			Assert.Equal(expectedResult, val);
		}
	}
}