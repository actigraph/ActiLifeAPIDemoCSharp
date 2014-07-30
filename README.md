This repository contains C# implementations of the ActiLife API.

* [ActiLife](http://actigraphcorp.com/actilife) 6.7 or greater is required to utilize the API Tester and Library.
* The API feature toggle must be licensed through ActiGraph.

ActiLife API Documentation
==========================
This codebase is built on the ActiLife API documentation: https://github.com/actigraph/ActiLifeAPIDocumentation

ActiLifeAPILibrary
==================
Library that provides an easy to use implementation of ActiLife API.  This Library handles connecting, sending and receiving data from ActiLife with public endpoints wrapped in c# methods.  The Library is based on .NET 4.0 and utilizes Tasks to ensure long running tasks do not block the calling threads.

Example usage of Library:

```
using (var api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
{
  try {
    bool connected = await api.Connect();
    if (api.IsConnected)
      var response = await api.GetActiLifeVersion();
  }
  catch(AggregateException ex) { } //handle Task exception
}
```

ActiLifeAPITester
=================
This project is a .NET 4.0 GUI application built on the ActilifeAPILibrary that provides an easy way to test requests and responses against ActiLife. 

To use, run ActiLife with the API feature toggle enabled. The GUI can then be connected to ActiLife and the built in tests can be populated to the upper request text area. Responses are then obtained by clicking Send Request.

Pre-built releases are found in the [release section of this repository](https://github.com/actigraph/ActiLifeAPIDemoCSharp/releases)

![2014-07-30_17-50-33](https://cloud.githubusercontent.com/assets/92913/3757691/1e56f114-183c-11e4-852f-f11bf0b1071b.png)
