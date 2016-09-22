using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace simpleASPNetCSRF
{
    public partial class shop : System.Web.UI.Page
    {
        private readonly bool isCsrfProtectionOn = true;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (isCsrfProtectionOn && Session.IsNewSession)
            {

                Session.Add("CSRFToken", Guid.NewGuid().ToString());
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bool validRequest = true;
            if (isCsrfProtectionOn)
            {
                validRequest = verificarToken(Request.QueryString["CSRFToken"]);
            }

           if (validRequest )
            {
                //get token from request
                if (Request.QueryString["newProduct"] != null)
                {
                    //verificar token

                    System.Collections.Generic.List<string> mycart = (System.Collections.Generic.List<string>)Session["myCart"];
                    mycart.Add(Request.QueryString["newProduct"]);//this is a product id
                }

            }
            showShopList();
            ShowProducts();
        }

        private void showShopList()
        {
            shopList.Controls.Add(buildShopList(this.isCsrfProtectionOn));
        }

        private Control buildShopList(bool protect)
        {
            string CSRFToken = protect ? "&csrftoken=" + Session["CSRFToken"].ToString() : "";

            string shopList =
            "<a href = \"http://localhost:52847/shop.aspx?newProduct=10" + CSRFToken + "\"> Adicione um Super telemóvel</a><br/>"
            +
             "<a href = \"http://localhost:52847/shop.aspx?newProduct=15" + CSRFToken + "\"> Adicione um Super PC</a><br/>"
             +
              "<a href = \"http://localhost:52847/shop.aspx?newProduct=18" + CSRFToken + "\"> Adicione uma Super TV</a><br/>";



            LiteralControl lt = new LiteralControl(shopList);

            return lt;
        }

        private bool verificarToken(string csrfToken)
        {
            return Session["CSRFToken"].ToString() == csrfToken;
        }

        private void ShowProducts()
        {
            System.Collections.Generic.List<string> carinho = (System.Collections.Generic.List<string>)Session["myCart"];
            if (carinho.Count > 0)
            {
                Label1.Text = "A sua lista de compras:";
                foreach (string item in carinho)
                {
                    Label1.Text += "<div>" + item + "</div>";
                }
            }
            else
                Label1.Text = "Shopping cart vazio....";

        }


    }
}