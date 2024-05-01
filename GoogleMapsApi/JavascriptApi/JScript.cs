using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class JScript
    {

        private string text;
        public string Text { get => this.text; }

        public string? GetFunctionName()
            //returns first instance
        {
            if (string.IsNullOrEmpty(this.text))
            {
                return null;
            }
            string pattern = @"function\s+([a-zA-Z_$][0-9a-zA-Z_$]*)\s*\(";

            Match match = Regex.Match(this.text, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return null;
            }
        }


        public static JScript Load(Uri fileName)
        {
            return new JScript(File.ReadAllText(fileName.AbsolutePath));
        }

        public JScript(string text)
        {
            this.text = text;

        }

    }
}
