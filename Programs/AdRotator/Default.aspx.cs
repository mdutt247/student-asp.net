﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AdRotator1_AdCreated(object sender, AdCreatedEventArgs e)
    {
        e.NavigateUrl = "AdRedirect.aspx?Adpath=" + e.NavigateUrl;
    }
}