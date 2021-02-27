using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.Backend.Models;
using Zip.Backend.Repositories.RepositoryModels;

namespace Zip.Backend.Provider
{
  public interface IGalleryProvider
  {
    Task<DogGalleryResponse[]> GetGalleryAsync();
  }
}
