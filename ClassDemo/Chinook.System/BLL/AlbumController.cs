using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.System.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion

namespace Chinook.System.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumArtist> ListAlbumsByArtist()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              orderby x.Artist.Name
                              select new AlbumArtist
                              {
                                  Artist = x.Artist.Name,
                                  Title = x.Title,
                                  ReleaseYear = x.ReleaseYear,
                                  ReleaseLabel = x.ReleaseLabel
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_GetForArtistsbyName(string name)
        {
            using (var context = new ChinookContext())
            {
                //This is using Linq
                //This is using the method syntax of the query
                var results = context.Albums
                            .Where(x => x.Artist.Name.Contains(name))
                            .OrderByDescending(x => x.ReleaseYear);
                //remember if you have used .Dump() in linqpad to view 
                //your contents of the query, .Dump() is a linqpad method
                //it is NOT C#
                return results.ToList();
            }
        }
    }
}
