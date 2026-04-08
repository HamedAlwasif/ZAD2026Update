using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Reporting.WinForms;

using System.Drawing.Printing;

using System.IO;

using System.Drawing.Imaging;

using System.Drawing;


namespace ZAD_Sales.ClassProject
{
    public class ReportPrinter
    {

        static List<Stream> m_streams;

        static int m_currentPageIndex;

        public static void Print(
LocalReport report,
string printerName,
string paperSize)
        {

            Export(report, paperSize);

            PrintDocument printDoc =
            new PrintDocument();

            printDoc.PrinterSettings.PrinterName =
            printerName;

            if (!printDoc.PrinterSettings.IsValid)
            {

                printDoc.PrinterSettings.PrinterName =
                new PrinterSettings().PrinterName;

            }

            printDoc.PrintPage += PrintPage;

            m_currentPageIndex = 0;

            printDoc.Print();

        }

        static void Export(LocalReport report,string paperSize)
        {

            string pageWidth = "21cm";

            if (ReportEngine.PaperWidths.ContainsKey(paperSize))
            {

                pageWidth =
                ReportEngine.PaperWidths[paperSize];

            }

            string deviceInfo =
            $@"<DeviceInfo>

            <OutputFormat>EMF</OutputFormat>

            <PageWidth>{pageWidth}</PageWidth>

            <PageHeight>29.7cm</PageHeight>

            <MarginTop>0cm</MarginTop>

            <MarginLeft>0cm</MarginLeft>

            <MarginRight>0cm</MarginRight>

            <MarginBottom>0cm</MarginBottom>

            <PrintDpiX>203</PrintDpiX>

            <PrintDpiY>203</PrintDpiY>

            </DeviceInfo>";

            Warning[] warnings;

            m_streams =
            new List<Stream>();

            report.Render(

            "IMAGE",

            deviceInfo,

            CreateStream,

            out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;

        }

        static Stream CreateStream(
        string name,
        string fileNameExtension,
        Encoding encoding,
        string mimeType,
        bool willSeek)
        {

            Stream stream =
            new MemoryStream();

            m_streams.Add(stream);

            return stream;

        }

        static void PrintPage(
        object sender,
        PrintPageEventArgs ev)
        {

            Metafile pageImage =
            new Metafile(
            m_streams[m_currentPageIndex]);

            Rectangle adjustedRect =
            new Rectangle(
            0,
            0,
            ev.PageBounds.Width,
            ev.PageBounds.Height);

            ev.Graphics.DrawImage(
            pageImage,
            adjustedRect);

            m_currentPageIndex++;

            ev.HasMorePages =
            (m_currentPageIndex <
            m_streams.Count);

        }

    }
}
