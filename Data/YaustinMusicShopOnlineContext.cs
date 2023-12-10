using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YaustinMusicShopOnline.Models;

namespace YaustinMusicShopOnline.Data
{
    public class YaustinMusicShopOnlineContext : DbContext
    {
        public YaustinMusicShopOnlineContext (DbContextOptions<YaustinMusicShopOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<YaustinMusicShopOnline.Models.Music> Music { get; set; } = default!;
    }
}
