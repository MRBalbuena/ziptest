using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Zip.Backend.Models;
using Zip.Backend.Repositories;
using Zip.Backend.Repositories.RepositoryModels;

namespace Zip.Backend.Provider
{
  public class GalleryProvider : IGalleryProvider
  {
    private readonly IDogGalleryRepo _dogGalleryRepo;
    const int calls = 8;

    public GalleryProvider(IDogGalleryRepo dogGalleryRepo)
    {
      _dogGalleryRepo = dogGalleryRepo;
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
  }
}
