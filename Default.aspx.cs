using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
http://stackoverflow.com/questions/250037/gridview-sorting-sortdirection-always-ascending
*/

namespace PagingSortingGridView
{
    public partial class Default : System.Web.UI.Page
    {
        public string SortColumn
        {
            get {return Convert.ToString(ViewState["SortColumn"]);}
            set {ViewState["SortColumn"] = value;}
        }

        public string SortDirection
        {
            get { return Convert.ToString(ViewState["SortDirection"]); }
            set { ViewState["SortDirection"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SortDirection = "ASC";
                SortColumn = "ProductId";
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var dt = GetTableData();
            if (dt != null)
            {
                //Sort the data.
                 dt.DefaultView.Sort = SortColumn + " " + SortDirection;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private DataTable GetTableData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ProductNumber", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitPrice", typeof(decimal));

            Random rnd = new Random();
            for (var i = 1; i <= 100; i++)
            {
                var qty = rnd.Next(1, 100);
                DataRow dr = dt.NewRow();
                dr["ProductId"] = i;
                dr["Name"] = $"Product{i}";
                dr["ProductNumber"] = $"A-{qty}";
                dr["Quantity"] = qty;
                dr["UnitPrice"] = i;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
            SortColumn = e.SortExpression ;
            BindGrid();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            int columnIndex = 0;
            foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
            {
                if (headerCell.ContainingField.SortExpression == SortColumn)
                {
                    columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                    break;
                }
            }

            Image sortImage = new Image();
            sortImage.ImageUrl = string.Format("images/sort-{0}ending.png", SortDirection);
            GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
        }
    }
}-