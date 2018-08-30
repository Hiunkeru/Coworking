using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Contracts.ApiCaller
{
    public interface IApiCaller
    {
        Task<T> GetServiceResponseById<T>(string controller, int id);
    }
}
