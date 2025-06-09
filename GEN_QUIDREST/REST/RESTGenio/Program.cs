using CSGenio.persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using RESTGenio;
using System.Text.Json.Serialization;
using System.Xml.Linq;


//FIXME - without this myslq databases and other libraries will fail
//Quidgest.AssemblyResolver.AssemblyResolver.Initialize("Libs");

//GenioServer services
CSGenio.GenioDIDefault.Use();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(AuthService.ConfigureJwt);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.UseAllOfForInheritance();
    //c.UseOneOfForPolymorphism();
    c.EnableAnnotations(true, true);
    
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "RESTGenio.xml");
    if (File.Exists(filePath))
    {
        c.IncludeXmlComments(filePath, true);
        var doc = XDocument.Load(filePath);
        c.SchemaFilter<DescribeRestEnumMembers>(doc);
    }
	
    var securityScheme = new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JSON Web Token based security",
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityReq = new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    };
    c.AddSecurityRequirement(securityReq);

    c.SwaggerDoc("v1", new OpenApiInfo() { 
        Title = CSGenio.framework.Configuration.Application.Name, 
        Version = "v1"
    });
});

var app = builder.Build();

string virDirectory = builder.Configuration.GetSection("VirtualDirectory").Value;

if (string.IsNullOrEmpty(virDirectory))
    virDirectory = "/";
else
{
    virDirectory = virDirectory.StartsWith("/") ? virDirectory : "/" + virDirectory;
    virDirectory += !virDirectory.EndsWith("/") ? "/" : "";
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(virDirectory + "swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


string https_redirect = builder.Configuration.GetSection("https_redirect").Value;
if (https_redirect == "none")
{
    // No action needed
}
else if (https_redirect== "hsts")
{
    app.UseHsts();
}
else
{
    //Default case. Invalid configs fallback to this.
    app.UseHttpsRedirection();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }