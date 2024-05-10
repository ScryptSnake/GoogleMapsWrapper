using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    public record ScriptResult (string? Result, bool IsSuccess, string ExceptionMessage)
    {
        public bool TryDeserialize<T>(out T? obj)
        {
            try
            {
                obj = JsonSerializer.Deserialize<T>(this.Result ?? "");
                if (obj == null) return false;
            }
            catch
            {
                obj = default;
                return false;
            }
            return false;
        }
    }
}
