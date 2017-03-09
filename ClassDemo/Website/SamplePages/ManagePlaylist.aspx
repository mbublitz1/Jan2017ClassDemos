<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManagePlaylist.aspx.cs" Inherits="SamplePages_ManagePlaylist" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Manage Playlists (UX TRX Sample)</h1>
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    <div class="row">
        <div class="col-sm-2">

        </div>
        <div class="col-sm-10">
            <asp:Label ID="Label1" runat="server" Text="Artist"></asp:Label><br />
            <asp:DropDownList ID="ArtistDDL" runat="server" DataSourceID="ArtistDDLODS" DataTextField="DisplayText" DataValueField="IDValueField"></asp:DropDownList><br />
            <asp:Button ID="ArtistFecth" runat="server" Text="Fetch" OnClick="ArtistFecth_Click" />
            <br /> <br />
            <asp:Label ID="Label2" runat="server" Text="Media"></asp:Label><br />
            <asp:DropDownList ID="MediaTypeDDL" runat="server" DataSourceID="MediaTypeDDLODS" DataTextField="DisplayText" DataValueField="IDValueField"></asp:DropDownList><br />
            <asp:Button ID="MediaTypeFetch" runat="server" Text="Fetch" />
            <br /> <br />
            <asp:Label ID="Label3" runat="server" Text="Genre"></asp:Label><br />
            <asp:DropDownList ID="GenreDDL" runat="server" DataSourceID="GenreDDLODS" DataTextField="DisplayText" DataValueField="IDValueField"></asp:DropDownList><br />
            <asp:Button ID="GenreFetch" runat="server" Text="Fetch" />
            <br /> <br />
            <asp:Label ID="Label4" runat="server" Text="Album"></asp:Label><br />
            <asp:DropDownList ID="AlbumDDL" runat="server" DataSourceID="AlbumDDLODS" DataTextField="DisplayText" DataValueField="IDValueField"></asp:DropDownList><br />
            <asp:Button ID="AlbumFetch" runat="server" Text="Fetch" />
        </div>
        <div class="col-sm-10">
            <asp:Label ID="Label5" runat="server" Text="Tracks"></asp:Label> &nbsp;&nbsp;
            <asp:Label ID="TracksBy" runat="server"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="SearchArgId" runat="server"></asp:Label> <br />
            <asp:ListView ID="TracksSelectionList" runat="server"></asp:ListView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ArtistDDLODS" runat="server" OldValuesParameterFormatString="original_{0}"
         SelectMethod="List_ArtistName" TypeName="Chinook.System.BLL.ArtistController" OnSelected="CheckForException"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MediaTypeDDLODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="List_MediaTypesName" TypeName="Chinook.System.BLL.MediaTypeController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GenreDDLODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="List_GenreName" TypeName="Chinook.System.BLL.GenreController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AlbumDDLODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="List_AlbumTitles" TypeName="Chinook.System.BLL.AlbumController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TrackSelectionListODS" runat="server"></asp:ObjectDataSource>
</asp:Content>

