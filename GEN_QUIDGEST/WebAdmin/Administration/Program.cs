using Administration;
using Administration.Models;
using CSGenio.framework;
using CSGenio.persistence;
using GenioServer.security;
using log4net;
using log4net.Config;
using SoapCore;

//---------------------------------
// Setup the GenioServer services
//---------------------------------
PersistenceFactoryExtension.Use();
PersistentSupport.SetControlQueries(
    GenioServer.persistence.PersistentSupportExtra.ControlQueries, 
    GenioServer.persistence.PersistentSupportExtra.ControlQueriesOverride);
GenioServer.framework.OverrideQueryDeclaring.Use();


//Dependency injection
UserFactory.BusinessManager = new UserBusinessService();

//---------------------------------
// Setup 3rd party services
//---------------------------------
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("web.config"));

//---------------------------------
// Setup the WebServer services
//---------------------------------
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => 
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    }).AddSessionStateTempDataProvider()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; //leave property names unchanged
    })
    .AddXmlSerializerFormatters();


//gzip compression
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});

//Add chaching service
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

//Add SOAP service interface
builder.Services.AddSingleton<IAdminService, WebAPI>();
builder.Services.AddSingleton<IUserManagementService, UserManagement>();

// USE /[MANUAL GQT APP_INIT]/

var app = builder.Build();


app.UseRouting();

//Map SOAP endpoint
((IEndpointRouteBuilder) app).UseSoapEndpoint<IAdminService>("/WebAPI.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer); //cast needed to solve ambiguity
((IEndpointRouteBuilder) app).UseSoapEndpoint<IUserManagementService>("/UserManagement.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);


app.UseSession();

// Configure the HTTP request pipeline.
app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

// AspCore wrapper already does this, so its not needed
//app.UseRouting();

app.UseSession();

//This is only needed when using the [ApiController] attributes
app.MapControllers();

//Get default system
string defaultSystem = "0";

//Default route
app.MapControllerRoute("default",
    "api/{culture}/{system}/{controller}/{action}/{id?}",
    new {
        culture = Administration.AuxClass.Culture.CultureManager.DefaultCulture.Name,
        system = defaultSystem
        }
    );

app.Run();
