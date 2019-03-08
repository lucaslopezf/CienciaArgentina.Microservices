﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RazorLight;

namespace CienciaArgentina.Microservices.Commons.Helpers
{
    public class RazorParser
    {
        private readonly Assembly _assembly;
        public RazorParser(Assembly assembly)
        {
            this._assembly = assembly;
        }

        public string Parse<T>(string template, T model)
        {
            return ParseAsync(template, model).GetAwaiter().GetResult();
        }

        public string UsingTemplateFromEmbedded<T>(string path, T model)
        {
            var template = EmbeddedResourceHelper.GetResourceAsString(_assembly, GenerateFileAssemblyPath(path, _assembly));
            var result = Parse(template, model);

            return result;
        }

        async Task<string> ParseAsync<T>(string template, T model)
        {
            var project = new InMemoryRazorLightProject();
            var engine = new EngineFactory().Create(project);

            return await engine.CompileRenderAsync<T>(Guid.NewGuid().ToString(), template, model);
        }

        string GenerateFileAssemblyPath(string template, Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name;
            return string.Format("{0}.Mail.{1}.{2}", assemblyName, template, "cshtml");
        }
    }
}
