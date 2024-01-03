<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SubjectManagement.aspx.cs" Inherits="Admin_SubjectManagement" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
              <li class="breadcrumb-item active">Subject Management</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">

        <asp:MultiView runat="server" ID="SubjectForm">
            <asp:View ID="FacultyDisplay" runat="server">
                <div>
                    <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="AddNew" OnClick="btnAddNew_Click" />
                    <asp:ListView runat="server" ID="SubjectViewer" OnItemCommand="SubjectViewer_ItemCommand" OnItemEditing="SubjectViewer_ItemEditing" OnItemDeleting="SubjectViewer_ItemDeleting" OnItemDataBound="SubjectViewer_ItemDataBound">
                         <LayoutTemplate>
                    <table class="table table-bordered table-light table-hover">
                        
                        <tr>
                            <td>
                                S.No
                            </td>
                            <td>
                                Faculty Id
                            </td>
                            <td>
                                Semester Id
                            </td>
                            <td>
                            
                                Subject Name
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
                            <%#Eval("facultyId") %>
                        </td>
                        <td>
                            <%#Eval("semesterId") %>
                        </td>
                        <td>
                            <%#Eval("SubjectName") %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="lbedit" Text="Edit" CommandArgument='<%#Eval("subId") %>' CommandName="Edit" CssClass="btn btn-info">

                            </asp:LinkButton>
                            |
                            <asp:LinkButton runat="server" ID="lbldel" Text="Delete"  CommandArgument='<%#Eval("subId") %>' CommandName="Delete" CssClass="btn btn-danger">

                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                    </asp:ListView>
                </div>
                
            </asp:View>
            <asp:View ID="SubjectAdder" runat="server">
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
                    <label for="exampleInputEmail1">Subject Name</label>
                     <asp:TextBox runat="server" ID="txtsubjectname"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdsubjectname" />
                  </div>
                  <div class="form-group">
                    <label for="exampleInputFile">Faculty</label>
                    <div class="input-group">
                      <div class="custom-file">
                         <asp:DropDownList runat="server" ID="ddlFaculty" AutoPostBack="true" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>                        
                    </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputFile">Semester</label>
                    <div class="input-group">
                      <div class="custom-file">
                         <asp:DropDownList runat="server" ID="ddlSemester">
                        
                    </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputFile">Status</label>
                    <div class="input-group">
                      <div class="custom-file">
                         <asp:DropDownList runat="server" ID="ddlSubjectStatus">
                        <asp:ListItem Value="0" Text="--Select Status--"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                    </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>                
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                      <asp:Button runat="server" ID="btnsubjectsave" Text="Save" OnClick="btnsubjectsave_Click" CssClass="btn btn-success"/>
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

