using HumanManagement.Domain.Employee.Dto;
using NPOI.SS.UserModel;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;
using HumanManagement.Domain.Security.Contracts;

namespace HumanManagement.ExactusImport.FromFile
{
    public class ImporterFromExcel : IImporterFromExcel
    {
        private string fullPath;
        public void ReadFile()
        {
            ISheet sheet = new FileExcelNpoi(fullPath, 0).ReadFile();
            for(int row = 0; row< sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    ImportEmployeeDto item = new ImportEmployeeDto
                    {
                        CodPerson = sheet.GetRow(row).GetCell(0).StringCellValue,
                        FirstName = sheet.GetRow(row).GetCell(1).StringCellValue,
                        IdState = 1,
                    };
                }
            }
        }

        public List<ImportEmployeeDto> GetListEmployee()
        {
            List<ImportEmployeeDto> importedEmployeeList = new List<ImportEmployeeDto>();
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00016536",
                FirstName = "EVA",
                SecondName = "RUTH",
                LastName = "SOLORZANO",
                MotherLastName = "ARCENTALES",
                plaza = "ND",
                IdSex = 1,
                BirthDate = DateTime.Now,
                Identification = "00016536",
                IsNoDomiciled = true,
                CodEmployee = "00016536",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "000193651",
                FirstName = "WALTER",
                SecondName = "",
                LastName = "HEILBRUNN",
                MotherLastName = "RODRIGO",
                plaza = "ND",
                IdSex = 12,
                BirthDate = DateTime.Now,
                Identification = "000193651",
                IsNoDomiciled = true,
                CodEmployee = "000193651",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 11,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "000291776",
                FirstName = "SUSANA",
                SecondName = "JULIETA",
                LastName = "ALIAGA",
                MotherLastName = "SOLIZ",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "000291776",
                IsNoDomiciled = true,
                CodEmployee = "000291776",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00030578",
                FirstName = "NORKA",
                SecondName = "LYLEANA",
                LastName = "ONEILL",
                MotherLastName = "GOYTIZOLO ",
                plaza = "ND",
                IdSex = 12,
                BirthDate = DateTime.Now,
                Identification = "00030578",
                IsNoDomiciled = true,
                CodEmployee = "00030578",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "000367578",
                FirstName = "ELINA",
                SecondName = "",
                LastName = "SOUCHTCHENKO",
                MotherLastName = "",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "000367578",
                IsNoDomiciled = true,
                CodEmployee = "000367578",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "000721649",
                FirstName = "WUILMER",
                SecondName = "ANTONIO",
                LastName = "EVVOLCAN",
                MotherLastName = "PICO",
                plaza = "ND",
                IdSex = 12,
                BirthDate = DateTime.Now,
                Identification = "000721649",
                IsNoDomiciled = true,
                CodEmployee = "000721649",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00090411",
                FirstName = "OLGA",
                SecondName = "FELICITA",
                LastName = "RENGIFO",
                MotherLastName = "ALVAN",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00090411",
                IsNoDomiciled = true,
                CodEmployee = "00090411",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00114329",
                FirstName = "CLARA",
                SecondName = "LUZ",
                LastName = "MELENDEZ",
                MotherLastName = "DAVILA",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00114329",
                IsNoDomiciled = true,
                CodEmployee = "00114329",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "001783130",
                FirstName = "BRENDALLY",
                SecondName = "",
                LastName = "SEQUERA",
                MotherLastName = "VARGAS",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "001783130",
                IsNoDomiciled = true,
                CodEmployee = "001783130",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "002107854",
                FirstName = "ANYERLIN",
                SecondName = "CAROLINA",
                LastName = "GONZALEZ",
                MotherLastName = "ZARATES",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "002107854",
                IsNoDomiciled = true,
                CodEmployee = "002107854",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00241923",
                FirstName = "HAYDEE",
                SecondName = "",
                LastName = "FERNANDEZ",
                MotherLastName = "ROCHA",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00241923",
                IsNoDomiciled = true,
                CodEmployee = "00241923",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00243782",
                FirstName = "MARIA",
                SecondName = "NAZARET",
                LastName = "PETIT",
                MotherLastName = "PESSOA",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00243782",
                IsNoDomiciled = true,
                CodEmployee = "00243782",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00247260",
                FirstName = "ANGELITA",
                SecondName = "YANIRA",
                LastName = "ESTRADA",
                MotherLastName = "APOLO ",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00247260",
                IsNoDomiciled = true,
                CodEmployee = "00247260",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00247306",
                FirstName = "SHYRLEY",
                SecondName = "GLENDA",
                LastName = "ZAPATA",
                MotherLastName = "APONTE",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00247306",
                IsNoDomiciled = true,
                CodEmployee = "00247306",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00249460",
                FirstName = "JOSE",
                SecondName = "LUIS",
                LastName = "TINOCO",
                MotherLastName = "PALACIOS",
                plaza = "ND",
                IdSex = 12,
                BirthDate = DateTime.Now,
                Identification = "00249460",
                IsNoDomiciled = true,
                CodEmployee = "00249460",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00321455",
                FirstName = "LILIANA",
                SecondName = "",
                LastName = "RODRIGUEZ",
                MotherLastName = "DE ROMERO",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00321455",
                IsNoDomiciled = true,
                CodEmployee = "00321455",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00323518",
                FirstName = "MARIA",
                SecondName = "",
                LastName = "CASTILLO DE RAMIREZ ",
                MotherLastName = "ROSA",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00323518",
                IsNoDomiciled = true,
                CodEmployee = "00323518",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "003704980",
                FirstName = "VICENTE",
                SecondName = "ENRIQUE",
                LastName = "RODRIGUEZ",
                MotherLastName = "MATA",
                plaza = "ND",
                IdSex = 12,
                BirthDate = DateTime.Now,
                Identification = "003704980",
                IsNoDomiciled = true,
                CodEmployee = "003704980",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00426538",
                FirstName = "CAMELIA",
                SecondName = "RUTH",
                LastName = "TASSARA",
                MotherLastName = "ROSAS",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00426538",
                IsNoDomiciled = true,
                CodEmployee = "00426538",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });
            importedEmployeeList.Add(new ImportEmployeeDto
            {
                CodPerson = "00431238",
                FirstName = "LOURDES",
                SecondName = "ELSA",
                LastName = "GALLEGOS",
                MotherLastName = "NUÑEZ",
                plaza = "ND",
                IdSex = 11,
                BirthDate = DateTime.Now,
                Identification = "00431238",
                IsNoDomiciled = true,
                CodEmployee = "00431238",
                Email = "robertooa@gmail.com",
                AdmissionDate = DateTime.Now,
                IdCostcenter = 1,
                IsDependents = true,
                IdPayroll = 1,
                DateOffirstAdmission = DateTime.Now,
                UniversityGraduationDate = DateTime.Now,
                CountryentryDate = DateTime.Now,
                IdAddress = 1,
                IdState = 24,
                CodeCharge = "000229",
                Company = "Campo Fe"
            });

            return importedEmployeeList;
        }
    }
}
