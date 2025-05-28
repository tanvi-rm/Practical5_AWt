using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EmployeeWebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployees();
            }
        }
        private void BindEmployees()
        {
            var service = new localhost.EmployeeService();
            gvEmployees.DataSource = service.GetAllEmployees().ToList();
            gvEmployees.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var service = new localhost.EmployeeService();
            gvEmployees.DataSource = service.SearchEmployees(txtSearch.Text).ToList();
            gvEmployees.DataBind();
        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindEmployees();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var service = new localhost.EmployeeService();
            int newId = service.AddEmployee(txtNewName.Text, txtNewDept.Text);
            if (newId > 0)
            {
                ShowMessage($"Employee added successfully with ID: {newId}", "success");
                txtNewName.Text = "";
                txtNewDept.Text = "";
                BindEmployees();
            }
            else
            {
                ShowMessage("Failed to add employee", "danger");
            }
        }
        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            BindEmployees();
        }
        protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs
e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            string name =
           ((TextBox)gvEmployees.Rows[e.RowIndex].FindControl("txtName")).Text;
            string dept =
           ((TextBox)gvEmployees.Rows[e.RowIndex].FindControl("txtDept")).Text;
            var service = new localhost.EmployeeService();
            bool success = service.UpdateEmployee(id, name, dept);
            if (success)
            {
                ShowMessage("Employee updated successfully", "success");
                gvEmployees.EditIndex = -1;
                BindEmployees();
            }
            else
            {
                ShowMessage("Failed to update employee", "danger");
            }
        }
        protected void gvEmployees_RowCancelingEdit(object sender,
       GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            BindEmployees();
        }
        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            var service = new localhost.EmployeeService();
            bool success = service.DeleteEmployee(id);
            if (success)
            {
                ShowMessage("Employee deleted successfully", "success");
                BindEmployees();
            }
            else
            {
                ShowMessage("Failed to delete employee", "danger");
            }
        }
        private void ShowMessage(string message, string type)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = $"alert alert-{type}";
            lblMessage.Visible = true;
        }
    }
}
