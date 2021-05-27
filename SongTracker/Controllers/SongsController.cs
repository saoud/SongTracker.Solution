using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SongTracker.Models;

namespace SongTracker.Controllers
{
  public class SongsController : Controller
  {
    private readonly SongTrackerContext _db;
    public SongsController (SongTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Song> model = _db.Songs.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View():
    }

    [HttpPost]
    public ActionResult Create(Song song)
    {
      _db.Songs.Add(song);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSong = _db.Songs
          .Include(song => song.JoinEntities)
          .ThenInclude(join => join.Instrument)
          .FirstOrDefault(