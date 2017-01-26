<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RepeaterNestedRepeater.aspx.cs" Inherits="SamplePages_RepeaterNestedRepeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <br />
    <br />
    <div class="col-sm-6">

        <%--    Inside a repeater you need as a minimum an ItemTemplate
    other templates include HeaderTemplate, FooterTemplate, AlternatingItemTemplate
    
    Outer repeater will display flat fields from the DTO class
    outer repeater gets it's data souce from the ODS control (DataSourceId)
    inner repeater will display flat fields from the POCO class
    inner repeater gets its datasource from the List<T> field of the DTO class (DataSource)
        --%>
        <asp:Repeater ID="ArtistAlbumReleases" runat="server" DataSourceID="ArtistAlbumReleasesODS">
            <HeaderTemplate>
                <h3>Album Releases for Artists</h3>
            </HeaderTemplate>
            <ItemTemplate>
                <%--Use the Eval to select the aritist field from the data source--%>
                <strong><%# Eval("Artist") %></strong><br />
                <asp:Repeater ID="Albums" DataSource='<%# Eval("Albums") %>' runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Year</th>
                                <th>Label</th>
                                <th>Title</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("RYear") %></td>
                            <td><%# Eval("Label") %></td>
                            <td><%# Eval("Title") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="col-sm-6">

        <%--    Inside a repeater you need as a minimum an ItemTemplate
    other templates include HeaderTemplate, FooterTemplate, AlternatingItemTemplate
    
    Outer repeater will display flat fields from the DTO class
    outer repeater gets it's data souce from the ODS control (DataSourceId)
    inner repeater will display flat fields from the POCO class
    inner repeater gets its datasource from the List<T> field of the DTO class (DataSource)
        --%>

<%--        Use of the ItemTypeParameter on the repeater allows you to use 
        object instance referencing (instance.property) for fields instead of Eval("xxxx") referencing
        set ItemType in the asp:Repeater - see line 64)
        --%>
        <asp:Repeater ID="ArtistAlbumReleasesB" runat="server" DataSourceID="ArtistAlbumReleasesODS"
            ItemType="Chinook.Data.DTOs.ArtistAlbumReleases">
            <HeaderTemplate>
                <h3>Album Releases for Artists</h3>
            </HeaderTemplate>
            <ItemTemplate>
                <%--Use the Eval to select the aritist field from the data source--%>
                <strong><%# Item.Albums %></strong><br />
                <asp:Repeater ID="AlbumsB" DataSource='<%# Eval("Albums") %>' runat="server" ItemType="Chinook.Data.POCOs.AlbumRelease">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Year</th>
                                <th>Label</th>
                                <th>Title</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.RYear %></td>
                            <td><%# Item.Label %></td>
                            <td><%# Item.Title %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:ObjectDataSource ID="ArtistAlbumReleasesODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ArtistAlbumReleases_List"
        TypeName="Chinook.System.BLL.AlbumController"></asp:ObjectDataSource>
</asp:Content>

