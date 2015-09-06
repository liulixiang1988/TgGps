using System;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace TgGPS
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<ITokenizer>(new Tokenizer(cfg=>cfg.TokenExpiration(()=>TimeSpan.FromMinutes(10))));
            // Example options for specifying additional values for token generation

            //container.Register<ITokenizer>(new Tokenizer(cfg =>
            //                                             cfg.AdditionalItems(
            //                                                 ctx =>
            //                                                 ctx.Request.Headers["X-Custom-Header"].FirstOrDefault(),
            //                                                 ctx => ctx.Request.Query.extraValue)));
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }
    }
}