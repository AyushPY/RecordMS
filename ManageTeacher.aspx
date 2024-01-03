<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageTeacher.aspx.cs" Inherits="Admin_ManageTeacher" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4>Teacher Management</h4>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Teacher Management</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <asp:MultiView runat="server" ID="TeacherForm">
            <asp:View ID="TeacherDisplay" runat="server">
                <div>
                    <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="AddNew" OnClick="btnAddNew_Click" />
                    <asp:ListView runat="server" ID="TeacherViewer" OnItemCommand="TeacherViewer_ItemCommand" OnItemEditing="TeacherViewer_ItemEditing" OnItemDeleting="TeacherViewer_ItemDeleting" OnItemDataBound="TeacherViewer_ItemDataBound">
                         <LayoutTemplate>
                    <table class="table table-bordered table-light table-hover">
                        
                        <tr>
                            <td>
                                S.No
                            </td>
                            <td>
                                Teacher Name
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
                                Shifts
                            </td>
                            <td>
                                Employment Type
                            </td>
                            <td>
                                Faculty
                            </td>
                            <td>
                                Semester
                            </td>
                            <td>
                                Subject
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
                            <%#Eval("TeacherName") %>
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
                            <%#Eval("Shifts") %>
                        </td>
                        <td>
                            <%#Eval("Type") %>
                        </td>
                        <td>
                            <%#Eval("facultyId") %>
                        </td>
                        <td>
                            <%#Eval("semesterId") %>
                        </td>
                        <td>
                            <%#Eval("subjectId") %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="lbedit" Text="Edit" CommandArgument='<%#Eval("tId") %>' CommandName="Edit" CssClass="btn btn-info">

                            </asp:LinkButton>
                            |
                            <asp:LinkButton runat="server" ID="lbldel" Text="Delete"  CommandArgument='<%#Eval("tId") %>' CommandName="Delete" CssClass="btn btn-danger">

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
                    <label for="exampleInputEmail1">Teacher Name</label>
                     <asp:TextBox runat="server" ID="txteachername" CssClass="form-control"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hftid" />
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1"> Address</label>
                      <asp:TextBox runat="server" ID="txtteacheraddress" CssClass="form-control"></asp:TextBox>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputPassword1"> Phone No</label>
                      <asp:TextBox runat="server" ID="txtteacherphoneno" CssClass="form-control"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputPassword1"> Email</label>
                      <asp:TextBox runat="server" ID="txtteacheremail" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputFile">Gender</label>
                    <div class="input-group">
                      <div class="custom-file">
                        <asp:DropDownList runat="server" ID="ddlteachergender" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Select a Gender"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputPassword1"> Shifts</label>
                      <asp:TextBox runat="server" ID="txtTeacherShift" CssClass="form-control"></asp:TextBox>
                  </div>
                <div class="form-group">
                    <label for="exampleInputFile">Type</label>
                    <div class="input-group">
                      <div class="custom-file">
                         <asp:DropDownList runat="server" ID="ddlTeacherType" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Select Employment Type--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Full Time"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Part Time"></asp:ListItem>
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
                         <asp:DropDownList runat="server" ID="ddlSemester" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                      </div>
                   
                    </div>
                  </div> 
                <div class="form-group">
                    <label for="exampleInputFile">Subject</label>
                    <div class="input-group">
                      <div class="custom-file">
                          <asp:DropDownList runat="server" ID="ddlSubject" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                      </div>
                   
                    </div>
                  </div> 
                <div class="form-group">
                    <label for="exampleInputFile">Status</label>
                    <div class="input-group">
                      <div class="custom-file">
                          <asp:DropDownList runat="server" ID="ddlTeacherStatus" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Select Status"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                   
                    </div>
                  </div> 

                                    
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                      <asp:Button runat="server" ID="btnteachersave" CssClass="btn btn-success" Text="Submit" OnClick="btnteachersave_Click" />
                      <asp:Button runat="server" ID="btnteachercancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btnteachercancel_Click" />
                    

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

