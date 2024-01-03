using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Assignments : System.Web.UI.Page
{
    BLL bl = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        statuscheck.Visible = false;
        if (!IsPostBack)
        {
            DataTable dt = bl.GetFaculty();
            ddlFaculty.DataSource = dt;
            ddlFaculty.DataValueField = "fId";
            ddlFaculty.DataTextField = "FacultyName";
            ddlFaculty.DataBind();
            ddlFaculty.Items.Insert(0, "--Select Faculty--");
            AssignmentForm.ActiveViewIndex = 0;
            GetAssigmentInfo();
        }
    }

    protected void btnassignmentsave_Click(object sender, EventArgs e)
    {
        
        if (btnassignmentsave.Text == "Submit")
        {
            DateTime a = DateTime.Today;
            int result = bl.InsertAssignmentInfo(txtstudentname.Text, Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue), a, txtstatus.Text);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sucessfully Registered')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration Unsuccesful')", true);
            }
        }
        else if (btnassignmentsave.Text == "Update")
        {
            DateTime a = DateTime.Today;
            int result = bl.UpdateAssignment(txtstudentname.Text, Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue),a, Convert.ToInt32(hdstudentname.Value), txtstatus.Text);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sucessfully Updated')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
        }
        GetAssigmentInfo();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        AssignmentForm.ActiveViewIndex = 0;
    }

    protected void AssignmentViewer_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            DataTable dt = bl.GetAssignmentById(id);
            if (dt.Rows.Count > 0)
            {
                hdstudentname.Value = dt.Rows[0]["aid"].ToString();
                txtstudentname.Text = dt.Rows[0]["StudentName"].ToString();
                ddlFaculty.SelectedValue = dt.Rows[0]["Faculty"].ToString();
                ddlSemester.SelectedValue = dt.Rows[0]["Semester"].ToString();
                ddlSubject.Text = dt.Rows[0]["Subject"].ToString();
                btnassignmentsave.Text = "Update";
                AssignmentForm.ActiveViewIndex = 1;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found!')", true);
            }
        }
    }

    protected void AssignmentViewer_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }
    protected void AssignmentViewer_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

    }
    public void GetAssigmentInfo()
    {
        DataTable dt = bl.LoadAssigment();
        AssignmentViewer.DataSource = dt;
        AssignmentViewer.DataBind();

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

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        AssignmentForm.ActiveViewIndex = 1;
    }
    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFaculty.SelectedIndex != 0 && ddlSemester.SelectedIndex != 0)
        {
            DataTable dtGetSubject = bl.GetSubjectByFacultyIdAndSemesterId(Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue));
            ddlSubject.DataSource = dtGetSubject;
            ddlSubject.DataValueField = "subId";
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, "--Select Subject");
        }
    }



    protected void chkGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (Convert.ToInt32(chkGender.SelectedIndex))
        {
            case 0:
                txtstatus.Text = "Complete";
                break;
            case 1:
                txtstatus.Text = "Incomplete";
                break;
            case 2:
                txtstatus.Text = "In Review";
                break;

        }
    }
}