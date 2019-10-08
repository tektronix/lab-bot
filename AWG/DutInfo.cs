using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace AwgTestFramework
{
    [Serializable()]

    public class MySettings
    {
        [XmlAttribute("DUTName")]
        public String DutName { get; set; }


        [XmlElement("Add_IP_Name")]
        public bool ADD_IP_NAME { get; set; }

        /// <summary>  
        /// get/set the DUTIP  
        /// </summary>  
        [XmlElement("DUTIPAddress")]
        public String DUTIP { get; set; }

        /// <summary>  
        /// get/set Connection 
        /// </summary>  
        [XmlElement("DUTConnectionType")]
        public String AwgConnType { get; set; }

        [XmlElement("ExtSourceName")]
        public String ExtSourceName { get; set; }
        [XmlElement("ExtSrc_IP_Name")]
        public bool EXTSRC_IP_NAME { get; set; }
        [XmlElement("ExtSrcConnectionType")]
        public String ExtSourceConnType { get; set; }
        [XmlElement("ExtSrcIPAddress")]
        public String ExtSourceIP { get; set; }

        [XmlElement("ScopeName")]
        public String ScopeName { get; set; }
        [XmlElement("ScopeIPAddress")]
        public String ScopeIP { get; set; }
        [XmlElement("ScopeConnectionType")]
        public String ScopeConnType { get; set; }
        [XmlElement("Scope_IP_Name")]
        public bool SCOPE_IP_NAME { get; set; }

        public string pc_state { get; set; }
        public string pbu_state { get; set; }
        public bool pc_pbu_state { get; set; }
        //Sharmila - 01/04/2015
        //Entries to be made into the serializable contents in order to save/retrieve SourceXpress radio button state and Controller enabled/disabled state
        public bool sx_state { get; set; }
        public bool IsAWGControllerEnabled { get; set; }

        [XmlElement("AWG1Controller")]
        public bool AWGController { get; set; }
    }
}