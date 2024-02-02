using Autofac;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.Conctrete;
using Microsoft.Extensions.Options;
using rick_morty_app.Configurations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoreInfrastructureLayer.Configuations
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registering the managers as services
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<CharacterManager>().As<ICharacterService>();
            builder.RegisterType<EpisodeManager>().As<IEpisodeService>();

            // Registering the options
            builder.RegisterType<ConfigureSwaggerOptions>().As<IConfigureOptions<SwaggerGenOptions>>();
        }
    }
}