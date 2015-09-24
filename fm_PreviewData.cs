using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManageBar
{
    public partial class fm_PreviewData : DevComponents.DotNetBar.OfficeForm
    {
        public fm_PreviewData()
        {
            InitializeComponent();
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        List<string> listTbTableNames = new List<string>();//存储数据库所有表名 为后面获取表名用
        private void fm_PreviewData_Load(object sender, EventArgs e)
        {
            string[] dbTableNames = SqlOperation.GetAllTableName();//数据库所有的表名
            
            List<string> tableNamesCN = new List<string>();//表名的中文
           
            foreach (string tableName in dbTableNames)
            {
                listTbTableNames.Add(tableName);
                if (tableName == "tb_dict")
                {
                    tableNamesCN.Add(tableName);
                }
                else
                {
                    string sqlSelect = "select TableName,TableNameNote from tb_dict where TableName ='" + tableName + "'";
                    DataTable dt = SqlOperation.SelectData(sqlSelect);
                    if (dt.Rows.Count == 0)
                    {
                        tableNamesCN.Add(tableName);
                    }
                    else
                    {
                        tableNamesCN.Add(dt.Rows[0]["TableNameNote"].ToString());
                    }

                    
                }
            }
            cbb_TableNames.DataSource = tableNamesCN;
            cbb_TableNames.SelectedIndex = 0;
            //初始化datagridview
            string selectTableName = listTbTableNames[cbb_TableNames.SelectedIndex];
            string sqlSelectData = "select * from " + selectTableName;
            DataTable datatable =  SqlOperation.SelectData(sqlSelectData);
            dataGridView1.DataSource = datatable;


        }

        private void cbb_TableNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectTableName = listTbTableNames[cbb_TableNames.SelectedIndex];
            string sqlSelectData = "select * from " + selectTableName;
            DataTable datatable = SqlOperation.SelectData(sqlSelectData);
            dataGridView1.DataSource = datatable;
        }
    }
}
