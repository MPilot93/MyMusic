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
        public IActionResult ElencoArtisti()
        {
            var result = artistiDB.GetAll();

            return View(result);
        }

        [HttpGet]
        public IActionResult ElencoAlbum()
        {
            var result = albumDB.GetAll();

            return View(result);
        }

        [HttpGet]
        public IActionResult ElencoBand()
        {
            var result = bandDB.GetAll();

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


        [HttpGet]
        public IActionResult ModificaArtista(int id)
        {
            var artista = artistiDB.GetAll().Where(x => x.ID == id).FirstOrDefault();
            return View(artista);
        }

        [HttpPost]
        public IActionResult ModificaArtista(ArtistiViewModel artista)
        {
            var res = artistiDB.GetAll().Where(x => x.ID == artista.ID).FirstOrDefault();
            if (res != null)
                artistiDB.EditArtisti(artista);

            return RedirectToAction("ElencoArtisti");
        }

        [HttpGet]
        public IActionResult ModificaAlbum(int id)
        {
            var album = albumDB.GetAll().Where(x => x.ID == id).FirstOrDefault();
            return View(album);
        }

        [HttpPost]
        public IActionResult ModificaAlbum(AlbumViewModel album)
        {
            var res = albumDB.GetAll().Where(x => x.ID == album.ID).FirstOrDefault();
            if (res != null)
                albumDB.EditAlbum(album);

            return RedirectToAction("ElencoAlbum");
        }

        [HttpGet]
        public IActionResult ModificaBand(int id)
        {
            var band = bandDB.GetAll().Where(x => x.ID == id).FirstOrDefault();
            return View(band);
        }

        [HttpPost]
        public IActionResult ModificaBand(BandViewModel band)
        {
            var res = bandDB.GetAll().Where(x => x.ID == band.ID).FirstOrDefault();
            if (res != null)
                bandDB.EditBand(band);

            return RedirectToAction("ElencoBand");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}