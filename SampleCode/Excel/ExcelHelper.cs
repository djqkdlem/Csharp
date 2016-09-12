
using System.Data;
using System.Web;

namespace Excel
{
    public class ExcelHelper
    {
        public static void CreateExcelReport(string xsltFilePath, DataSet reportDataSet, HttpResponse response
         , string fileName, string Charset, bool buffer)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "DownLoad.xls";
            }
            if (string.IsNullOrEmpty(Charset))
            {
                Charset = "UTF-8";
            }
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "Attachment;Filename=" + fileName);
            response.Charset = Charset;
            response.Buffer = buffer;
            System.Xml.XmlDataDocument xdd = new System.Xml.XmlDataDocument(reportDataSet);
            System.Xml.Xsl.XslCompiledTransform xct = new System.Xml.Xsl.XslCompiledTransform();
            xct.Load(xsltFilePath);
            xct.Transform(xdd, null, response.OutputStream);
            response.End();
        }
    }
}