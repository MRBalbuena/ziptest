using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Zip.Backend.Data;
using Zip.Backend.Repositories;
using Zip.Backend.Repositories.RepositoryModels;

namespace Zip.Backend.Provider
{

  /// <summary>
  /// This class manages requests and saving data related with Gallery.
  /// If it had more logic, or Gallery got more functionality could be renamed to service.
  /// This provider requires a IDogGalleryRepo and a _db context to work. 
  /// </summary>
  public class GalleryProvider : IGalleryProvider
  {
    private readonly IDogGalleryRepo _dogGalleryRepo;
    private readonly GuestBookContext _db;    

    public GalleryProvider(IDogGalleryRepo dogGalleryRepo, GuestBookContext db)
    {
      _dogGalleryRepo = dogGalleryRepo;
      _db = db;
    }

    /// <summary>
    /// Run async request to get a number of calls tp get images from a Repository. It could eventually decoupled to a m-service
    /// </summary>
    /// <param name="numberOfItems>Number of images requested</param>
    /// <returns></returns>
    public async Task<DogGalleryResponse[]> GetGalleryAsync(int numberOfItems)
    {
      var galleryTasks = new List<Task<DogGalleryResponse>>();
      for (int i = 0; i < numberOfItems; i++)
      {
        galleryTasks.Add(_dogGalleryRepo.GetDogGalleryDataAsync());
      }

      var resultTasks = Task.WhenAll(galleryTasks);

      resultTasks.Wait();

      return await resultTasks;
    }

    /// <summary>
    /// Saves the images passed to Gallery DS
    /// </summary>
    /// <param name="dogGalleryData">Array with DogGalleryResponses passed to save</param>
    /// <returns></returns>
    public async Task SaveGalleryImagesAsync(DogGalleryResponse[] dogGalleryData)
    {

      await CheckRecords();

      var galleryData = dogGalleryData
                          .Select(d => new Gallery
                          {
                            Id = new Guid(),
                            Url = d.Url,
                            Created = DateTime.Now
                          });


      await _db.Gallery.AddRangeAsync(galleryData);
      await _db.SaveChangesAsync();
    }

    /// <summary>
    /// validates the number of records doesn't exceed the max defined in specs
    /// </summary>
    /// <returns></returns>
    private async Task CheckRecords()
    {
      var totalRecords = _db.Gallery.Count();
      if(totalRecords >= 24)
      {
        var toRemove = _db.Gallery
          .OrderByDescending(g => g.Created)
          .Take(8);

        _db.Gallery.RemoveRange(toRemove);
        await _db.SaveChangesAsync();
          
      }
    }
  }
}
