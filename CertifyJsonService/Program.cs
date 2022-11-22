using System.Text.Json;
using System.Linq;
using CertifyJsonService;
using CertifyJsonService.Models;
using static System.Console;
using static System.Net.WebRequestMethods;

WriteLine("Certify Json Service");

CommandLineParameters.Parse(args);

ApiTestController<User> userCtrl = new("http://localhost", "5000", model: "users");
//var users = await userCtrl.List();
//users.ToList().ForEach(u => WriteLine(u));

WriteLine("All Users:");
var users = await userCtrl.List();
users.ToList().ForEach(u => WriteLine(u));
var newUser = await userCtrl.Create(User.NewUser);
WriteLine("New User:");
WriteLine(newUser);
newUser.Firstname = "ABC";
await userCtrl.Change(newUser.Id, newUser);
var chgUser = await userCtrl.Get(newUser.Id);
WriteLine("Changed:");
WriteLine(chgUser);
await userCtrl.Remove(newUser.Id);
users = await userCtrl.List();
WriteLine("All Users:");
users.ToList().ForEach(u => WriteLine(u));


/*
var user = await userCtrl.Get(1);
WriteLine(user?.ToString() ?? "(null)");

var users = await userCtrl.List();
users.ToList().ForEach(u => WriteLine(u));

ApiTestController<Vendor> vendCtrl = new(url, port, model: "vendors");
var vendor = await vendCtrl.Get(1);
WriteLine(vendor?.ToString() ?? "(null)");

var vendors = await vendCtrl.List();
vendors.ToList().ForEach(v => WriteLine(v));

ApiTestController<Product> prodCtrl = new(url, port, model: "products");
var product = await prodCtrl.Get(1);
WriteLine(product?.ToString() ?? "(null)");

var products = await prodCtrl.List();
products.ToList().ForEach(p => WriteLine(p));
*/