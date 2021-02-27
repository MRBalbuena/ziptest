using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.Backend.Repositories.RepositoryModels;

namespace Zip.Backend.Repositories
{
  public interface IDogGalleryRepo
  {
    Task<DogGalleryResponse> GetDogGalleryDataAsync();
  }
}
