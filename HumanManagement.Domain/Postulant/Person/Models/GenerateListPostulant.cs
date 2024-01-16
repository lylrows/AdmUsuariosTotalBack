using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Postulant.Person.Dto;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using System;
using System.Text.RegularExpressions;
using HumanManagement.Domain.Postulant.Person.QueryFilter;
using Microsoft.Extensions.Logging;

namespace HumanManagement.Domain.Postulant.Person.Models
{
    public class GenerateListPostulant
    {
        
        public List<PostulantDto> postulantList;
        private List<JobKeyWordDto> jobKeyWordList;
        private List<PostulantSkillsDto> postulantSkillList;
        private List<WorkExperienceDto> workExperienceList;
        private PostulantQueryFilter postulantQueryFilter;
        public List<PostulantDto> PostulantOrderList { get; private set; }
        public GenerateListPostulant(List<PostulantDto> postulantList,
                                     List<JobKeyWordDto> jobKeyWordList,
                                     List<PostulantSkillsDto> postulantSkillList,
                                     List<WorkExperienceDto> workExperienceList,
                                     PostulantQueryFilter postulantQueryFilter)
        {
            this.postulantList = postulantList;
            this.jobKeyWordList = jobKeyWordList;
            this.postulantSkillList = postulantSkillList;
            this.workExperienceList = workExperienceList; 
            this.postulantQueryFilter = postulantQueryFilter;
        } 

        public void Generate()
        {
            SetListPostulant();
            OrderListByTotalSkillAndName();
        }
        private void SetListPostulant()
        {
            using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
                                        .SetMinimumLevel(LogLevel.Trace));

            ILogger logger = loggerFactory.CreateLogger<GenerateListPostulant>();

            double totalSkillsJob = jobKeyWordList.Count();
            double contadorValidacion = 0;
            double contadorNuevasKeys = 0;

