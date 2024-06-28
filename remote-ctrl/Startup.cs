using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace remote_ctrl
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{action}", async context =>
                {
                    var action = context.GetRouteValue("action");

                    switch (action)
                    {
                        case "play":
                        case "pause":
                            MediaCtrl.PlayPause();
                            break;
                        case "stop":
                            MediaCtrl.Stop();
                            break;
                        case "next":
                            MediaCtrl.NextTrack();
                            break;
                        case "prev":
                            MediaCtrl.PreviousTrack();
                            break;
                        case "volume-up":
                            MediaCtrl.VolumeUp();
                            break;
                        case "volume-down":
                            MediaCtrl.VolumeDown();
                            break;
                        case "volume-mute":
                            MediaCtrl.VolumeMute();
                            break;
                        default:
                            // nothing
                            break;
                                                }

                    await context.Response.WriteAsync("OK" + action);
                });

                endpoints.MapPost("/open-url", async context =>
                {
                    var q = context.Request.Query;
                    var url = q["url"].ToString();

                    if (url is null)
                    {
                        await context.Response.WriteAsync("Pleas provide url");
                    } else
                    {
                        Process.Start("rundll32", "url.dll,FileProtocolHandler " + url);
                        await context.Response.WriteAsync("OK");
                    }
                });
            });
        }
    }
}