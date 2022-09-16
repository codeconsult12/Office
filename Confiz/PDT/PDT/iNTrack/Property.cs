using iNTrack.AXiNTrackService;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace iNTrack
{
    public static class Property
    {
        private static BasicHttpBinding_AXiNTrack m_AXClient;

        private static Form m_frmPrincipal;

        private static Form m_frmActive;

        private static Property.OperationModeEnum m_enmOpMode;

        private static Property.ModuleEnum m_enmModule;

        private static Property.TransactionTypeEnum m_enmTransType;

        private static DateTime m_dDocDate;

        private static DateTime m_dRefDate;

        private static bool m_bApplyDBFix;

        private static bool m_bIsDevConfigured;

        private static bool m_bBackdatedDocAllowedForUser;

        private static bool m_bShowInventoryForUser;

        private static bool m_bShowCostPrice;

        private static bool m_bBackdatedDocAllowed;

        private static bool m_bShowInventory;

        private static bool m_bNegativeStockAllowed;

        private static bool m_bShowPrice;

        private static bool m_bShowAmount;

        private static bool m_bIsNewDoc;

        private static bool m_bIsPortSelected;

        private static string m_sAppVersion;

        private static string m_sProgPath;

        private static string m_sDataPath;

        private static string m_sUserName;

        private static string m_sUserCode;

        private static string m_sTransNo;

        private static string m_sRemarks;

        private static string m_sTransStatus;

        private static string m_sTransOrigin;

        private static string m_sTransPortCode;

        private static string m_sTransPortName;

        private static string m_sBoxNo;

        private static string m_sHeaderRefNo1;

        private static string m_sHeaderRefNo2;

        private static string m_sLineRefNo1;

        private static string m_sLineRefNo2;

        private static string m_sDefReasonCode;

        private static DataSet m_dsConfig;

        private static DataTable m_dtSetup;

        private static DataTable m_dtHHTDocSetup;

        private static DataTable m_dtUserPermission;

        private static DataTable m_dtTransHeader;

        private static DataTable m_dtTransLine;

        private static DataTable m_dtDocLine;

        public static Form ActiveForm
        {
            get
            {
                return Property.m_frmActive;
            }
            set
            {
                Property.m_frmActive = value;
            }
        }

        public static string ApplicationVersion
        {
            get
            {
                return Property.m_sAppVersion;
            }
            set
            {
                Property.m_sAppVersion = value;
            }
        }

        public static bool ApplyDBFix
        {
            get
            {
                return Property.m_bApplyDBFix;
            }
            set
            {
                Property.m_bApplyDBFix = value;
            }
        }

        public static BasicHttpBinding_AXiNTrack AXClient
        {
            get
            {
                return Property.m_AXClient;
            }
            set
            {
                Property.m_AXClient = value;
            }
        }

        public static bool BackdatedDocumentAllowed
        {
            get
            {
                return Property.m_bBackdatedDocAllowed;
            }
            set
            {
                Property.m_bBackdatedDocAllowed = value;
            }
        }

        public static bool BackdatedDocumentAllowedForUser
        {
            get
            {
                return Property.m_bBackdatedDocAllowedForUser;
            }
            set
            {
                Property.m_bBackdatedDocAllowedForUser = value;
            }
        }

        public static DataSet Configuration
        {
            get
            {
                return Property.m_dsConfig;
            }
        }

        public static string DataPath
        {
            get
            {
                return Property.m_sDataPath;
            }
            set
            {
                Property.m_sDataPath = value;
            }
        }

        public static string DefaultReasonCode
        {
            get
            {
                return Property.m_sDefReasonCode;
            }
            set
            {
                Property.m_sDefReasonCode = value;
            }
        }

        public static DataTable DocLine
        {
            get
            {
                return Property.m_dtDocLine;
            }
            set
            {
                Property.m_dtDocLine = value;
            }
        }

        public static DateTime DocumentDate
        {
            get
            {
                return Property.m_dDocDate;
            }
            set
            {
                Property.m_dDocDate = value;
            }
        }

        public static DataTable DocumentSetup
        {
            get
            {
                return Property.m_dtHHTDocSetup;
            }
            set
            {
                Property.m_dtHHTDocSetup = value;
            }
        }

        public static string HeaderReferenceNo1
        {
            get
            {
                return Property.m_sHeaderRefNo1;
            }
            set
            {
                Property.m_sHeaderRefNo1 = value;
            }
        }

        public static string HeaderReferenceNo2
        {
            get
            {
                return Property.m_sHeaderRefNo2;
            }
            set
            {
                Property.m_sHeaderRefNo2 = value;
            }
        }

        public static bool IsDeviceConfigured
        {
            get
            {
                return Property.m_bIsDevConfigured;
            }
            set
            {
                Property.m_bIsDevConfigured = value;
            }
        }

        public static bool IsNewDoc
        {
            get
            {
                return Property.m_bIsNewDoc;
            }
            set
            {
                Property.m_bIsNewDoc = value;
            }
        }

        public static bool IsPortSelected
        {
            get
            {
                return Property.m_bIsPortSelected;
            }
            set
            {
                Property.m_bIsPortSelected = value;
            }
        }

        public static string LineReferenceNo1
        {
            get
            {
                return Property.m_sLineRefNo1;
            }
            set
            {
                Property.m_sLineRefNo1 = value;
            }
        }

        public static string LineReferenceNo2
        {
            get
            {
                return Property.m_sLineRefNo2;
            }
            set
            {
                Property.m_sLineRefNo2 = value;
            }
        }

        public static Property.ModuleEnum Module
        {
            get
            {
                return Property.m_enmModule;
            }
            set
            {
                Property.m_enmModule = value;
            }
        }

        public static bool NegativeStockAllowed
        {
            get
            {
                return Property.m_bNegativeStockAllowed;
            }
            set
            {
                Property.m_bNegativeStockAllowed = value;
            }
        }

        public static Property.OperationModeEnum OperationMode
        {
            get
            {
                return Property.m_enmOpMode;
            }
            set
            {
                Property.m_enmOpMode = value;
            }
        }

        public static Form PrincipalForm
        {
            get
            {
                return Property.m_frmPrincipal;
            }
            set
            {
                Property.m_frmPrincipal = value;
            }
        }

        public static string ProgramPath
        {
            get
            {
                return Property.m_sProgPath;
            }
        }

        public static DateTime ReferenceDate
        {
            get
            {
                return Property.m_dRefDate;
            }
            set
            {
                Property.m_dRefDate = value;
            }
        }

        public static string Remarks
        {
            get
            {
                return Property.m_sRemarks;
            }
            set
            {
                Property.m_sRemarks = value;
            }
        }

        public static DataTable Setup
        {
            get
            {
                return Property.m_dtSetup;
            }
            set
            {
                Property.m_dtSetup = value;
            }
        }

        public static bool ShowAmount
        {
            get
            {
                return Property.m_bShowAmount;
            }
            set
            {
                Property.m_bShowAmount = value;
            }
        }

        public static bool ShowCostPrice
        {
            get
            {
                return Property.m_bShowCostPrice;
            }
            set
            {
                Property.m_bShowCostPrice = value;
            }
        }

        public static bool ShowInventory
        {
            get
            {
                return Property.m_bShowInventory;
            }
            set
            {
                Property.m_bShowInventory = value;
            }
        }

        public static bool ShowInventoryForUser
        {
            get
            {
                return Property.m_bShowInventoryForUser;
            }
            set
            {
                Property.m_bShowInventoryForUser = value;
            }
        }

        public static bool ShowPrice
        {
            get
            {
                return Property.m_bShowPrice;
            }
            set
            {
                Property.m_bShowPrice = value;
            }
        }

        public static string TranactionOrigin
        {
            get
            {
                return Property.m_sTransOrigin;
            }
            set
            {
                Property.m_sTransOrigin = value;
            }
        }

        public static string TransactionNo
        {
            get
            {
                return Property.m_sTransNo;
            }
            set
            {
                Property.m_sTransNo = value;
            }
        }

        public static string TransactionPortCode
        {
            get
            {
                return Property.m_sTransPortCode;
            }
            set
            {
                Property.m_sTransPortCode = value;
            }
        }

        public static string TransactionPortName
        {
            get
            {
                return Property.m_sTransPortName;
            }
            set
            {
                Property.m_sTransPortName = value;
            }
        }

        public static string TransactionStatus
        {
            get
            {
                return Property.m_sTransStatus;
            }
            set
            {
                Property.m_sTransStatus = value;
            }
        }

        public static Property.TransactionTypeEnum TransactionType
        {
            get
            {
                return Property.m_enmTransType;
            }
            set
            {
                Property.m_enmTransType = value;
            }
        }

        public static DataTable TransHeader
        {
            get
            {
                return Property.m_dtTransHeader;
            }
            set
            {
                Property.m_dtTransHeader = value;
            }
        }

        public static DataTable TransLine
        {
            get
            {
                return Property.m_dtTransLine;
            }
            set
            {
                Property.m_dtTransLine = value;
            }
        }

        public static string UserCode
        {
            get
            {
                return Property.m_sUserCode;
            }
            set
            {
                Property.m_sUserCode = value;
            }
        }

        public static string UserName
        {
            get
            {
                return Property.m_sUserName;
            }
            set
            {
                Property.m_sUserName = value;
            }
        }

        public static DataTable UserPermission
        {
            get
            {
                return Property.m_dtUserPermission;
            }
            set
            {
                Property.m_dtUserPermission = value;
            }
        }

        static Property()
        {
            Property.m_frmActive = null;
            Property.m_enmOpMode = Property.OperationModeEnum.Online;
            Property.m_enmModule = Property.ModuleEnum.None;
            Property.m_enmTransType = Property.TransactionTypeEnum.None;
            Property.m_bApplyDBFix = false;
            Property.m_sAppVersion = "2.0.7";
            Property.m_sProgPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            Property.m_dsConfig = new DataSet();
        }

        public enum ModuleEnum
        {
            None,
            Count,
            Print,
            Purchase,
            Sales,
            Store
        }

        public enum OperationModeEnum
        {
            Offline,
            Online
        }

        public enum TransactionTypeEnum
        {
            None,
            SET,
            IC,
            PC,
            SPC,
            PRQ,
            PO,
            PI,
            PR,
            PRS,
            SO,
            SI,
            SR,
            SRR,
            TRQ,
            TRO,
            TRS,
            TRI,
            ADJ,
            SHRINK,
            MISC,
            SC,
            PLC,
            SLC,
            PLP,
            SLP
        }
    }
}