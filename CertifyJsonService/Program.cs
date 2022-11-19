using System.Text.Json;
using CertifyJsonService;
using CertifyJsonService.Models;
using static System.Console;
using static System.Net.WebRequestMethods;

WriteLine("Certify Json Service");

var cliParms = CommandLineParameters.ParseCommandLinesParameters(args);

string url = cliParms["url"] ?? "http://localhost";
string port = cliParms["port"] ?? "5000";
string model = cliParms["model"] ?? "users";


ApiTestController<User> userCtrl = new(url, port, model);

var users = await userCtrl.TestList();
users.ToList().ForEach(u => WriteLine(u));

ApiTestController<Vendor> vendCtrl = new(url, port, "vendors");

var vendors = await vendCtrl.TestList();
vendors.ToList().ForEach(v => WriteLine(v));
