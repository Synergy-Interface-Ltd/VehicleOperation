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
                txtSubmitDate.Text = dt.Rows[0][2].ToString();
                txtRemarks.Text = dt.Rows[0][6].ToString();
                txtComplain.Text = dt.Rows[0][8].ToString();
                var feedvalue= dt.Rows[0][7].ToString(); 
                for (int i=0;i< dtfeedbackType.Items.Count;i++)
                {
                    if (dtfeedbackType.Items[i].Text==feedvalue)
                    {
                        dtfeedbackType.SelectedIndex = i;
                        break;
                    }
                }
                var customerValue= dt.Rows[0][9].ToString(); 
                for (int i=0;i< dtCustomerFeedback.Items.Count;i++)
                {
                    if (dtCustomerFeedback.Items[i].Text== customerValue)
                    {
                        dtCustomerFeedback.SelectedIndex = i;
                        break;
                    }
                }

                txtRemarks.Text = dt.Rows[0][7].ToString();

                string operateBy = dt.Rows[0][4].ToString();
                string suggestBy = dt.Rows[0][5].ToString();

                switch (operateBy)
                {
                    case "1":
                        chkOperate1.Checked = true;
                        break;
                    case "2":
                        chkOperate2.Checked = true;
                        break;
                    case "3":
                        chkOperate3.Checked = true;
                        break;
                    default:
                        break;
                }

                switch (suggestBy)
                {
                    case "1":
                        chkSuggest1.Checked = true;
                        break;
                    case "2":
                        chkSuggest2.Checked = true;
                        break;
                    case "3":
                        chkSuggest3.Checked = true;
                        break;
                    default:
                        break;
                }

                feedbackId = dt.Rows[0][0].ToString();
            }
            


            Dictionary<int, Dictionary<RadioButtonList, Label>> quesText = new Dictionary<int, Dictionary<RadioButtonList, Label>>();

            Dictionary<RadioButtonList, Label> innerDic = new Dictionary<RadioButtonList, Label>();
            innerDic.Add(rdoProblem, txtProblem);
            quesText.Add(1, innerDic);

            Dictionary<RadioButtonList, Label> innerDic1 = new Dictionary<RadioButtonList, Label>();
            innerDic1.Add(rdoInform, txtInform);
            quesText.Add(2, innerDic1);

            Dictionary<RadioButtonList, Label> innerDic2 = new Dictionary<RadioButtonList, Label>();
            innerDic2.Add(rdoPermission, txtPermission);
            quesText.Add(3, innerDic2);

            Dictionary<RadioButtonList, Label> innerDic3 = new Dictionary<RadioButtonList, Label>();
            innerDic3.Add(rdoSolving, txtPermission);
            quesText.Add(4, innerDic3);

            Dictionary<RadioButtonList, Label> innerDic4 = new Dictionary<RadioButtonList, Label>();
            innerDic4.Add(rdoTiming, txtTiming);
            quesText.Add(5, innerDic4);

            Dictionary<RadioButtonList, Label> innerDic5 = new Dictionary<RadioButtonList, Label>();
            innerDic5.Add(rdoBill, txtBill);
            quesText.Add(6, innerDic5);


            Dictionary<RadioButtonList, Label> innerDic6 = new Dictionary<RadioButtonList, Label>();
            innerDic6.Add(rdoEnvironment, txtEnvironment);
            quesText.Add(7, innerDic6);

            Dictionary<RadioButtonList, Label> innerDic7 = new Dictionary<RadioButtonList, Label>();
            innerDic7.Add(rdoAttitude, txtAttitude);
            quesText.Add(8, innerDic7);
            DataSet data = new DataSet();
            for(int i = 1;i<=8 ;i++)
            {
                query = "select text,value from CustomerFeedbackData where QuestionNo="+i+" and CustomerFeedbackId='" + feedbackId + "' and Type=1";
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