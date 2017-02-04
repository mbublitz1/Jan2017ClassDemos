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
        //Coming from find tab
        GridViewRow agvRow = AlbumList.Rows[AlbumList.SelectedIndex];
        string albumId = (agvRow.FindControl("AlbumID") as Label).Text; //This will get the value from the text
        string albumTitle = (agvRow.FindControl("Title") as Label).Text;
        string albumYear = (agvRow.FindControl("Year") as Label).Text;
        string albumLabel = (agvRow.FindControl("AlbumLabel") as Label).Text;
        string artistId = (agvRow.FindControl("ArtistID") as Label).Text;
        //If for example you wanted to do something like above you can do the following for a DDL
        //string albumId = (agvRow.FindControl("AlbumID") as DropDownList).SelectedValue;

        //Displaying on find tab
        SelectedTitle.Text = albumTitle + " released in " + albumYear + " by " + albumLabel;

        //filling controls on tab maintain
        AlbumID.Text = albumId;
        AlbumTitle.Text = albumTitle;
        ArtistList.SelectedValue = artistId;
        AlbumReleaseYear.Text = albumYear;
        AlbumReleaseLabel.Text = albumLabel;



    }

    protected void AddAlbum_Click(object sender, EventArgs e)
    {
        //retest the validation of the incoming data via the Validation controls
        if (IsValid)
        {
            //any other business rules 
            MessageUserControl2.TryRun(() => 
            {
                AlbumController sysmgr = new AlbumController();
                Album newAlbum = new Album();
                newAlbum.Title = AlbumTitle.Text;
                newAlbum.ArtistId = int.Parse(ArtistList.SelectedValue);
                newAlbum.ReleaseYear = int.Parse(AlbumReleaseYear.Text);
                newAlbum.ReleaseLabel = string.IsNullOrEmpty(AlbumReleaseLabel.Text) ? null : AlbumReleaseLabel.Text;

                sysmgr.Albums_Add(newAlbum);
            }, "Add Album", "Album has been added sucessfully to the database");
        }
       
    }
    protected void UpdateAlbum_Click(object sender, EventArgs e)
    {
        //retest the validation of the incoming data via the Validation controls
        if (IsValid)
        {
            //any other business rules 
            if (string.IsNullOrEmpty(AlbumID.Text))
            {
                MessageUserControl2.ShowInfo("Missing Data","Missing Album Id, Use find to lcation the album you wish to update");
                
            }
            else
            {
                int albumid = 0;
                if (int.TryParse(AlbumID.Text, out albumid))
                {
                    MessageUserControl2.TryRun(() =>
                    {
                        AlbumController sysmgr = new AlbumController();
                        Album newAlbum = new Album();
                        newAlbum.AlbumId = albumid;
                        newAlbum.Title = AlbumTitle.Text;
                        newAlbum.ArtistId = int.Parse(ArtistList.SelectedValue);
                        newAlbum.ReleaseYear = int.Parse(AlbumReleaseYear.Text);
                        newAlbum.ReleaseLabel = string.IsNullOrEmpty(AlbumReleaseLabel.Text) ? null : AlbumReleaseLabel.Text;

                        sysmgr.Albums_Update(newAlbum);
                    }, "Add Album", "Album has been sucessfully updated to the database");
                }
                else
                {
                    MessageUserControl2.ShowInfo("Invalid Data", "Album Id, Use find to lcation the album you wish to update");
                }
            }
        }
    }
    protected void DeleteAlbum_Click(object sender, EventArgs e)
    {
        //retest the validation of the incoming data via the Validation controls

            //any other business rules 
            if (string.IsNullOrEmpty(AlbumID.Text))
            {
                MessageUserControl2.ShowInfo("Missing Data", "Missing Album Id, Use find to lcation the album you wish to update");

            }
            else
            {
                int albumid = 0;
                if (int.TryParse(AlbumID.Text, out albumid))
                {
                    MessageUserControl2.TryRun(() =>
                    {
                        AlbumController sysmgr = new AlbumController();
         
                        sysmgr.Album_Delete(albumid);
                    }, "Add Album", "Album has been sucessfully updated to the database");
                }
                else
                {
                    MessageUserControl2.ShowInfo("Invalid Data", "Album Id, Use find to lcation the album you wish to update");
                }
            }

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