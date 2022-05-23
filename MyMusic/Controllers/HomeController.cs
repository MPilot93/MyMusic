using Microsoft.AspNetCore.Mvc;
using MyMusic.Models;
using MyMusic.DBManage;
using System.Diagnostics;
using System.Data.SqlClient;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BraniManager branoDB;
        private AlbumManager albumDB;
        private BandManager bandDB;
        private ArtistiManager artistiDB;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            branoDB = new BraniManager();
            artistiDB= new ArtistiManager();
            albumDB= new AlbumManager();
            bandDB= new BandManager();
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = branoDB.GetAll();

            return View(result);
        }


        [HttpGet]
        public IActionResult AggiungiBrano()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiBrano(BranoViewModel brano)
        {
            branoDB.AggiungiBrano(brano);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiAlbum()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiAlbum(AlbumViewModel album)
        {
            albumDB.AggiungiAlbum(album);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiArtista()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiArtista(ArtistiViewModel artista)
        {
            artistiDB.AggiungiArtisti(artista);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiBand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiBand(BandViewModel band)
        {
            bandDB.AggiungiBand(band);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}