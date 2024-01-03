using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageTeacher : System.Web.UI.Page
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
            TeacherLoad();
            TeacherForm.ActiveViewIndex = 0;
        }

    }

    protected void btnteachersave_Click(object sender, EventArgs e)
    {
        if (btnteachersave.Text == "Submit")
        {
            int result = bl.insertteachersinfo(txteachername.Text, txtteacheraddress.Text, txtteacherphoneno.Text, txtteacheremail.Text, Convert.ToInt32(ddlteachergender.SelectedValue), txtTeacherShift.Text, Convert.ToInt32(ddlTeacherType.SelectedValue), Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue), Convert.ToInt32(ddlTeacherStatus.SelectedValue));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Teacher Info Successfuly Saved')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entry Unsuccessful')", true);
            }
        }
        else if (btnteachersave.Text == "Update")
        {
            int result = bl.UpdateTeacher(txteachername.Text, txtteacheraddress.Text, txtteacherphoneno.Text, txtteacheremail.Text, Convert.ToInt32(ddlteachergender.SelectedValue), txtTeacherShift.Text, Convert.ToInt32(ddlTeacherType.SelectedValue), Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue), Convert.ToInt32(ddlTeacherStatus.SelectedValue), Convert.ToInt32(hftid.Value));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Updated')", true);
            }
            else 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
        }
        TeacherLoad();
    }

    protected void btnteachercancel_Click(object sender, EventArgs e)
    {
        TeacherForm.ActiveViewIndex = 0;
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
        TeacherForm.ActiveViewIndex = 1;
    }
public void TeacherLoad()
    {
        DataTable dt = bl.GetTeacherInfo();
        TeacherViewer.DataSource = dt;
        TeacherViewer.DataBind();
    }

    protected void TeacherViewer_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            DataTable dt = bl.GetTeacherInfobyId(id);
            if (dt.Rows.Count > 0)
            {
                hftid.Value = dt.Rows[0]["tId"].ToString();
                txteachername.Text = dt.Rows[0]["TeacherName"].ToString();
                txtteacheraddress.Text = dt.Rows[0]["Address"].ToString();
                txtteacherphoneno.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtteacheremail.Text = dt.Rows[0]["Email"].ToString();
                ddlteachergender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                txtTeacherShift.Text = dt.Rows[0]["Shifts"].ToString();
                ddlTeacherType.SelectedValue = dt.Rows[0]["Type"].ToString();
                ddlFaculty.SelectedValue = dt.Rows[0]["facultyId"].ToString();
                ddlSemester.SelectedValue = dt.Rows[0]["semesterID"].ToString();
                ddlSubject.SelectedValue = dt.Rows[0]["subjectId"].ToString();
                ddlTeacherStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                //ddlfacultystatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                btnteachersave.Text = "Update";
                TeacherForm.ActiveViewIndex = 1;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found!')", true);
            }
            if (e.CommandName == "Delete")
            {
                int result = bl.DeleteTeacher(id);
                if (result > 0)
                {
                    TeacherLoad();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successful')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Failed')", true);
                }
            }
        }
    }

    protected void TeacherViewer_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }

    protected void TeacherViewer_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

    }

    protected void TeacherViewer_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

    }
}
