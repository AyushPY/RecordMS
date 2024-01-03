using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SemesterManagement : System.Web.UI.Page
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
            SemesterForm.ActiveViewIndex = 0;
            SemesterLoad();
            
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        SemesterForm.ActiveViewIndex = 1;
    }

    protected void SemesterViewer_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            DataTable dt = bl.GetSemesterById(id);
            if (dt.Rows.Count > 0)
            {
                hdsemestername.Value = dt.Rows[0]["semId"].ToString();
                txtSemestername.Text = dt.Rows[0]["SemesterName"].ToString();
                ddlFaculty.SelectedValue = dt.Rows[0]["facultyId"].ToString();
                btnsemestersave.Text = "Update";
                SemesterForm.ActiveViewIndex = 1;


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found!')", true);
            }
        }
        if (e.CommandName == "Delete")
        {
            int result = bl.DeleteSemester(id);
            if (result > 0)
            {
                SemesterLoad();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successful')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
        }
    }

    protected void SemesterViewer_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }

    protected void SemesterViewer_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

    }

    protected void SemesterViewer_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

    }

    protected void btnsemestersave_Click(object sender, EventArgs e)
    {
        if (btnsemestersave.Text == "Save")
        {
            int result = bl.InsertSemester(txtSemestername.Text, Convert.ToInt32(ddlFaculty.SelectedValue), 1);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Semester Info Has Been Saved')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operation Failed')", true);
            }
        }
        else if (btnsemestersave.Text=="Update")
        {

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        SemesterForm.ActiveViewIndex=0;
    }
    public void SemesterLoad()
    {
        DataTable dt = bl.GetSemesterInfo();
        SemesterViewer.DataSource = dt;
        SemesterViewer.DataBind();
    }

}