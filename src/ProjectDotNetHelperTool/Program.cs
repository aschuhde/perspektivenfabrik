// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

const string webApiProjectPath = "src/WebApi";
const string webApiProjectEndpointsPath = $"{webApiProjectPath}/Endpoints";
const string applicationProjectPath = $"src/Application";

Console.WriteLine("");
Console.WriteLine("this is clean-endpoint tool to quickly create a new endpoint");
Console.WriteLine("");

if (args.Length == 6 && args[0] == "new")
{
    args = ["", .. args];
}

if (args.Length != 7)
{
    Console.WriteLine("wrong argument length");
    ShowHelp();
    return;
}

var command = args[1];

if (command != "new")
{
    Console.WriteLine("wrong command: " + command);
    ShowHelp();
    return;
}

var endpointName = args[2];
if (string.IsNullOrWhiteSpace(endpointName))
{
    Console.WriteLine("empty endpoint name");
    ShowHelp();
    return;
}

var endpointClass = args[3];
if (string.IsNullOrWhiteSpace(endpointClass))
{
    Console.WriteLine("empty endpoint class");
    ShowHelp();
    return;
}

var endpointType = args[4];
if (string.IsNullOrWhiteSpace(endpointType) 
    || (endpointType != "json"
        && endpointType != "file"
        && endpointType != "string"
        && endpointType != "empty"))
{
    Console.WriteLine("wrong endpoint type: " + endpointType);
    ShowHelp();
    return;
}

var httpVerb = args[5];

if (string.IsNullOrWhiteSpace(httpVerb) 
    || (httpVerb.ToLower() != "get"
        && httpVerb.ToLower() != "post"
        && httpVerb.ToLower() != "put"
        && httpVerb.ToLower() != "patch"
        && httpVerb.ToLower() != "delete"))
{
    Console.WriteLine("wrong http verb: " + httpVerb);
    ShowHelp();
    return;
}

var httpVerbPascal = httpVerb.ToLower() switch
{
    "get" => "Get",
    "post" => "Post",
    "put" => "Put",
    "patch" => "Patch",
    "delete" => "Delete",
    _ => throw new ArgumentOutOfRangeException()
};

var routename = args[6];
if (string.IsNullOrWhiteSpace(routename))
{
    Console.WriteLine("empty routename");
    ShowHelp();
    return;
}

var cd = Directory.GetCurrentDirectory();
while (cd != null && !(new DirectoryInfo(Path.Join(cd, webApiProjectPath)).Exists))
{
    cd = (new DirectoryInfo(cd)).Parent?.FullName;
}

if (cd == null)
{
    Console.WriteLine($"could not find path {webApiProjectPath}");
    return;
}
Console.WriteLine("found main directory: " + cd);
Console.WriteLine("");

endpointClass = endpointClass.EndsWith(".cs") ? endpointClass[..^3] : endpointClass;

var endpointClassFile = Path.Join(cd, webApiProjectEndpointsPath,
    $"{(endpointClass)}.cs");

if (!File.Exists(endpointClassFile))
{
    using var createWriter = File.CreateText(endpointClassFile);
    createWriter.Write("""
                       using Application.Example.GetExample;
                       using WebApi.Attributes;

                       namespace WebApi.Endpoints;
                       """);
}

var responseEndpointType = endpointType.ToLower() switch
{
    "json" => "JsonResponseEndpoint",
    "string" => "StringResponseEndpoint",
    "empty" => "EmptyResponseEndpoint",
    "file" => "FileInfoResponseEndpoint",
    _ => throw new ArgumentOutOfRangeException()
};

var responseType = endpointType.ToLower() switch
{
    "json" => "JsonResponse",
    "string" => "StringResponse",
    "empty" => "EmptyStatusCodeResponse",
    "file" => "FileInfoResponse",
    _ => throw new ArgumentOutOfRangeException()
};

var endpointContent = File.ReadAllText(endpointClassFile);

