using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace tbp.Client
{
    public static class MonacoEditor
    {
        public static string LastPage { get; set; }

        public static Task<bool> CreateEditor(string id, string language = "plaintext", string value = "") =>
            JSRuntime.Current.InvokeAsync<bool>("newEditor", id, language, value);

        public static Task<bool> CreateDiffEditor(string id, string language = "plaintext", string originalValue = "", string modifiedValue = "") =>
            JSRuntime.Current.InvokeAsync<bool>("newDiffEditor", id, language, originalValue, modifiedValue);

        public static Task<bool> RemoveEditor(string id) => JSRuntime.Current.InvokeAsync<bool>("removeEditor", id);

        public static Task<bool> RemoveDiffEditor(string id) => JSRuntime.Current.InvokeAsync<bool>("removeDiffEditor", id);

        public static Task<bool> ChangeValue(string id, string newValue) =>
            JSRuntime.Current.InvokeAsync<bool>("setData", id, newValue);

        public static Task<bool> ChangeLanguage(string id, string newLanguage) =>
            JSRuntime.Current.InvokeAsync<bool>("setLanguage", id, newLanguage);

        public static Task<string> GetData(string id) => JSRuntime.Current.InvokeAsync<string>("getData", id);

        public static Task<bool> RemoveAll() => JSRuntime.Current.InvokeAsync<bool>("clearEditors");

        public static Task<bool> Exists(string id) => JSRuntime.Current.InvokeAsync<bool>("doesEditorExist", id);

        public static bool IsImage(string fileType)
        {
            switch (fileType)
            {
                case "jpg":
                case "png":
                case "svg":
                case "gif":
                case "tiff":
                case "jpeg":
                    return true;
                default: return false;
            }
        }

        public static string GetFileType(string fileType)
        {
            var newType = fileType.Replace(".", "");

            switch (newType)
            {
                case "cs":
                    return "csharp";
                case "fs":
                    return "fsharp";
                case "js":
                    return "javascript";
                case "ts":
                    return "typescript";
                case "py":
                    return "python";
                case "ps":
                    return "powershell";
                case "pl":
                    return "perl";
                case "clj":
                    return "clojure";
                case "coffee":
                    return "coffeescript";
                case "rdb":
                    return "redis";
                case "rb":
                    return "ruby";
                case "rs":
                case "rlib":
                    return "rust";
                case "scm":
                case "ss":
                    return "scheme";
                case "pbix":
                    return "powerquery";
                case "cshtml":
                case "vbhtml":
                    return "razor";
                case "sh":
                    return "shell";
                case "md":
                    return "markdown";
                case "h":
                case "m":
                case "mm":
                case "M":
                    return "cpp";
                case "bat":
                case "c":
                case "cpp":
                case "azcli":
                case "csp":
                case "css":
                case "dockerfile":
                case "go":
                case "html":
                case "java":
                case "ini":
                case "json":
                case "less":
                case "lua":
                case "msdax":
                case "sql":
                case "php":
                case "pug":
                case "r":
                case "sb":
                case "scss":
                case "sol":
                case "st":
                case "vb":
                case "xml":
                case "yaml":
                case "jpg":
                case "png":
                case "svg":
                case "gif":
                case "tiff":
                case "jpeg":
                case "folder":
                    return newType;
                default:
                    return "plaintext";
            }
        }
    }
}