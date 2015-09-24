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
    public partial class fm_DatabaseManage : DevComponents.DotNetBar.OfficeForm
    {
        public fm_DatabaseManage()
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
            string tableName = "HHWaterDSS.dbo.tb_SHJJBZH";
            //string tableName = "" + rankname;

            switch (rankname)
            {
                case "Province":
                    string sqlSelectProvinceCode0 = "select ProvinceCode from Province where ProvinceName = '" + rankCHname + "'";
                    DataTable dtProvinceCode0 = SqlOperation.SelectData(sqlSelectProvinceCode0);

                    string sqlSelectCode0 = "select TownCode from Town where ProvinceCode = '" + dtProvinceCode0.Rows[0][0].ToString() + "'";
                    DataTable dtCode0 = SqlOperation.SelectData(sqlSelectCode0);
                    
                    //string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    string sqlSelect0 = "select * from " + tableName + " where (";

                    for (int row = 0; row < dtCode0.Rows.Count-1; row++)
                    {
                        string townCode0 = dtCode0.Rows[row][0].ToString();
                        sqlSelect0 += "TOWNCODE = '" + townCode0 + "' or ";
                    }
                    sqlSelect0 += "TOWNCODE = '" + dtCode0.Rows[dtCode0.Rows.Count - 1][0].ToString() + "') and  SJ_S1 between '" + dT_maize_s.Value.Year + "' and '" + dT_maize_e.Value.Year + "'";
                    dt = SqlOperation.SelectData(sqlSelect0);
                    dtInfo = dt;
                    break;
                   
                case "City":
                    string sqlSelectProvinceCode1 = "select CityCode from City where CityName = '" + rankCHname + "'";
                    DataTable dtProvinceCode1 = SqlOperation.SelectData(sqlSelectProvinceCode1);

                    string sqlSelectCode1 = "select TownCode from Town where CityCode = '" + dtProvinceCode1.Rows[0][0].ToString() + "'";
                    DataTable dtCode1 = SqlOperation.SelectData(sqlSelectCode1);
                    
                    //string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    string sqlSelect1 = "select * from " + tableName + " where (";

                    for (int row = 0; row < dtCode1.Rows.Count-1; row++)
                    {
                        string townCode1 = dtCode1.Rows[row][0].ToString();
                        sqlSelect1 += "TOWNCODE = '" + townCode1 + "' or ";
                    }
                    sqlSelect1 += "TOWNCODE = '" + dtCode1.Rows[dtCode1.Rows.Count - 1][0].ToString() + "') and  SJ_S1 between '" + dT_maize_s.Value.Year + "' and '" + dT_maize_e.Value.Year + "'";
                    dt = SqlOperation.SelectData(sqlSelect1);
                    dtInfo = dt;
                    break;
                case "County":
                   string sqlSelectProvinceCode2 = "select CountyCode from County where CountyName = '" + rankCHname + "'";
                    DataTable dtProvinceCode2 = SqlOperation.SelectData(sqlSelectProvinceCode2);

                    string sqlSelectCode2 = "select TownCode from Town where CountyCode = '" + dtProvinceCode2.Rows[0][0].ToString() + "'";
                    DataTable dtCode2 = SqlOperation.SelectData(sqlSelectCode2);
                    
                    //string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and TOWNCODE = '" + townCode + "'";
                    string sqlSelect2 = "select * from " + tableName + " where (";

                    for (int row = 0; row < dtCode2.Rows.Count-1; row++)
                    {
                        string townCode2 = dtCode2.Rows[row][0].ToString();
                        sqlSelect2 += "TOWNCODE = '" + townCode2 + "' or ";
                    }
                    sqlSelect2 += "TOWNCODE = '" + dtCode2.Rows[dtCode2.Rows.Count - 1][0].ToString() + "') and  SJ_S1 between '" + dT_maize_s.Value.Year + "' and '" + dT_maize_e.Value.Year + "'";
                    dt = SqlOperation.SelectData(sqlSelect2);
                    dtInfo = dt;
                    break;
                    
                case "Town":
                    //dt = DataManager.getPlotSelectResult(tablename, cmbCropType.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value, rankCHname);
                    string sqlSelectCode = "select TownCode from Town where TownName = '" + rankCHname + "'";
                    DataTable dtCode = SqlOperation.SelectData(sqlSelectCode);
                    string townCode = dtCode.Rows[0][0].ToString();
                    string sqlSelect = "select * from " + tableName + " where SJ_S1 between '" + dT_maize_s.Value.Year + "' and '" + dT_maize_e.Value.Year + "' and TOWNCODE = '" + townCode + "'";
                    dt = SqlOperation.SelectData(sqlSelect);
                    dtInfo = dt;
                    break;
            }
            //string sqlSelectDic = "select * from tb_dict";
            //DataTable dtDic = SqlOperation.SelectData(sqlSelectDic);
            //for (int rowIndex = 0; rowIndex < dt.Columns.Count - 1; rowIndex++)
            //{
            //    string column = dt.Columns[rowIndex].ColumnName;

            //    string sqlSelectCN = "select * from tb_dict where TableName = tb_SHJJBZH and FieldName = '" + column + "'";
            //    DataTable dtDic = SqlOperation.SelectData(sqlSelectCN);
            //    dt.Columns[rowIndex].ColumnName = dtDic.Rows[0]["FieldNameNote"].ToString();
            
            //}

                if (dt.Rows.Count != 0)
                {
                    for (int columnIndex = 1; columnIndex < dt.Columns.Count ; columnIndex++)
                    {
                        string column = dt.Columns[columnIndex].ColumnName;

                        string sqlSelectCN = "select * from tb_dict where TableName = 'tb_SHJJBZH' and FieldName = '" + column + "'";
                        DataTable dtDic = SqlOperation.SelectData(sqlSelectCN);
                        dt.Columns[columnIndex].ColumnName = dtDic.Rows[0]["FieldNameNote"].ToString();

                    }

                    //dtInfo = DataManager.Convert_ColumeName(DataManager.convert_TableValue(rankname, typename, dt));
                    //InitDataSet();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[6].ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("没有符合条件的记录");
                    dataGridView1.DataSource = null;
                }

        }

        private void DataBaseManager_Load(object sender, EventArgs e)
        {
            TreeNodeOperate.generateTree(treeView1);
            //cmbCropType.DataSource = DataManager.get_CropType();
            //cmb_Type.SelectedIndex = 0;
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


        //public Dictionary<string, string> return_Dicts(List<string> list_value)
        //{
        //    Dictionary<string, string> dicts = new Dictionary<string, string>();
        //    string column1 = "";
        //    switch (rankname)
        //    {
        //        case "PLOT":
        //            column1 = DataBaseOperate.get_PlotCodeName(list_value[0]);
        //            break;
        //        case "COUNTY":
        //            column1 = DataBaseOperate.getCountyCode(list_value[0]);
        //            break;
        //        case "VILLAGE":
        //            column1 = DataBaseOperate.getVillCode(list_value[0]);
        //            break;
        //        case "TOWN":
        //            column1 = DataBaseOperate.getTownCode(list_value[0]);
        //            break;
        //    }
        //    dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[0].Name), column1);

        //    dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[1].Name), list_value[1]);
        //    dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[2].Name), DataBaseOperate.get_CropCode(list_value[2]));
        //    if (tablename.Contains("SOILNUTRIENT"))
        //    {
        //        dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[3].Name), DataBaseOperate.get_NutrientCode(list_value[3]));
        //        dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[4].Name), list_value[4]);
        //    }
        //    else
        //    {
        //        dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[3].Name), list_value[3]);
        //    }
        //    return dicts;
        //}



        //修改
        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count != 0)//是否选择某个单元格
            {
                //List<string> list = new List<string>();
                string sqlSelectDic = "select * from tb_SHJJBZH";
                DataTable dtDic = SqlOperation.SelectData(sqlSelectDic);
                for (int colunmIndex = 7; colunmIndex < dataGridView1.ColumnCount; colunmIndex++)
                {
                  int currentRow = dataGridView1.CurrentRow.Index;
                  string data = dataGridView1.Rows[currentRow].Cells[colunmIndex].Value.ToString();
                  string id = dataGridView1.Rows[currentRow].Cells["ID_AUTO"].Value.ToString();
                  string sqlUpdate = "update tb_SHJJBZH set " + dtDic.Columns[colunmIndex].ColumnName + "= '" + data + "' where ID_AUTO =" + id + "";
                  SqlOperation.SqlCom(sqlUpdate);
                }
                

                //string sqlUpdate = "update tb_SHJJBZH set ";


                MessageBox.Show("修改成功！");
                //绑定数据源
                BindDataSource();
            }
            else
            {
                MessageBox.Show("请选择修改项！");
            }
        }
        //删除
        private void button3_Click(object sender, EventArgs e)
        {

            int selectedRows = dataGridView1.SelectedRows.Count;
            if (selectedRows != 0)
            {
                int currentRow = dataGridView1.CurrentRow.Index;
                
                for (int i = 0; i < selectedRows; i++)
                {
                    string id = dataGridView1.Rows[currentRow - i].Cells["ID_AUTO"].Value.ToString();
                    string sqlDelete = "delete from tb_SHJJBZH where ID_AUTO = " + id;
                    SqlOperation.SqlCom(sqlDelete);
                    
                }

                MessageBox.Show("删除成功！");
                BindDataSource();
            }
            else
            {
                MessageBox.Show("请选择删除项！");
            }
        }


        //根据选择的表名来更新养分列表
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //string value = DataManager.get_TableName(cmb_Rank.SelectedItem.ToString());
        //    if (cmb_Type.SelectedItem.ToString().Contains("土壤"))
        //    {
        //        label2.Visible = true;
        //        cmb_Nutrient.Visible = true;
        //        cmb_Nutrient.DataSource = DataManager.get_NutrientType();
        //    }
        //    else
        //    {
        //        label2.Visible = false;
        //        cmb_Nutrient.Visible = false;
        //        cmb_Nutrient.DataSource = null;
        //    }
        //}

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



            //if (name.EndsWith("管理局"))
            //{
            //    rankname = "TOWN";
            //}
            //else if (name.EndsWith("农场"))
            //{
            //    rankname = "TOWN";
            //}
            //else if (name.EndsWith("作业区"))
            //{
            //    rankname = "VILLAGE";
            //}
            //else if (name.EndsWith("作业站"))
            //{
            //    rankname = "PLOT";
            //}
        }

    }
}
