// See https://aka.ms/new-console-template for more information
using Session_07;


ActionRequest request = new ActionRequest(Guid.NewGuid(),"Welcome",ActionRequest.ActionEnum.Reverse);

ActionResolver resolver = new ActionResolver();
ActionResponse response = new ActionResponse(Guid.NewGuid());
response = resolver.Execute(request);
request = new ActionRequest(Guid.NewGuid(), "Welcome man", ActionRequest.ActionEnum.Uppercase);
response = resolver.Execute(request);
request = new ActionRequest(Guid.NewGuid(), "10", ActionRequest.ActionEnum.Convert);
response = resolver.Execute(request);
request = new ActionRequest(Guid.NewGuid(), "rip", ActionRequest.ActionEnum.Convert);
response = resolver.Execute(request);

resolver.Logger.ReadAll();
Console.ReadLine();