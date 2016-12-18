using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
namespace FLS_Measurement_ToolKit
{
   public class GenratePDF
    {
        public void PdfSharpConvert()
        {
            string html = string.Empty;
            html = Resource.PDFTemp;
            //--------------CustomerInfo
            //{Customer Name}
            //{OEM}
            //{Location}
            //{Equipment Tag No}
            //{Kiln size}
            //{No Of bases}
            //{Project/ Contract No}
            //--------------gearInfo
            //{Type of gear }
            //{Gear outer diameter }
            //{No of teeth }
            //{Gear face width(mm)}
            //{Helix angle(in degree)}     
            //{Direction of rotation}
            //{No.of drive}
            //{Type of spring plate}
            //{Klin shell thickness under gear(mm)}
            //-------------------Girth Gear Axial Runout Measurement Graph
            //{ Client}
            //{ Kiln No}
            //{ Date}
            //------------------------------REsult
            //{Measured Axial run out}
            //{Allowable Axial Run out}
            //--------------CustomerInfo
            html = html.Replace("{Customer Name}", GlobalClass.CustomerName);
            html = html.Replace("{OEM}", GlobalClass.OEM);
            html = html.Replace("{Location}", GlobalClass.Location);
            html = html.Replace("{Equipment Tag No}", GlobalClass.EquipmentTagNo);
            html = html.Replace("{Kiln size}", GlobalClass.Kilnsize);
            html = html.Replace("{No Of bases}", GlobalClass.NoOfbases);
            html = html.Replace("{Project/ Contract No}", GlobalClass.ProjectContractNo);
            //--------------gearInfo
            html = html.Replace("{Type of gear }", GlobalClass.Typeofgear);
            html = html.Replace("{Gear outer diameter }", GlobalClass.GearOuterDiameter);
            html = html.Replace("{No of teeth }", GlobalClass.NoOfteeth);
            html = html.Replace("{Gear face width(mm)}", GlobalClass.Gearfacewidth);
            html = html.Replace("{Helix angle(in degree)}", GlobalClass.HelixAngle);
            html = html.Replace("{Direction of rotation}", GlobalClass.Directionofrotation);
            html = html.Replace("{No.of drive}", GlobalClass.Noofdrive);
            html = html.Replace("{Type of spring plate}", GlobalClass.Typeofspringplate);
            html = html.Replace("{Klin shell thickness under gear(mm)}", GlobalClass.Klinshellthicknessundergear);
            //-------------------Girth Gear Axial Runout Measurement Graph
            html = html.Replace("{ Client}", GlobalClass.CustomerName);
            html = html.Replace("{ Kiln No}", GlobalClass.KilnNo);
            html = html.Replace("{ Date}", DateTime.Now.ToString());
            //------------------------------REsult
            html = html.Replace("{Measured Axial run out}", GlobalClass.MeasuredAxialRunout);
            html = html.Replace("{Allowable Axial Run out}", GlobalClass.AllowableAxialRunout);
            html = html.Replace("{RadialChart}", @"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\New.bmp");
            html = html.Replace("{FLSLogo}", @"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\flsmidth_logo.jpg");
            //Byte[] res = null;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
            //    pdf.Save(ms);
            //    res = ms.ToArray();
            //    //System.IO.File.WriteAllBytes("hello.pdf", fileContent);
            //}
            using (Stream fileStream = File.Create(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\BE1.pdf"))
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(fileStream);
                //res = ms.ToArray();
                //System.IO.File.WriteAllBytes("hello.pdf", fileContent);
            }
            //return res;
        }
    }
}
