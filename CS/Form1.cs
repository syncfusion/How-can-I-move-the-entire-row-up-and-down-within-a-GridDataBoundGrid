using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDBGMoveRows
{
    public partial class Form1 : Form
    {
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn gridBoundColumn1;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn gridBoundColumn2;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn gridBoundColumn3;
        public Form1()
        {
            InitializeComponent();
            
            this.gridBoundColumn1 = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.gridBoundColumn1.HeaderText  = "Column1";
            this.gridBoundColumn1.MappingName = "Column1";
            this.gridBoundColumn2 = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.gridBoundColumn2.HeaderText  = "Column2";
            this.gridBoundColumn2.MappingName = "Column2";
            this.gridBoundColumn3 = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.gridBoundColumn3.HeaderText  = "Column3";
            this.gridBoundColumn3.MappingName = "Column3";

            this.gridDataBoundGrid1.GridBoundColumns.AddRange(new Syncfusion.Windows.Forms.Grid.GridBoundColumn[] { this.gridBoundColumn1, this.gridBoundColumn2, this.gridBoundColumn3 });//, this.gridBoundColumn3, this.gridBoundColumn4, this.gridBoundColumn5, this.gridBoundColumn6 });
            this.gridDataBoundGrid1.Model.EnableLegacyStyle = false;
            this.gridDataBoundGrid1.GridVisualStyles = GridVisualStyles.Office2010Black;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int nCols = 3;
            int nRows = 10;

            dt.Columns.Add("sortKey", typeof(int)); // Add sortKey for sorting
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");

            for (int i = 0; i < nRows; ++i)
            {
                DataRow dr = dt.NewRow();
                dr["sortKey"] = i; // Set initial sortKey
                dr["Column1"] = "Item " + i;
                dr["Column2"] = "Value A" + i;
                dr["Column3"] = "Value B" + i;
                dt.Rows.Add(dr);
            }

            // Sort by sortKey
            dt.DefaultView.Sort = "sortKey ASC";
            this.gridDataBoundGrid1.DataSource = dt;

            // Hide sortKey from UI
            var sortCol = new GridBoundColumn();
            sortCol.MappingName = "sortKey";
            sortCol.HeaderText = "sortKey";
            sortCol.StyleInfo.CellType = "Static";

            this.gridDataBoundGrid1.GridBoundColumns.Clear();
            this.gridDataBoundGrid1.GridBoundColumns.AddRange(new GridBoundColumn[]
            {
               this.gridBoundColumn1,
               this.gridBoundColumn2,
               this.gridBoundColumn3
            });

            this.gridDataBoundGrid1.ThemesEnabled = true;
            this.gridDataBoundGrid1.DefaultColWidth = 135;
        }       

        void Swap(int row1, int row2)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.gridDataBoundGrid1.DataSource,

            this.gridDataBoundGrid1.DataMember];

            if (row1 < cm.Count && row2 < cm.Count && row1 > -1 && row2 > -1)
            {

                DataRowView drv1 = (DataRowView)cm.List[row1];

                int val1 = (int)drv1.Row["sortKey"];

                DataRowView drv2 = (DataRowView)cm.List[row2];

                int val2 = (int)drv2.Row["sortKey"];

                drv1.Row["sortKey"] = val2;

                drv2.Row["sortKey"] = val1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRow = this.gridDataBoundGrid1.CurrentCell.RowIndex;

            // Ensure the selected row is valid and not the last row
            if (selectedRow > 0 && selectedRow < gridDataBoundGrid1.Model.RowCount - 1)
            {
                Swap(selectedRow - 1, selectedRow);
            }
        }
    }
}