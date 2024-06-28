using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;

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
            });
        }
    }
}