            postulantList.ForEach(x =>
            {
                contadorValidacion = 0;
                contadorNuevasKeys = 0;
                var flagCarrera = 0;
                logger.LogInformation(String.Format("Postulant Info => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(x)));
                logger.LogInformation(String.Format("postulantQueryFilter Info => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(postulantQueryFilter)));
                logger.LogInformation(String.Format("x.Scareer_position => {0}", x.Scareer_position));
                logger.LogInformation(String.Format("x.Scareer_postulant => {0}", x.Scareer_postulant));
                if (!String.IsNullOrEmpty(x.Scareer_position) && !String.IsNullOrEmpty(x.Scareer_postulant))
                {

                    foreach(var item in x.Scareer_position.Split("|"))
                    {
                        var text = Regex.Replace(item.ToString().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                        var select = x.Scareer_postulant.Split("|").ToList().Where(x => Regex.Replace(x.ToString().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "") == text).ToList();
                        if (select.Count() > 0) flagCarrera = 1;
                    }

                    foreach (var item in x.Scareer_postulant.Split("|"))
                    {
                        var text = Regex.Replace(item.ToString().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                        var select = x.Scareer_position.Split("|").ToList().Where(x => Regex.Replace(x.ToString().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "") == text).ToList();
                        if (select.Count() > 0) flagCarrera = 1;
                    }
                }

                var skillList = postulantSkillList.Where(s => s.IdPostulant == x.IdPerson).ToList();
                var workList = workExperienceList.Where(s => s.IdPerson == x.IdPerson).ToList();
                logger.LogInformation(String.Format("skillList => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(skillList)));
                logger.LogInformation(String.Format("workList => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(workList)));
                logger.LogInformation(String.Format("jobKeyWordList => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(jobKeyWordList)));
                int totalSkill = 0;
                int skillacumulate = 0;
                jobKeyWordList.ForEach(w =>
                {
                    totalSkill = 0;
                    var total = skillList.Where(s => s.Skill.ToLower().Contains(w.KeyWord.ToLower())).Count();
                    if (total > 0)
                    {
                        totalSkill += total;
                        contadorValidacion += 1;
                    }

                    var totalWork = workList.Where(s => s.DescriptionResponsabilities.ToLower().Contains(w.KeyWord.ToLower())).Count();
                    if (totalWork > 0)
                    {
                        totalSkill += totalWork;
                        contadorValidacion += 1;
                    }

                    if (totalSkill > 0) {
                        if (string.IsNullOrEmpty(x.Skill))
                        {
                            x.Skill = $"{w.KeyWord} : {totalSkill}";
                        }
                        else {
                            x.Skill = $"{x.Skill}, {w.KeyWord} : {totalSkill}";
                        }
                    }

                    skillacumulate += totalSkill;

                });
                if (x.Flag_coincide_grado == 1) contadorValidacion += 1;
                if (flagCarrera == 1) contadorValidacion += 1;

                #region "Filtros incluidos en el % de asertividad"
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.Estudios))
                {
                    contadorNuevasKeys++;
                    var _carrera = Regex.Replace(x.Scareer_postulant.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                    if (_carrera.ToLower().Contains(postulantQueryFilter.Estudios.ToLower()) || (postulantQueryFilter.Estudios.ToLower().Contains(_carrera.ToLower())))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.Universidad))
                {
                    contadorNuevasKeys++;
                    var _universidad = Regex.Replace(x.Universities.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                    if (_universidad.ToLower().Contains(postulantQueryFilter.Universidad.ToLower()) || (postulantQueryFilter.Universidad.ToLower().Contains(_universidad.ToLower())))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.EdadMinima) && String.IsNullOrEmpty(postulantQueryFilter.EdadMaxima))
                {
                    contadorNuevasKeys++;
                    if (x.AgePostulant >= Convert.ToInt32(postulantQueryFilter.EdadMinima))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.EdadMaxima) && String.IsNullOrEmpty(postulantQueryFilter.EdadMinima))
                {
                    contadorNuevasKeys++;
                    if (x.AgePostulant <= Convert.ToInt32(postulantQueryFilter.EdadMaxima))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.EdadMaxima) && !String.IsNullOrEmpty(postulantQueryFilter.EdadMinima))
                {
                    contadorNuevasKeys++;
                    if (x.AgePostulant >= Convert.ToInt32(postulantQueryFilter.EdadMinima) && x.AgePostulant <= Convert.ToInt32(postulantQueryFilter.EdadMaxima))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.SalarioMinimo) && String.IsNullOrEmpty(postulantQueryFilter.SalarioMaximo))
                {
                    contadorNuevasKeys++;
                    if (x.SalaryPostulant >= Convert.ToInt32(postulantQueryFilter.SalarioMinimo))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.SalarioMaximo) && String.IsNullOrEmpty(postulantQueryFilter.SalarioMinimo))
                {
                    contadorNuevasKeys++;
                    if (x.SalaryPostulant <= Convert.ToDecimal(postulantQueryFilter.SalarioMaximo))
                    {
                        contadorValidacion++;
                    }
                }
            
            if (!String.IsNullOrEmpty(postulantQueryFilter.SalarioMaximo) && !String.IsNullOrEmpty(postulantQueryFilter.SalarioMinimo))
            {
                contadorNuevasKeys++;
                if (x.SalaryPostulant >= Convert.ToDecimal(postulantQueryFilter.SalarioMinimo) && x.SalaryPostulant <= Convert.ToDecimal(postulantQueryFilter.SalarioMaximo))
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.Genero))
                {
                    contadorNuevasKeys++;
                    if (x.Gender == postulantQueryFilter.Genero)
                    {
                        contadorValidacion++;
                    }
                }
                
                if (!String.IsNullOrEmpty(postulantQueryFilter.LevelStudy))
                {
                    contadorNuevasKeys++;
                    var _niveles = Regex.Replace(x.NivelesEstudio.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                    postulantQueryFilter.LevelStudy = Regex.Replace(postulantQueryFilter.LevelStudy.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                    if (_niveles.ToLower().Contains(postulantQueryFilter.LevelStudy.ToLower()) || (postulantQueryFilter.LevelStudy.ToLower().Contains(_niveles.ToLower())))
                    {
                        contadorValidacion++;
                    }
                }

                
                if(x.CurrentWorking != 99)
                {
                    contadorNuevasKeys++;
                    if (x.CurrentWorking == (String.IsNullOrEmpty(postulantQueryFilter.IsWorking) ? 0 : Convert.ToInt32(postulantQueryFilter.IsWorking)))
                    {
                        contadorValidacion++;
                    }
                }                
                #endregion

                x.PorcentajeAsertividad = Convert.ToDouble(Convert.ToInt16(Math.Floor((contadorValidacion / (totalSkillsJob + 2 + contadorNuevasKeys)) * 100.00)));
                x.TotalSkills = skillacumulate;
            });
        }
        private void OrderListByTotalSkillAndName()
        {
            PostulantOrderList = postulantList.OrderBy(x => x.TotalSkills)
                                    .OrderBy(n => n.FullName).ToList();
        }
    }
}
