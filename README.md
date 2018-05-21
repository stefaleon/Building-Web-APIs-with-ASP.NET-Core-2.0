## [Building Web APIs with ASP.NET Core 2.0](https://www.youtube.com/watch?v=aIkpVzqLuhA)


### 01 Start an empty Core 2 Web App

* New Project -> ASP.NET Core Web Application-> Empty


### 02 Add an MVC service

* Edit *Startup.cs*.

```
services.AddMvc();
```

```
app.UseMvc();
```

### 03 Add the Web API controller

* Add the *Controllers* folder and inside add a class for the Web API using the *Web API Controller Class* template.

* Set the *ValuesController* class to derive from *ControllerBase* rather than from *Controller* in order to reduce some Intellisense noise.

* Edit the GET by Id route in order to display the Id value.
