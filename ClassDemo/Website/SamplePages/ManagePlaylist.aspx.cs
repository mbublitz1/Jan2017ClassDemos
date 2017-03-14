using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Chinook.System.BLL;
using Chinook.Data.POCOs;
#endregion
public partial class SamplePages_ManagePlaylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        //PreRenderComplete occurs just after databinding page events
        //load a pointer to point to your datapager control
        DataPager thePager = TracksSelectionList.FindControl("DataPager1") as DataPager;
        if (thePager != null)
        {
            //Thi code will check the StartRowIndex to see if it is greater than the 
            //total count of the collection
            if (thePager.StartRowIndex > thePager.TotalRowCount)
            {
                thePager.SetPageProperties(0, thePager.MaximumRows, true);
            }
        }
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

    protected void ArtistFecth_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "Artist";
            SearchArgId.Text = ArtistDDL.SelectedValue;
            TracksSelectionList.DataBind(); //Will force the ODS to execute
        });
    }

    protected void GenreFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "Genre";
            SearchArgId.Text = GenreDDL.SelectedValue;
            TracksSelectionList.DataBind(); //Will force the ODS to execute
        });
    }

    protected void MediaTypeFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "MediaType";
            SearchArgId.Text = MediaTypeDDL.SelectedValue;
            TracksSelectionList.DataBind(); //Will force the ODS to execute
        });
    }

    protected void AlbumFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "Album";
            SearchArgId.Text = AlbumDDL.SelectedValue;
            TracksSelectionList.DataBind(); //Will force the ODS to execute
        });
    }

    protected void PlayListFetch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(PlayListName.Text))
        {
            MessageUserControl.ShowInfo("Warning", "Playlist name is required.");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            {
                string userName = User.Identity.Name;
                PlayListTrackController sysmgr = new PlayListTrackController();
                List<UserPlayListTrack> playList = sysmgr.List_TracksForPlayList(PlayListName.Text, userName);
                PlayList.DataSource = playList;
                PlayList.DataBind();
            });
        }
    }

    protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        //MessageUserControl.ShowInfo("You pressed the plus sign button for track id " + e.CommandArgument.ToString());

        if (string.IsNullOrEmpty(PlayListName.Text))
        {
            MessageUserControl.ShowInfo("Warning", "You must supply a playlist name.");
        }
        else
        {
            //obtain the user name.
            string userName = User.Identity.Name;
            //obtain the playlist name 
            string playlistname = PlayListName.Text;
            int trackid = int.Parse(e.CommandArgument.ToString());

            //connect to BLL controller
            //call required method
            //refresh the screen
            //do all this under the user friendly error handler
            MessageUserControl.TryRun(() => 
            {
                PlayListTrackController sysmgr = new PlayListTrackController();
                sysmgr.Add_TrackToPlayList(playlistname, userName, trackid);
                List<UserPlayListTrack> results = sysmgr.List_TracksForPlayList(playlistname, userName);
                PlayList.DataSource = results;
                PlayList.DataBind();
                
            },"Playlist Track Added", "You have successfully added a new track to your list.");
        }
    }

    protected void MoveUp_Click(object sender, EventArgs e)
    {
        if (PlayList.Rows.Count == 0)
        {
            //did the user press the up button without fetching a playlist
            MessageUserControl.ShowInfo("Warning", "No playlist has been retrevied.");
        }
        else
        {
            if (string.IsNullOrEmpty(PlayListName.Text))
            {
                MessageUserControl.ShowInfo("Warning", "No playlist name exists.");
            }
            else
            {
                //check only one row selected
                int trackId = 0;
                int trackNumber = -1;
                int rowsSelected = 0;
                CheckBox playListSelection = null;
                //traverse the gridview checking each row for a checked box
                for (int i = 0; i < PlayList.Rows.Count; i++)
                {
                    //find the checkbox on the indexed gridview row
                    //playlistselection will point to the checkbox
                    playListSelection = PlayList.Rows[i].FindControl("Selected") as CheckBox;
                    if (playListSelection.Checked)
                    {
                        trackId = int.Parse((PlayList.Rows[i].FindControl("TrackID") as Label).Text);
                        rowsSelected++;
                    }
                }
                if (rowsSelected != 1)
                {
                    MessageUserControl.ShowInfo("Warning", "Select track to move");
                }
                else
                {
                    if (trackNumber == 1)
                    {
                        MessageUserControl.ShowInfo("Information", "Selected track can not be moved up");
                    }
                    else
                    {
                        MoveTrack(trackId, trackNumber, "up");
                    }
                }
            }
        }

    }

    protected void MoveDown_Click(object sender, EventArgs e)
    {
        if (PlayList.Rows.Count == 0)
        {
            //did the user press the up button without fetching a playlist
            MessageUserControl.ShowInfo("Warning", "No playlist has been retrevied.");
        }
        else
        {
            if (string.IsNullOrEmpty(PlayListName.Text))
            {
                MessageUserControl.ShowInfo("Warning", "No playlist name exists.");
            }
            else
            {
                //check only one row selected
                int trackId = 0;
                int trackNumber = -1;
                int rowsSelected = 0;
                CheckBox playListSelection = null;
                //traverse the gridview checking each row for a checked box
                for (int i = 0; i < PlayList.Rows.Count; i++)
                {
                    //find the checkbox on the indexed gridview row
                    //playlistselection will point to the checkbox
                    playListSelection = PlayList.Rows[i].FindControl("Selected") as CheckBox;
                    if (playListSelection.Checked)
                    {
                        trackId = int.Parse((PlayList.Rows[i].FindControl("TrackID") as Label).Text);
                        rowsSelected++;
                    }
                }
                if (rowsSelected != 1)
                {
                    MessageUserControl.ShowInfo("Warning", "Select track to move");
                }
                else
                {
                    if (trackNumber == PlayList.Rows.Count)
                    {
                        MessageUserControl.ShowInfo("Information", "Selected track can not be moved down");
                    }
                    else
                    {
                        MoveTrack(trackId, trackNumber, "down");
                    }
                }
            }
        }
    }

    protected void MoveTrack(int trackId, int trackNumber, string direction)
    {
        //call athe BLL move method
        //refresh the playlist
        MessageUserControl.TryRun(() =>
        {
            PlayListTrackController sysmgr = new PlayListTrackController();
            //sysmgr.Add_TrackToPlayList(playlistname, userName, trackid);
            List<UserPlayListTrack> results = sysmgr.List_TracksForPlayList(PlayListName.Text, User.Identity.Name);
            PlayList.DataSource = results;
            PlayList.DataBind();

        }, "Playlist Track Added", "You have successfully added a new track to your list.");
    }

    protected void DeleteTrack_Click(object sender, EventArgs e)
    {

    }
}