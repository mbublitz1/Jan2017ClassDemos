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
    public class PlayListTrackController
    {
        public List<UserPlayListTrack> List_TracksForPlayList(string playlistname, string userName)
        {
            using (var context = new ChinookContext())
            {
                var results = (from x in context.Playlists
                               where x.Name == playlistname
                               && x.UserName == userName
                               select x).FirstOrDefault();


                var theTracks = from x in context.PlaylistTracks
                                where x.PlaylistId == results.PlaylistId
                                select new UserPlayListTrack
                                {
                                    TrackID = x.TrackId,
                                    TrackNumber = x.TrackNumber,
                                    TrackName = x.Track.Name,
                                    Milliseconds = x.Track.Milliseconds,
                                    UnitPrice = x.Track.UnitPrice
                                };
                return theTracks.ToList();
            }
        }

        public void Add_TrackToPlayList(string playlistname, string userName, int trackid)
        {
            using (var context = new ChinookContext())
            {
                //does the playlist already exist?
                Playlist exists = (from x in context.Playlists
                                  where x.UserName.Equals(userName)
                                        && x.Name.Equals(playlistname)
                                  select x).FirstOrDefault();

                int tracknumber = 0;
                PlaylistTrack newTrack = null;
                if (exists == null)
                {
                    //create the new Playlist
                    exists = new Playlist();

                    exists.Name = playlistname;
                    exists.UserName = userName;
                    exists = context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //the playlist already exists
                    //and the query has given us the instance
                    //of that playlist from the database
                    //generate the next tracknumber
                    tracknumber = exists.PlaylistTracks.Count() + 1;

                    //on our sample, playlist tracks for a playlist are unique

                    newTrack = exists.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackid);
                    if (newTrack != null)
                    {
                        throw new Exception("Playlist already has requested track.");

                    }
                }

                //this is a boom test
                //remove after testing
                //if (playlistname.Equals("Boom"))
                //{
                //    throw new Exception("forced abort, check DB for Boom playlist");
                //}
                //you have a playlist
                //you know the track will be unique
                //create the new track
                newTrack = new PlaylistTrack();
                newTrack.TrackId = trackid;
                newTrack.TrackNumber = tracknumber;
                //since I am using the navigation property of the 
                //playlist to get to playlisttrack
                //the SaveChanges will fill the playlistid
                //from either the HashSet of from the existing instance
                exists.PlaylistTracks.Add(newTrack);

                context.SaveChanges();
            }
        }
    }
}
