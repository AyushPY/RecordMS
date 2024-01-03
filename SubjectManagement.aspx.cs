using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SubjectManagement : System.Web.UI.Page
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
            SubjectForm.ActiveViewIndex = 0;
            SubjectLoad();

        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        SubjectForm.ActiveViewIndex = 1;
    }

    protected void btnsubjectsave_Click(object sender, EventArgs e)
    {
        if (btnsubjectsave.Text == "Save")
        {
            int result = bl.insertsubject(txtsubjectname.Text, Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlSubjectStatus.SelectedValue));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subject Registered')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subject Was Not Registered')", true);
            }
        }
        else if (btnsubjectsave.Text == "Update")
        {

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        SubjectForm.ActiveViewIndex = 0;
    }

    protected void SubjectViewer_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            DataTable dt = bl.GetSubjectInforById(id);
            if (dt.Rows.Count > 0)
            {
                hdsubjectname.Value = dt.Rows[0]["subId"].ToString();
                txtsubjectname.Text = dt.Rows[0]["SubjectName"].ToString();
                ddlFaculty.SelectedValue = dt.Rows[0]["facultyId"].ToString();
                ddlSemester.SelectedValue = dt.Rows[0]["semesterId"].ToString();
                btnsubjectsave.Text = "Update";
                SubjectForm.ActiveViewIndex = 1;



            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found!')", true);
            }
        }
        if (e.CommandName == "Delete")
        {
            int result = bl.DeleteSubject(id);
            if (result > 0)
            {
                SubjectLoad();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successful')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
        }
    }

    protected void SubjectViewer_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }

    protected void SubjectViewer_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

    }

    protected void SubjectViewer_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

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
    public void SubjectLoad()
    {
        DataTable dt = bl.GetSubjectInfo();
        SubjectViewer.DataSource = dt;
        SubjectViewer.DataBind();
    }
}