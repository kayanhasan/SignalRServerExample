using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>
policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin=>true)
)) ;
builder.Services.AddTransient<MyBusiness>();
builder.Services.AddSignalR();
builder.Services.AddControllers();
var app = builder.Build();
app.UseCors();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapHub<MessageHub>("/messagehub");
    endpoints.MapControllers();
});
app.Run();
