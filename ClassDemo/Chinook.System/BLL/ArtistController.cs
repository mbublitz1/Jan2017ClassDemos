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
    public class ArtistController
    {
        //dump all instances of the entity
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Artist> Artist_ListAll()
        {
            using (var context = new ChinookContext())
            {
                //this is not using Linq
                //this is using EntityFramework
                return context.Artists.ToList();
            }
        }

        //dump a particular instances of the entity via the primary key
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Artist Artist_Get(int artistId)
        {
            using (var context = new ChinookContext())
            {
                //this is not using Linq
                //this is using EntityFramework
                return context.Artists.Find(artistId);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> List_ArtistName()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Artists
                              orderby x.Name
                              select new SelectionList
                              {
                                  IDValueField = x.ArtistId,
                                  DisplayText = x.Name
                              };

                return results.ToList();
            }
        }
    }
}
