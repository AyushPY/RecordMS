<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Assignments.aspx.cs" Inherits="Admin_Assignments" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4>Assignmnet Tracker </h4>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Assignment Entry</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">

        <asp:MultiView runat="server" ID="AssignmentForm">
            <asp:View ID="AssignmentDisplay" runat="server">
                <div>
                    <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add New" OnClick="btnAddNew_Click" />
                    <asp:ListView runat="server" ID="AssignmentViewer" OnItemCommand="AssignmentViewer_ItemCommand" OnItemEditing="AssignmentViewer_ItemEditing" OnItemDataBound="AssignmentViewer_ItemDataBound">
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
                                Faculty
                            </td>
                             <td>
                                Semester
                            </td>
                            <td>
                                Subject
                            </td>
                             <td>
                                Sumitted Date
                            </td>
                            <td>
                                Status
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
                            <%#Eval("Faculty") %>
                        </td>
                         <td>
                            <%#Eval("Semester") %>
                        </td>
                        <td>
                            <%#Eval("Subject") %>
                        </td>
                        <td>
                            <%#Eval("SubmittedDate") %>
                        </td>
                        <td>
                            <%#Eval("Status") %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="lbedit" Text="Update" CommandArgument='<%#Eval("aid") %>' CommandName="Edit" CssClass="btn btn-info">

                            </asp:LinkButton>
                                         
                        </td>
                    </tr>
                </ItemTemplate>
                    </asp:ListView>
                </div>
                
            </asp:View>
            <asp:View ID="AssignmentEntry" runat="server">
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
                    <asp:HiddenField runat="server" ID="hdstudentname" />
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
                    <div>
                        <asp:CheckBoxList runat="server" ID="chkGender" CssClass="form-control" RepeatDirection="Horizontal" OnSelectedIndexChanged="chkGender_SelectedIndexChanged">
                         <asp:ListItem Value="1">Complete&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                           <asp:ListItem Value="2">Incomplete&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="3">In Review&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                         </asp:CheckBoxList>
                    </div>               
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                      <asp:Button runat="server" ID="btnassignmentsave" CssClass="btn btn-primary" Text="Submit" OnClick="btnassignmentsave_Click"/>
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


          <div runat="server" id="statuscheck">
              <asp:TextBox runat="server" ID="txtstatus"></asp:TextBox>
          </div>
        
          
        <!-- /.row -->
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
</asp:Content>

