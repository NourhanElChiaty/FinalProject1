using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FinalProject1.Models;
using System.IO;

namespace FinalProject1.report
{

    public class carreport
    {
        #region Decleration
        int colm = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdftabel = new PdfPTable(3);
        PdfPCell _pdfcell;
        MemoryStream _memorystrem = new MemoryStream();
        List<car> _car = new List<car>();
        #endregion
        public byte[] PrepareReport(List<car> cars)
        {
            _car = cars;
            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(10f, 10f, 10f, 10f);
            _pdftabel.WidthPercentage = 100;
            _pdftabel.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memorystrem);
            _document.Open();
            //  _pdftabel.SetWidths(new float[]{ 40f,100,100,});
            #endregion
            this.ReportHeader();
            this.RepostBody();
            _pdftabel.HeaderRows = 3;
            _document.Add(_pdftabel);
            _document.Close();
            return _memorystrem.ToArray();

        }
        public void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("tahoma", 11f, 1);
            _pdfcell = new PdfPCell(new Phrase("my car report ", _fontStyle));
            _pdfcell.Colspan = colm;
            _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfcell.Border = 0;
            _pdfcell.BackgroundColor = BaseColor.WHITE;
            _pdfcell.ExtraParagraphSpace = 0;
            _pdftabel.AddCell(_pdfcell);
            _pdftabel.CompleteRow();


            _fontStyle = FontFactory.GetFont("tahoma", 9f, 1);
            _pdfcell = new PdfPCell(new Phrase("list car  ", _fontStyle));
            _pdfcell.Colspan = colm;
            _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfcell.Border = 0;
            _pdfcell.BackgroundColor = BaseColor.WHITE;
            _pdfcell.ExtraParagraphSpace = 0;
            _pdftabel.AddCell(_pdfcell);
            _pdftabel.CompleteRow();

        }

        public void RepostBody()
        {
            #region Table  header
            _fontStyle = FontFactory.GetFont("tahoma", 9f, 1);







            _pdfcell = new PdfPCell(new Phrase("Availability  ", _fontStyle));
            _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfcell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfcell.BackgroundColor = BaseColor.WHITE;

            _pdftabel.AddCell(_pdfcell);





            _pdfcell = new PdfPCell(new Phrase("CarType ", _fontStyle));
            _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfcell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfcell.BackgroundColor = BaseColor.WHITE;

            _pdftabel.AddCell(_pdfcell);


            _pdfcell = new PdfPCell(new Phrase("CarColore ", _fontStyle));
            _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfcell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfcell.BackgroundColor = BaseColor.WHITE;

            _pdftabel.AddCell(_pdfcell);
            _pdftabel.CompleteRow();


            #endregion

            #region Tabel body

            _fontStyle = FontFactory.GetFont("tahoma", 8f, 0);

            foreach (car car in _car)
            {




                _pdfcell = new PdfPCell(new Phrase(car.Availability.ToString(), _fontStyle));

                _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfcell.BackgroundColor = BaseColor.WHITE;

                _pdftabel.AddCell(_pdfcell);



                _pdfcell = new PdfPCell(new Phrase(car.CarType, _fontStyle));
                _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfcell.BackgroundColor = BaseColor.WHITE;
                _pdftabel.AddCell(_pdfcell);



                _pdfcell = new PdfPCell(new Phrase(car.CarColor, _fontStyle));
                _pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfcell.BackgroundColor = BaseColor.WHITE;
                _pdftabel.AddCell(_pdfcell);
                _pdftabel.CompleteRow();

                #endregion


            }
        }
    }
}
