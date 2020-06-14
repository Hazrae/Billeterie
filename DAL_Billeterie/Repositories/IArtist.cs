using Models.Artist;
using Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Billeterie.Repositories
{
    public interface IArtist : IRepository<Artist>
    {
        Artist GetArtist(int id);
        List<ArtistWall> GetWall();
    }
}
