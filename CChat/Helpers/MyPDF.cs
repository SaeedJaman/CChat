using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CChat.Helpers
{
    public class MyPDF
    {
        private readonly string rootPath;
        private readonly IConverter _converter;
        //private readonly string baseUrl;

        public MyPDF(IHostingEnvironment hostingEnvironment, IConverter converter)
        {
            this.rootPath = hostingEnvironment.ContentRootPath + "/wwwroot/pdf/";
            _converter = converter;
            //this.baseUrl = "http://localhost:5000/";
        }

        public string GeneratePDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GenerateLandscapePDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GenerateLandscapePDF_A3(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A3Extra,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GeneratePOSPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = new PechkinPaperSize("65mm","3275mm"),

                    Margins = new MarginSettings() { Top = 0, Bottom = 0, Left = .5, Right =0 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
    }
}
