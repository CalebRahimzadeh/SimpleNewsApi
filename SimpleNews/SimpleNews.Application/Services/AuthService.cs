using Microsoft.Extensions.Logging;
using SimpleNews.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNews.Application.Services
{
    internal class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        public AuthService(ILogger<AuthService> logger)
        {
            _logger = logger;
        }

    }
}
