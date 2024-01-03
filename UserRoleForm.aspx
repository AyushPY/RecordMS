<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRoleForm.aspx.cs" Inherits="UserRoleForm" %>

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
                        Role Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRoleName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnSaveUserRole" Text="Save"  OnClick="btnSaveUserRole_Click"/>
                    </td>
                </tr>
                    
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
