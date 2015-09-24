using DevComponents.DotNetBar;
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
    public partial class fm_Chart : DevComponents.DotNetBar.OfficeForm
    {
        public fm_Chart()
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
        public void BindDataSource()
        {
            DataTable dt = new DataTable();
            string tableName = "tb_SHJJBZH";
            //string tableName = "" + rankname;
            //获取选中属性的英文名
            string selectedColunmCN = cbb_Clounm.SelectedItem.ToString();
            string sqlSelectE = "select * from tb_dict where TableName = 'tb_SHJJBZH' and FieldNameNote = '" + selectedColunmCN + "'";
            DataTable dtDicColunm = SqlOperation.SelectData(sqlSelectE);
            string selectedColunmE = dtDicColunm.Rows[0]["FieldName"].ToString();


            switch (rankname)
            {
                case "Province":
                    string sqlSelectProvinceCode0 = "select ProvinceCode from Province where ProvinceName = '" + rankCHname + "'";
                    DataTable dtProvinceCode0 = SqlOperation.SelectData(sqlSelectProvinceCode0);

                    string sqlSelectCode0 = "select TownCode from Town where ProvinceCode = '" + dtProvinceCode0.Rows[0][0].ToString() + "'";
                    DataTable dtCode0 = SqlOperation.SelectData(sqlSelectCode0);

                    //string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    string sqlSelect0 = "select ID_AUTO,SJ,DJ,XJ,XZ,TOWNCODE,SJ_S1," + selectedColunmE + " from " + tableName + " where (";

                    for (int row = 0; row < dtCode0.Rows.Count - 1; row++)
                    {
                        string townCode0 = dtCode0.Rows[row][0].ToString();
                        sqlSelect0 += "TOWNCODE = '" + townCode0 + "' or ";
                    }
                    sqlSelect0 += "TOWNCODE = '" + dtCode0.Rows[dtCode0.Rows.Count - 1][0].ToString() + "') and  SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "'";
                    dt = SqlOperation.SelectData(sqlSelect0);
                    dtInfo = dt;
                    break;
                    //dt = 
                    
                case "City":
                    string sqlSelectProvinceCode1 = "select CityCode from City where CityName = '" + rankCHname + "'";
                    DataTable dtProvinceCode1 = SqlOperation.SelectData(sqlSelectProvinceCode1);

                    string sqlSelectCode1 = "select TownCode from Town where CityCode = '" + dtProvinceCode1.Rows[0][0].ToString() + "'";
                    DataTable dtCode1 = SqlOperation.SelectData(sqlSelectCode1);

                    //string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    string sqlSelect1 = "select ID_AUTO,SJ,DJ,XJ,XZ,TOWNCODE,SJ_S1," + selectedColunmE + " from " + tableName + " where (";

                    for (int row = 0; row < dtCode1.Rows.Count - 1; row++)
                    {
                        string townCode1 = dtCode1.Rows[row][0].ToString();
                        sqlSelect1 += "TOWNCODE = '" + townCode1 + "' or ";
                    }
                    sqlSelect1 += "TOWNCODE = '" + dtCode1.Rows[dtCode1.Rows.Count - 1][0].ToString() + "') and  SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "'";
                    dt = SqlOperation.SelectData(sqlSelect1);
                    dtInfo = dt;
                    break;
                case "County":
                    string sqlSelectProvinceCode2 = "select CountyCode from County where CountyName = '" + rankCHname + "'";
                    DataTable dtProvinceCode2 = SqlOperation.SelectData(sqlSelectProvinceCode2);

                    string sqlSelectCode2 = "select TownCode from Town where CountyCode = '" + dtProvinceCode2.Rows[0][0].ToString() + "'";
                    DataTable dtCode2 = SqlOperation.SelectData(sqlSelectCode2);

                    //string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    string sqlSelect2 = "select ID_AUTO,SJ,DJ,XJ,XZ,TOWNCODE,SJ_S1," + selectedColunmE + " from " + tableName + " where (";

                    for (int row = 0; row < dtCode2.Rows.Count - 1; row++)
                    {
                        string townCode2 = dtCode2.Rows[row][0].ToString();
                        sqlSelect2 += "TOWNCODE = '" + townCode2 + "' or ";
                    }
                    sqlSelect2 += "TOWNCODE = '" + dtCode2.Rows[dtCode2.Rows.Count - 1][0].ToString() + "') and  SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "'";
                    dt = SqlOperation.SelectData(sqlSelect2);
                    dtInfo = dt;
                    break;

                case "Town":
                    //dt = DataManager.getPlotSelectResult(tablename, cmbCropType.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value, rankCHname);
                    string sqlSelectCode = "select TownCode from Town where TownName = '" + rankCHname + "'";
                    DataTable dtCode = SqlOperation.SelectData(sqlSelectCode);
                    string townCode = dtCode.Rows[0][0].ToString();
                    string sqlSelect = "select ID_AUTO,SJ,DJ,XJ,XZ,TOWNCODE,SJ_S1," + selectedColunmE + " from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    dt = SqlOperation.SelectData(sqlSelect);
                    dtInfo = dt;
                    break;
            }  

            if (dt.Rows.Count != 0)
            {
                for (int columnIndex = 1; columnIndex < dt.Columns.Count; columnIndex++)
                {
                    string column = dt.Columns[columnIndex].ColumnName;

                    string sqlSelectCN = "select * from tb_dict where TableName = 'tb_SHJJBZH' and FieldName = '" + column + "'";
                    DataTable dtDic = SqlOperation.SelectData(sqlSelectCN);
                    dt.Columns[columnIndex].ColumnName = dtDic.Rows[0]["FieldNameNote"].ToString();

                }

                //dtInfo = DataManager.Convert_ColumeName(DataManager.convert_TableValue(rankname, typename, dt));
                //InitDataSet();
                dataGridView1.DataSource = dt;

                //建图表
                List<double> listNUm = new List<double>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][selectedColunmCN].ToString() == "NULL")
                    {
                        dt.Rows[i][selectedColunmCN] = "0";
                    }
                    double num = Convert.ToDouble(dt.Rows[i][selectedColunmCN].ToString());
                    listNUm.Add(num);
                }
               
                
                microChart1.Visible = true;
                string chartType = cbb_ChartType.SelectedItem.ToString();
                if (chartType == "折线图")
                {
                    microChart1.ChartType = eMicroChartType.Line;
                    lable_ChartName.Visible = true;
                    lable_ChartName.Text = rankCHname + selectedColunmCN + "变化折线图";
                }
                else
                    if (chartType == "散点图")
                    {
                        microChart1.ChartType = eMicroChartType.Plot;
                        lable_ChartName.Visible = true;
                        lable_ChartName.Text = rankCHname + selectedColunmCN + "变化散点图";
                    }
                    else
                    {
                        microChart1.ChartType = eMicroChartType.Pie;
                        lable_ChartName.Visible = true;
                        lable_ChartName.Text = rankCHname + selectedColunmCN + "统计饼状图";
                    }
                microChart1.DataPoints = listNUm;
                
                microChart1.LineChartStyle.DrawZeroLine = false;//表的0线除掉
                microChart1.Update();
                //microChart1.LineChartStyle.FirstPointColor = Color.Green;
                //microChart1.LineChartStyle.LastPointColor = Color.DarkRed;
                
                //microChart1.LineChartStyle.HighPointColor = Color.Blue;
                //microChart1.LineChartStyle.LowPointColor = Color.Red;
            }
            else
            {
                MessageBox.Show("没有符合条件的记录");
                dataGridView1.DataSource = null;
            }

        }
        public bool StrIsInt(string Str)
        {
            bool flag = true;
            if (Str != "")
            {
                for (int i = 0; i < Str.Length; i++)
                {
                    if (!Char.IsNumber(Str, i))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public void GetAttribute()
        {
            string sqlSelectColunm = "select * from tb_SHJJBZH";
            DataTable dtColunm = SqlOperation.SelectData(sqlSelectColunm);

            for (int colunmIndex = 7; colunmIndex < dtColunm.Columns.Count;colunmIndex++)
            {
                bool isNum = true;
                for (int rowIndex = 0; rowIndex < dtColunm.Rows.Count; rowIndex++)
                {
                    string temp = dtColunm.Rows[rowIndex][colunmIndex].ToString();
                    if (temp == "NULL")
                    {
                        temp = "0";
                    }
                    bool isInt = StrIsInt(temp);
                    if (!isInt)
                    {
                        isNum = false;
                        break;
                    }
                }
                if (isNum)
                {
                    string colunm = dtColunm.Columns[colunmIndex].ColumnName;
                    string sqlSelectCN = "select * from tb_dict where TableName = 'tb_SHJJBZH' and FieldName = '" + colunm + "'";
                    DataTable dtDic = SqlOperation.SelectData(sqlSelectCN);
                    cbb_Clounm.Items.Add(dtDic.Rows[0]["FieldNameNote"].ToString());
                    cbb_Clounm.SelectedIndex = 0;
                }

            }
            
        }

        private void DataBaseManager_Load(object sender, EventArgs e)
        {
            TreeNodeOperate.generateTree(treeView1);
            GetAttribute();
            string[] items = {"折线图","散点图","饼状图" };
            cbb_ChartType.DataSource = items;
            cbb_ChartType.SelectedIndex = 0;
           

        }
        string tablename = "";
        string rankname = "";
        string typename = "";
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            if (rankname != "")
            {
                BindDataSource();
                InitDataSet();

            }
            else
            {
                MessageBox.Show("请选择管理级别！");
            }
        }

        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录
        System.Data.DataTable dtInfo;
        string[] res;//存储解析的文件名
        private void InitDataSet()
        {
            pageSize = 20;      //设置页面行数
            nMax = dtInfo.Rows.Count;
            pageCount = (nMax / pageSize);    //计算出总页数
            if ((nMax % pageSize) > 0) pageCount++;
            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始
            LoadData();
        }


        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行
            if (dtInfo.Rows.Count != 0)
            {
                System.Data.DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

                if (pageCurrent == pageCount)
                {
                    nEndPos = nMax;
                }
                else
                {
                    nEndPos = pageSize * pageCurrent;
                }

                nStartPos = nCurrent;
                lblPageCount.Text = "/" + pageCount.ToString();
                txtCurrentPage.Text = Convert.ToString(pageCurrent);


                //从元数据源复制记录行
                for (int i = nStartPos; i < nEndPos; i++)
                {

                    dtTemp.ImportRow(dtInfo.Rows[i]);
                    nCurrent++;
                }
                bindingSource1.DataSource = dtTemp;
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.Visible = true;
            }
        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "关闭")
            {
                this.Close();
            }
            if (e.ClickedItem.Text == "上一页")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
            if (e.ClickedItem.Text == "下一页")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportDataToExcel.ExportExcel(dtInfo);
        }

        string rankCHname = "";
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = e.Node.Text;
            rankCHname = e.Node.Text;
            int level = e.Node.Level;

            switch (level)
            {
                case 0:
                    rankname = "Province";
                    break;
                case 1:
                    rankname = "City";
                    break;
                case 2:
                    rankname = "County";
                    break;
                case 3:
                    rankname = "Town";
                    break;
            }

        }

        private void cbb_ChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (microChart1.Visible)
            {
                BindDataSource();
                InitDataSet();
            }
        }
    }
}
