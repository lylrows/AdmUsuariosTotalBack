using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Country.IService
{
    public interface ICountryService
    {
        Task<Result> GetCountryes();
    }
}
