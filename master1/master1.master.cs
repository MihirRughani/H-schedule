using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class master1_master1 : System.Web.UI.MasterPage
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btn_reg_Click(object sender, EventArgs e)
    {
        tbl_register reg = new tbl_register();
        reg.stud_name = txt_name.Text;
        reg.stud_class = ddl_class.SelectedValue;
        reg.stud_email = txt_email.Text;
        reg.stud_password = txt_conPass.Text;
        if(FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/master1/images/"+ FileUpload1.FileName));

        }
        reg.stud_pic = "~/master1/images/" + FileUpload1.FileName;
        reg.user_type = "user";
        db.tbl_registers.InsertOnSubmit(reg);

        tbl_login log = new tbl_login();
        log.log_email = txt_email.Text;
        log.log_password = txt_conPass.Text;
        log.user_type ="user";
        db.tbl_logins.InsertOnSubmit(log);

        db.SubmitChanges();

        Response.Write("<script> alert('Now, You Are Registered User Please Login Here...') </script>");

    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        var rr= from p in db.tbl_logins
                where p.log_email==txt_username.Text && p.log_password==txt_password.Text
                    select p;

        tbl_login log = new tbl_login();
        if (rr.Count() != 0)
        {
            if (rr.First().user_type == "user")
            {
                Session["user"] = txt_username.Text;
                
                Response.Redirect("register_user.aspx");
            }

            else if(rr.First().user_type == "admin")
            {
                Session["user"] = txt_username.Text;
                Response.Redirect("~/master1/master2/admin_schedule.aspx");
            }
            else 
            {
                Response.Write("Invalid User");
            }
        }
    }
    protected void lnkb_fp_Click(object sender, EventArgs e)
    {

    }
}
