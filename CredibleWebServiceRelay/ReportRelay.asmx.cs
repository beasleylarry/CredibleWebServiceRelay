using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Services;
using System.IO;
using System.Diagnostics.Contracts;

namespace CredibleWebServiceRelay
{
    /// <summary>
    /// Summary description for ReportRelay
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ReportRelay : System.Web.Services.WebService
    {

        [WebMethod]
        public string IncorrectXML(string connection_string, string start_date, string end_date, string custom_param1, string custom_param2, string custom_param3)
        {
            try
            {
                if (connection_string != null && connection_string != "")
                {
                    CredibleExportService.ExportServiceSoapClient soapclient1 = new CredibleExportService.ExportServiceSoapClient("ExportServiceSoap");
                    StringReader reader = new StringReader(soapclient1.ExportXML(connection_string, start_date, end_date, custom_param1, custom_param2, custom_param3));

                    return reader.ReadToEnd();
                }
                else
                    throw new ArgumentNullException("connection_string");
            }
            catch (Exception ex)
            {
                return string.Format("The following errors occurred: {0}", ex);
            }

    }
        [WebMethod]
        public XmlDocument CorrectXML(string connection_string, string start_date, string end_date, string custom_param1, string custom_param2, string custom_param3)
        {
            XmlDocument readerXMLDocument = new XmlDocument();
            try
            {
                if (connection_string != null && connection_string != "")
                {

                   

                    //Declare new Credible Export Service Soap Client
                    CredibleExportService.ExportServiceSoapClient soapclient1 = new CredibleExportService.ExportServiceSoapClient("ExportServiceSoap");

                    XmlDocument reader = new XmlDocument();

                    reader.LoadXml(soapclient1.ExportXML(connection_string, start_date, end_date, custom_param1, custom_param2, custom_param3));

                    return reader;
                }
                else
                    throw new ArgumentNullException("connection_string");
            }
            catch (Exception ex)
            {
                readerXMLDocument.LoadXml (string.Format("<error>The following errors occurred: {0}</error>", ex));
                return readerXMLDocument;
            }

            
}


    }
}
