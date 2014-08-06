This repository contains C# implementations of the ActiLife API.

* [ActiLife](http://actigraphcorp.com/actilife) 6.7 or greater is required to utilize the API Tester and Library.
* The API feature toggle must be licensed through ActiGraph.

ActiLife API Documentation
==========================
This codebase is built on the ActiLife API documentation: https://github.com/actigraph/ActiLifeAPIDocumentation

ActiLifeAPILibrary
==================
Library that provides an easy to use implementation of ActiLife API.  This ActilifeAPILibrary handles connecting, sending and receiving data from ActiLife with public endpoints wrapped in c# methods.  The Library is based on .NET 4.0 and utilizes Tasks to ensure long running tasks do not block the calling threads.

#### Connecting to ActiLife via the API and obtaining a result


```c#
using (var api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
{
  try {
    bool connected = await api.Connect();
    if (!api.IsConnected) return; //can also use connected bool
      
    string responseJSON = await api.GetActiLifeVersion();
  }
  catch(AggregateException ex) { } //handle Task specific exception
  catch(Exception ex) { } //handle misc exception
}
```

#### Parsing JSON Data

Parsing data received from ActiLife is recommended via JSON.net.  The ActilifeAPILibrary contains an extension to easily obtain data from the JSON.net JObject/JToken class that is returned from Deserializing the JSON string:

```c#
using (var api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
{
  try {
    bool connected = await api.Connect();
    if (!api.IsConnected) return; //can also use connected bool
    
    JObject parsedJSON = JsonConvert.DeserializeObject<JObject>(await api.GetActiLifeVersion());
    
    bool success = parsedJSON.GetValueFromJToken<bool>("Success");
    if (!success) Console.WriteLine("ActiLife did not handle API command!");
    else
    {
      var payload = parsedJSON["payload"];
      if (payload != null)
      {
        string version = payload.GetValueFromJToken<string>("Version");
        
        Console.WriteLine(version);
      }
    }
  }
  catch(AggregateException ex) { } //handle Task specific exception
  catch(Exception ex) { } //handle misc exception
}
```

Will print a version string similar to:

> 6.11.0

The **GetValueFromJToken()** is an extension and might require a using statement to be used:

```
using ActiLifeAPILibrary;
```

#### Using Library endpoints with Request Models

All ActiLife API endpoints (or Actions) are represented with the ActilifeAPILibrary extended on the **ActiLifeAPIConnection**.  Some of these Actions require options (or Arguments) for ActiLife to respond.  These models can be inlined to the api call:

```c#
using (var api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
{
  try {
    bool connected = await api.Connect();
    if (!api.IsConnected) return; //can also use connected bool
    
    var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    
    string responseJSON = api.ConvertFile(
      new ActiLifeAPILibrary.Models.Request.ConvertFile
      {
        Options = new ActiLifeAPILibrary.Models.Actions.ConvertFile
        {
          FileInputPath = System.IO.Path.Combine(assemblyDir, "input.gt3x"),
          FileOutputPath = System.IO.Path.Combine(assemblyDir, "output.csv"),
          FileOutputFormat = "rawcsv"
        }
      }
    );
  }
  catch(AggregateException ex) { } //handle Task specific exception
  catch(Exception ex) { } //handle misc exception
}
```

ActiLifeAPITester
=================
This project is a .NET 4.0 GUI application built on the ActilifeAPILibrary that provides an easy way to test requests and responses against ActiLife. 

To use, run ActiLife with the API feature toggle enabled. The GUI can then be connected to ActiLife and the built in tests can be populated to the upper request text area. Responses are then obtained by clicking Send Request.

Pre-built releases are found in the [release section of this repository](https://github.com/actigraph/ActiLifeAPIDemoCSharp/releases)

![2014-07-30_17-50-33](https://cloud.githubusercontent.com/assets/92913/3757691/1e56f114-183c-11e4-852f-f11bf0b1071b.png)
