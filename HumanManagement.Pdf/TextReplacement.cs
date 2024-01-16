using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using WP = DocumentFormat.OpenXml.Wordprocessing;
using W = Microsoft.Office.Interop.Word;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System;
using Microsoft.Extensions.Logging;
using HumanManagement.CrossCutting.Utils;
using Microsoft.Extensions.Options;
using HumanManagement.Domain.Evaluation.Dto;
using DocumentFormat.OpenXml.Wordprocessing;
using HumanManagement.Domain.Proficiency.Contracts;
using System.Threading.Tasks;
using System.Globalization;
using HumanManagement.Domain.StaffRequest.Dto;


namespace HumanManagement.Pdf
{
    
    public class TextReplacement : ITextReplacement
    {
        private readonly ILogger<TextReplacement> _logger;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly AppSettings _appSettings;

        public TextReplacement(ILogger<TextReplacement> logger, IConvertWordToPdf convertWordToPdf, IOptions<AppSettings> appSettings
            )
        {
            this._logger = logger;
            this.convertWordToPdf = convertWordToPdf;
            this._appSettings = appSettings.Value;
            
        }

        public void ReplaceText(List<ReplaceEntity> listReplaceEntity, string pathSignature, string fullPath)
        {
            if (File.Exists(fullPath))
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullPath, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }
                    foreach (var bean in listReplaceEntity)
                    {
                        string sNombreCampo = bean.stag;
                        string sValorCampo = bean.sreplacetext;
                        Regex regexText = new Regex(sNombreCampo);
                        docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                    }
                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    if (!string.IsNullOrEmpty(pathSignature))
                    {
                        var mainPart = wordDoc.MainDocumentPart;
                        var table = wordDoc.MainDocumentPart.Document.MainDocumentPart.Document.Body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>().LastOrDefault();
                        if (table != null)
                        {
                            var row = table.Descendants<DocumentFormat.OpenXml.Wordprocessing.TableRow>().FirstOrDefault();
                            
                            var pictureCell = row.Descendants<DocumentFormat.OpenXml.Wordprocessing.TableCell>().FirstOrDefault();

                            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                            using (FileStream stream = new FileStream(pathSignature, FileMode.Open))
                            {
                                imagePart.FeedData(stream);
                            }

                            pictureCell.RemoveAllChildren();
                            AddImageToCell(pictureCell, mainPart.GetIdOfPart(imagePart));

                            mainPart.Document.Save();
                        }

                    }

