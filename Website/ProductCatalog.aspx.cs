﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData.App.BLL;

public partial class ProductCatalog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // do this setup once on first visit
        {
            var controller = new ProductController();
            var data = controller.AllProductsByCategory();
            CategoryRepeater.DataSource = data;
            CategoryRepeater.DataBind();
        }
    }
}