using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Zip.Backend.Repositories.RepositoryModels;

namespace Zip.Backend.Repositories
{
  public class DogGalleryRepo : IDogGalleryRepo
  {    

    public async Task<DogGalleryResponse> GetDogGalleryDataAsync()
    {
      const string dogGalleryUrl = "https://random.dog/woof.json";

      DogGalleryResponse dogGalleryData = new DogGalleryResponse();

      using (HttpClient client = new HttpClient())
      {
        client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


        using (HttpResponseMessage response = client.GetAsync(dogGalleryUrl).Result)
        {
          response.EnsureSuccessStatusCode();
          var result = await response.Content.ReadAsStringAsync();
          dogGalleryData = JsonConvert.DeserializeObject<DogGalleryResponse>(result);

        }
      }

      return dogGalleryData;
    }
  }
}
