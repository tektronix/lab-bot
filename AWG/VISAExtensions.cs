/*=============================================================================
	File		:	Visa.cs                 
	Author		:	Vikas Rao
	Description	:	
	See Also	:   
	Revisions	:	
	----------------------------------------------------------------
		Date					Who					What
		22 Jan, 2010 		  Vikas Rao   		Initial Version
        19 Sept, 2013         Glenn             Only needed one to extended the other VISA
	----------------------------------------------------------------
		Copyright (c) 2008-2009 Tektronix. All Rights Reserved.
	----------------------------------------------------------------
=============================================================================*/
using System;
using System.Runtime.InteropServices;


namespace AwgTestFramework
{
    /// <summary>
    /// Summary description for VISA.
    /// </summary>
    ///

    #region Definitions
    public class VISADefs
    {
        public enum AccessModes : uint
        {
            VI_NO_LOCK = 0,
            VI_EXCLUSIVE_LOCK = 1,
            VI_SHARED_LOCK = 2,
            VI_LOAD_CONFIG = 4
        }

        public enum Attributes : uint
        {
            RSRC_CLASS = 0xBFFF0001,
            RSRC_NAME = 0xBFFF0002,
            RSRC_IMPL_VERSION = 0x3FFF0003,
            RSRC_LOCK_STATE = 0x3FFF0004,
            MAX_QUEUE_LENGTH = 0x3FFF0005,
            USER_DATA = 0x3FFF0007,
            FDC_CHNL = 0x3FFF000D,
            FDC_MODE = 0x3FFF000F,
            FDC_GEN_SIGNAL_EN = 0x3FFF0011,
            FDC_USE_PAIR = 0x3FFF0013,
            SEND_END_EN = 0x3FFF0016,
            TERMCHAR = 0x3FFF0018,
            TMO_VALUE = 0x3FFF001A,
            GPIB_READDR_EN = 0x3FFF001B,
            IO_PROT = 0x3FFF001C,
            DMA_ALLOW_EN = 0x3FFF001E,
            ASRL_BAUD = 0x3FFF0021,
            ASRL_DATA_BITS = 0x3FFF0022,
            ASRL_PARITY = 0x3FFF0023,
            ASRL_STOP_BITS = 0x3FFF0024,
            ASRL_FLOW_CNTRL = 0x3FFF0025,
            RD_BUF_OPER_MODE = 0x3FFF002A,
            WR_BUF_OPER_MODE = 0x3FFF002D,
            SUPPRESS_END_EN = 0x3FFF0036,
            TERMCHAR_EN = 0x3FFF0038,
            DEST_ACCESS_PRIV = 0x3FFF0039,
            DEST_BYTE_ORDER = 0x3FFF003A,
            SRC_ACCESS_PRIV = 0x3FFF003C,
            SRC_BYTE_ORDER = 0x3FFF003D,
            SRC_INCREMENT = 0x3FFF0040,
            DEST_INCREMENT = 0x3FFF0041,
            WIN_ACCESS_PRIV = 0x3FFF0045,
            WIN_BYTE_ORDER = 0x3FFF0047,
            GPIB_ATN_STATE = 0x3FFF0057,
            GPIB_ADDR_STATE = 0x3FFF005C,
            GPIB_CIC_STATE = 0x3FFF005E,
            GPIB_NDAC_STATE = 0x3FFF0062,
            GPIB_SRQ_STATE = 0x3FFF0067,
            GPIB_SYS_CNTRL_STATE = 0x3FFF0068,
            GPIB_HS488_CBL_LEN = 0x3FFF0069,
            CMDR_LA = 0x3FFF006B,
            VXI_DEV_CLASS = 0x3FFF006C,
            MAINFRAME_LA = 0x3FFF0070,
            MANF_NAME = 0xBFFF0072,
            MODEL_NAME = 0xBFFF0077,
            VXI_VME_INTR_STATUS = 0x3FFF008B,
            VXI_TRIG_STATUS = 0x3FFF008D,
            VXI_VME_SYSFAIL_STATE = 0x3FFF0094,
            WIN_BASE_ADDR = 0x3FFF0098,
            WIN_SIZE = 0x3FFF009A,
            ASRL_AVAIL_NUM = 0x3FFF00AC,
            MEM_BASE = 0x3FFF00AD,
            ASRL_CTS_STATE = 0x3FFF00AE,
            ASRL_DCD_STATE = 0x3FFF00AF,
            ASRL_DSR_STATE = 0x3FFF00B1,
            ASRL_DTR_STATE = 0x3FFF00B2,
            ASRL_END_IN = 0x3FFF00B3,
            ASRL_END_OUT = 0x3FFF00B4,
            ASRL_REPLACE_CHAR = 0x3FFF00BE,
            ASRL_RI_STATE = 0x3FFF00BF,
            ASRL_RTS_STATE = 0x3FFF00C0,
            ASRL_XON_CHAR = 0x3FFF00C1,
            ASRL_XOFF_CHAR = 0x3FFF00C2,
            WIN_ACCESS = 0x3FFF00C3,
            RM_SESSION = 0x3FFF00C4,
            VXI_LA = 0x3FFF00D5,
            MANF_ID = 0x3FFF00D9,
            MEM_SIZE = 0x3FFF00DD,
            MEM_SPACE = 0x3FFF00DE,
            MODEL_CODE = 0x3FFF00DF,
            SLOT = 0x3FFF00E8,
            INTF_INST_NAME = 0xBFFF00E9,
            IMMEDIATE_SERV = 0x3FFF0100,
            INTF_PARENT_NUM = 0x3FFF0101,
            RSRC_SPEC_VERSION = 0x3FFF0170,
            INTF_TYPE = 0x3FFF0171,
            GPIB_PRIMARY_ADDR = 0x3FFF0172,
            GPIB_SECONDARY_ADDR = 0x3FFF0173,
            RSRC_MANF_NAME = 0xBFFF0174,
            RSRC_MANF_ID = 0x3FFF0175,
            INTF_NUM = 0x3FFF0176,
            TRIG_ID = 0x3FFF0177,
            GPIB_REN_STATE = 0x3FFF0181,
            GPIB_UNADDR_EN = 0x3FFF0184,
            DEV_STATUS_BYTE = 0x3FFF0189,
            FILE_APPEND_EN = 0x3FFF0192,
            VXI_TRIG_SUPPORT = 0x3FFF0194,
            TCPIP_ADDR = 0xBFFF0195,
            TCPIP_HOSTNAME = 0xBFFF0196,
            TCPIP_PORT = 0x3FFF0197,
            TCPIP_DEVICE_NAME = 0xBFFF0199,
            TCPIP_NODELAY = 0x3FFF019A,
            TCPIP_KEEPALIVE = 0x3FFF019B,

