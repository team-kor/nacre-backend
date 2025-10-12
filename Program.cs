using System;
using Handler.CustomerEndpointHandlers.ICustomerEntityHandler;
using Microsoft.VisualBasic;
using Handler.CustomerEndpointHandlers.CustomerEntityHandler;

namespace NacreProj
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<ICustomerEntityHandlers, CustomerHandlers>();
        }
    }
}