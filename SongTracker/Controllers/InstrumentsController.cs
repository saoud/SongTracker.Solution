using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SongTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace SongTracker.Controllers
{
  public class InstrumentsController : Controller
  {
    private readonly SongTrackerContext _db;
    public InstrumentsController(SongTrackerContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Instrument> model = _db.Instruments.ToList();
      return View(model);
    }

//     public ActionResult Create()
//     {
//       return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Instrument instrument)
//     {
//       _db.Instruments.Add(instrument);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//     var thisInstrument = _db.Instruments
//         .Include(instrument => instrument.JoinEntities)
//         .ThenInclude(join => join.Song)
//         .FirstOrDefault(Instrument => instrument.InstrumentId == id);
//     return View(thisInstrument);
//     }
//     public ActionResult Edit(int id)
//     {
//       var thisInstrument = _db.Instruments.FirstOrDefault(instrument => instrument.InstrumentId == id);
//       return View(thisInstrument);
//     }

//     [HttpPost]
//     public ActionResult Edit(Instrument instrument)
//     {
//       _db.Entry(instrument).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       var thisInstrument = _db.Instruments.FirstOrDefault(instrument => instrument.InstrumentId == id);
//       return View(thisInstrument);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisInstrument = _db.Instruments.FirstOrDefault(instrument => instrument.InstrumentId == id);
//       _db.Instruments.Remove(thisInstrument);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
  }
}