using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        WebService1 obj = new WebService1();
        int a, b, c;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(txtFno.Text);
            b = Convert.ToInt32(txtSno.Text);
            c = obj.Add(a, b);
            lblResult.Text = c.ToString();

        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(txtFno.Text);
            b = Convert.ToInt32(txtSno.Text);
            c = obj.Sub(a, b);
            lblResult.Text = c.ToString();

        }
    }
}