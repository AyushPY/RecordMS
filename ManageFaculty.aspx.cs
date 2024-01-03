using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageFaculty : System.Web.UI.Page
{
    BLL blfaculty = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FacultyForm.ActiveViewIndex = 0;
            GetFacultyInfo();
        }

    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        FacultyForm.ActiveViewIndex = 1;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        FacultyForm.ActiveViewIndex = 0;

    }

    protected void btnfacultysave_Click(object sender, EventArgs e)
    {
        if (btnfacultysave.Text == "Submit")
        {
            int result = blfaculty.InsertFacultyInfo(txtfacultyname.Text, txtfacultyshifts.Text, Convert.ToInt32(ddlfacultystatus.SelectedValue));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sucessfully Registered')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration Unsuccesful')", true);
            }
        }
        else if (btnfacultysave.Text == "Update")
        {
            int result = blfaculty.UpdateFaculty(txtfacultyname.Text, txtfacultyshifts.Text, Convert.ToInt32(ddlfacultystatus.SelectedValue), Convert.ToInt32(hdfacultyname.Value));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sucessfully Updated')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
        }
        GetFacultyInfo();
    }

    protected void FacultyViewer_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            DataTable dt = blfaculty.GetFacultybyId(id);
            if (dt.Rows.Count > 0)
            {
                hdfacultyname.Value = dt.Rows[0]["fId"].ToString();
                txtfacultyname.Text = dt.Rows[0]["FacultyName"].ToString();
                txtfacultyshifts.Text = dt.Rows[0]["Shifts"].ToString();
                ddlfacultystatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                btnfacultysave.Text = "Update";
                FacultyForm.ActiveViewIndex = 1;
                

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found!')", true);
            }
        }
        if (e.CommandName == "Delete")
        {
            int result = blfaculty.DeleteFaculty(id);
            if (result > 0)
            {
                GetFacultyInfo();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successful')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Failed')", true);
            }
        }
    }

    protected void FacultyViewer_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

    }

    protected void FacultyViewer_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

    }

    protected void FacultyViewer_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }
public void GetFacultyInfo()
    {
        DataTable dt = blfaculty.LoadFaculty();
        FacultyViewer.DataSource = dt;
        FacultyViewer.DataBind();

    }

}