using BestLogistic.Controllers;
using BestLogistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestLogistic
{
    public partial class OrderSummary : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (PreviousPage != null && PreviousPage is Checkout)
            {
                
               // LoadData();

            }
        }

        private void LoadData()
        {
            try
            {
                

            }
            catch (NullReferenceException)
            {
                Response.Write("Payment Not Successfully!");
            }
        }

        protected void btnNextSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendPackage.aspx");
        }
    }
}