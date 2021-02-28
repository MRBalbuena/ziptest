using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Zip.Backend.Data;
using Zip.Backend.Provider;
using Zip.Backend.Repositories;
using Zip.Backend.Repositories.RepositoryModels;

namespace Zip.Backend.Tests
{
  public class GalleryProviderTest
  {
    [Fact]
    public async void GetGalleryAsync_Returns_images()
    {
      var dbName = Guid.NewGuid().ToString();
      var options = new DbContextOptionsBuilder<GuestBookContext>()
          .UseInMemoryDatabase(databaseName: dbName).Options;

      var mqDogGalleryRepo = new Mock<IDogGalleryRepo>();      
      mqDogGalleryRepo.Setup(dgr => dgr.GetDogGalleryDataAsync()).ReturnsAsync(MockRepo.GetMockGalleryResponse());

      await using (var dbContext = new GuestBookContext(options))
      {
        var gp = new GalleryProvider(mqDogGalleryRepo.Object, dbContext);

        var r = await gp.GetGalleryAsync();

        r.Length.Should().Be(8);
        r.Select(a => a.Url).Should().NotBeNullOrEmpty();
      }
    }

    [Fact]
    public async void GetGalleryAsync_stores_up_to_limit()
    {
      var dbName = Guid.NewGuid().ToString();
      var options = new DbContextOptionsBuilder<GuestBookContext>()
          .UseInMemoryDatabase(databaseName: dbName).Options;

      var mqDogGalleryRepo = new Mock<IDogGalleryRepo>();
      mqDogGalleryRepo.Setup(dgr => dgr.GetDogGalleryDataAsync()).ReturnsAsync(MockRepo.GetMockGalleryResponse());

      await using (var dbContext = new GuestBookContext(options))
      {
        var gp = new GalleryProvider(mqDogGalleryRepo.Object, dbContext);

        await gp.SaveGalleryImagesAsync(MockRepo.GetImages());
        await gp.SaveGalleryImagesAsync(MockRepo.GetImages());
        await gp.SaveGalleryImagesAsync(MockRepo.GetImages());
        await gp.SaveGalleryImagesAsync(MockRepo.GetImages());

        var totalRecords = dbContext.Gallery.Count();

        totalRecords.Should().BeLessThan(25);        
      }
    }

  }

  internal static class MockRepo
  {
    public static DogGalleryResponse GetMockGalleryResponse()
    {           
      var random = new Random();
      var index = random.Next(GetImages().Length) ;
      return images[index];

    }

    public static DogGalleryResponse[] GetImages()
    {
      return images;
    }

    static DogGalleryResponse[] images = new DogGalleryResponse[] {
        new DogGalleryResponse() { Url = "https://random.dog/03024628-188b-408e-a853-d97c9f04f903.jpg", FileSizeBytes = "1" },
        new DogGalleryResponse() { Url = "https://random.dog/e654dc69-29a4-4eb6-ad2d-2c18e2c67eee.jpg", FileSizeBytes = "5" },
        new DogGalleryResponse() { Url = "https://random.dog/62d87d11-bcdb-410f-8aee-324fe07f0c70.mp4", FileSizeBytes = "5" },
        new DogGalleryResponse() { Url = "https://random.dog/3b5eae93-b3bd-4012-b789-64eb6cdaac65.png", FileSizeBytes = "5" },
        new DogGalleryResponse() { Url = "https://random.dog/a922da9a-437c-4400-9d94-f36ec2e5452c.mp4", FileSizeBytes = "5" },
        new DogGalleryResponse() { Url = "https://random.dog/f3923c95-bad4-4dac-8de6-5adc92e5944e.webm", FileSizeBytes = "5" },
        new DogGalleryResponse() { Url = "https://random.dog/48a94bcb-75d2-46de-9f81-e37cfb574674.jpg", FileSizeBytes = "5" },
        new DogGalleryResponse() { Url = "https://random.dog/8590d98b-5839-4ec7-9065-e3aa0c2d0763.mp4", FileSizeBytes = "5" }
      };
  }

}
