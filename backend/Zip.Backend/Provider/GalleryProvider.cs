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
  public class GalleryProvider : IGalleryProvider
  {
    private readonly IDogGalleryRepo _dogGalleryRepo;
    private readonly GuestBookContext _db;
    const int calls = 8;

    public GalleryProvider(IDogGalleryRepo dogGalleryRepo, GuestBookContext db)
    {
      _dogGalleryRepo = dogGalleryRepo;
      _db = db;
    }


    public async Task<DogGalleryResponse[]> GetGalleryAsync()
    {
      var galleryTasks = new List<Task<DogGalleryResponse>>();
      for (int i = 0; i < calls; i++)
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
    /// <param name="dogGalleryData"></param>
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
