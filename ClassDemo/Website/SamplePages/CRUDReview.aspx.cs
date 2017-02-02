using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.System.BLL;
//using Chinook.UI;
#endregion

public partial class SamplePages_CRUDReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SelectedTitle.Text = "";
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        //clear out the old album information on the maintain tab
        Clear_Click(sender, e);

        if (string.IsNullOrEmpty(SearchArg.Text))
        {
            MessageUserControl1.ShowInfo("Enter an album title or part of the title.");
        }
        else
        {
            //do a lookup of the data in the db view the controller
            //all actions that are extrernal to the web page should be done in a try/catch
            //for friendly error handling
            //we will use messageusercontrol to handle the error messages for this semester
            MessageUserControl1.TryRun(() =>
            {
                //coding block I wish MessageUserControl to try and run checking for 
                //any errors catching the errors, and displaying said error(s) for me
                //in it's error panel
                //what is left for me to do: simply the logic for the event

                //standard lookup
                AlbumController sysmgr = new AlbumController();
                List<Album> albumList = sysmgr.Albums_GetByTitle(SearchArg.Text);
                if (albumList.Count == 0)
                {
                    MessageUserControl1.ShowInfo("Search Result",
                        "No data for album title or partial title " + SearchArg.Text);
                    AlbumList.DataSource = null;
                    AlbumList.DataBind();
                }
                else
                {
                    MessageUserControl1.ShowInfo("Search Result",
                        "Select the desired album for maintenance");
                    AlbumList.DataSource = albumList;
                    AlbumList.DataBind();
                }
            });
        }
    }

   

    protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }

    protected void AddAlbum_Click(object sender, EventArgs e)
    {
       
       
    }
    protected void UpdateAlbum_Click(object sender, EventArgs e)
    {
       
    }
    protected void DeleteAlbum_Click(object sender, EventArgs e)
    {
       
    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        AlbumID.Text = "";
        AlbumTitle.Text = "";
        AlbumReleaseYear.Text = "";
        AlbumReleaseLabel.Text = "";
        ArtistList.SelectedIndex = 0;
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

}