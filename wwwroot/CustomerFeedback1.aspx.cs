using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerFeedback1 : System.Web.UI.Page
{
    string strconnection = ConfigurationSettings.AppSettings["ConnectionString1"];
    string strconnection2 = ConfigurationSettings.AppSettings["ConnectionString2"];
    SqlConnection Myconnection, myconnection1, myconnection2;
    SqlCommand Mycommand, Mycommand1, Mycommand2, Mycommand10;
    SqlCommand mynewrecord;
    string strnewrecord = string.Empty;
    SqlDataAdapter Mydataadapter, Mydataadapter1, Mydataadapter2, Mydataadapter10;
    genfunction gen = new genfunction();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblJobId.Visible = false;
        if (Button1.Visible == true)
        {
            txtSubmitDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Button1.Visible = false;
            var jobId = Session["JobId1"];
            lblJobId.Text = jobId.ToString();
            var query = "select  job_id 'Job Id',customer_name 'Customer Name',Vehicle,Model,reg_no,Eng_no 'Eng. NO',mobile from new_job_cart where job_id='" + jobId + "'";

            Myconnection = new SqlConnection(strconnection);
            Myconnection.Open();
            strnewrecord = query;
            DataSet dataSet = new DataSet();
            Mycommand1 = new SqlCommand(strnewrecord, Myconnection);
            Mydataadapter1 = new SqlDataAdapter(Mycommand1);
            Mydataadapter1.Fill(dataSet, "vehicle_model");
            var dt = dataSet.Tables[0];

            txtCustomerName.Text = dt.Rows[0][1].ToString();
            txtCarName.Text = dt.Rows[0][2].ToString();
            txtCarRegistration.Text = dt.Rows[0][4].ToString();
            txtMobile.Text = dt.Rows[0][6].ToString();
        }
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        Myconnection = new SqlConnection(strconnection);
        Myconnection.Open();

        var jobId = lblJobId.Text;

        var feedbackId = gen.returnvaluefromdv("select itemid from CustomerFeedback where JobId=" + jobId + " ", 0);

        strnewrecord = "update  CustomerFeedback set FeedbackType2='" + dtfeedbackType.SelectedValue + "',";
        strnewrecord += "ConductDate2='" + DateTime.Now + "',Remarks2='" + txtRemarks.Text + "' where ";
        strnewrecord += " itemId=" + feedbackId + "";

        Mycommand = new SqlCommand(strnewrecord, Myconnection);
        Mycommand.ExecuteNonQuery();


        Dictionary<int, Dictionary<int, string>> quesText = new Dictionary<int, Dictionary<int, string>>();

        Dictionary<int, string> innerDic = new Dictionary<int, string>();
        innerDic.Add(int.Parse(rdoProblem.SelectedValue), txtProblem.Text);
        quesText.Add(1, innerDic);

        var query = "delete from CustomerFeedbackData where type=2 and CustomerFeedbackId=" + feedbackId + "";
        Mycommand = new SqlCommand(query, Myconnection);
        Mycommand.ExecuteNonQuery();


        foreach (var item in quesText)
        {
            var values = item.Value;
            strnewrecord = "";
            foreach (var key in values)
            {
                strnewrecord += "insert into CustomerFeedbackData (CustomerFeedbackId,Type,QuestionNo,Value,Text) values";
                strnewrecord += " (" + feedbackId + ",2," + item.Key + "," + key.Key + ",'" + key.Value + "')";
            }

            Mycommand = new SqlCommand(strnewrecord, Myconnection);
            Mycommand.ExecuteNonQuery();
        }
        Myconnection.Close();

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully Inserted!');", true);
    }



    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        Session["JobId"] = lblJobId.Text;
        Response.Redirect("PrintInstantFeedback.aspx");
    }
}