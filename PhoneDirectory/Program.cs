using PhoneDirectory;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
  endpoints.MapGet("/Identity/Account/Register", context => Task.Factory.StartNew(() =>
      context.Response.Redirect("/RegistrationRedirect", true, true)));
  endpoints.MapPost("/Identity/Account/Register", context => Task.Factory.StartNew(() =>
      context.Response.Redirect("/RegistrationRedirect", true, true)));
  endpoints.MapGet("/Identity/Account/ForgotPassword", context => Task.Factory.StartNew(() =>
      context.Response.Redirect("/PasswordRedirect", true, true)));
  endpoints.MapPost("/Identity/Account/ForgotPassword", context => Task.Factory.StartNew(() =>
      context.Response.Redirect("/PasswordRedirect", true, true)));
  endpoints.MapGet("/Identity/Account/ResendEmailConfirmation", context => Task.Factory.StartNew(() =>
      context.Response.Redirect("/EmailConfirmationRedirect", true, true)));
  endpoints.MapPost("/Identity/Account/ResendEmailConfirmation", context => Task.Factory.StartNew(() =>
      context.Response.Redirect("/EmailConfirmationRedirect", true, true)));
});

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
