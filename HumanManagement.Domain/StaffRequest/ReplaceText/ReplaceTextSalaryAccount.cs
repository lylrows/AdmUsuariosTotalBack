using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextSalaryAccount
    {
        public GetStaffSalaryById staffRequestSalaryAccountDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextSalaryAccount(GetStaffSalaryById staffRequestSalaryAccountDto)
        {
            this.staffRequestSalaryAccountDto = staffRequestSalaryAccountDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = staffRequestSalaryAccountDto.scodemployee
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = staffRequestSalaryAccountDto.dadmissiondate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = staffRequestSalaryAccountDto.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = staffRequestSalaryAccountDto.sidentification
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGE",
                sreplacetext = staffRequestSalaryAccountDto.snamecharge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AREA",
                sreplacetext = staffRequestSalaryAccountDto.snamearea
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANKIGENTITYCURRENT",
                sreplacetext = staffRequestSalaryAccountDto.BankingEntityCurrent
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANK_ORIGEN",
                sreplacetext = staffRequestSalaryAccountDto.bank_origen
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANK_DESTINO",
                sreplacetext = staffRequestSalaryAccountDto.bank_destino
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANKINGENTITYCHANGE",
                sreplacetext = staffRequestSalaryAccountDto.BankingEntityChange
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MONTH",
                sreplacetext = staffRequestSalaryAccountDto.snamemonth
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "PERIOD_CTA_MM",
                sreplacetext = staffRequestSalaryAccountDto.period_cta_mm< 10?NameMonth(staffRequestSalaryAccountDto.period_cta_mm) : NameMonth(staffRequestSalaryAccountDto.period_cta_mm)
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "YEAR",
                sreplacetext = staffRequestSalaryAccountDto.ddatechange.Year.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "PERIOD_CTA_YYYY",
                sreplacetext = staffRequestSalaryAccountDto.period_cta_yyyy.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEISSUE",
                sreplacetext = staffRequestSalaryAccountDto.sdateissuetext
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATETEXTCTA",
                sreplacetext = SetDateText(staffRequestSalaryAccountDto.date_request_cta)
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = staffRequestSalaryAccountDto.scodemployee
            });
        }

        #region NameMonth
        private string NameMonth(int mes)
        {
            string name_month="";
            switch (mes)
            {
                case 1:
                    name_month = "ENERO";
                    break;
                case 2:
                    name_month = "FEBRERO";
                    break;
                case 3:
                    name_month = "MARZO";
                    break;
                case 4:
                    name_month = "ABRIL";
                    break;
                case 5:
                    name_month = "MAYO";
                    break;
                case 6:
                    name_month = "JUNIO";
                    break;
                case 7:
                    name_month = "JULIO";
                    break;
                case 8:
                    name_month = "AGOSTO";
                    break;
                case 9:
                    name_month = "SEPTIEMBRE";
                    break;
                case 10:
                    name_month = "OCTUBRE";
                    break;
                case 11:
                    name_month = "NOVIEMBRE";
                    break;
                case 12:
                    name_month = "DICIEMBRE";
                    break;
                default:
                    name_month = "";
                    break;

            }

            return name_month;

        }

        #endregion

        #region DATE TEXT
        private string SetDateText(DateTime fecha)
        {
            string date_text_cta="";

            date_text_cta = $"{fecha.Day} de {NameMonth(fecha.Month)} del {fecha.Year}";
            return date_text_cta;
        }
        #endregion
    }
}
