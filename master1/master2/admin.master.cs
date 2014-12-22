using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master1_master2_admin : System.Web.UI.MasterPage
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

    protected void ddl_day_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_day.SelectedValue == "SUNDAY")
        {
            ddl_sun.Visible = true;

            ddl_mon.Visible = false;
            ddl_tue.Visible = false;
            ddl_wed.Visible = false;
            ddl_thu.Visible = false;
            ddl_fri.Visible = false;
            ddl_sat.Visible = false;
        }
        else if (ddl_day.SelectedValue == "MONDAY")
        {
            ddl_mon.Visible = true;

            ddl_sun.Visible = false;
            ddl_tue.Visible = false;
            ddl_wed.Visible = false;
            ddl_thu.Visible = false;
            ddl_fri.Visible = false;
            ddl_sat.Visible = false;
        }
        else if (ddl_day.SelectedValue == "TUESDAY")
        {
            ddl_tue.Visible = true;

            ddl_sun.Visible = false;
            ddl_mon.Visible = false;
            ddl_wed.Visible = false;
            ddl_thu.Visible = false;
            ddl_fri.Visible = false;
            ddl_sat.Visible = false;
        }
        else if (ddl_day.SelectedValue == "WEDNESDAY")
        {
            ddl_wed.Visible = true;

            ddl_sun.Visible = false;
            ddl_mon.Visible = false;
            ddl_tue.Visible = false;
            ddl_thu.Visible = false;
            ddl_fri.Visible = false;
            ddl_sat.Visible = false;
        }
        else if (ddl_day.SelectedValue == "THURSDAY")
        {
            ddl_thu.Visible = true;

            ddl_sun.Visible = false;
            ddl_mon.Visible = false;
            ddl_tue.Visible = false;
            ddl_wed.Visible = false;
            ddl_fri.Visible = false;
            ddl_sat.Visible = false;
        }
        else if (ddl_day.SelectedValue == "FRIDAY")
        {
            ddl_fri.Visible = true;

            ddl_sun.Visible = false;
            ddl_mon.Visible = false;
            ddl_tue.Visible = false;
            ddl_wed.Visible = false;
            ddl_thu.Visible = false;
            ddl_sat.Visible = false;
        }
        else if (ddl_day.SelectedValue == "SATURDAY")
        {
            ddl_sat.Visible = true;

            ddl_sun.Visible = false;
            ddl_mon.Visible = false;
            ddl_tue.Visible = false;
            ddl_wed.Visible = false;
            ddl_thu.Visible = false;
            ddl_fri.Visible = false;

        }
        else
        {
            Response.Write("alert('Please Select your Day')");
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        tbl_schedule sch = new tbl_schedule();
        sch.sch_day = ddl_day.SelectedValue;
        sch.sch_date = Calendar_date.SelectedDate.ToString();


        if (ddl_day.SelectedValue == "SUNDAY")
        {
            sch.sch_time = ddl_sun.SelectedValue;
        }

        if (ddl_day.SelectedValue == "MONDAY")
        {
            sch.sch_time = ddl_mon.SelectedValue;
        }

        if (ddl_day.SelectedValue == "TUESDAY")
        {
            sch.sch_time = ddl_tue.SelectedValue;
        }
        if (ddl_day.SelectedValue == "WEDNESDAY")
        {
            sch.sch_time = ddl_wed.SelectedValue;
        }
        if (ddl_day.SelectedValue == "THURSDAY")
        {
            sch.sch_time = ddl_thu.SelectedValue;
        }

        if (ddl_day.SelectedValue == "FRIDAY")
        {
            sch.sch_time = ddl_fri.SelectedValue;
        }

        if (ddl_day.SelectedValue == "SATURDAY")
        {
            sch.sch_time = ddl_sat.SelectedValue;
        }

        sch.sch_class = ddl_class.SelectedValue;
        sch.sch_class_name = ddl_class_name.SelectedValue;
        sch.sch_subject = txt_sub.Text;
        sch.sch_prof = txt_prof.Text;

        db.tbl_schedules.InsertOnSubmit(sch);
        db.SubmitChanges();

        Response.Write("<script> alert('Your Schedule added Successfully ')</script>");

        GridView1.Visible = true;

    }
}
