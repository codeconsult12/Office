using iNTrack.AXiNTrackService;
using iNTrack.iNTrackService;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web.Services.Protocols;

namespace iNTrack
{
    public static class iNTrackLib
    {
        public static bool CheckItemValidity()
        {
            bool flag;
            bool flag1;
            try
            {
                if ((Property.TransactionType != Property.TransactionTypeEnum.PI || !(Property.Setup.Rows[0]["Download Purchase Invoice Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Download Purchase Invoice Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.PRS || !(Property.Setup.Rows[0]["Download Purchase Return Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Download Purchase Return Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.SI || !(Property.Setup.Rows[0]["Download Sales Invoice Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Download Sales Invoice Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.SRR || !(Property.Setup.Rows[0]["Download Sales Return Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Download Sales Return Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.TRS || !(Property.Setup.Rows[0]["Download Transfer Shipment Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Download Transfer Shipment Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")))
                {
                    flag1 = (Property.TransactionType != Property.TransactionTypeEnum.TRI || !(Property.Setup.Rows[0]["Download Transfer Receipt Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Download Transfer Receipt Line"].ToString() == "1") ? false : Property.TransactionStatus == "AU");
                }
                else
                {
                    flag1 = true;
                }
                flag = flag1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public static void CreateAXClient(string CompanyID, string URL, string Domain, string UserName, string Password)
        {
            try
            {
                Property.AXClient = new BasicHttpBinding_AXiNTrack();
                CallContext callContext = new CallContext()
                {
                    Company = CompanyID,
                    LogonAsUser = string.Concat(Domain, "\\", UserName)
                };
                Property.AXClient.Url = URL;
                Property.AXClient.Credentials = new NetworkCredential(UserName, Password, Domain);
                Property.AXClient.CallContextValue = callContext;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void CreateDB()
        {
            try
            {
                SqlCeLib.ConnectionString = string.Format("Data Source={0};Password=a1pntbs1365*;Max Database Size=1000;", string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Data.sdf"));
                SqlCeLib.CreateDatabase();
                SqlCeLib.Execute("Create Table [Parameter]([Code] nvarchar(10), [Description] nvarchar(250), [Value] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Parameter] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Location]([Code] nvarchar(10), [Name] nvarchar(250), [Location is a Warehouse] nvarchar(5))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Location] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Vendor]([Code] nvarchar(20), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On Vendor ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Customer]([Code] nvarchar(20), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On Customer ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Reason]([Code] nvarchar(10), [Description] nvarchar(250), [Type] nvarchar(10))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Reason] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Transporter]([Code] nvarchar(10), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Transporter] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Setup]([AIF User Domain] nvarchar(250), [AIF User Name] nvarchar(250), [AIF User Password] nvarchar(250), [Version No.] nvarchar(10), [Location wise HHT Barcodes] nvarchar(5), [Download Purchase Invoice Line] nvarchar(5), [Download Purchase Return Line] nvarchar(5), [Download Sales Invoice Line] nvarchar(5), [Download Sales Return Line] nvarchar(5), [Download Transfer Shipment Line] nvarchar(5), [Download Transfer Receipt Line] nvarchar(5), [Show Purchase Invoice Line] nvarchar(5), [Show Purchase Return Line] nvarchar(5), [Show Sales Invoice Line] nvarchar(5), [Show Sales Return Line] nvarchar(5), [Show Transfer Shipment Line] nvarchar(5), [Show Transfer Receipt Line] nvarchar(5), [Check Item Validity - Stock] nvarchar(5), [Prompt on Invalid Barcode-SC] nvarchar(5), [Check Item Validity - Data] nvarchar(5), [Prompt on Invalid Barcode-Data] nvarchar(5), [Capture Reference No.] nvarchar(5), [Enable Auto Quantity - Data] nvarchar(5), [Enable Auto Quantity - SC] nvarchar(5), [iNTrack Web Service URL] nvarchar(250), [Download Path] nvarchar(250), [Update Path] nvarchar(250), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT Setup] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Role]([Code] nvarchar(20), [Name] nvarchar(250), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [HHT User Role] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Role] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Role Permission]([HHT User Role Code] nvarchar(20), [Transaction Type] nvarchar(20), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [HHT User Role Permission] ([HHT User Role Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Role Permission] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Setup]([HHT User ID] nvarchar(20), [Password] nvarchar(10), [HHT User Name] nvarchar(250), [Backdated Document Allowed] nvarchar(5), [Show Inventory] nvarchar(5), [Show Cost Price] nvarchar(5), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixHHTUserID On [HHT User Setup] ([HHT User ID])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Setup] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Permission]([HHT User ID] nvarchar(20), [Location Code] nvarchar(10), [HHT User Role Code] nvarchar(20), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixHHTUserID On [HHT User Permission] ([HHT User ID])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Permission] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [HHT User Permission] ([HHT User ID], [Location Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Document Setup]([Location Code] nvarchar(10), [Transaction Type] nvarchar(20), [Backdated Document Allowed] nvarchar(5), [Negative Stock Allowed] nvarchar(5), [Show Inventory] nvarchar(5), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [HHT Document Setup] ([Location Code], [Transaction Type])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Barcodes]([Itemcode] nvarchar(20), [Barcode] nvarchar(80), [Description] nvarchar(250), [Vendor] nvarchar(1000), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixItemcode On [HHT Barcodes] ([Itemcode])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixBarcode On [HHT Barcodes] ([Barcode])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixDescription On [HHT Barcodes] ([Description])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT Barcodes] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Item Category]([Code] nvarchar(10), [Description] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Item Category] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Product Group]([Item Category Code] nvarchar(10), [Code] nvarchar(10), [Description] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Product Group] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [Product Group] ([Item Category Code], [Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Transaction Header]([Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Source] nvarchar(20), [Source Name] nvarchar(250), [Destination] nvarchar(20), [Destination Name] nvarchar(250), [Document Date] datetime, [Expected Date] datetime, [Closing Date] datetime, [Reference No.1] nvarchar(20), [Reference No.2] nvarchar(20), [Reference No.3] nvarchar(20), [Reference No.4] nvarchar(20), [Reference No.5] nvarchar(20), [Receive] int, [Remarks] nvarchar(250), [Status] nvarchar(10), [Origin] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [Transaction Header] ([Transaction Type], [Transaction No.])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Transaction Line]([Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Line No.] int, [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [Quantity] float, [Unit Price] float, [Amount] float, [Discount Perc.] float, [Discount Amount] float)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Transactions]([Line No.] int, [Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Source] nvarchar(20), [Source Name] nvarchar(250), [Destination] nvarchar(20), [Destination Name] nvarchar(250), [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [FOC Item] int, [Reason Code] nvarchar(10), [Reference No.1] nvarchar(20), [Reference No.2] nvarchar(20), [Reference No.3] nvarchar(20), [Reference No.4] nvarchar(20), [Reference No.5] nvarchar(20), [Quantity] float, [Unit Price] float, [Amount] float, [Status] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Stock Count Bin]([Count No.] nvarchar(20), [Location Code] nvarchar(20), [Bin Code] nvarchar(20), [Enable Count] int)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Stock Count]([Line No.] int, [Count No.] nvarchar(20), [Location Code] nvarchar(20), [Bin Code] nvarchar(20), [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [Valid Item] int, [Quantity] float, [Unit Price] float, [Amount] float, [Status] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (File.Exists(string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Data.sdf")))
                {
                    File.Delete(string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Data.sdf"));
                }
                throw exception;
            }
        }

        public static void GetDocumentLines()
        {
            string[] str;
            try
            {
                Service service = new Service();
                try
                {
                    service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                    switch (Property.TransactionType)
                    {
                        case Property.TransactionTypeEnum.PI:
                            {
                                if (!(Property.TranactionOrigin == "iNTrack"))
                                {
                                    Property.DocLine = (DataTable)SqlCeLib.Execute(string.Format("Select * From [Transaction Line] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType.ToString(), Property.TransactionNo), SqlCeLib.ExecMode.Query, new SqlCeParameter[0]);
                                }
                                else
                                {
                                    str = new string[] { "Transaction_Line_3004", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionTypeEnum.PO.ToString(), Property.TransactionNo };
                                    Property.DocLine = service.GetData(str).Tables[0];
                                }
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                        case Property.TransactionTypeEnum.PR:
                        case Property.TransactionTypeEnum.SO:
                        case Property.TransactionTypeEnum.SR:
                        case Property.TransactionTypeEnum.TRQ:
                        case Property.TransactionTypeEnum.TRO:
                            {
                                break;
                            }
                        case Property.TransactionTypeEnum.PRS:
                            {
                                if (!(Property.TranactionOrigin == "iNTrack"))
                                {
                                    str = new string[] { "Transaction_Line_3001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo };
                                    Property.DocLine = service.GetData(str).Tables[0];
                                }
                                else
                                {
                                    str = new string[] { "Transaction_Line_3004", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionTypeEnum.PR.ToString(), Property.TransactionNo };
                                    Property.DocLine = service.GetData(str).Tables[0];
                                }
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                        case Property.TransactionTypeEnum.SI:
                            {
                                str = new string[] { "Transaction_Line_3002", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo };
                                Property.DocLine = service.GetData(str).Tables[0];
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                        case Property.TransactionTypeEnum.SRR:
                            {
                                str = new string[] { "Transaction_Line_3005", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo };
                                Property.DocLine = service.GetData(str).Tables[0];
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                        case Property.TransactionTypeEnum.TRS:
                            {
                                str = new string[] { "Transaction_Line_3003", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo };
                                Property.DocLine = service.GetData(str).Tables[0];
                                Property.DocLine.Columns["QtyTransfer"].ColumnName = "Quantity";
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                        case Property.TransactionTypeEnum.TRI:
                            {
                                str = new string[] { "Transaction_Line_3003", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo };
                                Property.DocLine = service.GetData(str).Tables[0];
                                Property.DocLine.Columns["QtyShipped"].ColumnName = "Quantity";
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                        default:
                            {
                                goto case Property.TransactionTypeEnum.TRO;
                            }
                    }
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void GetTransactionLines()
        {
            try
            {
                Service service = new Service();
                try
                {
                    service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                    if (Property.TransactionType == Property.TransactionTypeEnum.PI)
                    {
                        Property.TransLine = (DataTable)SqlCeLib.Execute(string.Format("Select * From [HHT Transactions] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}' Order By [Line No.]", Property.TransactionType.ToString(), Property.TransactionNo), SqlCeLib.ExecMode.Query, new SqlCeParameter[0]);
                    }
                    else
                    {
                        string[] str = new string[] { "HHT_Transactions_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                        Property.TransLine = service.GetData(str).Tables[0];
                        switch (Property.TransactionType)
                        {
                            case Property.TransactionTypeEnum.SPC:
                            case Property.TransactionTypeEnum.TRQ:
                            case Property.TransactionTypeEnum.TRO:
                            case Property.TransactionTypeEnum.TRS:
                            case Property.TransactionTypeEnum.TRI:
                            case Property.TransactionTypeEnum.ADJ:
                            case Property.TransactionTypeEnum.SHRINK:
                            case Property.TransactionTypeEnum.MISC:
                            case Property.TransactionTypeEnum.PLC:
                            case Property.TransactionTypeEnum.SLC:
                                {
                                    Property.TransLine.Columns["InventLocationIdFrom"].ColumnName = "Source";
                                    Property.TransLine.Columns["FromLocationName"].ColumnName = "Source Name";
                                    Property.TransLine.Columns["InventLocationIdTo"].ColumnName = "Destination";
                                    Property.TransLine.Columns["ToLocationName"].ColumnName = "Destination Name";
                                    goto case Property.TransactionTypeEnum.SC;
                                }
                            case Property.TransactionTypeEnum.PRQ:
                            case Property.TransactionTypeEnum.PO:
                            case Property.TransactionTypeEnum.SR:
                            case Property.TransactionTypeEnum.SRR:
                                {
                                    Property.TransLine.Columns["HHTSourceNo"].ColumnName = "Source";
                                    Property.TransLine.Columns["SourceName"].ColumnName = "Source Name";
                                    Property.TransLine.Columns["InventLocationIdTo"].ColumnName = "Destination";
                                    Property.TransLine.Columns["ToLocationName"].ColumnName = "Destination Name";
                                    goto case Property.TransactionTypeEnum.SC;
                                }
                            case Property.TransactionTypeEnum.PI:
                            case Property.TransactionTypeEnum.SC:
                                {
                                    Property.TransLine.AcceptChanges();
                                    break;
                                }
                            case Property.TransactionTypeEnum.PR:
                            case Property.TransactionTypeEnum.PRS:
                            case Property.TransactionTypeEnum.SO:
                            case Property.TransactionTypeEnum.SI:
                                {
                                    Property.TransLine.Columns["InventLocationIdFrom"].ColumnName = "Source";
                                    Property.TransLine.Columns["FromLocationName"].ColumnName = "Source Name";
                                    Property.TransLine.Columns["HHTSourceNo"].ColumnName = "Destination";
                                    Property.TransLine.Columns["SourceName"].ColumnName = "Destination Name";
                                    goto case Property.TransactionTypeEnum.SC;
                                }
                            default:
                                {
                                    goto case Property.TransactionTypeEnum.SC;
                                }
                        }
                    }
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void InsertStockCount(string BinNo, string Itemcode, string Barcode, string Description, string UOM, int IsValidItem, double Quantity, double UnitPrice, double Amount)
        {
            try
            {
                int num = (int)Conversion.Val(Convert.ToString(Property.TransLine.Compute("Max([Line No.])", string.Empty))) + 1;
                DateTime now = DateTime.Now;
                Service service = new Service();
                try
                {
                    service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                    string[] str = new string[] { "HHT_Stock_Count_1000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo, Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.UserCode, Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString(), string.Empty, IsValidItem.ToString(), num.ToString(), BinNo, Itemcode, Barcode, CommonLib.FormatString(Description), UOM, Quantity.ToString(), string.Empty };
                    service.SetData(str, new DataSet());
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
                DataRow binNo = Property.TransLine.NewRow();
                binNo["Line No."] = num;
                binNo["Bin Code"] = BinNo;
                binNo["Itemcode"] = Itemcode;
                binNo["Barcode"] = Barcode;
                binNo["Description"] = Description;
                binNo["UOM"] = UOM;
                binNo["Valid Item"] = IsValidItem;
                binNo["Quantity"] = Quantity;
                Property.TransLine.Rows.Add(binNo);
                Property.TransLine.AcceptChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void InsertTrans(string Itemcode, string Barcode, string Description, string UOM, string ReasonCode, double Quantity, double Price, double Discount, double Amount, bool IsPriceRevised, string ProductionDate, string ExpiryDate, bool ExcludePrice)
        {
            double num;
            DataRow price;
            DateTime documentDate;
            string[] str;
            object[] objArray;
            DataRow[] dataRowArray;
            int i;
            try
            {
                string empty = string.Empty;
                string transactionPortName = string.Empty;
                string transactionPortCode = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string transactionPortName1 = string.Empty;
                string transactionPortCode1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string transactionPortName2 = string.Empty;
                int num1 = 0;
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.SPC:
                    case Property.TransactionTypeEnum.ADJ:
                    case Property.TransactionTypeEnum.SHRINK:
                    case Property.TransactionTypeEnum.MISC:
                    case Property.TransactionTypeEnum.PLC:
                    case Property.TransactionTypeEnum.SLC:
                        {
                            transactionPortCode = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            transactionPortCode1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PRQ:
                    case Property.TransactionTypeEnum.PO:
                    case Property.TransactionTypeEnum.PI:
                        {
                            num1 = 2;
                            empty = Property.TransactionPortCode;
                            transactionPortName = Property.TransactionPortName;
                            str1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            transactionPortName1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            transactionPortCode1 = Property.TransactionPortCode;
                            empty2 = Property.TransactionPortName;
                            str2 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            transactionPortName2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PR:
                    case Property.TransactionTypeEnum.PRS:
                        {
                            num1 = 2;
                            empty = Property.TransactionPortCode;
                            transactionPortName = Property.TransactionPortName;
                            transactionPortCode = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            transactionPortCode1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            str2 = Property.TransactionPortCode;
                            transactionPortName2 = Property.TransactionPortName;
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SO:
                    case Property.TransactionTypeEnum.SI:
                        {
                            num1 = 1;
                            empty = Property.TransactionPortCode;
                            transactionPortName = Property.TransactionPortName;
                            transactionPortCode = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            transactionPortCode1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            str2 = Property.TransactionPortCode;
                            transactionPortName2 = Property.TransactionPortName;
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SR:
                    case Property.TransactionTypeEnum.SRR:
                        {
                            num1 = 1;
                            empty = Property.TransactionPortCode;
                            transactionPortName = Property.TransactionPortName;
                            str1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            transactionPortName1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            transactionPortCode1 = Property.TransactionPortCode;
                            empty2 = Property.TransactionPortName;
                            str2 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            transactionPortName2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.TRQ:
                    case Property.TransactionTypeEnum.TRI:
                        {
                            transactionPortCode = Property.TransactionPortCode;
                            empty1 = Property.TransactionPortName;
                            str1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            transactionPortName1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            transactionPortCode1 = Property.TransactionPortCode;
                            empty2 = Property.TransactionPortName;
                            str2 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            transactionPortName2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.TRO:
                    case Property.TransactionTypeEnum.TRS:
                        {
                            transactionPortCode = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty1 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            str1 = Property.TransactionPortCode;
                            transactionPortName1 = Property.TransactionPortName;
                            transactionPortCode1 = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                            empty2 = Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString();
                            str2 = Property.TransactionPortCode;
                            transactionPortName2 = Property.TransactionPortName;
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SC:
                        {
                            string transactionNo = Property.TransactionNo;
                            int num2 = (int)Conversion.Val(Convert.ToString(Property.TransLine.Compute("Max([Line No.])", string.Empty))) + 1;
                            DateTime now = DateTime.Now;
                            Service service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                if (Property.IsNewDoc)
                                {
                                    if (string.IsNullOrEmpty(transactionNo))
                                    {
                                        string upper = Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString().PadRight(4, '0').ToUpper();
                                        documentDate = DateTime.ParseExact(service.GetServerTime(), "dd/MMM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                        transactionNo = string.Concat(upper, documentDate.ToString("ddMMyyHHmmss"));
                                    }
                                    if (Property.OperationMode == Property.OperationModeEnum.Online)
                                    {
                                        Service service1 = service;
                                        str = new string[] { "Transaction_Header_1000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), transactionNo, num1.ToString(), (Property.IsPortSelected ? empty : string.Empty), (Property.IsPortSelected ? CommonLib.FormatString(transactionPortName) : string.Empty), transactionPortCode, CommonLib.FormatString(empty1), str1, CommonLib.FormatString(transactionPortName1), (Property.TransactionStatus == "AU" ? "0" : "1"), "0", Property.UserCode, Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString(), string.Empty, null, null, null, null, null, null, null, null, null, null };
                                        documentDate = Property.DocumentDate;
                                        str[16] = documentDate.ToString("MM-dd-yyyy");
                                        documentDate = Property.ReferenceDate;
                                        str[17] = documentDate.ToString("MM-dd-yyyy");
                                        str[18] = ((Property.TransactionType == Property.TransactionTypeEnum.PI || Property.TransactionType == Property.TransactionTypeEnum.PRS || Property.TransactionType == Property.TransactionTypeEnum.TRS || Property.TransactionType == Property.TransactionTypeEnum.SI || Property.TransactionType == Property.TransactionTypeEnum.SRR) && Property.TransactionStatus == "SM" ? "1" : "0");
                                        str[19] = CommonLib.FormatString(Property.Remarks);
                                        str[20] = CommonLib.FormatString(Property.HeaderReferenceNo1);
                                        str[21] = CommonLib.FormatString(Property.HeaderReferenceNo2);
                                        str[22] = string.Empty;
                                        str[23] = string.Empty;
                                        str[24] = string.Empty;
                                        str[25] = Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString();
                                        service1.SetData(str, new DataSet());
                                    }
                                }
                                else if (Property.OperationMode != Property.OperationModeEnum.Online)
                                {
                                    objArray = new object[] { Property.TransactionType.ToString(), transactionNo, Property.DocumentDate, Property.ReferenceDate, CommonLib.FormatString(Property.Remarks), CommonLib.FormatString(Property.HeaderReferenceNo1), CommonLib.FormatString(Property.HeaderReferenceNo2) };
                                    SqlCeLib.Execute(string.Format("Update [Transaction Header] Set [Document Date] = '{2}', [Expected Date] = '{3}', [Remarks] = '{4}', [Reference No.1] = '{5}', [Reference No.2] = '{6}' Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", objArray), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                }
                                else
                                {
                                    str = new string[] { "Transaction_Header_4000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), transactionNo, Property.UserCode, null, null, null, null, null, null, null, null };
                                    documentDate = Property.DocumentDate;
                                    str[5] = documentDate.ToString("MM-dd-yyyy");
                                    documentDate = Property.ReferenceDate;
                                    str[6] = documentDate.ToString("MM-dd-yyyy");
                                    str[7] = CommonLib.FormatString(Property.Remarks);
                                    str[8] = CommonLib.FormatString(Property.HeaderReferenceNo1);
                                    str[9] = CommonLib.FormatString(Property.HeaderReferenceNo2);
                                    str[10] = string.Empty;
                                    str[11] = string.Empty;
                                    str[12] = string.Empty;
                                    service.SetData(str, new DataSet());
                                }
                                iNTrackLib.InsertTransHeader(transactionNo, transactionPortCode1, empty2, str2, transactionPortName2);
                                bool length = false;
                                if (IsPriceRevised)
                                {
                                    DataRow[] dataRowArray1 = Property.TransLine.Select(string.Format("[Barcode] = '{0}'", Barcode));
                                    length = (int)dataRowArray1.Length > 0;
                                }
                                if ((Property.TransactionType != Property.TransactionTypeEnum.PI ? true : !(Property.TransactionStatus == "AU")))
                                {
                                    if (Property.OperationMode != Property.OperationModeEnum.Online)
                                    {
                                        objArray = new object[] { "Insert Into [HHT Transactions] ([Line No.], [Transaction Type], [Transaction No.], [Source], [Source Name], [Destination], [Destination Name], [Itemcode], [Barcode], [Description], [UOM], [Reason Code], [Reference No.1], [Reference No.2], [Quantity], [Unit Price], [Amount], [Status], [HHT User ID], [Created On]) Values (", num2, ", '", Property.TransactionType.ToString(), "', '", transactionNo, "', '", transactionPortCode1, "', '", CommonLib.FormatString(empty2), "', '", str2, "', '", CommonLib.FormatString(transactionPortName2), "', '", Itemcode, "', '", Barcode, "', '", CommonLib.FormatString(Description), "', '", UOM, "', '", ReasonCode, "', '", CommonLib.FormatString(Property.LineReferenceNo1), "', '", CommonLib.FormatString(Property.LineReferenceNo2), "', ", Quantity, ", ", Price, ", ", Amount, ", '", Property.TransactionStatus, "', '", Property.UserCode, "', GetDate())" };
                                        SqlCeLib.Execute(string.Concat(objArray), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                        if (length)
                                        {
                                            objArray = new object[] { Property.TransactionType.ToString(), transactionNo, Price, Discount };
                                            SqlCeLib.Execute(string.Format("Update ax.HHTTRANSACTIONSX Set [Unit Price] = {2}, [Amount] = Case When [Amount] = 0 Then 0 Else Round(([Quantity]*{2})-([Quantity]*{3}),2) End Where [Transaction Type]  = '{0}' And [Transaction No.] = '{1}'", objArray), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                        }
                                    }
                                    else
                                    {
                                        Service service2 = service;
                                        str = new string[] { "HHT_Transactions_1000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), transactionNo, num1.ToString(), empty, CommonLib.FormatString(transactionPortName), transactionPortCode, CommonLib.FormatString(empty1), str1, CommonLib.FormatString(transactionPortName1), (Property.TransactionStatus == "AU" ? "0" : "1"), "0", Property.UserCode, Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString(), string.Empty, CommonLib.FormatString(Property.LineReferenceNo2), num2.ToString(), string.Empty, Itemcode, Barcode, CommonLib.FormatString(Description), UOM, Quantity.ToString(), Price.ToString(), Amount.ToString(), string.Empty, "0", ReasonCode, ProductionDate, ExpiryDate, (ExcludePrice ? "1" : "0"), (length ? "1" : "0"), Discount.ToString() };
                                        service2.SetData(str, new DataSet());
                                    }
                                    iNTrackLib.InsertTransLine(transactionPortCode1, empty2, str2, transactionPortName2, num2, Itemcode, Barcode, Description, UOM, ReasonCode, Quantity, Price, Amount);
                                }
                                else
                                {
                                    double num3 = 0;
                                    double num4 = Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Quantity)", string.Format("Barcode = '{0}'", Barcode))));
                                    double num5 = 0;
                                    dataRowArray = Property.DocLine.Select(string.Format("[Barcode] = '{0}'", Barcode), "[Amount], [Line No.]");
                                    for (i = 0; i < (int)dataRowArray.Length; i++)
                                    {
                                        price = dataRowArray[i];
                                        num3 += double.Parse(price["Quantity"].ToString());
                                        if (num3 > num4)
                                        {
                                            num2 = (int)Conversion.Val(Convert.ToString(Property.TransLine.Compute("Max([Line No.])", string.Empty))) + 1;
                                            num = (Quantity > num3 - num4 ? num3 - num4 : Quantity);
                                            num5 = (double.Parse(price["Amount"].ToString()) == 0 ? 0 : Math.Round(num * Price - num * Discount, 2));
                                            if (Property.OperationMode != Property.OperationModeEnum.Online)
                                            {
                                                objArray = new object[] { "Insert Into [HHT Transactions] ([Line No.], [Transaction Type], [Transaction No.], [Source], [Source Name], [Destination], [Destination Name], [Itemcode], [Barcode], [Description], [UOM], [Reason Code], [Reference No.1], [Reference No.2], [Quantity], [Unit Price], [Amount], [Status], [HHT User ID], [Created On]) Values (", num2, ", '", Property.TransactionType.ToString(), "', '", transactionNo, "', '", transactionPortCode1, "', '", CommonLib.FormatString(empty2), "', '", str2, "', '", CommonLib.FormatString(transactionPortName2), "', '", Itemcode, "', '", Barcode, "', '", CommonLib.FormatString(Description), "', '", UOM, "', '", ReasonCode, "', '", CommonLib.FormatString(Property.LineReferenceNo1), "', '", CommonLib.FormatString(Property.LineReferenceNo2), "', ", num, ", ", Price, ", ", num5, ", '", Property.TransactionStatus, "', '", Property.UserCode, "', GetDate())" };
                                                SqlCeLib.Execute(string.Concat(objArray), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                                if (length)
                                                {
                                                    objArray = new object[] { Property.TransactionType.ToString(), transactionNo, Price, Discount };
                                                    SqlCeLib.Execute(string.Format("Update [HHT Transactions] Set [Unit Price] = {2}, [Amount] = Case When [Amount] = 0 Then 0 Else Round(([Quantity]*{2})-([Quantity]*{3}),2) End Where [Transaction Type]  = '{0}' And [Transaction No.] = '{1}'", objArray), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                                }
                                            }
                                            else
                                            {
                                                Service service3 = service;
                                                str = new string[] { "HHT_Transactions_1000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), transactionNo, num1.ToString(), empty, CommonLib.FormatString(transactionPortName), transactionPortCode, CommonLib.FormatString(empty1), str1, CommonLib.FormatString(transactionPortName1), (Property.TransactionStatus == "AU" ? "0" : "1"), "0", Property.UserCode, Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString(), string.Empty, CommonLib.FormatString(Property.LineReferenceNo2), num2.ToString(), string.Empty, Itemcode, Barcode, CommonLib.FormatString(Description), UOM, num.ToString(), Price.ToString(), num5.ToString(), string.Empty, "0", ReasonCode, ProductionDate, ExpiryDate, (ExcludePrice ? "1" : "0"), (length ? "1" : "0"), Discount.ToString() };
                                                service3.SetData(str, new DataSet());
                                            }
                                            iNTrackLib.InsertTransLine(transactionPortCode1, empty2, str2, transactionPortName2, num2, Itemcode, Barcode, Description, UOM, ReasonCode, num, Price, num5);
                                            if (Quantity > num3 - num4)
                                            {
                                                Quantity -= num;
                                                num4 = num3;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (length)
                                {
                                    dataRowArray = Property.TransLine.Select(string.Format("[Barcode] = '{0}'", Barcode));
                                    for (i = 0; i < (int)dataRowArray.Length; i++)
                                    {
                                        price = dataRowArray[i];
                                        Quantity = double.Parse(price["Quantity"].ToString());
                                        price["Unit Price"] = Price;
                                        if (double.Parse(price["Amount"].ToString()) > 0)
                                        {
                                            price["Amount"] = Math.Round(Quantity * Price - Quantity * Discount, 2);
                                        }
                                    }
                                    Property.TransLine.AcceptChanges();
                                }
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    default:
                        {
                            goto case Property.TransactionTypeEnum.SC;
                        }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void InsertTransHeader(string TransactionNo, string SourceCode, string SourceName, string DestinationCode, string DestinationName)
        {
            DataRow documentDate;
            try
            {
                if (!string.IsNullOrEmpty(Property.TransactionNo))
                {
                    documentDate = Property.TransHeader.Select(string.Format("No = '{0}'", TransactionNo))[0];
                    documentDate["New"] = "0";
                    documentDate["Document Date"] = Property.DocumentDate;
                    documentDate["Expected Date"] = Property.ReferenceDate;
                    documentDate["Reference No.1"] = Property.HeaderReferenceNo1;
                    documentDate["Reference No.2"] = Property.HeaderReferenceNo2;
                }
                else
                {
                    documentDate = Property.TransHeader.NewRow();
                    documentDate["No"] = TransactionNo;
                    documentDate["Source"] = (!(SourceCode == Property.TransactionPortCode) || Property.IsPortSelected ? SourceCode : string.Empty);
                    documentDate["Source Name"] = (!(SourceCode == Property.TransactionPortCode) || Property.IsPortSelected ? SourceName : string.Empty);
                    documentDate["Destination"] = (!(DestinationCode == Property.TransactionPortCode) || Property.IsPortSelected ? DestinationCode : string.Empty);
                    documentDate["Destination Name"] = (!(DestinationCode == Property.TransactionPortCode) || Property.IsPortSelected ? DestinationName : string.Empty);
                    documentDate["Status"] = Property.TransactionStatus;
                    documentDate["Document Date"] = Property.DocumentDate;
                    documentDate["Expected Date"] = Property.ReferenceDate;
                    documentDate["Reference No.1"] = Property.HeaderReferenceNo1;
                    documentDate["Reference No.2"] = Property.HeaderReferenceNo2;
                    documentDate["New"] = "0";
                    Property.TransHeader.Rows.Add(documentDate);
                }
                Property.TransHeader.AcceptChanges();
                if (Property.IsNewDoc)
                {
                    Property.IsNewDoc = false;
                }
                if (string.IsNullOrEmpty(Property.TransactionNo))
                {
                    Property.TransactionNo = TransactionNo;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void InsertTransLine(string SourceCode, string SourceName, string DestinationCode, string DestinationName, int LineNo, string Itemcode, string Barcode, string Description, string UOM, string ReasonCode, double Quantity, double Price, double Amount)
        {
            try
            {
                DataRow lineNo = Property.TransLine.NewRow();
                lineNo["Line No."] = LineNo;
                lineNo["Source"] = SourceCode;
                lineNo["Source Name"] = SourceName;
                lineNo["Destination"] = DestinationCode;
                lineNo["Destination Name"] = DestinationName;
                lineNo["Itemcode"] = Itemcode;
                lineNo["Barcode"] = Barcode;
                lineNo["Description"] = Description;
                lineNo["UOM"] = UOM;
                lineNo["Reason Code"] = ReasonCode;
                lineNo["Reference No.2"] = Property.LineReferenceNo2;
                lineNo["Quantity"] = Quantity;
                lineNo["Unit Price"] = Price;
                lineNo["Amount"] = Amount;
                Property.TransLine.Rows.Add(lineNo);
                Property.TransLine.AcceptChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static bool IsItemBlocked(string Value)
        {
            bool flag;
            try
            {
                string value = Value;
                if (value != null)
                {
                    if (value == "0")
                    {
                        flag = false;
                        return flag;
                    }
                    else if (value == "1")
                    {
                        flag = true;
                        return flag;
                    }
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}