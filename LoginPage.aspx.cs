using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    BLL bl = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
           
        }
    }


    protected void btnlogin_Click(object sender, EventArgs e)
    {
        DataTable dtl = bl.loginvalidation(txtloginusername.Text, txtpassword.Text);
        if (dtl.Rows.Count > 0)
        {
            Session["FullName"] = dtl.Rows[0]["Fullname"].ToString();
            Session["Userrole"] = dtl.Rows[0]["UserRole"].ToString();
            Session["Gender"] = dtl.Rows[0]["Gender"].ToString();
            Session["FacultyID"] = dtl.Rows[0]["facultyId"].ToString();
            Session["SemesterID"] = dtl.Rows[0]["semesterId"].ToString();
            if (Convert.ToInt32(Session["Userrole"]) == 1)
            {
                Response.Redirect("Admin/AdminDashboard.aspx");
            }
            else if(Convert.ToInt32(Session["Userrole"]) == 2)
            {
                Response.Redirect("Teacher/TeacherDashboard.aspx");
            }
            else if (Convert.ToInt32(Session["Userrole"]) == 3)
            {
                Response.Redirect("Student/StudentDashboard.aspx");
            }
            else if (Convert.ToInt32(Session["Userrole"]) == 4)
            {
                Response.Redirect("Coordinator/CoordinatorDashboard.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            //switch (ddlUserRole.SelectedIndex)
            //{
            //    case 1:
            //        Response.Redirect("SubjectsForm.aspx");
            //        break;
            //    case 2:
            //        Response.Redirect("TeachersForm.aspx");
            //        break;
            //    case 3:
            //        Response.Redirect("Studentform.aspx");
            //        break;
            //    case 4:
            //        Response.Redirect("Semesterform.aspx");
            //        break;

            //}

        }
        else
        {
            lblerror.Text = "Invalid Username or Password";
            //lbRegistration.Text = "Click Here to Register";
        }

       
 }

    protected void lbRegistration_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserInformation.aspx");
    }




protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }

    
}