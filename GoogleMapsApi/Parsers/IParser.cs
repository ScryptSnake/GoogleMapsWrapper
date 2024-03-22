using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Parsers
{
    public interface IParser<TOutput>
    {
        public TOutput Parse(object input);

    }
}