                    wordDoc.Close();
                }
            }
        }

        public void ReplaceText(List<ReplaceEntity> listReplaceEntity, string pathSignature, string fullPath, GetStaffBurialByIdDto sepelioDto)
        {
            if (File.Exists(fullPath))
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullPath, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }
                    foreach (var bean in listReplaceEntity)
                    {
                        string sNombreCampo = bean.stag;
                        string sValorCampo = bean.sreplacetext;
                        Regex regexText = new Regex(sNombreCampo);
                        docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                    }
                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    if (!string.IsNullOrEmpty(pathSignature))
                    {
                        var mainPart = wordDoc.MainDocumentPart;
                        var table = wordDoc.MainDocumentPart.Document.MainDocumentPart.Document.Body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>().LastOrDefault();
                        if (table != null)
                        {
                            var row = table.Descendants<DocumentFormat.OpenXml.Wordprocessing.TableRow>().FirstOrDefault();
                            
                            var pictureCell = row.Descendants<DocumentFormat.OpenXml.Wordprocessing.TableCell>().FirstOrDefault();

                            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                            using (FileStream stream = new FileStream(pathSignature, FileMode.Open))
                            {
                                imagePart.FeedData(stream);
                            }

                            pictureCell.RemoveAllChildren();
                            AddImageToCell(pictureCell, mainPart.GetIdOfPart(imagePart));

                            mainPart.Document.Save();
                        }

                    }


                    WP.Table tableServicio = wordDoc.MainDocumentPart.Document.Body
                               .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Servicio")).ToList()[1];
                    

                    if (tableServicio != null)
                    {

                        WP.TableProperties tblProperties = new WP.TableProperties(
                          new WP.TableBorders(
                              new WP.TopBorder()
                              {
                                  Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                  Color = "000000"
                              },
                              new WP.LeftBorder()
                              {
                                  Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                  Color = "000000"
                              },
                              new WP.RightBorder()
                              {
                                  Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                  Color = "000000"
                              },
                              new WP.BottomBorder()
                              {
                                  Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                  Color = "000000"
                              }
                              )
                          );
                        




                        tableServicio.AppendChild(tblProperties);

                        if (sepelioDto.serviciosepultura)
                        {
                            WP.TableRow trSepultura = new WP.TableRow();

                            trSepultura.TableRowProperties = new TableRowProperties(new TableRowHeight() { Val = 400 });
                            trSepultura.Append(NewCellTableLeft("•	Servicio de Sepultura", ""));
                            

                            tableServicio.AppendChild(trSepultura);
                        }

                        if (sepelioDto.serviciofunerario)
                        {
                            WP.TableRow trFunerario = new WP.TableRow();
                            trFunerario.TableRowProperties = new TableRowProperties(new TableRowHeight() { Val = 400 });
                            trFunerario.Append(NewCellTableLeft("•	Servicio Funerario", ""));

                            tableServicio.AppendChild(trFunerario);
                        }
                           if (sepelioDto.ceremoniainhumacion)
                        {
                            WP.TableRow trCeremonia = new WP.TableRow();
                            trCeremonia.TableRowProperties = new TableRowProperties(new TableRowHeight() { Val = 400 });
                            trCeremonia.Append(NewCellTableLeft("•	Ceremonia de Inhumación", ""));

                            tableServicio.AppendChild(trCeremonia);
                        }
                        if (sepelioDto.otros)
                        {
                            WP.TableRow trOtros = new WP.TableRow();
                            trOtros.TableRowProperties = new TableRowProperties(new TableRowHeight() { Val = 400 });
                            trOtros.Append(NewCellTableLeft("•	Otros", ""));

                            tableServicio.AppendChild(trOtros);
                        }



                    }

                    WP.Table tableSepultura = wordDoc.MainDocumentPart.Document.Body
                                .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Tiempo en Planilla")).ToList()[1];

                    if ( tableSepultura != null)
                    {

                        string sTiempoEnPlanilla = "";
                        string sPorcDescuentoPlanilla = "";

                        if (sepelioDto.serviciosepulturaporc == 25)
                        {
                            sTiempoEnPlanilla = "Menor de 3 años";
                            sPorcDescuentoPlanilla = "25 %";
                        }

                        if (sepelioDto.serviciosepulturaporc == 50)
                        {
                            sTiempoEnPlanilla = "Mas o igual a 3 años";
                            sPorcDescuentoPlanilla = "50 %";
                        }

                        WP.TableProperties tableSepulturaProperties = new WP.TableProperties(
                        new WP.TableBorders(
                            new WP.TopBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            },
                            new WP.LeftBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            },
                            new WP.RightBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            },
                            new WP.BottomBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            }
                            )
                        );

                        tableSepultura.AppendChild(tableSepulturaProperties);

                        WP.TableRow tr = new WP.TableRow( );
                        tr.TableRowProperties = new TableRowProperties(new TableRowHeight() { Val = 400 });

                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_Tiempo = NewMergeCellTable(sTiempoEnPlanilla, MergedCellValues.Restart, "", false, true);
                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_PorcDescuentoPlanilla = NewMergeCellTable(sPorcDescuentoPlanilla, MergedCellValues.Restart, "", false, true);

                        
                        tr.Append(tablecell_Tiempo, tablecell_PorcDescuentoPlanilla);
                        tableSepultura.AppendChild(tr);

                    }

                    WP.Table tableProducto = wordDoc.MainDocumentPart.Document.Body
                                .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Producto")).ToList()[1];

                    if (tableProducto != null)
                    {

                        string sProducto = "";
                        string sDescuento = "";

                      
                        sDescuento = sepelioDto.serviciofunerarioporc + " %";

                        switch (sepelioDto.serviciofunerarioporc)
                        {
                            case 25:
                                sProducto = "Clásico";
                                break;
                            case 35:
                                sProducto = "Superior";
                                break;
                            case 45:
                                sProducto = "Lujo";
                                break;
                            case 50:
                                sProducto = "VIP";
                                break;
                            default:
                                sProducto = "";
                                break;
                        }



                        WP.TableProperties tableProductoProperties = new WP.TableProperties(
                        new WP.TableBorders(
                            new WP.TopBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            },
                            new WP.LeftBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            },
                            new WP.RightBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            },
                            new WP.BottomBorder()
                            {
                                Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                Color = "000000"
                            }
                            )
                        );

                        tableProducto.AppendChild(tableProductoProperties);

                        WP.TableRow tr = new WP.TableRow();
                        tr.TableRowProperties = new TableRowProperties(new TableRowHeight() { Val = 400 });

                        tr.Append(NewCellTable(sProducto, ""), NewCellTable(sDescuento, ""));
                        tableProducto.AppendChild(tr);

                    }


                    wordDoc.Close();
                }
            }
        }

        public string ReplaceTextEmployeeCV(EmployeeCVDto employeeCVDto, string pathDirectory, string pathTemplate)
        {
            string fullpathdocx = string.Empty;
            string fullpathpdf = string.Empty;
            W.Application appWord = null;
            W.Document wordDocument = null;
            string filecv = string.Empty;

            try
            {
                if (!string.IsNullOrWhiteSpace(pathTemplate))
                {
                    _logger.LogInformation("pathTemplate: " + pathTemplate);
                    if (File.Exists(pathTemplate))
                    {
                        string randomnameNew5 = "profile_" + employeeCVDto.nid_employee;

                        bool exists = Directory.Exists(pathDirectory);
                        _logger.LogInformation("pathDirectory: " + pathDirectory);
                        if (!exists)
                            Directory.CreateDirectory(pathDirectory);

                        fullpathdocx = string.Format("{0}{1}.docx", pathDirectory, randomnameNew5);
                        fullpathpdf = string.Format("{0}{1}.pdf", pathDirectory, randomnameNew5);

                        if (File.Exists(fullpathdocx))
                        {
                            File.Delete(fullpathdocx);
                        }
                        _logger.LogInformation("fullpathdocx: " + fullpathdocx);

                        if (File.Exists(fullpathpdf))
                        {
                            File.Delete(fullpathpdf);
                        }
                        _logger.LogInformation("fullpathpdf: " + fullpathpdf);

                        File.Copy(pathTemplate, fullpathdocx);


                        if (File.Exists(fullpathdocx))
                        {
                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullpathdocx, true))
                            {
                                string docText = null;
                                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                                {
                                    docText = sr.ReadToEnd(); 
                                }

                                var lstReplaces = new List<ReplaceEntity>();
                                var lstReplaces2 = new List<ReplaceEntity>();
                       
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"FECHANACIMIENTO", sreplacetext = employeeCVDto.dbirthdate?.ToString("dd/MM/yyyy") ?? string.Empty });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"INGRESOPAIS", sreplacetext = employeeCVDto.dcountryentrydate?.ToString("dd/MM/yyyy") ?? string.Empty });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"LICENCIACOND", sreplacetext = employeeCVDto.sdrivinglicense });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"LICENCIAMAQ", sreplacetext = employeeCVDto.sheavymachinerylicense });
                                lstReplaces2.Add(new ReplaceEntity() { stag = "TAGACT", sreplacetext = employeeCVDto.sstate });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[NOMBRESCOMPLETOS\]", sreplacetext = employeeCVDto.sfullname });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[TITULO\]", sreplacetext = employeeCVDto.snamecharge });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[PERFIL\]", sreplacetext = employeeCVDto.snamecharge });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[EDAD\]", sreplacetext = employeeCVDto.nedad.ToString() });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[DNI\]", sreplacetext = employeeCVDto.sidentification }); 
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[SEXO\]", sreplacetext = employeeCVDto.ssexo });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[ESTADOCIVIL\]", sreplacetext = employeeCVDto.scivil });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[TELEFONO\]", sreplacetext = employeeCVDto.phone });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[CORREO\]", sreplacetext = employeeCVDto.semail });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[DIRECCION\]", sreplacetext = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(employeeCVDto.saddress)) });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[EMPRESA\]", sreplacetext = employeeCVDto.scompany });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[CARGO\]", sreplacetext = employeeCVDto.snamecharge });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[AREA\]", sreplacetext = employeeCVDto.snamearea });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[SEDE\]", sreplacetext = employeeCVDto.ssede });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[JEFE\]", sreplacetext = employeeCVDto.sjefe });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[FECHAINGRESO\]", sreplacetext = employeeCVDto.dadmissiondate.ToString("dd/MM/yyyy") });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[ANEXO\]", sreplacetext = employeeCVDto.sannexed });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[CORREOCORPORATIVO\]", sreplacetext = employeeCVDto.scorporatemail });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[PLANEPS\]", sreplacetext = employeeCVDto.seps });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[PLANFESALUD\]", sreplacetext = employeeCVDto.sfesalud });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[PLANPRACTICANTE\]", sreplacetext = employeeCVDto.PLAN_SEGURO_PRACT });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[AFP\]", sreplacetext = employeeCVDto.safp });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[SCTR\]", sreplacetext = employeeCVDto.SCTR });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[VIDALEY\]", sreplacetext = employeeCVDto.svidaley });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"APESPOSA", sreplacetext = employeeCVDto.slastname_partner });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"AMESPOSA", sreplacetext = employeeCVDto.smotherlastname_partner });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"NESPOSA", sreplacetext = employeeCVDto.snamewife_partner });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"ANIOCOMPROMISO", sreplacetext = employeeCVDto.ddateofmarriage?.ToString("dd/MM/yyyy") ?? string.Empty });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"TAGGERENCIA", sreplacetext = employeeCVDto.namegerencia.ToUpper() });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"TAGAREA", sreplacetext = employeeCVDto.namearea});
                                lstReplaces.Add(new ReplaceEntity() { stag = @"TAGSUBAREA", sreplacetext = employeeCVDto.namesubarea });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"TAGCENTROCOSTO", sreplacetext = employeeCVDto.nameareacc });



                                _logger.LogInformation("var bean in lstReplaces: ");
                                foreach (var bean in lstReplaces)
                                {
                                    string sNombreCampo = bean.stag;
                                    string sValorCampo = bean.sreplacetext;

                                    _logger.LogInformation("sNombreCampo: " + sNombreCampo);
                                    _logger.LogInformation("sValorCampo: " + sValorCampo);
                                    Regex regexText = new Regex(sNombreCampo);
                                    docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                                }

                                lstReplaces2.Add(new ReplaceEntity() { stag = @"PASSP", sreplacetext = employeeCVDto.spassport });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"NACLY", sreplacetext = employeeCVDto.snationality });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"TIPSN", sreplacetext = employeeCVDto.sbloodtype });
                                foreach (var bean in lstReplaces2)
                                {
                                    string sNombreCampo = bean.stag;
                                    string sValorCampo = bean.sreplacetext;

                                    _logger.LogInformation("sNombreCampo: " + sNombreCampo);
                                    _logger.LogInformation("sValorCampo: " + sValorCampo);
                                    Regex regexText = new Regex(sNombreCampo);
                                    docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                                }

                                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                                {
                                    sw.Write(docText);
                                }

                                wordDoc.Close();
                            }
                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullpathdocx, true))
                            {
                                string docText = null;

                                var doc = wordDoc.MainDocumentPart.Document;

                                WP.Table table = doc.MainDocumentPart.Document.Body
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Carrera"))
                                    .FirstOrDefault();

                                if (table != null)
                                {
                                    WP.TableProperties tblProperties = new WP.TableProperties(
                                    new WP.TableBorders(
                                        new WP.TopBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.LeftBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.RightBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.BottomBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        }
                                        )
                                    );

                                    table.AppendChild(tblProperties);

                                    int icounterforlistaStudients;
                                    _logger.LogInformation("for icounterforlistaStudients: ");
                                    for (icounterforlistaStudients = 0; icounterforlistaStudients < employeeCVDto.listaStudients.Count; icounterforlistaStudients++)
                                    {
                                        #region Armando las filas

                                        WP.TableRow tr = new WP.TableRow();

                   
                                        _logger.LogInformation("Nivel academico: " + employeeCVDto.listaStudients[icounterforlistaStudients].sdescription_value?.ToString());
                                        WP.TableCell tablecellsdescription_value =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].sdescription_value?.ToString() ?? string.Empty))));


      
                                        _logger.LogInformation("Carrera: " + employeeCVDto.listaStudients[icounterforlistaStudients].scarreer?.ToString());
                                        WP.TableCell tablecellscarreer =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].scarreer?.ToString() ?? string.Empty))));


                                        _logger.LogInformation("Centro de estudios: " + employeeCVDto.listaStudients[icounterforlistaStudients].sstudy_center?.ToString());
                                        WP.TableCell tablecellssstudy_center =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].sstudy_center?.ToString() ?? string.Empty))));

                                        _logger.LogInformation("Situacion actual: " + employeeCVDto.listaStudients[icounterforlistaStudients].scurrent_cycle?.ToString());
                                        WP.TableCell tablecellscurrent_cycle =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].scurrent_cycle?.ToString() ?? string.Empty))));

         
                                        _logger.LogInformation("Fecha inicio: " + employeeCVDto.listaStudients[icounterforlistaStudients].dateStart.ToString("dd/MM/yyyy"));
                                        WP.TableCell tablecelldateStart =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].dateStart.ToString("dd/MM/yyyy")))));

                                        

                                        var dFechaFin = employeeCVDto.listaStudients[icounterforlistaStudients].dateEnd;
                                        var sFechaFin = string.Empty;
                                        if (dFechaFin != null) {
                                            sFechaFin = dFechaFin.Value.ToString("dd/MM/yyyy");
                                        }

                                        _logger.LogInformation("Fecha fin: " + sFechaFin);
                                        WP.TableCell tablecelldateEnd =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(sFechaFin))));



                                        tr.Append(tablecellsdescription_value, tablecellscarreer, tablecellssstudy_center, tablecellscurrent_cycle, tablecelldateStart, tablecelldateEnd);
                                        table.AppendChild(tr);
                                        #endregion
                                    }
                                }


                                WP.Table tableJob = doc.MainDocumentPart.Document.Body
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Funciones"))
                                    .FirstOrDefault();

                                if (tableJob != null)
                                {
                                    WP.TableProperties tblJobProperties = new WP.TableProperties(
                                    new WP.TableBorders(
                                        new WP.TopBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.LeftBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.RightBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.BottomBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        }
                                        )
                                    );

                                    tableJob.AppendChild(tblJobProperties);

                                    int icounterforlistaJobs;
                                    for (icounterforlistaJobs = 0; icounterforlistaJobs < employeeCVDto.listaJobs.Count; icounterforlistaJobs++)
                                    {
                                        #region Armando las filas

                                        WP.TableRow tr = new WP.TableRow();

                                        
                                        _logger.LogInformation("Nombre: " + employeeCVDto.listaJobs[icounterforlistaJobs].namejob?.ToString());
                                        WP.TableCell tablecellnamejob =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaJobs[icounterforlistaJobs].namejob?.ToString() ?? string.Empty))));

                                        
                                        _logger.LogInformation("Tiempo: " + employeeCVDto.listaJobs[icounterforlistaJobs].timejob?.ToString());
                                        WP.TableCell tablecelltimejob =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaJobs[icounterforlistaJobs].timejob?.ToString() ?? string.Empty))));

                                        
                                        _logger.LogInformation("Posicion: " + employeeCVDto.listaJobs[icounterforlistaJobs].positionjob?.ToString());
                                        WP.TableCell tablecellpositionjob =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaJobs[icounterforlistaJobs].positionjob?.ToString() ?? string.Empty))));

                                        
                                        _logger.LogInformation("Funciones: " + employeeCVDto.listaJobs[icounterforlistaJobs].sfunction?.ToString());
                                        WP.TableCell tablecellsfunction =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaJobs[icounterforlistaJobs].sfunction?.ToString() ?? string.Empty))));


                                        tr.Append(tablecellnamejob, tablecelltimejob, tablecellpositionjob, tablecellsfunction);
                                        tableJob.AppendChild(tr);
                                        #endregion
                                    }
                                }


                                WP.Table tableSon = doc.MainDocumentPart.Document.Body
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Apellidos y nombres"))
                                    .FirstOrDefault();

                                if (tableSon != null)
                                {
                                    WP.TableProperties tblSonProperties = new WP.TableProperties(
                                    new WP.TableBorders(
                                        new WP.TopBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.LeftBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.RightBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        },
                                        new WP.BottomBorder()
                                        {
                                            Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                            Color = "000000"
                                        }
                                        )
                                    );

                                    tableSon.AppendChild(tblSonProperties);
                                    

                                    int icounterforlistaSons;
                                    for (icounterforlistaSons = 0; icounterforlistaSons < employeeCVDto.listaSons.Count; icounterforlistaSons++)
                                    {
                                        #region Armando las filas

                                        WP.TableRow tr = new WP.TableRow();



                                        WP.TableCell tablecellstype=
                                           new WP.TableCell(
                                               new WP.Paragraph(
                                                   new WP.ParagraphProperties(
                                                       new WP.Justification() { Val = WP.JustificationValues.Center }
                                                       ),
                                                   new WP.Run(
                                                       new WP.RunProperties(
                                                           new WP.FontSize() { Val = "20" }
                                                           ),
                                                       new WP.RunFonts() { Ascii = "Calibri" },
                                                       new WP.Text(employeeCVDto.listaSons[icounterforlistaSons].sfamilytypedescription))));


                                        
                                        var nombreCompletoHijo = ( (employeeCVDto.listaSons[icounterforlistaSons].slastname?.ToString() ?? string.Empty) + " " +
                                                         (employeeCVDto.listaSons[icounterforlistaSons].smotherslastname?.ToString() ?? string.Empty) + " " +
                                                         (employeeCVDto.listaSons[icounterforlistaSons].sfullname?.ToString() ?? string.Empty));
                                        _logger.LogInformation("Nombre: " + employeeCVDto.listaSons[icounterforlistaSons].sfullname?.ToString());

                                        WP.TableCell tablecellsfullname =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "20" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Calibri" },
                                                        new WP.Text(nombreCompletoHijo))));
                                        
                                        _logger.LogInformation("Fecha nacimiento: " + employeeCVDto.listaSons[icounterforlistaSons].ddateofbirth.ToString("dd/MM/yyyy"));
                                        WP.TableCell tablecellddateofbirth =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Center }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaSons[icounterforlistaSons].ddateofbirth.ToString("dd/MM/yyyy")))));

                                        tr.Append(tablecellstype,tablecellsfullname, tablecellddateofbirth);
                                        tableSon.AppendChild(tr);
                                        #endregion
                                    }
                                }

                                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                                {
                                    docText = sr.ReadToEnd();
                                }

                                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                                {
                                    sw.Write(docText);
                                }

                                wordDoc.Close();
                            }
                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullpathdocx, true))
                            {
                                
                                _logger.LogInformation("IMAGEN: " + employeeCVDto.simg);
                                if (!string.IsNullOrEmpty(employeeCVDto.simg))
                                {
                                    try
                                    {
                                        var mainPart = wordDoc.MainDocumentPart;

                                        ImagePart imagePart = (ImagePart)mainPart.GetPartById("rId5");

                                        System.Net.WebClient client = new System.Net.WebClient();
                                        Stream stream = client.OpenRead(employeeCVDto.simg);
                                        imagePart.FeedData(stream);
                                        stream.Flush();
                                        stream.Close();
                                        client.Dispose();
                                    }
                                    catch (Exception)
                                    {
                                    }

                                }
                            }
                        }

                        
                        Byte[] bytes5 = File.ReadAllBytes(fullpathdocx);
                        _logger.LogInformation("bytes5: " + bytes5);

                        filecv = Convert.ToBase64String(bytes5);
                        _logger.LogInformation("filecv: " + filecv);

                        if (File.Exists(fullpathdocx))
                        {
                            File.Delete(fullpathdocx);
                        }
                        if (File.Exists(fullpathpdf))
                        {
                            File.Delete(fullpathpdf);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            
            return filecv;
        }
        
        private string ReplaceSpecialCharacters(string str)
        {
            if (str == null) str = string.Empty;

            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\"", "&quot;");
            str = str.Replace("'", "&apos;");
            return str.ToString();
        }
        private static void AddImageToCell(DocumentFormat.OpenXml.Wordprocessing.TableCell cell, string relationshipId)
        {
            var element =
              new DocumentFormat.OpenXml.Wordprocessing.Drawing(
                new DW.Inline(
                  new DW.Extent() { Cx = 990000L, Cy = 450000L },
                  new DW.EffectExtent()
                  {
                      LeftEdge = 350000L,
                      TopEdge = 150000L,
                      RightEdge = 350000L,
                      BottomEdge = 100000L
                  },
                  new DW.DocProperties()
                  {
                      Id = (UInt32Value)1U,
                      Name = "Picture Firma"
                  },
                  new DW.NonVisualGraphicFrameDrawingProperties(
                      new A.GraphicFrameLocks() { NoChangeAspect = true }),
                  new A.Graphic(
                    new A.GraphicData(
                      new PIC.Picture(
                        new PIC.NonVisualPictureProperties(
                          new PIC.NonVisualDrawingProperties()
                          {
                              Id = (UInt32Value)0U,
                              Name = "New Bitmap Image.jpg"
                          },
                          new PIC.NonVisualPictureDrawingProperties()),
                        new PIC.BlipFill(
                          new A.Blip(
                            new A.BlipExtensionList(
                              new A.BlipExtension()
                              {
                                  Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
                              })
                           )
                          {
                              Embed = relationshipId,
                              CompressionState =
                              A.BlipCompressionValues.Print
                          },
                          new A.Stretch(
                            new A.FillRectangle())),
                          new PIC.ShapeProperties(
                            new A.Transform2D(
                              new A.Offset() { X = 0L, Y = 0L },
                              new A.Extents() { Cx = 990000L, Cy = 450000L }),
                            new A.PresetGeometry(
                              new A.AdjustValueList()
                            )
                            { Preset = A.ShapeTypeValues.Rectangle }))
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                )
                {
                    DistanceFromTop = (UInt32Value)5U,
                    DistanceFromBottom = (UInt32Value)5U,
                    DistanceFromLeft = (UInt32Value)5U,
                    DistanceFromRight = (UInt32Value)5U
                });

            cell.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(element)));
        }

        public async Task<string> ReplaceTextEvuationDetailPDF(object res)
        {
            _logger.LogInformation("ReplaceTextEvuationDetailPDF - INICIO ");
            var result = (PrintEvaluationDto)res;
            string fullpathdocx = string.Empty;
            string fullpathpdf = string.Empty;
            W.Application appWord = null;
            W.Document wordDocument = null;
            string fileEvaluation = string.Empty;


            string pathDirectory= _appSettings.PathSaveExportDetailEvaluationPDF; 
            string pathTemplate = _appSettings.TemplateExportDetailEvaluation;


            try
            {
                if (!string.IsNullOrWhiteSpace(pathTemplate))
                {
                    _logger.LogInformation("pathTemplate: " + pathTemplate);
                    if (File.Exists(pathTemplate))
                    {
                        string randomnameNew5 = String.Format("evaluacion_{0}{1}{2}{3}", DateTime.Now.ToString("yyyymmdd"), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());

                        bool exists = Directory.Exists(pathDirectory);
                        _logger.LogInformation("pathDirectory: " + pathDirectory);
                        if (!exists)
                            Directory.CreateDirectory(pathDirectory);

                        fullpathdocx = string.Format("{0}{1}.docx", pathDirectory, randomnameNew5);
                        fullpathpdf = string.Format("{0}{1}.pdf", pathDirectory, randomnameNew5);

                        if (File.Exists(fullpathdocx))
                        {
                            File.Delete(fullpathdocx);
                        }
                        _logger.LogInformation("fullpathdocx: " + fullpathdocx);

                        if (File.Exists(fullpathpdf))
                        {
                            File.Delete(fullpathpdf);
                        }
                        _logger.LogInformation("fullpathpdf: " + fullpathpdf);

                        File.Copy(pathTemplate, fullpathdocx);


                        if (File.Exists(fullpathdocx))
                        {
                            _logger.LogInformation("Exists fullpathdocx");
                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullpathdocx, true))
                            {
                                string docText = null;
                                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                                {
                                    docText = sr.ReadToEnd();
                                }

                                var lstReplaces = new List<ReplaceEntity>();

                                string sanio = "";
                                string smes = "";
                                string speriod = "";
                                if (result.header.AdmissionDate == null)
                                {
                                    sanio = "";
                                    smes = "";
                                }
                                else
                                {
                                    string sfecha_period = result.header.AdmissionDate.ToString();
                                    sanio = sfecha_period.Substring(6, 4);
                                    smes = sfecha_period.Substring(3, 2);
                                    speriod = sanio + "-" + smes;
                                }


                                _logger.LogInformation("CAMPANA: " + result.header.Period ?? string.Empty);
                                _logger.LogInformation("ADMISIONDATE: " + result.header.AdmissionDate?? string.Empty);
                                _logger.LogInformation("PERIOD: " + speriod);
                                _logger.LogInformation("CHARGE: " + result.header.scharge_company ?? string.Empty);
                                _logger.LogInformation("EVALUATEDNAME: " + result.header.EvaluatedName ?? string.Empty);
                                _logger.LogInformation("EVALUATEDDNI: " + result.header.EvaluatedDNI ?? string.Empty);
                                _logger.LogInformation("EVALUATORNAME: " + result.header.EvaluatorName ?? string.Empty);
                                _logger.LogInformation("EVALUATORDNI: " + result.header.EvaluatorDNI ?? string.Empty);
                                _logger.LogInformation("AREANAME: " + result.header.ChargeName ?? string.Empty);

                                lstReplaces.Add(new ReplaceEntity() { stag = @"CAMPANA", sreplacetext = result.header.Period ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"ADMISIONDATE", sreplacetext = result.header.AdmissionDate ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"PERIOD", sreplacetext = speriod });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"CHARGE", sreplacetext = result.header.scharge_company ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"EVALUATEDNAME", sreplacetext = result.header.EvaluatedName ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"EVALUATEDDNI", sreplacetext = result.header.EvaluatedDNI ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"EVALUATORNAME", sreplacetext = result.header.EvaluatorName ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"EVALUATORDNI", sreplacetext = result.header.EvaluatorDNI ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"AREANAME", sreplacetext = result.header.ChargeName ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"SUBETAPA", sreplacetext = result.header.substage_evaluation.ToUpper() ?? string.Empty });


                                _logger.LogInformation("var bean in lstReplaces: ");
                                foreach (var bean in lstReplaces)
                                {
                                    string sNombreCampo = bean.stag;
                                    string sValorCampo = bean.sreplacetext;

                                    Regex regexText = new Regex(sNombreCampo);
                                    docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                                }

                                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                                {
                                    sw.Write(docText);
                                }

                                wordDoc.Close();
                            }

                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullpathdocx, true))
                            {
                                _logger.LogInformation("Open Objetivos");
                                string docText = null;

                                var doc = wordDoc.MainDocumentPart.Document;

                                WP.Table table = doc.MainDocumentPart.Document.Body
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Objetivos Puesto"))
                                    .FirstOrDefault();

                                if (table != null)
                                {
                                    WP.TableProperties tblProperties = new WP.TableProperties(
                                   new WP.TableBorders(
                                       new WP.TopBorder()
                                       {
                                           Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                           Color = "8EAADB"
                                       },
                                       new WP.LeftBorder()
                                       {
                                           Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                           Color = "8EAADB"
                                       },
                                       new WP.RightBorder()
                                       {
                                           Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                           Color = "8EAADB"
                                       },
                                       new WP.BottomBorder()
                                       {
                                           Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                           Color = "8EAADB"
                                       }, 
                                       new WP.InsideVerticalBorder()
                                       {
                                           Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                           Color = "8EAADB",
                                           Size = 4
                                       },new WP.InsideHorizontalBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           }
                                           
                                       )
                                   );

                                    table.AppendChild(tblProperties);

                                   
                                    _logger.LogInformation("for icounterforlistaStudients: ");

                                    

                                    #region OBJETIVOS
                                    
                                    var objetives = result.objetives;
                                    _logger.LogInformation("objetives");
                                    foreach (var item in objetives)
                                    {
                                        #region Armando las filas

                                        WP.TableRow tr = new WP.TableRow();

                                        
                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_obj_fecha_ini= NewMergeCellTable(item.fecha_ini ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                        
                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_obj_fecha_fin = NewMergeCellTable(item.fecha_fin ?? string.Empty, MergedCellValues.Restart, "", false, true);
                                        
                                        
                                        String objetivo_puesto = item.objetivo_puesto;
                                        var arreglo_objetivo_puesto = objetivo_puesto.Split("\n");
                                        
                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_objetivo_puesto = new WP.TableCell();
                                        #region Agregar Lista en la Celda
                                        for (int i = 0; i < arreglo_objetivo_puesto.Length; i++)
                                        {
                                            String item_objetivo_puesto = arreglo_objetivo_puesto[i].ToString();

                                           
                                            DocumentFormat.OpenXml.Wordprocessing.Paragraph p1 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                                            
                                            p1.Append(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(item_objetivo_puesto)));
                                            tablecell_objetivo_puesto.Append(p1);
                                        }
                                        #endregion

                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_indicador = NewMergeCellTable(item.indicador ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_meta_texto = NewMergeCellTable(item.smeta ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_meta_porc = NewMergeCellTable(item.nmeta_porc ==0?"-":item.nmeta_porc.ToString(), MergedCellValues.Restart, "", false, true);
                                        
                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_Peso = NewMergeCellTable(item.npeso_porc == 0 ? "-" : item.npeso_porc.ToString(), MergedCellValues.Restart, "", false, true);
                                        
                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_E2_Verificacion = NewMergeCellTable(item.e2_verificacion == 0 ? "-" : item.e2_verificacion.ToString(), MergedCellValues.Restart, "", false, true);
                                        
                                        DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_evaluacion_final0 = NewMergeCellTable(item.e3_eval_final == 0 ? "-" : item.e3_eval_final.ToString(), MergedCellValues.Restart, "", false, true);


                                        tr.Append(tablecell_obj_fecha_ini, tablecell_obj_fecha_fin, tablecell_objetivo_puesto, 
                                                    tablecell_indicador, tablecell_meta_texto, tablecell_meta_porc, tablecell_Peso, tablecell_E2_Verificacion, tablecell_evaluacion_final0);
                                        table.AppendChild(tr);
                                        #endregion
                                    }
                                    #endregion
                                    

                                    #region COMPETENCIAS
                                    
                                    docText = null;

                                    var doc1 = wordDoc.MainDocumentPart.Document;

                                    WP.Table table1 = doc1.MainDocumentPart.Document.Body
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Competencias"))
                                    .FirstOrDefault();
                                    _logger.LogInformation("Competencias" );
                                    if (table1 != null)
                                    {
                                        WP.TableProperties tblProperties1 = new WP.TableProperties(
                                       new WP.TableBorders(
                                           new WP.TopBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.LeftBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.RightBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.BottomBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.InsideVerticalBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.InsideHorizontalBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           }
                                           )
                                       );

                                        table1.AppendChild(tblProperties1);


                                        var competences = result.competencies;
                                        _logger.LogInformation("foreach Competencias");
                                        foreach (var item in competences)
                                        {
                                            #region Armando las filas

                                            WP.TableRow tr = new WP.TableRow();
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_StartDate = NewMergeCellTable(item.fecha_ini ?? string.Empty, MergedCellValues.Restart,"",false,true);
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_EndDate = NewMergeCellTable(item.fecha_fin ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecells_Proficiency = NewMergeCellTable(item.competencia.ToUpper() ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_expectativa = NewMergeCellTable(item.expectativa.ToString() ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                            DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                                                new TableCellWidth { Type = TableWidthUnitValues.Auto, }
                                            );
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.Shading shading =
                                                new DocumentFormat.OpenXml.Wordprocessing.Shading()
                                                {
                                                    Color = "auto",
                                                    Fill = "8CACDA",
                                                    Val = ShadingPatternValues.Clear
                                                };

                                            TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

                                            tcp.Append(tcVA);
                                            tablecell_expectativa.Append(tcp);

                                            
                                            string background_evaluacion="FFFFFF";
                                            decimal _expectativa = item.expectativa;
                                            if (item.e1_auto_evaluacion>=0)
                                            {
                                                if (item.e1_auto_evaluacion < item.expectativa)
                                                {
                                                    background_evaluacion = "FF0000"; 
                                                }
                                                else
                                                {
                                                    if (item.e1_auto_evaluacion == item.expectativa)
                                                    {
                                                        background_evaluacion = "219653"; 
                                                    }
                                                    else
                                                    {
                                                        background_evaluacion = "6366F1";  
                                                    }
                                                }
                                            }

                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_autoevaluacion = NewMergeCellTable(item.e1_auto_evaluacion == -1 || item.e1_auto_evaluacion == 0 ? "-" : item.e1_auto_evaluacion.ToString(), MergedCellValues.Restart, "", false, true,2, background_evaluacion);

                                            
                                            background_evaluacion = "FFFFFF";
                                            if (item.e1_eval_inicial >= 0)
                                            {
                                                if (item.e1_eval_inicial < item.expectativa)
                                                {
                                                    background_evaluacion = "FF0000"; 
                                                }
                                                else
                                                {
                                                    if (item.e1_eval_inicial == item.expectativa) 
                                                    {
                                                        background_evaluacion = "219653"; 
                                                    }
                                                    else 
                                                    {
                                                        background_evaluacion = "6366F1";  
                                                    }
                                                }
                                            }
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_evaluacioninicial = NewMergeCellTable(item.e1_eval_inicial == -1 || item.e1_eval_inicial == 0 ? "-" : item.e1_eval_inicial.ToString(), MergedCellValues.Restart, "", false, true,2, background_evaluacion);

                                            
                                            background_evaluacion = "FFFFFF";
                                            if (item.e2_verificacion >= 0)
                                            {
                                                if (item.e2_verificacion < item.expectativa)
                                                {
                                                    background_evaluacion = "FF0000"; 
                                                }
                                                else
                                                {
                                                    if (item.e2_verificacion == item.expectativa)
                                                    {
                                                        background_evaluacion = "219653"; 
                                                    }
                                                    else
                                                    {
                                                        background_evaluacion = "6366F1";  
                                                    }
                                                }
                                            }
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_verificacion = NewMergeCellTable(item.e2_verificacion == -1 || item.e2_verificacion == 0 ? "-" : item.e2_verificacion.ToString(), MergedCellValues.Restart, "", false, true,2, background_evaluacion);

                                            
                                            background_evaluacion = "FFFFFF";
                                            if (item.e3_eval_final >= 0)
                                            {
                                                if (item.e3_eval_final < item.expectativa)
                                                {
                                                    background_evaluacion = "FF0000"; 
                                                }
                                                else
                                                {
                                                    if (item.e3_eval_final == item.expectativa)
                                                    {
                                                        background_evaluacion = "219653"; 
                                                    }
                                                    else
                                                    {
                                                        background_evaluacion = "6366F1";  
                                                    }
                                                }
                                            }
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_evaluacionfinal = NewMergeCellTable(item.e3_eval_final == -1 || item.e3_eval_final == 0 ? "-" : item.e3_eval_final.ToString(), MergedCellValues.Restart,"", false, true,2, background_evaluacion);

                                            
                                            String plan_accion = item.plan_accion==null? "" : item.plan_accion;
                                            var arreglo_plan_accion = plan_accion.Split("\n");
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_planaccion = new WP.TableCell();
                                            #region Agregar Lista en la Celda
                                            for (int i = 0; i < arreglo_plan_accion.Length; i++)
                                            {
                                                String item_plan_accion=arreglo_plan_accion[i].ToString();
                                                DocumentFormat.OpenXml.Wordprocessing.Paragraph p1 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                                                p1.Append(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(item_plan_accion)));
                                                tablecell_planaccion.Append(p1);
                                            }
                                            #endregion

                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_indicador = NewMergeCellTable(item.indicador ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                            tr.Append(tablecell_StartDate, tablecell_EndDate, tablecells_Proficiency, tablecell_expectativa,
                                                tablecell_autoevaluacion, tablecell_evaluacioninicial, tablecell_verificacion, 
                                                tablecell_evaluacionfinal, tablecell_planaccion,tablecell_indicador
                                                );

                                            table1.AppendChild(tr);
                                            

                                            #endregion
                                        }


                                    }

                                    #endregion
                                    
                                    #region COMENTARIOS
                                    
                                    docText = null;

                                    var doc2 = wordDoc.MainDocumentPart.Document;

                                    WP.Table table2 = doc2.MainDocumentPart.Document.Body
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("Usuario"))
                                    .FirstOrDefault();
                                    _logger.LogInformation("COMENTARIOS");
                                    if (table2 != null)
                                    {
                                        WP.TableProperties tblProperties1 = new WP.TableProperties(
                                       new WP.TableBorders(
                                           new WP.TopBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.LeftBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.RightBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.BottomBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.InsideVerticalBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           },
                                           new WP.InsideHorizontalBorder()
                                           {
                                               Val = new EnumValue<WP.BorderValues>(WP.BorderValues.Thick),
                                               Color = "8EAADB",
                                               Size = 4
                                           }
                                           )
                                       );

                                        table2.AppendChild(tblProperties1);

                                        
                                        var comments =result.comments;
                                        _logger.LogInformation("foreach comments");
                                        foreach (var item in comments)
                                        {
                                            #region Armando las filas

                                            WP.TableRow tr = new WP.TableRow();
                                           
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_susuario = NewMergeCellTable(item.usuario ?? string.Empty, MergedCellValues.Restart, "", false, true);
                                            
                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecells_setapa = NewMergeCellTable(item.etapa ?? string.Empty, MergedCellValues.Restart, "", false, true);

                                            DocumentFormat.OpenXml.Wordprocessing.TableCell tablecell_scomentario = NewMergeCellTable(item.comentario==null || item.comentario==""?"-": item.comentario.ToString(), MergedCellValues.Restart,"",false,true,11);
                                            

                                            tr.Append(tablecell_susuario, tablecells_setapa, tablecell_scomentario);

                                            table2.AppendChild(tr);


                                            #endregion
                                        }


                                    }

                                    #endregion

                                }
                            }

                            try
                            {
                                convertWordToPdf.ExportToPdf(fullpathdocx, fullpathpdf); 

                            }
                            catch (Exception ex)
                            {
                                _logger.LogInformation("ex.StackTrace: " + ex.StackTrace);
                                _logger.LogInformation("ex.Message: " + ex.Message);
                                _logger.LogInformation("ex.TargetSite: " + ex.TargetSite);
                                
                            }
                        }

                         Byte[] bytes5 = File.ReadAllBytes(fullpathpdf);
                       
                        _logger.LogInformation("bytes5: " + bytes5);

                        fileEvaluation = Convert.ToBase64String(bytes5);
                        _logger.LogInformation("filecv: " + fileEvaluation);

                        if (File.Exists(fullpathdocx))
                        {
                            File.Delete(fullpathdocx);
                        }
                        if (File.Exists(fullpathpdf))
                        {
                            File.Delete(fullpathpdf);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error: "+ex.StackTrace);
            }
            _logger.LogInformation("ReplaceTextEvuationDetailPDF - FIN ");
            return fileEvaluation;
        }
        private DocumentFormat.OpenXml.Wordprocessing.TableCell NewCellTable(string stext,string colorText="")
        {
            var newcell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(
                                                     new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                                         new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                                                             new Justification() { Val = JustificationValues.Center }
                                                             , new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }
                                                             ),
                                                         new DocumentFormat.OpenXml.Wordprocessing.Run(
                                                              new DocumentFormat.OpenXml.Wordprocessing.RunProperties(
                                                                  new FontSize() { Val = "20" }, 
                                                                  new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = colorText==""?"black": colorText }
                                                                  ),
                                                             new RunFonts() { Ascii = "Arial" },
                                                             new DocumentFormat.OpenXml.Wordprocessing.Text(stext)))
                                                     );
            DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties();
            TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            tcp.Append(tcVA);
            newcell.Append(tcp);

            return newcell;
        }
        private DocumentFormat.OpenXml.Wordprocessing.TableCell NewCellTableLeft(string stext, string colorText = "")
        {
            var newcell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(
                                                     new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                                         new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                                                             new Justification() { Val = JustificationValues.Left }
                                                             , new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }
                                                             ),
                                                         new DocumentFormat.OpenXml.Wordprocessing.Run(
                                                              new DocumentFormat.OpenXml.Wordprocessing.RunProperties(
                                                                  new FontSize() { Val = "20" },
                                                                  new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = colorText == "" ? "black" : colorText }
                                                                  ),
                                                             new RunFonts() { Ascii = "Arial" },
                                                             new DocumentFormat.OpenXml.Wordprocessing.Text(stext)))
                                                     );
            DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties();
            TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            tcp.Append(tcVA);
            newcell.Append(tcp);

            return newcell;
        }

        private DocumentFormat.OpenXml.Wordprocessing.TableCell NewMergeCellTable(
                    string stext, EnumValue<MergedCellValues> horizontalmerge,
                    string colorText = "", bool fontBold = false,
                    bool horizontaVerticalCenter = false,
                    int justificationOption = 2,
                    string background = "FFFFFF"

            )
        {
            var newcell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(
                                                new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                                    new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                                                             new Justification() { Val = justificationOption == 2 ? JustificationValues.Center : JustificationValues.ThaiDistribute }
                                                             , new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }
                                                             ),
                                                    new DocumentFormat.OpenXml.Wordprocessing.Run(
                                                              new DocumentFormat.OpenXml.Wordprocessing.RunProperties(
                                                                  new Bold() { Val = fontBold == false ? OnOffValue.FromBoolean(false) : OnOffValue.FromBoolean(true) },
                                                                  new FontSize() { Val = "20" },
                                                                  new WP.Color() { Val = colorText == "" ? "black" : colorText }
                                                                  ),
                                                             new RunFonts() { Ascii = "Arial" },
                                                             new DocumentFormat.OpenXml.Wordprocessing.Text(stext))
                                                    ),
                                                new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                                                    new HorizontalMerge() { Val = horizontalmerge }
                                                    )
                                                );
            if (background != "")
            {
                
                DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Auto, }
                );
                
                DocumentFormat.OpenXml.Wordprocessing.Shading shading =
                    new DocumentFormat.OpenXml.Wordprocessing.Shading()
                    {
                        Color = "auto",
                        Fill = background,
                        Val = ShadingPatternValues.Clear
                    };

                if (horizontaVerticalCenter)
                {
                    TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
                    tcp.Append(tcVA);
                }

                
                tcp.Append(shading);
                
                newcell.Append(tcp);
            }




            return newcell;
        }

        private DocumentFormat.OpenXml.Wordprocessing.TableCell NewMergeCellTableForLista(
                    string stext, EnumValue<MergedCellValues> horizontalmerge,
                    string colorText = "", bool fontBold = false,
                    bool horizontaVerticalCenter = false,
                    int justificationOption = 2,
                    string background = "FFFFFF"

            )
        {
            var newcell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(
                                                new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                                    new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                                                             new Justification() { Val = justificationOption == 2 ? JustificationValues.Center : JustificationValues.ThaiDistribute }
                                                             , new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }
                                                             ),
                                                    new DocumentFormat.OpenXml.Wordprocessing.Run(
                                                              new DocumentFormat.OpenXml.Wordprocessing.RunProperties(
                                                                  new Bold() { Val = fontBold == false ? OnOffValue.FromBoolean(false) : OnOffValue.FromBoolean(true) },
                                                                  new FontSize() { Val = "20" },
                                                                  new WP.Color() { Val = colorText == "" ? "black" : colorText }
                                                                  ),
                                                             new RunFonts() { Ascii = "Arial" })
                                                    ),
                                                new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                                                    new HorizontalMerge() { Val = horizontalmerge }
                                                    )
                                                );
            if (background != "")
            {
                
                DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Auto, }
                );
                
                DocumentFormat.OpenXml.Wordprocessing.Shading shading =
                    new DocumentFormat.OpenXml.Wordprocessing.Shading()
                    {
                        Color = "auto",
                        Fill = background,
                        Val = ShadingPatternValues.Clear
                    };

                if (horizontaVerticalCenter)
                {
                    TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
                    tcp.Append(tcVA);
                }

                
                tcp.Append(shading);
                
                newcell.Append(tcp);
            }




            return newcell;
        }

        private DocumentFormat.OpenXml.Wordprocessing.TableCellVerticalAlignment HorizontalVerticalAlignment()
        {
            TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() 
            { 
                Val = TableVerticalAlignmentValues.Center 
            
            };



            return tcVA;
        }


    }


}