            JOB_ID = 0x3FFF4006,
            EVENT_TYPE = 0x3FFF4010,
            SIGP_STATUS_ID = 0x3FFF4011,
            RECV_TRIG_ID = 0x3FFF4012,
            INTR_STATUS_ID = 0x3FFF4023,
            STATUS = 0x3FFF4025,
            RET_COUNT = 0x3FFF4026,
            BUFFER = 0x3FFF4027,
            RECV_INTR_LEVEL = 0x3FFF4041,
            OPER_NAME = 0xBFFF4042,
            GPIB_RECV_CIC_STATE = 0x3FFF4193,
            RECV_TCPIP_ADDR = 0xBFFF4198
        }

        public enum Status : int
        {
            SUCCESS = 0,
            SUCCESS_EVENT_EN = 1073676290,
            SUCCESS_EVENT_DIS = 1073676291,
            SUCCESS_QUEUE_EMPTY = 1073676292,
            SUCCESS_TERM_CHAR = 1073676293,
            SUCCESS_MAX_CNT = 1073676294,
            SUCCESS_DEV_NPRESENT = 1073676413,
            SUCCESS_TRIG_MAPPED = 1073676414,
            SUCCESS_QUEUE_NEMPTY = 1073676416,
            SUCCESS_NCHAIN = 1073676440,
            SUCCESS_NESTED_SHARED = 1073676441,
            SUCCESS_NESTED_EXCLUSIVE = 1073676442,
            SUCCESS_SYNC = 1073676443,

            WARN_CONFIG_NLOADED = 1073676407,
            WARN_NULL_OBJECT = 1073676418,
            WARN_NSUP_ATTR_STATE = 1073676420,
            WARN_UNKNOWN_STATUS = 1073676421,
            WARN_NSUP_BUF = 1073676424,

