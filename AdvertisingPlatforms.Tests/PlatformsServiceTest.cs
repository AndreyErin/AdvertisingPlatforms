//using AdvertisingPlatforms.Domain.Services;
//using Moq;


namespace AdvertisingPlatforms.Tests
{
    //public class PlatformsServiceTest
    //{
    //    [Fact]
    //    public void GetPlatformsResult()
    //    {
    //        //Arrange
    //        Dictionary<string, List<string>> data = new()
    //        {
    //            { "/ru", new List<string>{ "Яндекс.Директ" } },
    //            { "/ru/svrd/revda", new List < string > { "Ревдинский рабочий", "Крутая реклама", "Яндекс.Директ" } },
    //            { "/ru/svrd/pervik", new List < string > { "Ревдинский рабочий", "Крутая реклама", "Яндекс.Директ" } },
    //            { "/ru/msk", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
    //            { "/ru/permobl", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
    //            { "/ru/chelobl", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
    //            { "/ru/svrd", new List < string > { "Крутая реклама", "Яндекс.Директ" } }
    //        };

    //        string region1 = "ru/msk";
    //        string region2 = "ru/svrd/revda";
    //        string region3 = "Привейт";

    //        var mockPlatformsRepository = new Mock<IPlatformsRepository>();
    //        mockPlatformsRepository.Setup(x => x.GetDb()).Returns(data);

    //        AdvertisingPlatformsService pfService = new(mockPlatformsRepository.Object);

    //        //Act
    //        var result1 = pfService.GetAdvertisingPlatforms(region1);
    //        var result2 = pfService.GetAdvertisingPlatforms(region2);
    //        var result3 = pfService.GetAdvertisingPlatforms(region3);

    //        //Assert
    //        Assert.NotNull(result1);
    //        Assert.IsType<List<string>>(result1);
    //        Assert.Equal(2, result1?.Count);

    //        Assert.NotNull(result2);
    //        Assert.IsType<List<string>>(result2);
    //        Assert.Equal(3, result2?.Count);

    //        Assert.NotNull(result3);
    //        Assert.IsType<List<string>>(result3);
    //        Assert.Empty(result3);
    //    }

    //    [Fact]
    //    public void SetDbPlatforms()
    //    {
    //        //Arrange
    //        Dictionary<string, List<string>> newData1 = new() 
    //        {
    //            { "/ru", new List<string>{ "Яндекс.Директ" } },
    //            { "/ru/svrd/revda", new List < string > { "Ревдинский рабочий", "Крутая реклама", "Яндекс.Директ" } },
    //            { "/ru/svrd/pervik", new List < string > { "Ревдинский рабочий", "Крутая реклама", "Яндекс.Директ" } },
    //            { "/ru/msk", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
    //            { "/ru/permobl", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
    //            { "/ru/chelobl", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
    //            { "/ru/svrd", new List < string > { "Крутая реклама", "Яндекс.Директ" } }
    //        };

    //        Dictionary<string, List<string>> newData2 = new()
    //        {
    //            { "/ru", new() { "Яндекс.Директ" } },
    //            { "/ru/svrd", new() { "Крутая реклама" } }
    //        };

    //        Dictionary<string, List<string>> newData3 = new();

    //        var mockPlatformsRepository = new Mock<IPlatformsRepository>();
    //        mockPlatformsRepository.Setup(x=>x.SetDb(It.IsAny<Dictionary<string,List<string>>>())).Returns(1);

    //        AdvertisingPlatformsService pfService = new(mockPlatformsRepository.Object);


    //        //Act
    //        var result1 = pfService.SetDbAdvertisingPlatforms(newData1);
    //        var result2 = pfService.SetDbAdvertisingPlatforms(newData2);
    //        var result3 = pfService.SetDbAdvertisingPlatforms(newData3);

    //        //Assert
    //        Assert.IsType<int>(result1);
    //        Assert.Equal(7, result1);

    //        Assert.IsType<int>(result2);
    //        Assert.Equal(2, result2);

    //        Assert.IsType<int>(result3);
    //        Assert.Equal(0, result3);
    //    }
    //}
}
