using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_StudentManagement : System.Web.UI.Page
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
            StudentLoad();
            StudentForm.ActiveViewIndex = 0;
        }
    }

    protected void btnstudentsave_Click(object sender, EventArgs e)
    {
        if(btnstudentsave.Text== "Submit")
        {
            int result = bl.insertstudentinfo(txtstudentname.Text, txtstudentaddress.Text, txtstudentphoneno.Text, txtstudentemail.Text, Convert.ToInt32(ddlstudentgender.SelectedValue), txtstudentrollno.Text, Convert.ToInt32(ddlFaculty.SelectedValue), Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlStudentStatus.SelectedValue));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Info Has Been Saved')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entry Unsuccessful')", true);
            }
        }
        else if (btnstudentsave.Text == "Update")
        {
            int a = Convert.ToInt32(ddlstudentgender.SelectedValue);
            int b = Convert.ToInt32(ddlFaculty.SelectedValue);
            int c = Convert.ToInt32(ddlSemester.SelectedValue);
            int d = Convert.ToInt32(ddlStudentStatus.SelectedValue);
            int f = Convert.ToInt32(hdstudent.Value);
            int result = bl.UpdateStudent( txtstudentname.Text , txtstudentaddress.Text, txtstudentphoneno.Text , txtstudentemail.Text , a , txtstudentrollno.Text , b , c , d , f );
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Updated')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
            StudentLoad();
        }
    }

    protected void btnstudentcancel_Click(object sender, EventArgs e)
    {
        StudentForm.ActiveViewIndex = 0;
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
public void StudentLoad()
    {
        DataTable dt = bl.GetStudentInfo();
        StudentViewer.DataSource = dt;
        StudentViewer.DataBind();
        
    }


    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        StudentForm.ActiveViewIndex = 1;
    }

    protected void StudentViewer_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            DataTable dt = bl.GetStudentInfoById(id);
            if (dt.Rows.Count > 0)
            {
                hdstudent.Value = dt.Rows[0]["sid"].ToString();
                txtstudentname.Text = dt.Rows[0]["StudentName"].ToString();
                txtstudentaddress.Text = dt.Rows[0]["Address"].ToString();
                txtstudentphoneno.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtstudentemail.Text = dt.Rows[0]["Email"].ToString();
                ddlstudentgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                txtstudentrollno.Text = dt.Rows[0]["RollNo"].ToString();
                ddlFaculty.SelectedValue = dt.Rows[0]["FacultyId"].ToString();
                ddlSemester.SelectedValue= dt.Rows[0]["SemesterId"].ToString();
                ddlStudentStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                //ddlfacultystatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                btnstudentsave.Text = "Update";
                StudentForm.ActiveViewIndex = 1;


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found!')", true);
            }
        }
        if (e.CommandName == "Delete")
        {
            int result = bl.DeleteStudent(id);
            if (result > 0)
            {
                StudentLoad();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successful')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Failed')", true);
            }
        }
    }

    protected void StudentViewer_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }

    protected void StudentViewer_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

    }

    protected void StudentViewer_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

    }

    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}