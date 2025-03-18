using AdvertisingPlatforms.Models;

namespace AdvertisingPlatforms.Tests
{
    public class PlatformsServiceTest
    {
        [Fact]
        public void GetPlatformsResult()
        {
            //Arrange
            string region1 = "ru/msk";
            string region2 = "ru/svrd/revda";
            string region3 = "Привейт";
            PlatformsService pfService = new();

            //Act
            var result1 = pfService.GetPlatforms(region1);
            var result2 = pfService.GetPlatforms(region2);
            var result3 = pfService.GetPlatforms(region3);

            //Assert
            Assert.NotNull(result1);
            Assert.IsType<List<string>>(result1);
            Assert.Equal(2, result1?.Count);

            Assert.NotNull(result2);
            Assert.IsType<List<string>>(result2);
            Assert.Equal(3, result2?.Count);

            Assert.NotNull(result3);
            Assert.IsType<List<string>>(result3);
            Assert.Empty(result3);
        }

        [Fact]
        public void SetDbPlatforms()
        {
            //Arrange
            Dictionary<string, string> newData1 = new() 
            {
                { "/ru", "Яндекс.Директ" },
                { "/ru/svrd/revda", "Ревдинский рабочий" },
                { "/ru/svrd/pervik", "Ревдинский рабочий" },
                { "/ru/msk", "Газета уральских москвичей" },
                { "/ru/permobl", "Газета уральских москвичей" },
                { "/ru/chelobl", "Газета уральских москвичей" },
                { "/ru/svrd", "Крутая реклама" }
            };

            Dictionary<string, string> newData2 = new()
            {
                { "/ru", "Яндекс.Директ" },
                { "/ru/svrd", "Крутая реклама" }
            };

            Dictionary<string, string> newData3 = new();

            PlatformsService pfService = new();


            //Act
            var result1 = pfService.SetDbPlatforms(newData1);
            var result2 = pfService.SetDbPlatforms(newData2);
            var result3 = pfService.SetDbPlatforms(newData3);

            //Assert
            Assert.IsType<int>(result1);
            Assert.Equal(7, result1);

            Assert.IsType<int>(result2);
            Assert.Equal(2, result2);

            Assert.IsType<int>(result3);
            Assert.Equal(0, result3);
        }
    }
}
