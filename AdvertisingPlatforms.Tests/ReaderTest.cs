//using AdvertisingPlatforms.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace AdvertisingPlatforms.Tests
{
    //public class ReaderTest
    //{
    //    [Fact]
    //    public async Task GetValidDataAsyncResult()
    //    {
    //        //Arrange
    //        FileStream fileStream1 = File.Open(@"ReaderTestFiles\data1.txt", FileMode.Open);
    //        FileStream fileStream2 = File.Open(@"ReaderTestFiles\data2.txt", FileMode.Open);
    //        FileStream fileStream3 = File.Open(@"ReaderTestFiles\data3.txt", FileMode.Open);

    //        IFormFile file1 = new FormFile( fileStream1, 0, fileStream1.Length, "data1.txt","data1.txt");
    //        IFormFile file2 = new FormFile(fileStream2, 0, fileStream2.Length, "data2.txt", "data2.txt");
    //        IFormFile file3 = new FormFile(fileStream3, 0, fileStream3.Length, "data3.txt", "data3.txt");

    //        FileReader reader = new FileReader();

    //        //Act
    //        var result1 = await reader.GetDataFromFileAsync(file1);
    //        var result2 = await reader.GetDataFromFileAsync(file2);
    //        var result3 = await reader.GetDataFromFileAsync(file3);

    //        //Assert
    //        Assert.NotNull(result1);
    //        Assert.IsType<Dictionary<string, List<string>>?>(result1);
    //        Assert.Equal(7, result1.Count);

    //        Assert.NotNull(result2);
    //        Assert.IsType<Dictionary<string, List<string>>?>(result2);
    //        Assert.Equal(2, result2.Count);  
                                             
    //        Assert.NotNull(result3);         
    //        Assert.IsType<Dictionary<string, List<string>>?>(result3);
    //        Assert.Empty(result3);
    //    }
    //}
}
