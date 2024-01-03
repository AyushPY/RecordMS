<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInformation.aspx.cs" Inherits="UserInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table>
                <tr>
                    <td>
                        Full Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserInfoFullName"></asp:TextBox>
                    </td>
                    </tr>
               <tr>
                        <td>
                            User Name
                        </td>
                   <td>
                       <asp:TextBox runat="server" ID="txtUserInfoUserName"></asp:TextBox>
                   </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserInfoPassword" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        User Role
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserInfoUserRole"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gender
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserInfoGender" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="--Select a Gender--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Roll Number
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserInformationRollNo"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Faculty 
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlFaculty" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Semester
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSemester" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserInformationStatus">
                            <asp:ListItem Value="0" Text="--Select Status--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnUserInfoSave" Text="Save" OnClick="btnUserInfoSave_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
