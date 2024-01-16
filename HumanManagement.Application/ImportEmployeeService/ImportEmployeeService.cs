using AutoMapper;

using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.General.Contracts;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;

using HumanManagement.Domain.Security.Events;

using System;
using System.Collections.Generic;


namespace HumanManagement.Application.ImportEmployeeService
{
    public class ImportEmployeeService : IImportEmployeeService
    {
        private readonly IBaseRepository<PersonModel> personRepository;
        private readonly IBaseRepository<EmployeeModel> employeeRepository;
        private readonly IBaseRepository<EmployeeFile> employeeFileRepository;
        private readonly ICargoRepository cargoRepository;
        private readonly IBankRepository bankRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IBaseRepository<User> baseUserRepository;
        private readonly ICryptography cryptography;
        private readonly IMailRepository mailRepository;
        private readonly IMapper mapper;
        private List<UserMailDto> userMailDtoList;
        private readonly IImporterFromExcel importerFromExcel;
        public ImportEmployeeService(IMapper mapper,
                                    IBaseRepository<PersonModel> personRepository,
                                    IBaseRepository<EmployeeModel> employeeRepository,
                                    ICargoRepository cargoRepository,
                                    IBaseRepository<EmployeeFile> employeeFileRepository,
                                    IBankRepository bankRepository,
                                    IBaseRepository<User> baseUserRepository,
                                    ICryptography cryptography,
                                    IMailRepository mailRepository,
                                    IImporterFromExcel importerFromExcel,
                                    IEmpresaRepository empresaRepository)
        {
            this.mapper = mapper;
            this.personRepository = personRepository;
            this.employeeRepository = employeeRepository;
            this.cargoRepository = cargoRepository;
            this.employeeFileRepository = employeeFileRepository;
            this.bankRepository = bankRepository;
            this.baseUserRepository = baseUserRepository;
            this.cryptography = cryptography;
            this.mailRepository = mailRepository;
            this.importerFromExcel = importerFromExcel;
            this.empresaRepository = empresaRepository;
            userMailDtoList = new List<UserMailDto>();
        }

        public void Import()
        {
            List<ImportEmployeeDto> importedEmployeeList = importerFromExcel.GetListEmployee();
            importedEmployeeList.ForEach(x =>
            {
                int idPosition = cargoRepository.GetIdByCode(x.CodeCharge).Result;
                x.IdPosition = idPosition;
                int idCtsOriginBank = bankRepository.GetIdByCode(x.CtsOriginBank).Result;
                if (idCtsOriginBank > 0)
                {
                    x.IdCtsOriginBank = idCtsOriginBank;
                }
                int idOriginBank = bankRepository.GetIdByCode(x.OriginBankRemuneration).Result;
                if (idOriginBank > 0)
                {
                    x.IdOriginBank = idOriginBank;
                }
                int idFinancialEntity = bankRepository.GetIdByCode(x.FinancialEntity).Result;
                if (idFinancialEntity > 0)
                {
                    x.IdFinancialEntity = idFinancialEntity;
                }
                x.IdCompany = empresaRepository.GetIdByName(x.Company).Result;
                x.IdActive = 20;
            });
            importedEmployeeList.ForEach(x =>
            {
                var person = mapper.Map<PersonModel>(x);
                var employee = mapper.Map<EmployeeModel>(x);
                var employeeFile = mapper.Map<EmployeeFile>(x);
                employee.DateRegister = DateTime.Now;
                employee.DateUpdate = DateTime.Now;
                employee.IdUserRegister = 1;
                employee.IdUserUpdate = 1;
                employeeFile.DateRegister = DateTime.Now;
                employeeFile.DateUpdate = DateTime.Now;
                employeeFile.IdUserRegister = 1;
                employeeFile.IdUserUpdate = 1;

                bool exist = personRepository.Exist(x => x.CodPerson.Equals(person.CodPerson)).Result;
                if (!exist)
                {
                    personRepository.Add(person).Wait();
                    employee.IdPerson = person.Id;
                    employeeRepository.Add(employee).Wait();
                    employeeFile.IdEmployee = employee.Id;
                    employeeFileRepository.Add(employeeFile).Wait();

                    User user = new User
                    {
                        UserName = person.GetUserName(),
                        Password = person.CodPerson,
                        IdPerson = person.Id,
                        Active = true,
                        State = 1
                    };
                    user.SetEncryptPassword(cryptography);
                    baseUserRepository.Add(user).Wait();
                    UserMailDto userMailDto = new UserMailDto
                    {
                        UserName = user.UserName,
                        Password = person.CodPerson,
                        Email = person.Email,
                        FullName = $"{person.FirstName} {person.SecondName}, {person.LastName} {person.MotherLastName}"
                    };
                    userMailDtoList.Add(userMailDto);
                }
            });

            SendMail();
        }

        private void SendMail()
        {
            
            userMailDtoList.ForEach(x =>
            {
            

                var userRegistered = new UserRegistered(x);
                DomainEvent.Raise(userRegistered);

            });
        }
    }
}
