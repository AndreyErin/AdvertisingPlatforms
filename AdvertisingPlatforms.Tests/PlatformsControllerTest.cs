//using AdvertisingPlatforms.Controllers;
//using AdvertisingPlatforms.Domain.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Moq;


namespace AdvertisingPlatforms.Tests
{
    //public class PlatformsControllerTest
    //{
    //    [Fact]
    //    public void Get()
    //    {
    //        //Arrange
    //        var mockReader = new Mock<IReader>();

    //        List<string> stringList1 = new() { "Первая площадка", "Вторая площадка" };
    //        var mockPlatformService1 = new Mock<IAdvertisingPlatformsService>();
    //        mockPlatformService1.Setup(x=>x.GetAdvertisingPlatforms(It.IsAny<string>())).Returns(stringList1);
    //        AdvertisingPlatformsController platformsController1 = new(mockPlatformService1.Object, mockReader.Object);

    //        var mockPlatformService2 = new Mock<IAdvertisingPlatformsService>();
    //        mockPlatformService2.Setup(x => x.GetAdvertisingPlatforms(It.IsAny<string>())).Returns(new List<string>());
    //        AdvertisingPlatformsController platformsController2 = new(mockPlatformService2.Object, mockReader.Object);

    //        //Act
    //        var result1 = platformsController1.Get("");
    //        var result2 = platformsController2.Get("");

    //        //Assert
    //        Assert.NotNull(result1);
    //        Assert.IsType<OkObjectResult>(result1);
    //        Assert.Equal("Первая площадка", ((result1 as ObjectResult)?.Value as List<string>)?[0]);

    //        Assert.NotNull(result2);
    //        Assert.IsType<NotFoundResult>(result2);
    //    }

    //    [Fact]
    //    public async Task UpdateAsync()
    //    {
    //        //Arrange
    //        var mockPfService = new Mock<IAdvertisingPlatformsService>();
    //        mockPfService.Setup(x=>x.SetDbAdvertisingPlatforms(It.IsAny<Dictionary<string, List<string>>>())).Returns(5);

    //        Dictionary<string, List<string>>? db1 = new();
    //        Dictionary<string, List<string>>? db2 = null;
    //        Dictionary<string, List<string>>? db3 = new() { { "Ключ1",new() { "Значение" } }, { "Ключ2", new() { "Значение" } } };
    //        var mockReader1 = new Mock<IReader>();
    //        mockReader1.Setup(x=> x.GetDataFromFileAsync(It.IsAny<IFormFile>())).ReturnsAsync(db1);
    //        AdvertisingPlatformsController platformsController1 = new AdvertisingPlatformsController(mockPfService.Object, mockReader1.Object);

    //        var mockReader2 = new Mock<IReader>();
    //        mockReader2.Setup(x => x.GetDataFromFileAsync(It.IsAny<IFormFile>())).ReturnsAsync(db2);
    //        AdvertisingPlatformsController platformsController2 = new AdvertisingPlatformsController(mockPfService.Object, mockReader2.Object);

    //        var mockReader3 = new Mock<IReader>();
    //        mockReader3.Setup(x => x.GetDataFromFileAsync(It.IsAny<IFormFile>())).ReturnsAsync(db3);
    //        AdvertisingPlatformsController platformsController3 = new AdvertisingPlatformsController(mockPfService.Object, mockReader3.Object);

    //        //Act
    //        var resultUnprocessableEntity = await platformsController1.UpdateAsync(It.IsAny<IFormFile>());
    //        var resultStatusCode500 = await platformsController2.UpdateAsync(It.IsAny<IFormFile>());
    //        var resultOk = await platformsController3.UpdateAsync(It.IsAny<IFormFile>());

    //        //Assert
    //        Assert.NotNull(resultUnprocessableEntity);
    //        Assert.IsType<UnprocessableEntityObjectResult>(resultUnprocessableEntity);
    //        Assert.True((resultUnprocessableEntity as UnprocessableEntityObjectResult)?.Value is string);

    //        Assert.NotNull(resultStatusCode500);
    //        Assert.IsType<StatusCodeResult>(resultStatusCode500);
    //        Assert.Equal(500, (resultStatusCode500 as StatusCodeResult)?.StatusCode);

    //        Assert.NotNull(resultOk);
    //        Assert.IsType<OkObjectResult>(resultOk);
    //        Assert.True((resultOk as OkObjectResult)?.Value is string);
    //    }
    //}
}
