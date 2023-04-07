using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace LabRab_3.Дмитриченко
{
    public partial class View : Form
    {
        GraphPane graphPane;
        public View()
        {
            InitializeComponent();

            DataSource.SetSource("D:\\SUAI 2 year\\ТП\\ВВП.xlsx", 1);
            DataTable.DataSource = DataSource.ExtractData();

            
            graphPane = zedGraphControl1.GraphPane;
            graphPane.XAxis.Title.Text = "Year";
            graphPane.YAxis.Title.Text = "GDP";
        }
    }
}
