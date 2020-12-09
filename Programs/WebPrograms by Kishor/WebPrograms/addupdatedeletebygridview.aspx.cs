﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebPrograms
{
    public partial class addupdatedeletebygridview : System.Web.UI.Page
    {
        public string conString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Kishor Trimal\\Documents\\empdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            con.ConnectionString = conString;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from emp_table";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string empid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblid")).Text;
            string Name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtname")).Text;
            string address = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaddress")).Text;
            string salary = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsalary")).Text;
            con.ConnectionString = conString;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update emp_table set name='"+ Name +"',address='"+ address +"',salary='"+ salary +"' where id='"+ Convert.ToInt32(empid) +"'";
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            bind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string emp_id = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblitemid")).Text;
            con.ConnectionString = conString;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from emp_table where id='" + Convert.ToInt32(emp_id) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }
    }
}