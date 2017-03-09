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
using Chinook.Data.DTOs;
#endregion

namespace Chinook.System.BLL
{
    [DataObject]
    public class GenreController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> List_GenreName()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Genres
                              orderby x.Name
                              select new SelectionList
                              {
                                  IDValueField = x.GenreId,
                                  DisplayText = x.Name
                              };

                return results.ToList();
            }
        }
    }
}
