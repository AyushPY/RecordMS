using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewLoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnsignin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=.;Integrated Security=True;Initial Catalog=RecordDBMS");
        SqlCommand cmd = new SqlCommand("select * from tblUserInformation where Username=@uname and Password=@passwd ", con);
        cmd.Parameters.AddWithValue("@uname", txtusername.Text);
        cmd.Parameters.AddWithValue("@passwd", txtpassword.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Session["Username"] = dt.Rows[0]["Fullname"].ToString();
            Response.Redirect("AdminDashboard.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid  Username or Password')", true);
           

        }
    }

    protected void txtclick_Click(object sender, EventArgs e)
    {

    }
}