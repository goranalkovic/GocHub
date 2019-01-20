using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace tbp.Client
{
    public static class CookieManager
    {
        public static Task<bool> Set(string name, string value, int expirationDays = 1) =>
            JSRuntime.Current.InvokeAsync<bool>("setCookie", name, value, expirationDays);

        public static Task<bool> ReloadWindow() =>JSRuntime.Current.InvokeAsync<bool>("reloadPage");

        public static Task<string> GetData(string name) => JSRuntime.Current.InvokeAsync<string>("getCookie", name);
        
    }
}