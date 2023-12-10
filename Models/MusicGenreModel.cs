using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace YaustinMusicShopOnline.Models
{
    public class MusicGenreModel
    {
        public List<Music>? Musics { get; set; }
        public SelectList? Genres { get; set; }
        public string? MusicGenre { get; set; }

        public SelectList? Artists { get; set; }
        public string? MusicArtist { get; set; }


    }
}
