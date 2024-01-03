<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentManagement.aspx.cs" Inherits="Admin_StudentManagement" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4>Student Management</h4>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Student Management</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <asp:MultiView runat="server" ID="StudentForm">
            <asp:View ID="TeacherDisplay" runat="server">
                <div>
                    <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="AddNew" OnClick="btnAddNew_Click" /> 
                    <asp:ListView runat="server" ID="StudentViewer" OnItemCommand="StudentViewer_ItemCommand" OnItemEditing="StudentViewer_ItemEditing" OnItemDeleting="StudentViewer_ItemDeleting" OnItemDataBound="StudentViewer_ItemDataBound">
                         <LayoutTemplate>
                     <table class="table table-bordered table-light table-hover">
                        
                        <tr>
                            <td>
                                S.No
                            </td>
                            <td>
                                Student Name
                            </td>
                            <td>
                                Address
                            </td>
                            <td>
                                Phone No.
                            </td>
                            <td>
                                Email
                            </td>
                            <td>
                                Gender
                            </td>
                            <td>
                                Roll No
                            </td>
                            <td>
                                Faculty
                            </td>
                            <td>
                                Semester
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
                            <%#Eval("StudentName") %>
                        </td>
                        <td>
                            <%#Eval("Address") %>
                        </td>
                        <td>
                            <%#Eval("PhoneNo") %>
                        </td>
                        <td>
                            <%#Eval("Email") %>
                        </td>
                        <td>
                            <%#Eval("Gender") %>
                        </td>
                        <td>
                            <%#Eval("RollNo") %>
                        </td>
                        <td>
                            <%#Eval("facultyId") %>
                        </td>
                        <td>
                            <%#Eval("semesterId") %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="lbedit" Text="Edit" CommandArgument='<%#Eval("sid") %>' CommandName="Edit" CssClass="btn btn-info">

                            </asp:LinkButton>
                            |
                            <asp:LinkButton runat="server" ID="lbldel" Text="Delete"  CommandArgument='<%#Eval("sid") %>' CommandName="Delete" CssClass="btn btn-danger">

                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                    </asp:ListView>
                </div>
                
            </asp:View>
            <asp:View ID="TeacherAdder" runat="server">
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
                    <label for="exampleInputEmail1">Student Name</label>
                     <asp:TextBox runat="server" ID="txtstudentname" CssClass="form-control"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdstudent" />
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1"> Address</label>
                       <asp:TextBox runat="server" ID="txtstudentaddress" CssClass="form-control"></asp:TextBox>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputPassword1"> Phone No</label>
                      <asp:TextBox runat="server" ID="txtstudentphoneno" CssClass="form-control"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputPassword1"> Email</label>
                      <asp:TextBox runat="server" ID="txtstudentemail" CssClass="form-control"></asp:TextBox>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputPassword1"> Roll No</label>
                      <asp:TextBox runat="server" ID="txtstudentrollno" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputFile">Gender</label>
                    <div class="input-group">
                      <div class="custom-file">
                        <asp:DropDownList runat="server" ID="ddlstudentgender" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Select a Gender"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>
                 <div class="form-group">
                    <label for="exampleInputFile">Faculty</label>
                    <div class="input-group">
                      <div class="custom-file">
                        <asp:DropDownList runat="server" ID="ddlFaculty" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                      </div>
                   
                    </div>
                  </div> 
                <div class="form-group">
                    <label for="exampleInputFile">Semester</label>
                    <div class="input-group">
                      <div class="custom-file">
                         <asp:DropDownList runat="server" ID="ddlSemester" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged"></asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>  
                <div class="form-group">
                    <label for="exampleInputFile">Status</label>
                    <div class="input-group">
                      <div class="custom-file">
                          <asp:DropDownList runat="server" ID="ddlStudentStatus" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Specify Status--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div> 

                                    
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                      <asp:Button runat="server" ID="btnstudentsave" Text="Submit" OnClick="btnstudentsave_Click" CssClass="btn btn-success" />
                      <asp:Button runat="server" ID="btnstudentcancel" Text="Cancel" OnClick="btnstudentcancel_Click" CssClass="btn btn-danger" />
                    

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

