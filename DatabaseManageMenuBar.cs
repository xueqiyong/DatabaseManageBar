﻿using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseManageBar
{
    public class DatabaseManageMenuBar : MyPluginEngine.IMenuDef
    {
        #region IMenuDef 成员

        public string Caption
        {
            get { return "数据库管理"; }
        }

        public void GetItemInfo(int pos, ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "DatabaseManageBar.DataBaseConnectCmd";
                    itemDef.Group = true;
                    break;
                case 1:
                    itemDef.ID = "DatabaseManageBar.fm_CreateDatabaseTableCmd";
                    itemDef.Group = true;
                    break;
                case 2:
                    itemDef.ID = "DatabaseManageBar.fm_CreateDatabaseTableDisposeCmd";
                    itemDef.Group = false;
                    break;
                case 3:
                    itemDef.ID = "DatabaseManageBar.fm_InsertDataAndTemplateCmd";
                    itemDef.Group = false;
                    break;
                case 4:
                    itemDef.ID = "DatabaseManageBar.fm_CreateTableToWordCmd";
                    itemDef.Group = false;
                    break;
                case 5:
                    itemDef.ID = "DatabaseManageBar.fm_InsertDicCmd";
                    itemDef.Group = false;
                    break;
                case 6:
                    itemDef.ID = "DatabaseManageBar.fm_PreviewDataCmd";
                    itemDef.Group = true;
                    break;
                case 7:
                    itemDef.ID = "DatabaseManageBar.fm_DatabaseManageCmd";
                    itemDef.Group = false;
                    break;
                case 8:
                    itemDef.ID = "DatabaseManageBar.fm_ChartCmd";
                    itemDef.Group = true;
                    break;
                
                default:
                    break;

            }
        }

        public long ItemCount
        {
            get { return 9; }
        }

        public string Name
        {
            get { return "数据库管理"; }
        }

        #endregion
    }
}
