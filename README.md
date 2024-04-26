app.UseGlobalExceptionHandler();


app.UseStatusCodePagesWithReExecute("/error/{0}");


add this in startup.cs
