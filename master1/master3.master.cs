using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master1_master3 : System.Web.UI.MasterPage
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null)
        {

            Response.Write("<script> alert('You must login') </script>");

        }
        else
        {
            lbl_username.Text = Session["user"].ToString();
            

        }


       
    }
    protected void btn_attend_Click(object sender, EventArgs e)
    {
        tbl_attend att = new tbl_attend();
        
        att.attend_curr_date = Calendar1.SelectedDate.ToString();
        att.attend_class = DropDownList1.SelectedValue;
        att.attend_attendance = RadioButtonList1.SelectedValue;
        db.tbl_attends.InsertOnSubmit(att);

        db.SubmitChanges();

        Response.Write("<script>alert('You are Present') </script>");
    }
}