            ERROR_SYSTEM_ERROR = -1073807360,
            ERROR_INV_OBJECT = -1073807346,
            ERROR_RSRC_LOCKED = -1073807345,
            ERROR_INV_EXPR = -1073807344,
            ERROR_RSRC_NFOUND = -1073807343,
            ERROR_INV_RSRC_NAME = -1073807342,
            ERROR_INV_ACC_MODE = -1073807341,
            ERROR_TMO = -1073807339,
            ERROR_CLOSING_FAILED = -1073807338,
            ERROR_INV_DEGREE = -1073807333,
            ERROR_INV_JOB_ID = -1073807332,
            ERROR_NSUP_ATTR = -1073807331,
            ERROR_NSUP_ATTR_STATE = -1073807330,
            ERROR_ATTR_READONLY = -1073807329,
            ERROR_INV_LOCK_TYPE = -1073807328,
            ERROR_INV_ACCESS_KEY = -1073807327,
            ERROR_INV_EVENT = -1073807322,
            ERROR_INV_MECH = -1073807321,
            ERROR_HNDLR_NINSTALLED = -1073807320,
            ERROR_INV_HNDLR_REF = -1073807319,
            ERROR_INV_CONTEXT = -1073807318,
            ERROR_QUEUE_OVERFLOW = -1073807315,
            ERROR_NENABLED = -1073807313,
            ERROR_ABORT = -1073807312,
            ERROR_RAW_WR_PROT_VIOL = -1073807308,
            ERROR_RAW_RD_PROT_VIOL = -1073807307,
            ERROR_OUTP_PROT_VIOL = -1073807306,
            ERROR_INP_PROT_VIOL = -1073807305,
            ERROR_BERR = -1073807304,
            ERROR_IN_PROGRESS = -1073807303,
            ERROR_INV_SETUP = -1073807302,
            ERROR_QUEUE_ERROR = -1073807301,
            ERROR_ALLOC = -1073807300,
            ERROR_INV_MASK = -1073807299,
            ERROR_IO = -1073807298,
            ERROR_INV_FMT = -1073807297,
            ERROR_NSUP_FMT = -1073807295,
            ERROR_LINE_IN_USE = -1073807294,
            ERROR_NSUP_MODE = -1073807290,
            ERROR_SRQ_NOCCURRED = -1073807286,
            ERROR_INV_SPACE = -1073807282,
            ERROR_INV_OFFSET = -1073807279,
            ERROR_INV_WIDTH = -1073807278,
            ERROR_NSUP_OFFSET = -1073807276,
            ERROR_NSUP_VAR_WIDTH = -1073807275,
            ERROR_WINDOW_NMAPPED = -1073807273,
            ERROR_RESP_PENDING = -1073807271,
            ERROR_NLISTENERS = -1073807265,
            ERROR_NCIC = -1073807264,
            ERROR_NSYS_CNTLR = -1073807263,
            ERROR_NSUP_OPER = -1073807257,
            ERROR_INTR_PENDING = -1073807256,
            ERROR_ASRL_PARITY = -1073807254,
            ERROR_ASRL_FRAMING = -1073807253,
            ERROR_ASRL_OVERRUN = -1073807252,
            ERROR_TRIG_NMAPPED = -1073807250,
            ERROR_NSUP_ALIGN_OFFSET = -1073807248,
            ERROR_USER_BUF = -1073807247,
            ERROR_RSRC_BUSY = -1073807246,
            ERROR_NSUP_WIDTH = -1073807242,
            ERROR_INV_PARAMETER = -1073807240,
            ERROR_INV_PROT = -1073807239,
            ERROR_INV_SIZE = -1073807237,
            ERROR_WINDOW_MAPPED = -1073807232,
            ERROR_NIMPL_OPER = -1073807231,
            ERROR_INV_LENGTH = -1073807229,
            ERROR_INV_MODE = -1073807215,
            ERROR_SESN_NLOCKED = -1073807204,
            ERROR_MEM_NSHARED = -1073807203,
            ERROR_LIBRARY_NFOUND = -1073807202,
            ERROR_NSUP_INTR = -1073807201,
            ERROR_INV_LINE = -1073807200,
            ERROR_FILE_ACCESS = -1073807199,
            ERROR_FILE_IO = -1073807198,
            ERROR_NSUP_LINE = -1073807197,
            ERROR_NSUP_MECH = -1073807196,
            ERROR_INTF_NUM_NCONFIG = -1073807195,
            ERROR_CONN_LOST = -1073807194,
        }

