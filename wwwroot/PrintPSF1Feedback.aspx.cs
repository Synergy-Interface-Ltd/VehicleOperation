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

public partial class PrintPSF1Feedback :  System.Web.UI.Page
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
            if(dt.Rows.Count>0)
            {
                txtCustomerName.Text = dt.Rows[0][1].ToString();
                txtCarName.Text = dt.Rows[0][2].ToString();
                txtCarRegistration.Text = dt.Rows[0][4].ToString();
                txtMobile.Text = dt.Rows[0][6].ToString();
            }
          
            query = "select * from CustomerFeedback where JobId='" + jobId + "'";

            strnewrecord = query;
            DataSet dtq = new DataSet();
            Mycommand1 = new SqlCommand(strnewrecord, Myconnection);
            Mydataadapter1 = new SqlDataAdapter(Mycommand1);
            Mydataadapter1.Fill(dtq, "vehicle_model");
            dt = dtq.Tables[0];
            string feedbackId = "";
            if (dt.Rows.Count > 0)
            {
                txtSubmitDate.Text = dt.Rows[0][12].ToString();
                txtRemarks.Text = dt.Rows[0][11].ToString();


                var customerValue = dt.Rows[0][10].ToString();
                for (int i = 0; i < dtfeedbackType.Items.Count; i++)
                {
                    if (dtfeedbackType.Items[i].Text == customerValue)
                    {
                        dtfeedbackType.SelectedIndex = i;
                        break;
                    }
                }
                feedbackId = dt.Rows[0][0].ToString();
            }
            


            Dictionary<int, Dictionary<RadioButtonList, Label>> quesText = new Dictionary<int, Dictionary<RadioButtonList, Label>>();

            Dictionary<RadioButtonList, Label> innerDic = new Dictionary<RadioButtonList, Label>();
            innerDic.Add(rdoProblem, txtProblem);
            quesText.Add(1, innerDic);

           
            DataSet data = new DataSet();
            for(int i = 1;i<=8 ;i++)
            {
                query = "select text,value from CustomerFeedbackData where QuestionNo="+i+" and CustomerFeedbackId='" + feedbackId + "' and Type=2";
                Mycommand1 = new SqlCommand(query, Myconnection);
                Mydataadapter1 = new SqlDataAdapter(Mycommand1);
                data = new DataSet();
                Mydataadapter1.Fill(data, "vehicle_model");
                dt = data.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dicValue = quesText[i];
                    foreach (var item in dicValue)
                    {
                        int value = Convert.ToInt32(dt.Rows[0][1].ToString() != "" ? dt.Rows[0][1].ToString() : "0");
                        item.Key.SelectedIndex = value-1;
                        item.Value.Text = dt.Rows[0][0].ToString();
                    }                 
                }
            }
        }
    }

}