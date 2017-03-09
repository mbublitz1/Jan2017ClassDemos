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
            <asp:DropDownList ID="ArtistDDL" runat="server"></asp:DropDownList><br />
            <asp:Button ID="ArtistFecth" runat="server" Text="Fetch" />
            <br /> <br />
            <asp:Label ID="Label2" runat="server" Text="Media"></asp:Label><br />
            <asp:DropDownList ID="MediaTypeDDL" runat="server"></asp:DropDownList><br />
            <asp:Button ID="MediaTypeFetch" runat="server" Text="Fetch" />
            <br /> <br />
            <asp:Label ID="Label3" runat="server" Text="Genre"></asp:Label><br />
            <asp:DropDownList ID="GenreDDL" runat="server"></asp:DropDownList><br />
            <asp:Button ID="GenreFetch" runat="server" Text="Fetch" />
            <br /> <br />
            <asp:Label ID="Label4" runat="server" Text="Album"></asp:Label><br />
            <asp:DropDownList ID="AlbumDDL" runat="server"></asp:DropDownList><br />
            <asp:Button ID="AlbumFetch" runat="server" Text="Fetch" />
            
        </div>
    </div>
</asp:Content>

