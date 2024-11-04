using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Parsers;
/// <Summary>Defines an object that parses an input of one type to an output of another.</Summary>
/// <Remarks>IResponses depend on this type to allow parse-ability directly within an IResponse object.</Remarks>
public interface IParser<TOutput, TInput>
{
    public TOutput Parse(TInput input);
    public bool TryParse(TInput input, out TOutput? output); 
}
