
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Postulant.Education.Dto;
using HumanManagement.Domain.Postulant.Languages.Dto;
using HumanManagement.Domain.Postulant.Skills.Dto;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Globalization;
using HumanManagement.Domain.Postulant.Person.Dto;

namespace HumanManagement.Application.Postulant.Commands
{
    public class GenerateWord
    {
        public bool GenertaWordByPath(string fullpath, List<WorkExperienceDto> lstWorks, 
            List<EducationPostulantDto> lstEducations, List<SkillsPostulantDto> lstSkills, List<LanguagePostulantDto> lstLanguages, PersonDto person)
        {
            var _result = false;

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;

            formato.CurrencyGroupSeparator = ",";
            formato.NumberDecimalSeparator = ".";

            
            List<ReplaceEntity> lstReplaces = new List<ReplaceEntity>();
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[NOMBRESCOMPLETOS\]", sreplacetext = string.Concat(person?.FirstName.ToUpper(), ' ', person?.LastName.ToUpper()) });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[FECHANACIMIENTO\]", sreplacetext = person?.BirthDate });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[SEXO\]", sreplacetext = person?.SexComplete });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[ESTADOCIVIL\]", sreplacetext = person?.CivilStatus });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[NUM\]", sreplacetext = person?.DocumentNumber });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[CELULAR\]", sreplacetext = person?.CellPhone });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[CORREO\]", sreplacetext = person?.Email });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[DIRECCION\]", sreplacetext = person?.Address });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[REFERENCIA_LABORAL\]", sreplacetext = person?.LaboralObjective });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[TIPODOCUMENTO\]", sreplacetext = person?.DocumentType });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[TELEFONO\]", sreplacetext = person?.AnotherPhone });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[NACLY\]", sreplacetext = person?.Nationality });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[LICENCIACOND\]", sreplacetext = person?.LicenceDrive });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[LINKEDIN\]", sreplacetext = person?.UrlProfesional });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[SALARIO\]", sreplacetext = person?.SalaryPretesion });
            lstReplaces.Add(new ReplaceEntity() { stag = @"\[SKILLS\]", sreplacetext = person?.Skills });

            if (File.Exists(fullpath))
            {
                using (WordprocessingDocument _wordDoc = WordprocessingDocument.Open(fullpath, true))
                {
                    try
                    {
                        string docText = null;
                        using (StreamReader sr = new StreamReader(_wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        foreach (var bean in lstReplaces)
                        {
                            string sNombreCampo = bean.stag;
                            string sValorCampo = bean.sreplacetext;

                            Regex regexText = new Regex(sNombreCampo);
                            docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                        }

                        using (StreamWriter sw = new StreamWriter(_wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }

                        #region "Experiencia Laboral"
                        var _idChunk = 0;
                        var _sidChunk = "";
                        lstWorks = lstWorks.OrderBy(x => x.YearStart).ToList();
                        foreach (var _work in lstWorks)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.Text _text = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_WORKS]"))
                                           .FirstOrDefault();
                            MainDocumentPart mainDocPart = _wordDoc.MainDocumentPart;
                            if (_text != null) 
                            {
                                _idChunk++;
                                _sidChunk = string.Format("Chunk{0}", _idChunk);
                                var parent = _text.Parent.Parent;

                                Table table = new Table();
                                
                                TableRow _tr1 = new TableRow(new SpacingBetweenLines() { After = "0", Before = "0" });
                                TableCell _tc1 = new TableCell(new SpacingBetweenLines() { After = "0", Before = "0" });
                                var _run = new Run(new Text(string.Format("Cargo: {0}", _work.Stand.ToUpper())));
                                RunProperties runPropertieBold = new RunProperties();
                                runPropertieBold.Append(new Bold());
                                _run.RunProperties = runPropertieBold;

                                var _paragraph = new Paragraph();
                                ParagraphProperties paragraphProperties = new ParagraphProperties();
                                SpacingBetweenLines spacing = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties.Append(spacing);
                                _paragraph.Append(paragraphProperties);
                                _paragraph.Append(_run);

                                _tc1.Append(_paragraph);
                                _tr1.Append(_tc1);

                                
                                TableRow _tr2 = new TableRow(new SpacingBetweenLines() { After = "0", Before = "0" });
                                TableCell _tc2 = new TableCell(new SpacingBetweenLines() { After = "0", Before = "0" });
                                var _run2 = new Run(new Text(string.Format("Empresa: {0}", _work.Company.ToUpper())));
                                RunProperties runPropertieBold2 = new RunProperties(
                                    new Bold(),
                                    new RunFonts() { Ascii = "Calibri" });
                                _run2.RunProperties = runPropertieBold2;
                                
                                var _paragraph2 = new Paragraph();
                                ParagraphProperties paragraphProperties2 = new ParagraphProperties();
                                SpacingBetweenLines spacing2 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties2.Append(spacing2);
                                _paragraph2.Append(paragraphProperties2);
                                _paragraph2.Append(_run2);

                                _tc2.Append(_paragraph2);
                                _tr2.Append(_tc2);

                                
                                TableRow _tr3 = new TableRow();
                                TableCell _tc3 = new TableCell();
                                var _run3 = new Run();
                                if (_work.Present == true) { _run3 = new Run(new Text(string.Format("{0} {1} - Al presente", _work.MonthStart, _work.YearStart))); }
                                else { _run3 = new Run(new Text(string.Format("{0} {1} - {2} {3}", _work.MonthStart, _work.YearStart, _work.MonthEnd, _work.YearEnd))); }

                                var _paragraph3 = new Paragraph();
                                ParagraphProperties paragraphProperties3 = new ParagraphProperties();
                                SpacingBetweenLines spacing3 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties3.Append(spacing3);
                                _paragraph3.Append(paragraphProperties3);
                                _paragraph3.Append(_run3);

                                _tc3.Append(_paragraph3);
                                _tr3.Append(_tc3);
                                
                                
                                TableRow _tr4 = new TableRow();
                                TableCell _tc4 = new TableCell();
                                
                                string _html = "<meta charset='UTF-8'><html><head/><style> p,ul,li { margin-top: 0px !important; margin-bottom: 0px !important;} body { font-family:'Calibri' !important; font-size: 11pt !important} </style><body>" + _work.DescriptionResponsabilities + "</body></html>";

                                string altChunkId = _sidChunk;
                                MainDocumentPart mainPart = _wordDoc.MainDocumentPart;
                                AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart("application/xhtml+xml", altChunkId);

                                using (Stream chunkStream = chunk.GetStream(FileMode.Create, FileAccess.Write))
                                using (StreamWriter stringStream = new StreamWriter(chunkStream))
                                    stringStream.Write(_html);

                                AltChunk _altChunk = new AltChunk();
                                _altChunk.Id = altChunkId;

                                
                                var _paragraph4 = new Paragraph();
                                var _run4 = new Run(new Text(""));
                                ParagraphProperties paragraphProperties4 = new ParagraphProperties();
                                SpacingBetweenLines spacing4 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties4.Append(spacing4);
                                _paragraph4.Append(paragraphProperties4);
                                _paragraph4.Append(_run4);

                                _tc4.Append(_paragraph4);
                                _tc4.InsertAfter(_altChunk, _tc4.Elements<Paragraph>().Last());
                                var _para = _tc4.Elements<Paragraph>().Last();
                                _para.Remove();
                                _tr4.Append(_tc4);


                                
                                TableRow _tr5 = new TableRow();
                                TableCell _tc5 = new TableCell();
                                var _run5 = new Run(new Text(string.Format("Personas a cargo: {0}", _work.IdPeopleCharge)));
                                
                                var _paragraph5 = new Paragraph();
                                ParagraphProperties paragraphProperties5 = new ParagraphProperties();
                                SpacingBetweenLines spacing5 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties5.Append(spacing5);
                                _paragraph5.Append(paragraphProperties5);
                                _paragraph5.Append(_run5);

                                _tc5.Append(_paragraph5);
                                _tr5.Append(_tc5);

                                
                                TableRow _tr6 = new TableRow();
                                TableCell _tc6 = new TableCell();
                                decimal _salario = 0;
                                var _run6 = new Run();
                                if (!string.IsNullOrEmpty(_work.Salary))
                                {
                                    _salario = Convert.ToDecimal(_work.Salary);
                                    _run6 = new Run(new Text(string.Format("Sueldo percibido: S/ {0}", _salario.ToString("N", formato))));
                                } else _run6 = new Run(new Text(string.Format("Sueldo percibido: -")));

                                var _paragraph6 = new Paragraph();
                                ParagraphProperties paragraphProperties6 = new ParagraphProperties();
                                SpacingBetweenLines spacing6 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties6.Append(spacing6);
                                _paragraph6.Append(paragraphProperties6);
                                _paragraph6.Append(_run6);

                                _tc6.Append(_paragraph6);
                                _tr6.Append(_tc6);

                                
                                TableRow _tr7 = new TableRow();
                                TableCell _tc7 = new TableCell();
                                var _run7 = new Run(new Text(string.Empty));

                                var _paragraph7 = new Paragraph();
                                ParagraphProperties paragraphProperties7 = new ParagraphProperties();
                                SpacingBetweenLines spacing7 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties7.Append(spacing7);
                                _paragraph7.Append(paragraphProperties7);
                                _paragraph7.Append(_run7);

                                _tc7.Append(_paragraph7);
                                _tr7.Append(_tc7);

                                
                                TableRow _tr0 = new TableRow();
                                TableCell _tc0 = new TableCell();
                                var _run0 = new Run(new Text(string.Empty));

                                var _paragraph0 = new Paragraph();
                                ParagraphProperties paragraphProperties0 = new ParagraphProperties();
                                SpacingBetweenLines spacing0 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties0.Append(spacing0);
                                _paragraph0.Append(paragraphProperties0);
                                _paragraph0.Append(_run0);

                                _tc0.Append(_paragraph0);
                                _tr0.Append(_tc0);

                                table.Append(_tr0);
                                table.Append(_tr1);
                                table.Append(_tr2);
                                table.Append(_tr3);
                                table.Append(_tr4);
                                table.Append(_tr5);
                                table.Append(_tr6);
                                table.Append(_tr7);
                                parent.InsertAfter(table, _text.Parent);

                                List<Run> _runsExisting = table.Descendants<Run>().ToList();
                                foreach (var _runnn in _runsExisting)
                                {
                                    RunProperties prop = new RunProperties(
                                                                new RunFonts() { Ascii = "Calibri" });
                                    _runnn.Append(prop);
                                }
                                _wordDoc.MainDocumentPart.Document.Save();
                            }                            
                        }

                        DocumentFormat.OpenXml.Wordprocessing.Text _replaceText = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_WORKS]"))
                                           .FirstOrDefault();
                        if(_replaceText != null) _replaceText.Text = _replaceText.Text.Replace("[TABLE_WORKS]", "");

                        #endregion

                        #region "Educacion"
                        lstEducations = lstEducations.OrderBy(x => x.YearStart).ToList();
                        foreach (var _education in lstEducations)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.Text _textEducation = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_EDUCATIONS]"))
                                           .FirstOrDefault();

                            if (_textEducation != null)
                            {
                                var parentEducation = _textEducation.Parent.Parent;

                                Table table = new Table();
                                
                                TableRow _tr1 = new TableRow();
                                TableCell _tc1 = new TableCell();
                                var _run1 = new Run(new Text(string.Format("Carrera: {0}", _education.Carreer.ToUpper())));
                                RunProperties runPropertieBold = new RunProperties();
                                runPropertieBold.Append(new Bold());
                                _run1.RunProperties = runPropertieBold;

                                var _paragraph1 = new Paragraph();
                                ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                                SpacingBetweenLines spacing1 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties1.Append(spacing1);
                                _paragraph1.Append(paragraphProperties1);
                                _paragraph1.Append(_run1);

                                _tc1.Append(_paragraph1);
                                _tr1.Append(_tc1);

                                
                                TableRow _tr2 = new TableRow();
                                TableCell _tc2 = new TableCell();
                                var _run2 = new Run();
                                if (!string.IsNullOrEmpty(_education.Institution))
                                {
                                    _run2 = new Run(new Text(string.Format("Institución Educativa: {0}, {1}", _education.Institution.ToUpper(), _education.Country)));
                                }
                                else _run2 = new Run(new Text(string.Format("Institución Educativa: {0}, {1}", _education.OtherInstitution.ToUpper(), _education.Country)));

                                var _paragraph2 = new Paragraph();
                                ParagraphProperties paragraphProperties2 = new ParagraphProperties();
                                SpacingBetweenLines spacing2 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties2.Append(spacing2);
                                _paragraph2.Append(paragraphProperties2);
                                _paragraph2.Append(_run2);

                                _tc2.Append(_paragraph2);
                                _tr2.Append(_tc2);

                                
                                TableRow _tr3 = new TableRow();
                                TableCell _tc3 = new TableCell();
                                var _run3 = new Run(new Text(string.Format("{0}, {1}", _education.DescriptionTypeStudy, _education.DescriptionState)));

                                var _paragraph3 = new Paragraph();
                                ParagraphProperties paragraphProperties3 = new ParagraphProperties();
                                SpacingBetweenLines spacing3 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties3.Append(spacing3);
                                _paragraph3.Append(paragraphProperties3);
                                _paragraph3.Append(_run3);

                                _tc3.Append(_paragraph3);
                                _tr3.Append(_tc3);

                                
                                TableRow _tr4 = new TableRow();
                                TableCell _tc4 = new TableCell();
                                var _run4 = new Run();
                                if (_education.Present == true) _run4 = new Run(new Text(string.Format("{0} {1} - Al presente", _education.MonthStart, _education.YearStart)));
                                else _run4 = new Run(new Text(string.Format("{0} {1} - {2} {3}", _education.MonthStart, _education.YearStart, _education.MonthEnd, _education.YearEnd)));

                                var _paragraph4 = new Paragraph();
                                ParagraphProperties paragraphProperties4 = new ParagraphProperties();
                                SpacingBetweenLines spacing4 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties4.Append(spacing4);
                                _paragraph4.Append(paragraphProperties4);
                                _paragraph4.Append(_run4);

                                _tc4.Append(_paragraph4);
                                _tr4.Append(_tc4);

                                
                                TableRow _tr5 = new TableRow();
                                TableCell _tc5 = new TableCell();
                                var _run5 = new Run(new Text(string.Empty));

                                var _paragraph5 = new Paragraph();
                                ParagraphProperties paragraphProperties5 = new ParagraphProperties();
                                SpacingBetweenLines spacing5 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties5.Append(spacing5);
                                _paragraph5.Append(paragraphProperties5);
                                _paragraph5.Append(_run5);

                                _tc5.Append(_paragraph5);
                                _tr5.Append(_tc5);

                                
                                TableRow _tr0 = new TableRow();
                                TableCell _tc0 = new TableCell();
                                var _run0 = new Run(new Text(string.Empty));

                                var _paragraph0 = new Paragraph();
                                ParagraphProperties paragraphProperties0 = new ParagraphProperties();
                                SpacingBetweenLines spacing0 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties0.Append(spacing0);
                                _paragraph0.Append(paragraphProperties0);
                                _paragraph0.Append(_run0);

                                _tc0.Append(_paragraph0);
                                _tr0.Append(_tc0);

                                table.Append(_tr0);
                                table.Append(_tr1);
                                table.Append(_tr2);
                                table.Append(_tr3);
                                table.Append(_tr4);
                                table.Append(_tr5);
                                parentEducation.InsertAfter(table, _textEducation.Parent);

                                _wordDoc.MainDocumentPart.Document.Save();
                            }
                        }

                        DocumentFormat.OpenXml.Wordprocessing.Text _replaceTextEducation = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_EDUCATIONS]"))
                                           .FirstOrDefault();
                        if (_replaceTextEducation != null) _replaceTextEducation.Text = _replaceTextEducation.Text.Replace("[TABLE_EDUCATIONS]", "");
                        #endregion

                        #region "Conocimientos y Habilidades"
                        foreach (var _skill in lstSkills)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.Text _textSkill = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_SKILLS]"))
                                           .FirstOrDefault();

                            if (_textSkill != null)
                            {
                                var parentSkill = _textSkill.Parent.Parent;

                                Table table = new Table();
                                
                                TableRow _tr1 = new TableRow();
                                TableCell _tc1 = new TableCell();
                                _tc1.Append(new Paragraph(new Run(new Text(_skill.DescriptionSkill))));
                                _tr1.Append(_tc1);

                                table.Append(_tr1);
                                parentSkill.InsertAfter(table, _textSkill.Parent);

                                _wordDoc.MainDocumentPart.Document.Save();
                            }
                        }

                        DocumentFormat.OpenXml.Wordprocessing.Text _replaceTextSkill = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_SKILLS]"))
                                           .FirstOrDefault();
                        if (_replaceTextSkill != null) _replaceTextSkill.Text = _replaceTextSkill.Text.Replace("[TABLE_SKILLS]", "");
                        #endregion

                        #region "Idiomas"
                        foreach (var _language in lstLanguages)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.Text _textLanguage = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_LANGUAGES]"))
                                           .FirstOrDefault();

                            if (_textLanguage != null)
                            {
                                var parentLanguage = _textLanguage.Parent.Parent; 

                                Table table = new Table();
                                
                                TableRow _tr1 = new TableRow();
                                TableCell _tc1 = new TableCell();
                                var _run1 = new Run(new Text(_language.DescripcionLang.ToUpper()));
                                RunProperties runPropertieBold = new RunProperties();
                                runPropertieBold.Append(new Bold());
                                _run1.RunProperties = runPropertieBold;

                                var _paragraph1 = new Paragraph();
                                ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                                SpacingBetweenLines spacing1 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties1.Append(spacing1);
                                _paragraph1.Append(paragraphProperties1);
                                _paragraph1.Append(_run1);

                                _tc1.Append(_paragraph1);
                                _tr1.Append(_tc1);

                                
                                TableRow _tr2 = new TableRow();
                                TableCell _tc2 = new TableCell();
                                var _run2 = new Run(new Text(string.Format("Escrito: {0}", _language.DescriptionWrittenLeven)));

                                var _paragraph2 = new Paragraph();
                                ParagraphProperties paragraphProperties2 = new ParagraphProperties();
                                SpacingBetweenLines spacing2 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties2.Append(spacing2);
                                _paragraph2.Append(paragraphProperties2);
                                _paragraph2.Append(_run2);

                                _tc2.Append(_paragraph2);
                                _tr2.Append(_tc2);

                                
                                TableRow _tr3 = new TableRow();
                                TableCell _tc3 = new TableCell();
                                var _run3 = new Run(new Text(string.Format("Escrito: {0}", _language.DescriptionOralLeven)));
                                var _paragraph3 = new Paragraph();
                                ParagraphProperties paragraphProperties3 = new ParagraphProperties();
                                SpacingBetweenLines spacing3 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties3.Append(spacing3);
                                _paragraph3.Append(paragraphProperties3);
                                _paragraph3.Append(_run3);

                                _tc3.Append(_paragraph3);
                                _tr3.Append(_tc3);

                                
                                TableRow _tr4 = new TableRow();
                                TableCell _tc4 = new TableCell();
                                var _run4 = new Run(new Text(string.Empty));
                                var _paragraph4 = new Paragraph();
                                ParagraphProperties paragraphProperties4 = new ParagraphProperties();
                                SpacingBetweenLines spacing4 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties4.Append(spacing4);
                                _paragraph4.Append(paragraphProperties4);
                                _paragraph4.Append(_run4);

                                _tc4.Append(_paragraph4);
                                _tr4.Append(_tc4);

                                
                                TableRow _tr0 = new TableRow();
                                TableCell _tc0 = new TableCell();
                                var _run0 = new Run(new Text(string.Empty));
                                var _paragraph0 = new Paragraph();
                                ParagraphProperties paragraphProperties0 = new ParagraphProperties();
                                SpacingBetweenLines spacing0 = new SpacingBetweenLines() { After = "0" };
                                paragraphProperties0.Append(spacing0);
                                _paragraph0.Append(paragraphProperties0);
                                _paragraph0.Append(_run0);

                                _tc0.Append(_paragraph0);
                                _tr0.Append(_tc0);

                                table.Append(_tr0);
                                table.Append(_tr1);
                                table.Append(_tr2);
                                table.Append(_tr3);
                                table.Append(_tr4);
                                parentLanguage.InsertAfter(table, _textLanguage.Parent);

                                _wordDoc.MainDocumentPart.Document.Save();
                            }
                        }

                        DocumentFormat.OpenXml.Wordprocessing.Text _replaceTextLanguage = _wordDoc.MainDocumentPart.Document.Body
                                           .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Where(tbl => tbl.InnerText.ToUpper().Contains("[TABLE_LANGUAGES]"))
                                           .FirstOrDefault();
                        if (_replaceTextLanguage != null) _replaceTextLanguage.Text = _replaceTextLanguage.Text.Replace("[TABLE_LANGUAGES]", "");
                        #endregion

                        using (StreamWriter sw = new StreamWriter(_wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }

                        _result = true;
                        _wordDoc.Close();
                    }
                    catch (Exception ex)
                    {
                        _result = true;
                        _wordDoc.Close();
                    }
                }

                #region "Foto de Perfil"
                if (File.Exists(person.Img))
                {
                    using (WordprocessingDocument _wordDoc = WordprocessingDocument.Open(fullpath, true))
                    {
                        string fullPathImage = string.Empty;
                        
                        fullPathImage = person.Img;
                        MainDocumentPart mainPart = _wordDoc.MainDocumentPart;
                        ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                        using (FileStream stream = new FileStream(fullPathImage, FileMode.Open))
                        {
                            imagePart.FeedData(stream);
                        }
                        var element = new Drawing(

                                    new DW.Inline(
                                    new DW.Extent() { Cx = 900000L, Cy = 950000L },
                                    new DW.EffectExtent()
                                    {
                                        LeftEdge = 0L,
                                        TopEdge = 0L,
                                        RightEdge = 0L,
                                        BottomEdge = 0L
                                    },
                                    new DW.DocProperties()
                                    {
                                        Id = (UInt32Value)1U,
                                        Name = "Profile"
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
                                                        Name = "Profile.jpg"
                                                    },
                                                    new PIC.NonVisualPictureDrawingProperties()),
                                                new PIC.BlipFill(
                                                    new A.Blip(
                                                        new A.BlipExtensionList(
                                                            new A.BlipExtension()
                                                            {
                                                                Uri =
                                                                  "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                            })
                                                    )
                                                    {
                                                        Embed = mainPart.GetIdOfPart(imagePart),
                                                        CompressionState =
                                                        A.BlipCompressionValues.Print
                                                    },
                                                    new A.Stretch(
                                                        new A.FillRectangle())),
                                                new PIC.ShapeProperties(
                                                    new A.Transform2D(
                                                        new A.Offset() { X = 0L, Y = 0L },
                                                        new A.Extents() { Cx = 900000L, Cy = 950000L }),
                                                    new A.PresetGeometry(
                                                        new A.AdjustValueList()
                                                    )
                                                    { Preset = A.ShapeTypeValues.Rectangle }))
                                        )
                                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                    )
                                    {
                                        DistanceFromTop = (UInt32Value)0U,
                                        DistanceFromBottom = (UInt32Value)0U,
                                        DistanceFromLeft = (UInt32Value)0U,
                                        DistanceFromRight = (UInt32Value)0U,
                                        EditId = "50D07946"
                                    }
                                );
                        try
                        {
                            Text textPlaceHolder = _wordDoc.MainDocumentPart.Document.Body.Descendants<Text>()
                             .Where((x) => x.Text == "[IMAGEN_FOTO]").First();
                            if (textPlaceHolder != null)
                            {
                                var parent = textPlaceHolder.Parent;
                                if ((parent is Run))
                                {
                                    textPlaceHolder.Parent.InsertAfter<Drawing>(element, textPlaceHolder);
                                    textPlaceHolder.Remove();
                                }
                            }

                            string docText = null;
                            using (StreamReader sr = new StreamReader(_wordDoc.MainDocumentPart.GetStream()))
                            {
                                docText = sr.ReadToEnd();
                            }
                        }
                        catch (Exception ex)
                        {
                            var error = ex;
                        } finally
                        {
                            _wordDoc.Close();
                        }
                    }
                }
                #endregion
            }

            return _result;
        }

        private Style CreateTableCharacterStyle()
        {
            Style styl = new Style()
            {
                CustomStyle = true,
                StyleId = "Table9Point",
                Type = StyleValues.Character,
            };
            StyleName stylName = new StyleName() { Val = "Table9Point" };
            styl.AppendChild(stylName);
            StyleRunProperties stylRunProps = new StyleRunProperties();
            stylRunProps.FontSize = new FontSize() { Val = "24" };
            styl.AppendChild(stylRunProps);
            BasedOn basedOn1 = new BasedOn() { Val = "DefaultParagraphFont" };
            styl.AppendChild(basedOn1);
            return styl;
        }

        private string ReplaceSpecialCharacters(string str)
        {
            if (String.IsNullOrEmpty(str)) return string.Empty;
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\"", "&quot;");
            str = str.Replace("'", "&apos;");
            return str.ToString();
        }
    }
}
