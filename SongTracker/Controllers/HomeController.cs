using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SongTracker.Models;

namespace SongTracker.Controllers
{
  public class HomeController : Controller
  {
    private readonly SongTrackerContext _db;
    public HomeController(SongTrackerContext db)
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Instrument> instruments = _db.Instruments.ToList();
      List<Song> songs = _db.Songs.ToList();

      ViewBag.Songs = songs;
      return View(instruments);
    }
  }
}