using System;
using System.Reflection;
using System.Threading.Tasks;
using RazorLight;

namespace CienciaArgentina.Microservices.Commons.Helpers.Razor
{
    public class RazorParser
    {
        private readonly Assembly _assembly;
        public RazorParser(Assembly assembly)
        {
            this._assembly = assembly;
        }

        public async Task<string> Parse<T>(string template, T model)
        {
            //return ParseAsync(template, model).GetAwaiter().GetResult();
            return await ParseAsync(template, model);
        }

        public async Task<string> UsingTemplateFromEmbedded<T>(string path, T model)
        {
            var template = EmbeddedResourceHelper.GetResourceAsString(_assembly, GenerateFileAssemblyPath(path, _assembly));
            var result = await Parse(template, model);

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
            return string.Format("{0}.{1}.{2}", assemblyName, template, "cshtml");
        }
    }
}
