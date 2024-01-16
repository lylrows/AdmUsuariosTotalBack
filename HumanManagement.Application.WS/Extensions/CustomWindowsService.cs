using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.General.Contracts;
using HumanManagement.Domain.General.Dto;
using System;

using System.Timers;

namespace WSHumanManagement.Application.Extensions
{
    public abstract class CustomWindowsService
    {
        
        private Timer feqProcessVh;
        private Timer feqProcessDay;
        private TimeSpan StartTime;
        private TimeSpan EndTime;
        private bool InProcess;
        public ParameterFilterDto ParameterFilter { get; set; }
        private readonly ICoreParameterRepository coreParameterRepository;
        public CustomWindowsService(ICoreParameterRepository coreParameterRepository)
        {
            this.coreParameterRepository = coreParameterRepository;
            SetParameter();
            ParameterFilter = new ParameterFilterDto();
        }

        public void Start()
        {
            try
            {
                ParameterFilter.Key = Constants.HumanManagemen.Keys.FrequencyProcVH;
                ParameterResultDto result = coreParameterRepository.GetValue(ParameterFilter).Result;
                feqProcessVh = new Timer(result.ValueNumeric.Value);
                feqProcessVh.Elapsed += feqProcessVh_Elapsed;
                ParameterFilter.Key = Constants.HumanManagemen.Keys.HoraInicio;
                ParameterResultDto resultStartTime = coreParameterRepository.GetValue(ParameterFilter).Result;
                StartTime = DateTime.Parse(resultStartTime.ValueString).TimeOfDay;
                ParameterFilter.Key = Constants.HumanManagemen.Keys.HoraFin;
                ParameterResultDto resultEndTime = coreParameterRepository.GetValue(ParameterFilter).Result;
                EndTime = DateTime.Parse(resultEndTime.ValueString).TimeOfDay;
                feqProcessVh.Start();
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Finish()
        {
            if (feqProcessDay != null && feqProcessDay.Enabled)
            {
                feqProcessDay.Stop();
                feqProcessDay.Elapsed -= feqProcessDay_Elapsed;
                feqProcessDay.Dispose();
                feqProcessDay = null;
            }

            if (feqProcessVh != null && feqProcessVh.Enabled)
            {
                feqProcessVh.Stop();
                feqProcessVh.Elapsed -= feqProcessVh_Elapsed;
                feqProcessVh.Dispose();
                feqProcessVh = null;
            }
            InProcess = false;
        }

        void feqProcessVh_Elapsed(object sender, ElapsedEventArgs e)
        {
            var horaActual = DateTime.Now.TimeOfDay;
            if (horaActual >= StartTime && horaActual <= EndTime)
            {
                if (feqProcessDay == null)
                {
                    ParameterFilter.Key = Constants.HumanManagemen.Keys.FrequencyProcDay;
                    ParameterResultDto resultProcessDay = coreParameterRepository.GetValue(ParameterFilter).Result;
                    feqProcessDay = new Timer(resultProcessDay.ValueNumeric.Value);
                    feqProcessDay.Elapsed += feqProcessDay_Elapsed;
                }
                if (!feqProcessDay.Enabled && !InProcess)
                {
                    InProcess = true;

                    Run();
                    feqProcessDay.Start();
                }
            }
            else
            {
                if (feqProcessDay != null && feqProcessDay.Enabled)
                {
                    InProcess = false;
                    feqProcessDay.Stop();
                }
            }
        }

        void feqProcessDay_Elapsed(object sender, ElapsedEventArgs e)
        {
            Run();
        }

        private void SetParameter()
        {
            SetParameterBase();
        }

        public abstract void Run();

        public abstract void SetParameterBase();
    }
}
