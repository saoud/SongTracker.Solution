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
      return View(_db.Songs.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.InstrumentId = new SelectList(_db.Instruments, "InstrumentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Song song, int InstrumentId)
    {
      _db.Songs.Add(song);
      _db.SaveChanges();
      if (InstrumentId != 0)
      {
        _db.InstrumentSong.Add(new InstrumentSong() { InstrumentId = InstrumentId, SongId = song.SongId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSong = _db.Songs
          .Include(song => song.JoinEntities)
          .ThenInclude(join => join.Instrument)
          .FirstOrDefault(song => song.SongId == id);
      return View(thisSong);
    }

    public ActionResult Edit(int id)
    {
      var thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      ViewBag.InstrumentId = new SelectList(_db.Instruments, "InstrumentId", "Name");
      return View(thisSong);
    }

    [HttpPost]
    public ActionResult Edit(Song song, int InstrumentId)
    {
      if(InstrumentId != 0)
      {
        _db.InstrumentSong.Add(new InstrumentSong() { InstrumentId = InstrumentId, SongId = song.SongId });
      }
      _db.Entry(song).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddInstrument(int id)
    {
      var thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      ViewBag.InstrumentId = new SelectList(_db.Instruments, "InstrumentId", "Name");
      return View(thisSong);
    }

    [HttpPost]
    public ActionResult AddInstrument(Song song, int InstrumentId)
    {
      if (InstrumentId != 0)
      {
      _db.InstrumentSong.Add(new InstrumentSong() { InstrumentId = InstrumentId, SongId = song.SongId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      return View(thisSong);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
      _db.Songs.Remove(thisSong);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteInstrument(int joinId)
    {
      var joinEntry = _db.InstrumentSong.FirstOrDefault(entry => entry.InstrumentSongId == joinId);
      _db.InstrumentSong.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}