        public enum EventTypes : int
        {
            EVENT_IO_COMPLETION = 1073684489, //0x3FFF2009,
            EVENT_TRIG = -1073799158, //0xBFFF200A,
            EVENT_SERVICE_REQ = 1073684491, //0x3FFF200B,
            EVENT_CLEAR = 1073684493, //0x3FFF200D,
            EVENT_EXCEPTION = -1073799154, //0xBFFF200E,
            EVENT_GPIB_CIC = 1073684498, //0x3FFF2012,
            EVENT_GPIB_TALK = 1073684499, //0x3FFF2013,
            EVENT_GPIB_LISTEN = 1073684500, //0x3FFF2014,
            EVENT_VXI_VME_SYSFAIL = 1073684509, //0x3FFF201D,
            EVENT_VXI_VME_SYSRESET = 1073684510, //0x3FFF201E,
            EVENT_VXI_SIGP = 1073684512, //0x3FFF2020,
            EVENT_VXI_VME_INTR = -1073799135, //0xBFFF2021,
            EVENT_TCPIP_CONNECT = 1073684534, //0x3FFF2036,

            ALL_ENABLED_EVENTS = 1073709055 //0x3FFF7FFF
        }

        public enum EventMechanism : ushort
        {
            QUEUE = 1,
            HNDLR = 2,
            QUEUE_HNDLR = 3,
            SUSPEND = 4,
            SUSPEND_QUEUE = 5,
            SUSPEND_HNDLR = 6,
            SUSPEND_HNDLR_QUEUE = 7
        }

        public enum Definitions : int
        {
            ALL_MECH = 0xFFFF,

            FIND_BUFLEN = 256,

            INTF_GPIB = 1,
            INTF_VXI = 2,
            INTF_GPIB_VXI = 3,
            INTF_ASRL = 4,
            INTF_TCPIP = 6,

            NORMAL = 1,
            FDC = 2,
            HS488 = 3,
            PROT_4882_STRS = 4,

            FDC_NORMAL = 1,
            FDC_STREAM = 2,

            LOCAL_SPACE = 0,
            A16_SPACE = 1,
            A24_SPACE = 2,
            A32_SPACE = 3,

            UNKNOWN_LA = -1,
            UNKNOWN_SLOT = -1,
            UNKNOWN_LEVEL = -1,

            ANY_HNDLR = 0,

            TRIG_ALL = -2,
            TRIG_SW = -1,
            TRIG_TTL0 = 0,
            TRIG_TTL1 = 1,
            TRIG_TTL2 = 2,
            TRIG_TTL3 = 3,
            TRIG_TTL4 = 4,
            TRIG_TTL5 = 5,
            TRIG_TTL6 = 6,
            TRIG_TTL7 = 7,
            TRIG_ECL0 = 8,
            TRIG_ECL1 = 9,
            TRIG_PANEL_IN = 27,
            TRIG_PANEL_OUT = 28,

            TRIG_PROT_DEFAULT = 0,
            TRIG_PROT_ON = 1,
            TRIG_PROT_OFF = 2,
            TRIG_PROT_SYNC = 5,

            READ_BUF = 1,
            WRITE_BUF = 2,
            READ_BUF_DISCARD = 4,
            WRITE_BUF_DISCARD = 8,
            IO_IN_BUF = 16,
            IO_OUT_BUF = 32,
            IO_IN_BUF_DISCARD = 64,
            IO_OUT_BUF_DISCARD = 128,

            FLUSH_ON_ACCESS = 1,
            FLUSH_WHEN_FULL = 2,
            FLUSH_DISABLE = 3,

            NMAPPED = 1,
            USE_OPERS = 2,
            DEREF_ADDR = 3,

            TMO_IMMEDIATE = 0,
            TMO_INFINITE = -1, //0xFFFFFFFF,

            NO_LOCK = 0,
            EXCLUSIVE_LOCK = 1,
            SHARED_LOCK = 2,
            LOAD_CONFIG = 4,

            NO_SEC_ADDR = 0xFFFF,

