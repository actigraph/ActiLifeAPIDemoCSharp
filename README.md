This repository contains CSharp implementations of the ActiLife API.

* [ActiLife](http://actigraphcorp.com/actilife) 6.9 or greater is required to utilize the API Tester and Library.
* The API feature toggle must be licensed through ActiGraph.

ActiLife API Documentation
==========================
This codebase is built on the API documentation that can be found:
https://github.com/actigraph/ActiLifeAPIDocumentation

ActiLifeAPILibrary
==================
Library that provides an easy to use implementation of ActiLife API.  This Library handles connecting, sending and receiving data from ActiLife with Endpoints wrapped in methods.  The Library is based on .NET 4.0 and utilizes Tasks to ensure long running tasks do not block the calling threads.

Example usage of Library:

```
using (var api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
{
  try {
    await api.Connect();
    await api.GetActiLifeVersion();
  }
  catch(AggregateException ex) { } //handle Task exception
}
```

ActiLifeAPITester
=================
This project is a GUI tester application that provides an easy way to test request and responses against ActiLife.

Pre-built releases are found in the [release section of this repository](https://github.com/actigraph/ActiLifeAPIDemoCSharp/releases)

![screenshot 2014-07-29 16 03 00](https://cloud.githubusercontent.com/assets/92913/3741868/c8597c6a-1763-11e4-89dd-bc45542cf25e.png)

To use, run ActiLife with the API feature toggle enabled. The GUI can then be connected to ActiLife and the built in tests can be populated to the Request text area. Responses can be obtained by clicking Send Request.

* ActiLife must be running before starting the API demo.


