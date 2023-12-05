﻿using Web.Repositories;

namespace Blazor.WEB.Repositories
{
    public interface IRepository
    {
        //GET
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        
        //POST
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);
        
        //POST que devuelve respuesta
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);

        //DELETE
        Task<HttpResponseWrapper<object>> Delete(string url);

        //PUT
        Task<HttpResponseWrapper<object>> Put<T>(string url, T model);

        //PUT que devuelve respuesta
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model);
    }
}
