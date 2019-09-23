using AutoMapper;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Quiz.Api.GraphQL;
using Quiz.Repositories.Abstractions;
using Quiz.Repositories.Context;
using Quiz.Repositories.Map;
using Quiz.Repositories.Model;
using Quiz.Services;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Quiz.Api
{
    public static class MiddleWareExtensions
    {
        public static IApplicationBuilder UseGraphQLExtensions(this IApplicationBuilder app)
        {
            app.UseGraphQL<QuestionarioSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
            return app;
        }

        public static IApplicationBuilder UseSwaggerExtensions(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiz.Api");
            });

            var routesToIgnore = new[] { "/liveness", "/readiness", "/swagger", "/metrics" };
            return app;
        }
    }

    public static class ServicesExtensions
    {
        public static void AddGraphQlExtensions(this IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<QuestionarioSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped);
        }
        public static void AddSwaggerExtensions(this IServiceCollection services)
        {

            services
              .AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Quiz.Api", Version = "v1" }); })
              .AddMvc(opts =>
              {

              });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }

    public static class ServicesRepository
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration Configuration)
        {
            DbContext.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            DbContext.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            DbContext.IsSSL = Convert.ToBoolean(Configuration.GetSection("MongoConnection:IsSSL").Value);

            services.AddSingleton<DbContext>();
            services.AddScoped<IQuestionarioRepository, QuestionarioRepository>();
            services.AddScoped<IQuestionarioService, QuestionarioService>();
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }

    public static class LoadRepositoryExtension
    {
        public static IApplicationBuilder LoadRepository(this IApplicationBuilder app, IConfiguration Configuration, string path)
        {
            var fileName = Path.Combine(path, Configuration["nameFile"]);
            var text = File.ReadAllText(fileName, Encoding.UTF8);
            var questoes = JsonConvert.DeserializeObject<List<QuestaoModel>>(text);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DbContext>();

                //remove itens da coleção
                var collection = context.Questao;
                var filter = new BsonDocument();
                var docs = collection.Find(filter).ToList();

                if (docs.Any())
                {
                    var ids = docs.Select(d => d.Id);
                    var idsFilter = Builders<QuestaoModel>.Filter.In(d => d.Id, ids);
                    var result = collection.DeleteMany(idsFilter);
                }

                //adiciona novamente os itens do arquivo json questoes.json
                context.Questao.InsertMany(questoes);
            }
            return app;
        }
    }
}
