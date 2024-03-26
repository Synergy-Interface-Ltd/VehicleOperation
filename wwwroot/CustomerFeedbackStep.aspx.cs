using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerFeedbackStep :  System.Web.UI.Page
{
    genfunction genf = new genfunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Button1.Visible==true)
        {
            //txtInstant.Text = (genf.returnvaluefromdv("select count(*) from new_job_cart where bill_date=getdate()", 0)).ToString();
            //txtOneDay.Text = (genf.returnvaluefromdv("select count(*) from new_job_cart where bill_date=getdate()-1", 0)).ToString();
            //txtThreeDay.Text = (genf.returnvaluefromdv("select count(*) from new_job_cart where bill_date=getdate()-3", 0)).ToString();
            //txtcomplete.Text = (genf.returnvaluefromdv("select count(*) from new_job_cart where bill_date=getdate()-3", 0)).ToString();

            var query = "select  job_id 'Job Id',customer_name 'Customer Name',Vehicle,Model,Eng_no 'Eng. NO',";
            query += " bill_date as 'Bill Date' from new_job_cart where  cast(bill_date as date)=cast(getdate() as date)";
            query += " and job_id not in (select JobId from CustomerFeedback )";

            genf.populate_grid(query, gridFeedback);

            Button1.Visible = false;
        }
    }

    protected void gridFeedback_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["JobId"] = gridFeedback.SelectedRow.Cells[1].Text;
        Response.Redirect("CustomerFeedback.aspx");
    } 
}