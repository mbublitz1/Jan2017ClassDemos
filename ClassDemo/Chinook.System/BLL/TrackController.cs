﻿using System;
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
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackList> List_TracksForPlayListSelections(string tracksBy, int argId)
        {
            using (var context = new ChinookContext())
            {
                List<TrackList> results = null;

                switch (tracksBy)
                {
                    case "Artist":
                        {
                            results = (from x in context.Tracks
                                      orderby x.Name
                                      where x.Album.ArtistId == argId
                                      select new TrackList
                                      {
                                          TrackID = x.TrackId,
                                          Name = x.Name,
                                          Title = x.Album.Title,
                                          MediaName = x.MediaType.Name,
                                          GenreName = x.Genre.Name,
                                          Composer = x.Composer,
                                          Milliseconds = x.Milliseconds,
                                          Bytes = x.Bytes,
                                          UnitPrice = x.UnitPrice
                                      }).ToList();

                            break;
                        }
                    case "MediaType":
                        {
                            break;
                        }
                    case "Genre":
                        {
                            break;
                        }
                    default:
                        break;
                } //eos
                return results;
            }
        }
    }
}
