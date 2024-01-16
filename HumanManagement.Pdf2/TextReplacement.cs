using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office.Drawing;
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

namespace HumanManagement.Pdf2
{
    public class TextReplacement : ITextReplacement
    {
        private readonly ILogger<TextReplacement> _logger;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly AppSettings _appSettings;

        public TextReplacement(ILogger<TextReplacement> logger, IConvertWordToPdf convertWordToPdf, IOptions<AppSettings> appSettings)
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
                            // var pictureCell = row.ChildElements.First(c => c.InnerText.Contains("EMPLOYEESIGNATURA"));
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
                                _logger.LogInformation("sfullname: " + employeeCVDto.sfullname);
                                _logger.LogInformation("snamecharge: " + employeeCVDto.snamecharge);
                                _logger.LogInformation("nedad: " + employeeCVDto.nedad);
                                _logger.LogInformation("sidentification: " + employeeCVDto.sidentification);
                                _logger.LogInformation("ssexo: " + employeeCVDto.ssexo);
                                _logger.LogInformation("scivil: " + employeeCVDto.scivil);
                                _logger.LogInformation("phone: " + employeeCVDto.phone);
                                _logger.LogInformation("semail: " + employeeCVDto.semail);
                                _logger.LogInformation("saddress: " + employeeCVDto.saddress);
                                _logger.LogInformation("scompany: " + employeeCVDto.scompany);
                                _logger.LogInformation("snamecharge: " + employeeCVDto.snamecharge);
                                _logger.LogInformation("snamearea: " + employeeCVDto.snamearea);
                                _logger.LogInformation("ssede: " + employeeCVDto.ssede);
                                _logger.LogInformation("sjefe: " + employeeCVDto.sjefe);
                                _logger.LogInformation("dadmissiondate: " + employeeCVDto.dadmissiondate);
                                _logger.LogInformation("sannexed: " + employeeCVDto.sannexed);
                                _logger.LogInformation("scorporatemail: " + employeeCVDto.scorporatemail);
                                _logger.LogInformation("seps: " + employeeCVDto.seps);
                                _logger.LogInformation("MAS: ...............");



