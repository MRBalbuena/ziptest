using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Zip.Backend.Provider;
using Zip.Backend.Models;
using System.IO;

namespace Zip.Backend.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class GalleryController : ControllerBase
  {
    private readonly IGalleryProvider _galleryProvider;

    public GalleryController(IGalleryProvider galleryProvider)
    {
      _galleryProvider = galleryProvider;
    }

    [HttpGet]
    public async Task<IEnumerable<GetGalleryResponse>> Get()
    {
      var gallery = await _galleryProvider.GetGalleryAsync(8);
      await _galleryProvider.SaveGalleryImagesAsync(gallery);

      var response = gallery
        .Select(g => new GetGalleryResponse
        {
          Url = g.Url,
          Extension = Path.GetExtension(g.Url)
        })
        .ToList();

      return response;
    }

  }

}
