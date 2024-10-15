using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject;
public class HttpClientSingleton
    //returns singleton instance of HttpClient.
{
    private HttpClientSingleton() { } //private constructor

    private static readonly HttpClient instance = new HttpClient();

    public static HttpClient Instance => instance;


    
}