                                lstReplaces2.Add(new ReplaceEntity() { stag = @"FECHANACIMIENTO", sreplacetext = employeeCVDto.dbirthdate?.ToString("dd/MM/yyyy") ?? string.Empty });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"INGRESOPAIS", sreplacetext = employeeCVDto.dcountryentrydate?.ToString("dd/MM/yyyy") ?? string.Empty });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"LICENCIACOND", sreplacetext = employeeCVDto.sdrivinglicense });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"LICENCIAMAQ", sreplacetext = employeeCVDto.sheavymachinerylicense });
                                lstReplaces2.Add(new ReplaceEntity() { stag = @"ACT", sreplacetext = employeeCVDto.sstate });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[NOMBRESCOMPLETOS\]", sreplacetext = employeeCVDto.sfullname });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[TITULO\]", sreplacetext = employeeCVDto.snamecharge });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[PERFIL\]", sreplacetext = employeeCVDto.snamecharge });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[EDAD\]", sreplacetext = employeeCVDto.nedad.ToString() });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[DNI\]", sreplacetext = employeeCVDto.sidentification });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[SEXO\]", sreplacetext = employeeCVDto.ssexo });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[ESTADOCIVIL\]", sreplacetext = employeeCVDto.scivil });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[TELEFONO\]", sreplacetext = employeeCVDto.phone });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[CORREO\]", sreplacetext = employeeCVDto.semail });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[DIRECCION\]", sreplacetext = employeeCVDto.saddress });

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
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[PLANPRACTICANTE\]", sreplacetext = employeeCVDto.spracticante });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[AFP\]", sreplacetext = employeeCVDto.safp });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[SCTR\]", sreplacetext = employeeCVDto.ssctr });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"\[VIDALEY\]", sreplacetext = employeeCVDto.svidaley });

                                lstReplaces.Add(new ReplaceEntity() { stag = @"APESPOSA", sreplacetext = employeeCVDto.slastname_partner });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"AMESPOSA", sreplacetext = employeeCVDto.smotherlastname_partner });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"NESPOSA", sreplacetext = employeeCVDto.snamewife_partner });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"ANIOCOMPROMISO", sreplacetext = employeeCVDto.ddateofmarriage?.ToString("dd/MM/yyyy") ?? string.Empty });



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

                                        // Nivel academico
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


                                        // Carrera
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

                                        // Centro de estudios
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

                                        // Situacion actual
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

                                        // Fecha inicio
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

                                        // Fecha fin
                                        _logger.LogInformation("Fecha fin: " + employeeCVDto.listaStudients[icounterforlistaStudients].dateEnd.ToString("dd/MM/yyyy"));
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
                                                        new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].dateEnd.ToString("dd/MM/yyyy")))));



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

                                        // Nombre
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

                                        // Tiempo
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

                                        // Posicion
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

                                        // Funciones
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

                                        // Nombre
                                        var nombreCompletoHijo = ((employeeCVDto.listaSons[icounterforlistaSons].slastname?.ToString() ?? string.Empty) + " " +
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
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(nombreCompletoHijo))));

                                        // Apellido paterno
                                        /*_logger.LogInformation("Apellido paterno: " + employeeCVDto.listaSons[icounterforlistaSons].slastname?.ToString());
                                        WP.TableCell tablecellslastname =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Left }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaSons[icounterforlistaSons].slastname?.ToString() ?? string.Empty))));

                                        // Apellido materno
                                        _logger.LogInformation("Apellido materno: " + employeeCVDto.listaSons[icounterforlistaSons].smotherslastname?.ToString());
                                        WP.TableCell tablecellsmotherslastname =
                                            new WP.TableCell(
                                                new WP.Paragraph(
                                                    new WP.ParagraphProperties(
                                                        new WP.Justification() { Val = WP.JustificationValues.Left }
                                                        ),
                                                    new WP.Run(
                                                        new WP.RunProperties(
                                                            new WP.FontSize() { Val = "16" }
                                                            ),
                                                        new WP.RunFonts() { Ascii = "Arial" },
                                                        new WP.Text(employeeCVDto.listaSons[icounterforlistaSons].smotherslastname?.ToString() ?? string.Empty))));
                                        */
                                        // Fecha nacimiento
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

                                        tr.Append(tablecellsfullname, tablecellddateofbirth);
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
                                //IMAGEN
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

                            try
                            {
                                //appWord = new W.Application();
                                //wordDocument = new W.Document();
                                //wordDocument = appWord.Documents.Open(fullpathdocx);
                                //wordDocument.ExportAsFixedFormat(fullpathpdf, W.WdExportFormat.wdExportFormatPDF);


                                //convertWordToPdf.ExportToPdf(fullpathdocx, fullpathpdf); descomentar

                                //wordDocument.Close();
                                //appWord.Quit();
                            }
                            catch (Exception ex)
                            {
                                _logger.LogInformation("ex.StackTrace: " + ex.StackTrace);
                                _logger.LogInformation("ex.Message: " + ex.Message);
                                _logger.LogInformation("ex.TargetSite: " + ex.TargetSite);
                                if (appWord != null)
                                    appWord.Quit();
                                if (wordDocument != null)
                                    wordDocument.Close();
                            }
                        }

                        //Byte[] bytes5 = File.ReadAllBytes(fullpathpdf);
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

        //public string ReplaceTextCampaignDetailPDF(EmployeeCVDto employeeCVDto, string pathDirectory, string pathTemplate)
        public string ReplaceTextEvuationDetailPDF(object res, string pathDirectory1, string pathTemplate1)
        {
            var result = (FullEvaluationDto)res;
            string fullpathdocx = string.Empty;
            string fullpathpdf = string.Empty;
            W.Application appWord = null;
            W.Document wordDocument = null;
            string filecv = string.Empty;


            string pathDirectory = _appSettings.PathSaveExportDetailEvaluationPDF;
            string pathTemplate = _appSettings.TemplateExportDetailEvaluation;

            try
            {
                if (!string.IsNullOrWhiteSpace(pathTemplate))
                {
                    _logger.LogInformation("pathTemplate: " + pathTemplate);
                    if (File.Exists(pathTemplate))
                    {
                        string randomnameNew5 = "evaluacion_p";

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
                                ////_logger.LogInformation("sfullname: " + employeeCVDto.sfullname);
                                ////_logger.LogInformation("snamecharge: " + employeeCVDto.snamecharge);
                                ////_logger.LogInformation("nedad: " + employeeCVDto.nedad);
                                ////_logger.LogInformation("sidentification: " + employeeCVDto.sidentification);
                                ////_logger.LogInformation("ssexo: " + employeeCVDto.ssexo);
                                ////_logger.LogInformation("scivil: " + employeeCVDto.scivil);
                                ////_logger.LogInformation("phone: " + employeeCVDto.phone);
                                ////_logger.LogInformation("semail: " + employeeCVDto.semail);
                                ////_logger.LogInformation("saddress: " + employeeCVDto.saddress);
                                ////_logger.LogInformation("scompany: " + employeeCVDto.scompany);
                                ////_logger.LogInformation("snamecharge: " + employeeCVDto.snamecharge);
                                ////_logger.LogInformation("snamearea: " + employeeCVDto.snamearea);
                                ////_logger.LogInformation("ssede: " + employeeCVDto.ssede);
                                ////_logger.LogInformation("sjefe: " + employeeCVDto.sjefe);
                                ////_logger.LogInformation("dadmissiondate: " + employeeCVDto.dadmissiondate);
                                ////_logger.LogInformation("sannexed: " + employeeCVDto.sannexed);
                                ////_logger.LogInformation("scorporatemail: " + employeeCVDto.scorporatemail);
                                ////_logger.LogInformation("seps: " + employeeCVDto.seps);
                                ////_logger.LogInformation("MAS: ...............");

                                lstReplaces.Add(new ReplaceEntity() { stag = @"FECHAINGRESO", sreplacetext = result.header.AdmissionDate ?? string.Empty });
                                //lstReplaces2.Add(new ReplaceEntity() { stag = @"PERIODO", sreplacetext = result.header.dcountryentrydate?.ToString("dd/MM/yyyy") ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"PERIODO", sreplacetext = result.header.Period ?? string.Empty });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"CARGO", sreplacetext = result.header.scharge_company });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"EVALUADO", sreplacetext = result.header.EvaluatedName });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"DNIEVALUADO", sreplacetext = result.header.EvaluatedDNI });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"EVALUADOR", sreplacetext = result.header.EvaluatedDNI });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"DNIEVALUADOR", sreplacetext = result.header.EvaluatedDNI });
                                lstReplaces.Add(new ReplaceEntity() { stag = @"AREA", sreplacetext = result.header.ChargeName });


                                ////lstReplaces.Add(new ReplaceEntity() { stag = @"\[AREA\]", sreplacetext = employeeCVDto.snamecharge });
                                ////lstReplaces.Add(new ReplaceEntity() { stag = @"\[EDAD\]", sreplacetext = employeeCVDto.nedad.ToString() });


                                _logger.LogInformation("var bean in lstReplaces: ");

                                ////lstReplaces2.Add(new ReplaceEntity() { stag = @"PASSP", sreplacetext = employeeCVDto.spassport });
                                ////lstReplaces2.Add(new ReplaceEntity() { stag = @"NACLY", sreplacetext = employeeCVDto.snationality });
                                ////lstReplaces2.Add(new ReplaceEntity() { stag = @"TIPSN", sreplacetext = employeeCVDto.sbloodtype });
                                foreach (var bean in lstReplaces)
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
                                    .Descendants<WP.Table>().Where(tbl => tbl.InnerText.Contains("FechaInicio"))
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
                                    //for (icounterforlistaStudients = 0; icounterforlistaStudients < employeeCVDto.listaStudients.Count; icounterforlistaStudients++)
                                    //{
                                    //    #region Armando las filas

                                    //    WP.TableRow tr = new WP.TableRow();

                                    //    // Nivel academico
                                    //    _logger.LogInformation("Nivel academico: " + employeeCVDto.listaStudients[icounterforlistaStudients].sdescription_value?.ToString());
                                    //    WP.TableCell tablecellsdescription_value =
                                    //        new WP.TableCell(
                                    //            new WP.Paragraph(
                                    //                new WP.ParagraphProperties(
                                    //                    new WP.Justification() { Val = WP.JustificationValues.Center }
                                    //                    ),
                                    //                new WP.Run(
                                    //                    new WP.RunProperties(
                                    //                        new WP.FontSize() { Val = "16" }
                                    //                        ),
                                    //                    new WP.RunFonts() { Ascii = "Arial" },
                                    //                    new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].sdescription_value?.ToString() ?? string.Empty))));


                                    //    // Carrera
                                    //    _logger.LogInformation("Carrera: " + employeeCVDto.listaStudients[icounterforlistaStudients].scarreer?.ToString());
                                    //    WP.TableCell tablecellscarreer =
                                    //        new WP.TableCell(
                                    //            new WP.Paragraph(
                                    //                new WP.ParagraphProperties(
                                    //                    new WP.Justification() { Val = WP.JustificationValues.Center }
                                    //                    ),
                                    //                new WP.Run(
                                    //                    new WP.RunProperties(
                                    //                        new WP.FontSize() { Val = "16" }
                                    //                        ),
                                    //                    new WP.RunFonts() { Ascii = "Arial" },
                                    //                    new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].scarreer?.ToString() ?? string.Empty))));

                                    //    // Centro de estudios
                                    //    _logger.LogInformation("Centro de estudios: " + employeeCVDto.listaStudients[icounterforlistaStudients].sstudy_center?.ToString());
                                    //    WP.TableCell tablecellssstudy_center =
                                    //        new WP.TableCell(
                                    //            new WP.Paragraph(
                                    //                new WP.ParagraphProperties(
                                    //                    new WP.Justification() { Val = WP.JustificationValues.Center }
                                    //                    ),
                                    //                new WP.Run(
                                    //                    new WP.RunProperties(
                                    //                        new WP.FontSize() { Val = "16" }
                                    //                        ),
                                    //                    new WP.RunFonts() { Ascii = "Arial" },
                                    //                    new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].sstudy_center?.ToString() ?? string.Empty))));

                                    //    // Situacion actual
                                    //    _logger.LogInformation("Situacion actual: " + employeeCVDto.listaStudients[icounterforlistaStudients].scurrent_cycle?.ToString());
                                    //    WP.TableCell tablecellscurrent_cycle =
                                    //        new WP.TableCell(
                                    //            new WP.Paragraph(
                                    //                new WP.ParagraphProperties(
                                    //                    new WP.Justification() { Val = WP.JustificationValues.Center }
                                    //                    ),
                                    //                new WP.Run(
                                    //                    new WP.RunProperties(
                                    //                        new WP.FontSize() { Val = "16" }
                                    //                        ),
                                    //                    new WP.RunFonts() { Ascii = "Arial" },
                                    //                    new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].scurrent_cycle?.ToString() ?? string.Empty))));

                                    //    // Fecha inicio
                                    //    _logger.LogInformation("Fecha inicio: " + employeeCVDto.listaStudients[icounterforlistaStudients].dateStart.ToString("dd/MM/yyyy"));
                                    //    WP.TableCell tablecelldateStart =
                                    //        new WP.TableCell(
                                    //            new WP.Paragraph(
                                    //                new WP.ParagraphProperties(
                                    //                    new WP.Justification() { Val = WP.JustificationValues.Center }
                                    //                    ),
                                    //                new WP.Run(
                                    //                    new WP.RunProperties(
                                    //                        new WP.FontSize() { Val = "16" }
                                    //                        ),
                                    //                    new WP.RunFonts() { Ascii = "Arial" },
                                    //                    new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].dateStart.ToString("dd/MM/yyyy")))));

                                    //    // Fecha fin
                                    //    _logger.LogInformation("Fecha fin: " + employeeCVDto.listaStudients[icounterforlistaStudients].dateEnd.ToString("dd/MM/yyyy"));
                                    //    WP.TableCell tablecelldateEnd =
                                    //        new WP.TableCell(
                                    //            new WP.Paragraph(
                                    //                new WP.ParagraphProperties(
                                    //                    new WP.Justification() { Val = WP.JustificationValues.Center }
                                    //                    ),
                                    //                new WP.Run(
                                    //                    new WP.RunProperties(
                                    //                        new WP.FontSize() { Val = "16" }
                                    //                        ),
                                    //                    new WP.RunFonts() { Ascii = "Arial" },
                                    //                    new WP.Text(employeeCVDto.listaStudients[icounterforlistaStudients].dateEnd.ToString("dd/MM/yyyy")))));



                                    //    tr.Append(tablecellsdescription_value, tablecellscarreer, tablecellssstudy_center, tablecellscurrent_cycle, tablecelldateStart, tablecelldateEnd);
                                    //    table.AppendChild(tr);
                                    //    #endregion
                                    //}

                                }

                            }




                            try
                            {
                                appWord = new W.Application();
                                wordDocument = new W.Document();
                                wordDocument = appWord.Documents.Open(fullpathdocx);
                                wordDocument.ExportAsFixedFormat(fullpathpdf, W.WdExportFormat.wdExportFormatPDF);


                                convertWordToPdf.ExportToPdf(fullpathdocx, fullpathpdf);

                                wordDocument.Close();
                                appWord.Quit();
                            }
                            catch (Exception ex)
                            {
                                _logger.LogInformation("ex.StackTrace: " + ex.StackTrace);
                                _logger.LogInformation("ex.Message: " + ex.Message);
                                _logger.LogInformation("ex.TargetSite: " + ex.TargetSite);
                                if (appWord != null)
                                    appWord.Quit();
                                if (wordDocument != null)
                                    wordDocument.Close();
                            }
                        }

                        //Byte[] bytes5 = File.ReadAllBytes(fullpathpdf);
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
                            //File.Delete(fullpathpdf);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return filecv;
        }


    }
}
