using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YaustinMusicShopOnline.Data;
using YaustinMusicShopOnline.Models;

namespace YaustinMusicShopOnline.Controllers
{
    public class CustomersController : Controller
    {
        private readonly YaustinMusicShopOnlineContext _context;

        public CustomersController(YaustinMusicShopOnlineContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string musicGenre, string musicArtist)
        {
            /*
              return _context.Music != null ? 
                          View(await _context.Music.ToListAsync()) :
                          Problem("Entity set 'YaustinMusicShopOnline.Music'  is null.");
            */

            IQueryable<string> genreQuery = from m in _context.Music
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> artistQuery = from m in _context.Music
                                            orderby m.Artist
                                            select m.Artist;

            var showAll = from m in _context.Music
                          select m;

          if (!string.IsNullOrEmpty(musicGenre))
            {
                showAll = showAll.Where(s => s.Genre == musicGenre);
            }

            if (!string.IsNullOrEmpty(musicArtist))
            {
                showAll = showAll.Where(s => s.Artist == musicArtist);
            }

            var musicGenreArtistVM = new MusicGenreModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Artists = new SelectList(await artistQuery.Distinct().ToListAsync()),
                Musics = await showAll.ToListAsync()
            };
            
            return View(musicGenreArtistVM);

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.MusicId == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        public async Task<IActionResult> ShoppingCart(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.MusicId == id);


            if (music == null)
            {
                return NotFound();
            }


            return View(music);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicId,Title,Artist,Genre,Price")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        private bool MusicExists(int id)
        {
          return (_context.Music?.Any(e => e.MusicId == id)).GetValueOrDefault();
        }
    }
}
