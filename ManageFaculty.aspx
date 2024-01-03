<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageFaculty.aspx.cs" Inherits="Admin_ManageFaculty" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function validatef()
        {
            if(document.getElementById("<%=txtfacultyname.ClientID%>").value=="")
            {
                alert("Please Enter Student Name");
                document.getElementById("<%=txtfacultyname.ClientID%>").focus();
                document.getElementById("<%=txtfacultyname.ClientID%>").style.borderColor="red";
                return false;
            }
            if(document.getElementById("<%=txtfacultyshifts.ClientID%>").value=="")
            {
                alert("Please Select Course Type");
                document.getElementById("<%=txtfacultyshifts.ClientID%>").focus();
                document.getElementById("<%=txtfacultyshifts.ClientID%>").style.borderColor="red";
                return false;
            }
            if(document.getElementById("<%=ddlfacultystatus.ClientID%>").value==0)
            {
                alert("Please Enter Shift");
                document.getElementById("<%=ddlfacultystatus.ClientID%>").focus();
                document.getElementById("<%=ddlfacultystatus.ClientID%>").style.borderColor="red";
                return false;
            }
            

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4>Faculty Management</h4>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Faculty Management</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">

        <asp:MultiView runat="server" ID="FacultyForm">
            <asp:View ID="FacultyDisplay" runat="server">
                <div>
                    <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="AddNew" OnClick="btnAddNew_Click" />
                    <asp:ListView runat="server" ID="FacultyViewer" OnItemCommand="FacultyViewer_ItemCommand" OnItemDataBound="FacultyViewer_ItemDataBound" OnItemDeleting="FacultyViewer_ItemDeleting" OnItemEditing="FacultyViewer_ItemEditing">
                         <LayoutTemplate>
                     <table class="table table-bordered table-light table-hover">
                        
                        <tr>
                            <td>
                                S.No
                            </td>
                            <td>
                                Faculty Name
                            </td>
                            <td>
                                Shift
                            </td>
                            <td>
                            
                                Action
                            </td>
                        </tr>
                        <tbody>
                            <asp:PlaceHolder ID="Itemplaceholder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>

                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Container.DataItemIndex+1%>
                        </td>
                        <td>
                            <%#Eval("FacultyName") %>
                        </td>
                        <td>
                            <%#Eval("Shifts") %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="lbedit" Text="Edit" CommandArgument='<%#Eval("fId") %>' CommandName="Edit" CssClass="btn btn-info">

                            </asp:LinkButton>
                            |
                            <asp:LinkButton runat="server" ID="lbldel" Text="Delete"  CommandArgument='<%#Eval("fId") %>' CommandName="Delete" CssClass="btn btn-danger">

                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                    </asp:ListView>
                </div>
                
            </asp:View>
            <asp:View ID="FacultyAdder" runat="server">
                <div class="row">
          <!-- left column -->
          <div class="col-md-6">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Add New</h3>
              </div>
          
                <div class="card-body">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Faculty Name</label>
                     <asp:TextBox runat="server" ID="txtfacultyname" CssClass="form-control"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdfacultyname" />
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1"> Shift</label>
                     <asp:TextBox runat="server" ID="txtfacultyshifts" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputFile">Status</label>
                    <div class="input-group">
                      <div class="custom-file">
                        <asp:DropDownList runat="server" ID="ddlfacultystatus" CssClass="form-control">
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                    </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>                 
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                      <asp:Button runat="server" ID="btnfacultysave" CssClass="btn btn-primary" Text="Submit" OnClick="btnfacultysave_Click"/>
                      <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                    

                </div>
             
            </div>
            <!-- /.card -->

            
            <!-- /.card -->

          </div>
          <!--/.col (left) -->
          <!-- right column -->
          <div class="col-md-6">          
           
              <!-- /.card-body -->
            </div>
            <!-- /.card -->

          
              </div>
            </asp:View>
            
        </asp:MultiView>



        
          
        <!-- /.row -->
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
</asp:Content>

