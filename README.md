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


### 04 Optional, default and constrained route values

* Optional route values: {id?}

* Default route values: {id=1234}

* Constrains: {id:int}

```
// GET api/<controller>/5
//[HttpGet("{id}")] //standard
//[HttpGet("{id?}")] //optional
//[HttpGet("{id=42}")] //optional with a default value
[HttpGet("{id:int}")] //constrain to int
public string Get(int id)
{
    return $"value {id}";
}
```
