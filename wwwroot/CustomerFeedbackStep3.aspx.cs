using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerFeedbackStep3 :  System.Web.UI.Page
{
    genfunction genf = new genfunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Button1.Visible==true)
        {
            var query = "select top(10) job_id 'Job Id',customer_name 'Customer Name',Vehicle,Model,Eng_no 'Eng. NO',";
            query += " bill_date as 'Bill Date' from new_job_cart  where (bill_date=getdate()-3 or job_id=5737)";
            query += " and job_id in (select JobId from CustomerFeedback where ConductDate2 !=null and ConductDate3 is null)";

            genf.populate_grid(query, gridFeedback);
            Button1.Visible = false;
        }
    }

    protected void gridFeedback_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["JobId2"] = gridFeedback.SelectedRow.Cells[1].Text;
        Response.Redirect("CustomerFeedback2.aspx");
    }


  
}