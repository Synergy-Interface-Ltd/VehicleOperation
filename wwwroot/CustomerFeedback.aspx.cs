using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerFeedback :  System.Web.UI.Page
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
        if (Button1.Visible==true)
        {
            txtSubmitDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Button1.Visible = false;
            var jobId = Session["JobId"];
            var query="select  job_id 'Job Id',customer_name 'Customer Name',Vehicle,Model,reg_no,Eng_no 'Eng. NO',mobile from new_job_cart where job_id='"+jobId+"'";

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

        var jobId = Session["JobId"];
        int operateBy = 0;
        if(chkOperate1.Checked == true)
        {
            operateBy = 1;
        }
        else if(chkOperate2.Checked == true)
        {
            operateBy = 2;
        }
        else
        {
            operateBy = 3;
        }

        int suggestBy = 0;
        if (chkSuggest1.Checked == true)
        {
            suggestBy = 1;
        }
        else if (chkSuggest2.Checked == true)
        {
            suggestBy = 2;
        }
        else
        {
            suggestBy = 3;
        }


        strnewrecord = "insert into CustomerFeedback (JobId,ConductDate1,ConductBy,OperateBy,SuggestBy,Remarks1,";
        strnewrecord += " FeedbackType1,Complain1,CustomerFeedBack1) values (";
        strnewrecord += " " + jobId + ",'" + DateTime.Now + "','" + Session["uid"].ToString() + "',";
        strnewrecord += " " + operateBy + "," + suggestBy + ",'" + txtRemarks.Text+ "',";
        strnewrecord += " '" + dtfeedbackType.SelectedValue + "','" + txtComplain.Text + "',"; 
        strnewrecord += " '" + dtCustomerFeedback.SelectedValue+ "'); select scope_identity()";

        Mycommand = new SqlCommand(strnewrecord, Myconnection);
        var feedBackId = Convert.ToInt32(Mycommand.ExecuteScalar());
   
        Dictionary<int, Dictionary<int,string>> quesText = new Dictionary<int, Dictionary<int, string>>();
        
        Dictionary<int, string> innerDic = new Dictionary<int, string>();
        innerDic.Add(int.Parse(rdoProblem.SelectedValue), txtProblem.Text);
        quesText.Add(1, innerDic);

        Dictionary<int, string> innerDic1 = new Dictionary<int, string>();
        innerDic1.Add(int.Parse(rdoInform.SelectedValue), txtInform.Text);
        quesText.Add(2, innerDic1);

        Dictionary<int, string> innerDic2 = new Dictionary<int, string>();
        innerDic2.Add(int.Parse(rdoPermission.SelectedValue), rdoPermission.Text);
        quesText.Add(3, innerDic2);

        Dictionary<int, string> innerDic3 = new Dictionary<int, string>();
        innerDic3.Add(int.Parse(rdoSolving.SelectedValue), rdoPermission.Text);
        quesText.Add(4, innerDic3);

        Dictionary<int, string> innerDic4 = new Dictionary<int, string>();
        innerDic4.Add(int.Parse(rdoTiming.SelectedValue), txtTiming.Text);
        quesText.Add(5, innerDic4);

        Dictionary<int, string> innerDic5 = new Dictionary<int, string>();
        innerDic5.Add(int.Parse(rdoBill.SelectedValue), txtBill.Text);
        quesText.Add(6, innerDic5);


        Dictionary<int, string> innerDic6 = new Dictionary<int, string>();
        innerDic6.Add(int.Parse(rdoEnvironment.SelectedValue), txtEnvironment.Text);
        quesText.Add(7, innerDic6);

        Dictionary<int, string> innerDic7 = new Dictionary<int, string>();
        innerDic7.Add(int.Parse(rdoAttitude.SelectedValue), txtAttitude.Text);
        quesText.Add(8, innerDic7);

        var query = "delete from CustomerFeedbackData where type=1 and CustomerFeedbackId=" + feedBackId + "";
        Mycommand = new SqlCommand(query, Myconnection);
        Mycommand.ExecuteNonQuery();

        foreach (var item in quesText)
        {
            var values = item.Value;
            strnewrecord = "";
            foreach (var key in values)
            {
                strnewrecord += "insert into CustomerFeedbackData (CustomerFeedbackId,Type,QuestionNo,Value,Text) values";
                strnewrecord += " (" + feedBackId + ",1," + item.Key + "," + key.Key + ",'"+key.Value+"')";
            }

            Mycommand = new SqlCommand(strnewrecord, Myconnection);
            Mycommand.ExecuteNonQuery();
        }
        Myconnection.Close();

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully Inserted!');", true);
    }
}