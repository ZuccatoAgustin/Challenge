﻿using WAC.Admin.Domain.Url;
using System.Reflection;
using System.Text;
using FWK.Domain.Extensions;
using FWK.Extensions;

namespace WAC.Admin.Domain.Emailing
{
    public class EmailTemplateProvider : IEmailTemplateProvider
    {
        private readonly IWebUrlService _webUrlService;

        public EmailTemplateProvider(
            IWebUrlService webUrlService)
        {
            _webUrlService = webUrlService;
        }

        public string GetDefaultTemplate()
        {
            using (var stream = typeof(EmailTemplateProvider).GetTypeInfo().Assembly.GetManifestResourceStream("WAC.Admin.Domain.Emailing.EmailTemplates.default.html"))
            { 
                var bytes = stream.GetAllBytes();
                var template = Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3);
                return template.Replace("{EMAIL_LOGO_URL}", GetLogoUrl());
            }
        }

        private string GetLogoUrl()
        {
            return "http://www.rosariobus.com.ar/rosario/wp-content/themes/tema/images/rosariobus.png";
            //return _webUrlService.GetServerRootAddress().EnsureEndsWith('/') + "TenantCustomization/GetTenantLogo";
        }
    }
}