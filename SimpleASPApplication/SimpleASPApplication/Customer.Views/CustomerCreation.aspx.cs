using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SimpleASPApplication.Customer.Entities;
using SimpleASPApplication.Helpers;
using SimpleASPApplication.Manager;

namespace SimpleASPApplication.Customer.Views
{
    public partial class CustomerCreation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetFocus(txtFirstName);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            BindDropDownLists();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerInfoMessage cust = new CustomerInfoMessage();
                cust.FirstName = txtFirstName.Text;
                cust.LastName = txtLastName.Text;
                cust.MiddleName = txtMiddleName.Text;
                cust.Address = txtAddress.Text;

                string Bdate = ddlMonth.SelectedItem.ToString() + "/" + ddlDay.SelectedItem.ToString() + "/" + ddlYear.SelectedItem.ToString();
                cust.BirthDay = Convert.ToDateTime(Bdate);

                if (DataAccessHelper.Instance.InsertCustomerInfo(cust))
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Customer successfully created";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Failed to create customer";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Instance.ExceptionLogger(ex.StackTrace, DateTime.Now, AppEnums.LoggerStatus.Failed);
                throw ex;
            }
        }

        private void BindDropDownLists()
        {
            //Month
            List<string> MonthList = new List<string>();
            //MonthList.Add("-Select Month-");
            for (int month = 1; month < 13; month++)
            {
                MonthList.Add(month.ToString());
            }
            ddlMonth.DataSource = MonthList;
            ddlMonth.DataBind();

            //Day
            List<string> DayList = new List<string>();
            //DayList.Add("-Select Day-");
            for (int day = 1; day < 32; day++)
            {
                DayList.Add(day.ToString());
            }
            ddlDay.DataSource = DayList;
            ddlDay.DataBind();

            //Year
            List<string> YearList = new List<string>();
            //YearList.Add("-Select Year-");
            for (int year = 0; year < 61; year++)
            {
                YearList.Add((DateTime.Now.Year - year).ToString());
            }
            YearList.Sort();
            ddlYear.DataSource = YearList;
            ddlYear.DataTextFormatString = "{0:yyyy}";
            ddlYear.DataBind();

            ddlDay.SelectedIndex = -1;
            ddlMonth.SelectedIndex = -1;
            ddlYear.SelectedIndex = -1;
        }
    }
}