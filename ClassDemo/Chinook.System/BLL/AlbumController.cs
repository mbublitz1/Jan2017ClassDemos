using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
        } //eom

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
        } //eom

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbumReleases> ArtistAlbumReleases_List()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              group x by x.Artist.Name into result
                              select new ArtistAlbumReleases
                              {
                                  Artist = result.Key,
                                  Albums = (from y in result
                                           select new AlbumRelease
                                           {
                                               Title = y.Title,
                                               RYear = y.ReleaseYear,
                                               Label = y.ReleaseLabel
                                           }).ToList()
                              };
                return results.ToList();
            }
        }//eom

        #region CRUD
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_GetByTitle(string title)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              where x.Title.Contains(title)
                              select x;

                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Album Albums_Get(int albumId)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumId);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Albums_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                //any business rules
                context.Albums.Add(item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Albums_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                //any business rules

                //any data refinements
                //review of using iif
                //composer cam be a mi;; stromg
                //we do not wish to store an empty string
                context.Albums.Attach(item);
                item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null : item.ReleaseLabel;

                //update the existing instance of truckinfo on the database
                context.Entry(item).State = EntityState.Modified;

                //update command if updating selected fields
                //context
                context.SaveChanges();

            }
            
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Albums_Delete(Album item)
        {
            Album_Delete(item.AlbumId);
        }

        public void Album_Delete(int albumId)
        {
            using (var context = new ChinookContext())
            {
                //do the delete
                //find the existing record in the database
                var existing = context.Albums.Find(albumId);

                if (existing == null)
                {
                    throw new Exception("Album does not exist in database.");
                }
                //delete the record from the database
                context.Albums.Remove(existing);
                //commit the transaction
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> List_AlbumTitles()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              orderby x.Title
                              select new SelectionList
                              {
                                  IDValueField = x.AlbumId,
                                  DisplayText = x.Title
                              };

                return results.ToList();
            }
        }

        #endregion

    } //eoc
} //eon
