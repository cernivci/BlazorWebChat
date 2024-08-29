using BlazorWebChat;
using BlazorWebChat.Components;
using BlazorWebChat.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWebChat {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder();

            builder.Services
                .AddRazorComponents()
                .AddInteractiveServerComponents();
            
            builder.Services.AddSignalR();
            
            var app = builder.Build();

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseAntiforgery();
            
            app
                .MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            
            app.MapHub<ChatHub>("/chathub");

            app.Run();
        }
    }
}