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
        MessageUserControl.ShowInfo("You pressed the plus sign button for track id " + e.CommandArgument.ToString());
    }
}