if (!endpointContent.Contains($"public sealed class {endpointName}"))
{
    Console.WriteLine($"Adding class {endpointName} in {endpointClass}.cs");
    using var writer = File.CreateText(endpointClassFile);
    writer.Write($"""
                  using Application.{endpointClass}.{endpointName};
                  {endpointContent}

                  [Http{httpVerbPascal}(Constants.Routes.{endpointName})]
                  public sealed class {endpointName} : {responseEndpointType}<{endpointName}Request, {endpointName}Response>;
                  """);
}
else
{
    Console.WriteLine($"Class {endpointName} in {endpointClass}.cs already exists");
}

var routesFilePath = Path.Join(cd, webApiProjectPath, "Constants/Routes.cs");

var routesContent = File.ReadAllText(routesFilePath);
routesContent = routesContent.TrimEnd('\n', '\r', '\t', ' ', '}');

if (!routesContent.Contains($"public const string {endpointName}"))
{
    Console.WriteLine($"Adding route for {endpointName} in Routes.cs");
    using var writer = File.CreateText(routesFilePath);
    writer.Write($$$"""
                    {{{routesContent}}}
                        public const string {{{endpointName}}} = $"{ApiRoute}/{{{routename.TrimStart('/')}}}";
                    }
                    """);
}
else
{
    Console.WriteLine($"Route for {endpointName} already exists in Routes.cs");
}


var applicationEndpointFolder = new DirectoryInfo(Path.Join(cd, applicationProjectPath, endpointClass));

if (!applicationEndpointFolder.Exists)
    applicationEndpointFolder.Create();

var applicationEndpointContentFolder = new DirectoryInfo(Path.Join(applicationEndpointFolder.FullName, endpointName));

if (!applicationEndpointContentFolder.Exists)
    applicationEndpointContentFolder.Create();

var handlerPath = Path.Join(applicationEndpointContentFolder.FullName, $"{endpointName}Handler.cs");
using (var writer = File.CreateText(handlerPath))
{
    Console.WriteLine($"write {endpointName}Handler.cs");
    writer.Write($$"""
                   using Application.Common;

                   namespace Application.{{endpointClass}}.{{endpointName}};

                   public sealed class {{endpointName}}Handler(IServiceProvider serviceProvider) : BaseHandler<{{endpointName}}Request, {{endpointName}}Response>(serviceProvider)
                   {
                       public override Task<{{endpointName}}Response> ExecuteAsync({{endpointName}}Request command, CancellationToken ct)
                       {
                           return Task.FromResult(new {{endpointName}}Response() { });
                       }
                   }

                   """);
}

var requestPath = Path.Join(applicationEndpointContentFolder.FullName, $"{endpointName}Request.cs");
using (var writer = File.CreateText(requestPath))
{
    Console.WriteLine($"write {endpointName}Request.cs");
    writer.Write($$"""
                   using Application.Common;

                   namespace Application.{{endpointClass}}.{{endpointName}};

                   public sealed class {{endpointName}}Request : BaseRequest<{{endpointName}}Response>
                   {
                       
                   }


                   """);
}

var responsePath = Path.Join(applicationEndpointContentFolder.FullName, $"{endpointName}Response.cs");
using (var writer = File.CreateText(responsePath))
{
    Console.WriteLine($"write {endpointName}Response.cs");
    writer.Write($$"""
                   using Application.Common.Response;

                   namespace Application.{{endpointClass}}.{{endpointName}};

                   public sealed class {{endpointName}}Response : {{responseType}}
                   {
                       
                   }


                   """);
}

Console.WriteLine("");
Console.WriteLine("adding to git...");

var process = new Process()
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "/bin/bash",
        Arguments = $"-c \"git add {handlerPath} ; git add {requestPath} ; git add {responsePath}\"",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true,
    }
};
process.Start();
process.WaitForExit();


void ShowHelp()
{
    Console.WriteLine("Use this tool as follows:");
    Console.WriteLine("dotnet clean-endpoint new [endpoint-name] [endpoint-class] [endpoint-type] [http-verb] [routename]");
    Console.WriteLine("possible endpoint-types: json, string, empty, file");
    Console.WriteLine("possible http verbs: get, post, put, patch, delete");
}
