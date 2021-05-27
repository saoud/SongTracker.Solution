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
    return View(_db.Instruments.ToList());
}

  }
}