            ASRL_PAR_NONE = 0,
            ASRL_PAR_ODD = 1,
            ASRL_PAR_EVEN = 2,
            ASRL_PAR_MARK = 3,
            ASRL_PAR_SPACE = 4,

            ASRL_STOP_ONE = 10,
            ASRL_STOP_ONE5 = 15,
            ASRL_STOP_TWO = 20,

            ASRL_FLOW_NONE = 0,
            ASRL_FLOW_XON_XOFF = 1,
            ASRL_FLOW_RTS_CTS = 2,
            ASRL_FLOW_DTR_DSR = 4,

            ASRL_END_NONE = 0,
            ASRL_END_LAST_BIT = 1,
            ASRL_END_TERMCHAR = 2,
            ASRL_END_BREAK = 3,

            STATE_ASSERTED = 1,
            STATE_UNASSERTED = 0,
            STATE_UNKNOWN = -1,

            BIG_ENDIAN = 0,
            LITTLE_ENDIAN = 1,

            DATA_PRIV = 0,
            DATA_NPRIV = 1,
            PROG_PRIV = 2,
            PROG_NPRIV = 3,
            BLCK_PRIV = 4,
            BLCK_NPRIV = 5,
            D64_PRIV = 6,
            D64_NPRIV = 7,

            WIDTH_8 = 1,
            WIDTH_16 = 2,
            WIDTH_32 = 4,

            GPIB_REN_DEASSERT = 0,
            GPIB_REN_ASSERT = 1,
            GPIB_REN_DEASSERT_GTL = 2,
            GPIB_REN_ASSERT_ADDRESS = 3,
            GPIB_REN_ASSERT_LLO = 4,
            GPIB_REN_ASSERT_ADDRESS_LLO = 5,
            GPIB_REN_ADDRESS_GTL = 6,

            GPIB_ATN_DEASSERT = 0,
            GPIB_ATN_ASSERT = 1,
            GPIB_ATN_DEASSERT_HANDSHAKE = 2,
            GPIB_ATN_ASSERT_IMMEDIATE = 3,

            GPIB_HS488_DISABLED = 0,
            GPIB_HS488_NIMPL = -1,

            GPIB_UNADDRESSED = 0,
            GPIB_TALKER = 1,
            GPIB_LISTENER = 2,

            VXI_CMD16 = 0x0200,
            VXI_CMD16_RESP16 = 0x0202,
            VXI_RESP16 = 0x0002,
            VXI_CMD32 = 0x0400,
            VXI_CMD32_RESP16 = 0x0402,
            VXI_CMD32_RESP32 = 0x0404,
            VXI_RESP32 = 0x0004,

            ASSERT_SIGNAL = -1,
            ASSERT_USE_ASSIGNED = 0,
            ASSERT_IRQ1 = 1,
            ASSERT_IRQ2 = 2,
            ASSERT_IRQ3 = 3,
            ASSERT_IRQ4 = 4,
            ASSERT_IRQ5 = 5,
            ASSERT_IRQ6 = 6,
            ASSERT_IRQ7 = 7,

            UTIL_ASSERT_SYSRESET = 1,
            UTIL_ASSERT_SYSFAIL = 2,
            UTIL_DEASSERT_SYSFAIL = 3,

            VXI_CLASS_MEMORY = 0,
            VXI_CLASS_EXTENDED = 1,
            VXI_CLASS_MESSAGE = 2,
            VXI_CLASS_REGISTER = 3,
            VXI_CLASS_OTHER = 4
        }

        #endregion
    }

    public class VisaExtensions
	{
        
		private uint	_instrSession = 0;

	    public uint Session
	    {
	        get { return _instrSession; }
            set { _instrSession = value; }
	    }

		#region VISA IMPORTS
		
        [DllImport("visa32.dll")]
        static extern int viWrite(uint _instrSession, byte[] buffer, uint count, out uint retCount);

		#endregion

	    public TekVISANet.VISA WorkingSession;

        public VisaExtensions(TekVISANet.VISA workingSession)
		{
            WorkingSession = workingSession;
		}
	
		#region Write

        public bool Write(Byte[] InputBuffer)
        {
            uint    returnCount = (uint)InputBuffer.Length;
            return false == WorkingSession.OnErrorHandler((TekVISANet.TekVISADefs.Status)viWrite(_instrSession, InputBuffer, returnCount, out returnCount));
        }

		#endregion
	}
}
