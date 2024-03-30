using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Engine
{
    public interface IApiEngine
    {
        public ApiEngineOptions Options { get; set; }

        public Task<IResponse<JsonDocument>> GetJsonAsync(IRequest request);

        public Task<IResponse<byte[]>> GetBytesAsync(IRequest request);


    }
}
