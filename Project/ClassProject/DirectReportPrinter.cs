using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ZAD_Sales.ClassProject
{
    public class DirectReportPrinter
    {
        private IList<Stream> _streams;
        private int _currentPage;

        public void Print(LocalReport report, string printerName, string deviceInfo)
        {
            Export(report, deviceInfo);

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;

            if (!printDoc.PrinterSettings.IsValid)
                throw new System.Exception("الطابعة غير صالحة");

            _currentPage = 0;
            printDoc.PrintPage += PrintPage;
            printDoc.Print();
        }

        private void Export(LocalReport report, string deviceInfo)
        {
            Warning[] warnings;
            _streams = new List<Stream>();

            report.Render(
                "Image",
                deviceInfo,
                CreateStream,
                out warnings
            );

            foreach (Stream s in _streams)
                s.Position = 0;
        }

        private Stream CreateStream(string name, string extension,
            Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            _streams.Add(stream);
            return stream;
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Metafile pageImage = new Metafile(_streams[_currentPage]))
            {
                e.Graphics.DrawImage(pageImage, e.PageBounds);
            }

            _currentPage++;
            e.HasMorePages = (_currentPage < _streams.Count);
        }

    }
}
