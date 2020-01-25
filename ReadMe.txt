Retrospectives
--------------

The solution consists of 3 projects.
1) The API (restful service)
2) Unit tests for the API
3) The Front End (written in React)

The API
-------

The API was created in Visual Studio 2019.
Restore the NuGet packages.
The API is configured to run under SSL, if you choose to not run it under SSL, then the baseurl will need to be changed in the react front end (found in src/common.js).
If you use Visual Studio to run the API, and it's your first time running it under SSL, it will ask you to install a self signing certificate, which you must do.
Basic logging is stored in memory as there is no db. This can be found in the Filters\LoggingFilter.cs class.
Exceptions are also stored in memory, again as there is no db. This can be found in the ErrorHandlingMiddleware class.

Some notes on the architecture.
A lot of projects use a controller with a respository that is dependancy injected.
This solutions adds another abstract layer called an engine, therefore you have a controller, an engine and a repository. (both the engine and repository are dependancy injected)
The reason behind this is for 2 reasons.

1. The main reason is to keep the controller thin (does not have a lot of code). The controller in this project contains no business logic, it's all abstracted away into the engine.
Therefore the controller only needs to worry about the end points, security around the endpoints (which doesn't pertain to this demo), and sending back the correct response types.
If you look at the controller code, you wil see it inherits from a base controller, which expected an engine interface generic which it will implement.

2. A second reason (although not entirely neccessary), is the engine (like the respository), is dependacy injected into the controller as well. 
This means the controller is decoupled from the engine (business logic), and you can easily swap it out if need be.

The drawback to doing this architecture, is there is a lot more setup and files with base classes. It may not be necessary in a small project like this, but it's an idea that has worked for
me on a couple of larger projects.

The Unit Tests
--------------

These can be run from Visual Studio.

The Front End
-------------

You have to use node to run the front end. (npm start).
There are some unit tests as well, to test these you can run the following command: npm test
As mentioned above, if you have not run the API under SSL, you will need to change the baseurl (found in src/common.js) to http://localhost:61575/api/