using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInformation : System.Web.UI.Page
{
    BLL bl = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = bl.GetFaculty();
            ddlFaculty.DataSource = dt;
            ddlFaculty.DataValueField = "fId";
            ddlFaculty.DataTextField = "FacultyName";
            ddlFaculty.DataBind();
            ddlFaculty.Items.Insert(0, "--Select Faculty--");
            ddlSemester.Items.Insert(0, "--Select Semester--");
            DataTable dtr = bl.GetUserRole();
            ddlUserInfoUserRole.DataSource = dtr;
            ddlUserInfoUserRole.DataValueField = "uId";
            ddlUserInfoUserRole.DataTextField = "RoleName";
            ddlUserInfoUserRole.DataBind();
            ddlUserInfoUserRole.Items.Insert(0, "--Select User Role");

        }
    }

    protected void btnUserInfoSave_Click(object sender, EventArgs e)
    {
        int result = bl.InsertUserInformation(txtUserInfoFullName.Text, txtUserInfoUserName.Text, txtUserInfoPassword.Text, Convert.ToInt32(ddlUserInfoUserRole.SelectedValue), Convert.ToInt32(ddlUserInfoGender.SelectedValue), txtUserInformationRollNo.Text, Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlUserInformationStatus.SelectedValue));
        if (result > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subject Registered')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration Failed')", true);
        }
    }

    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFaculty.SelectedIndex != 0)
        {
            DataTable dtGetSem = bl.GetSemesterByFacultyId(Convert.ToInt32(ddlFaculty.SelectedValue));
            ddlSemester.DataSource = dtGetSem;
            ddlSemester.DataValueField = "semId";
            ddlSemester.DataTextField = "SemesterName";
            ddlSemester.DataBind();
        }
    }
}