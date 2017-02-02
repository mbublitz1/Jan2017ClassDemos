<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CRUDReview.aspx.cs" Inherits="SamplePages_CRUDReview" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h1>CRUD in Tabs</h1>
       <!--Common Update panel for user message control -->

    <asp:UpdatePanel ID="UpdatePanelMessage" runat="server">
        <ContentTemplate>
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </ContentTemplate>
    </asp:UpdatePanel>
        <div class="row">
        <div class="col-md-12">
          <!--script for tab to tab movement -->
            <script>
                function nextButton(anchorRef) {
                    $('a[href="' + anchorRef + '"]').tab('show');
                }
            </script>
            <!--Nav tabs-->
            <ul class="nav nav-tabs">
                <li class="active"><a href="#find" data-toggle="tab">Find</a></li>
                <li ><a href="#maintain" data-toggle="tab">Maintain</a></li>
                <li ><a href="#lvmaintain" data-toggle="tab">ListView</a></li>
             
            </ul>

            <!--Tab panes one for each tab-->
            <div class="tab-content"> 
        
                <div class="tab-pane fade in active" id="find">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                             <!--  user message control for this panel -->
                                <uc1:MessageUserControl runat="server" ID="MessageUserControl1" />
                                <asp:Label ID="Label1" runat="server" Text="Album Title:"></asp:Label>&nbsp;&nbsp;
                                <asp:TextBox ID="SearchArg" runat="server"></asp:TextBox>&nbsp;&nbsp;

                                <!-- Search buttons do not want Validation(on tap 2) to happen on the web page-->
                                <asp:Button  ID="Search" runat="server" OnClick="Search_Click" Text="Search" CausesValidation="False"></asp:Button>
                            <br /><br />
                                <asp:GridView ID="AlbumList" runat="server" AutoGenerateColumns="False" 
                                    OnSelectedIndexChanged="AlbumList_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                        <asp:TemplateField HeaderText="Title">
                                            <ItemTemplate>
                                                <asp:Label Id="Title" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year">
                                            <ItemTemplate>
                                                <asp:Label Id="Year" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Label">
                                            <ItemTemplate>
                                                <asp:Label Id="AlbumLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AlbumID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label Id="AlbumID" runat="server" Text='<%# Eval("AlbumId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ArtistID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label Id="ArtistID" runat="server" Text='<%# Eval("ArtistId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br /><br />
                                <asp:Label ID="Label2" runat="server" Text="Selected"></asp:Label>

                            <!--added attribute to button to call js script for tab to tab movement-->
                                <button type="button"  class="btn" onclick="nextButton('#maintain')" >Next</button><br />

                                <asp:Label ID="SelectedTitle" runat="server" ></asp:Label>

                           
                        </ContentTemplate>
                    </asp:UpdatePanel>   
                </div>
                 <div class="tab-pane fade" id="maintain">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                             <!--  user message control for this panel -->
                            <uc1:MessageUserControl runat="server" ID="MessageUserControl2" />
                            <!--validation controls on Insert, Update, and Delete tab panel-->
                            <asp:ValidationSummary ID="ContrestValidationSummary" runat="server" BackColor="#ff99cc"
                                HeaderText="Please correct the following parts of the form before submitting:<br/>" />
                            <asp:RequiredFieldValidator ID="RequiredFieldAlbumTitle" runat="server" ForeColor="#990000" 
                                ErrorMessage="Title required field" Display="None" ControlToValidate="AlbumTitle" SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldAlbumReleaseYear" runat="server" ForeColor="#990000" 
                                ErrorMessage="Year required field" ControlToValidate="AlbumReleaseYear" SetFocusOnError="True"  Display="None">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareAlbumReleaseYear" runat="server" ForeColor="#990000" Display="None"
                                ErrorMessage="Invalid year not numeric." ControlToValidate="AlbumReleaseYear" SetFocusOnError="True" 
                                Type="Integer" Operator="DataTypeCheck">
                            </asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionAlbumReleaseYear" runat="server" Display="None"
                                 ControlToValidate="AlbumReleaseYear" ValidationExpression="[0-9][0-9][0-9][0-9]" 
                                SetFocusOnError="True" ForeColor="#990000" ErrorMessage="Invalid year format (yyyy).">
                            </asp:RegularExpressionValidator>    

                            <!--form-->
                               <fieldset class="form-horizontal">
                                    <legend>Album Maintenance</legend>
                                    <asp:Label ID="Label4" runat="server" Text="Album ID:"
                                        AssociatedControlID="AlbumID"></asp:Label> 
                                    <asp:Label ID="AlbumID" runat="server" ></asp:Label><br />
                                    <asp:Label ID="Label6" runat="server" Text="Title"
                                         AssociatedControlID="AlbumTitle"></asp:Label>
                                    <asp:TextBox ID="AlbumTitle" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="Label3" runat="server" Text="Artist"
                                         AssociatedControlID="ArtistList"></asp:Label>
                                    <asp:DropDownList ID="ArtistList" runat="server" 
                                        DataSourceID="ArtistListODS" 
                                        DataTextField="Name" 
                                        DataValueField="ArtistId">
                                    </asp:DropDownList><br />
                                    <asp:Label ID="Label7" runat="server" Text="Year"
                                         AssociatedControlID="AlbumReleaseYear"></asp:Label>
                                    <asp:TextBox ID="AlbumReleaseYear" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="Label8" runat="server" Text="Label"
                                         AssociatedControlID="AlbumReleaseLabel"></asp:Label>
                                    <asp:TextBox ID="AlbumReleaseLabel" runat="server"></asp:TextBox><br />
                               </fieldset>
                            
                            <br/>
                                <!-- Delete and Clear buttons do not want Validation to happen on the web page-->
                                <asp:Button cssclass="btn" ID="AddAlbum" runat="server" OnClick="AddAlbum_Click" Text="Add"></asp:Button>
                                <asp:Button cssclass="btn" ID="UpdateAlbum" runat="server" OnClick="UpdateAlbum_Click" Text="Update"></asp:Button>
                                <asp:Button cssclass="btn" ID="DeleteAlbum" runat="server" OnClick="DeleteAlbum_Click" Text="Delete" CausesValidation="false"></asp:Button>
                                <asp:Button cssclass="btn" ID="Clear" runat="server" OnClick="Clear_Click" Text="Clear" CausesValidation="false"></asp:Button>
                                <button type="button"  class="btn" onclick="nextButton('#find')" >Back</button><br />
                            <br/>
                            <asp:ObjectDataSource ID="ArtistListODS" runat="server" 
                                OldValuesParameterFormatString="original_{0}" 
                                SelectMethod="Artist_ListAll" 
                                TypeName="Chinook.System.BLL.ArtistController">
                            </asp:ObjectDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel> 
                </div> 
                 <div class="tab-pane fade" id="lvmaintain">
                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <uc1:MessageUserControl runat="server" ID="MessageUserControl3" />
                           <p>Do wired CRUD using ListView</p>
                        </ContentTemplate>
                    </asp:UpdatePanel>   
                </div>


           </div>
        </div>
    </div>
  <%-- to use Bootwrap-freecode for formating as shown in CPSC1517
       this will NOT work here as the author of the code
        did not design the javascript to handle bootstrap tabs
        
      <script src="../Scripts/bootwrap-freecode.js"></script>--%>
</asp:Content>

