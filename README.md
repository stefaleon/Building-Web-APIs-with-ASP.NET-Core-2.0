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


### 05 Model binding and validation

* The route values have priority over the query parameters.

* Objects can be declared as route value types.

* Create the *Value* class, edit the POST method and pass abiding objects to the POST request body.

* Add validation with data annotations to the *Value* class.

```
public class Value
{
    public int Id { get; set; }

    [MinLength(3)]
    public string Text { get; set; }
}
```

* **Don't forget to check the model state**.

```
[HttpPost]
//public void Post([FromBody]string value)
//{
//}
public void Post([FromBody]Value value)
{
    if (!ModelState.IsValid)
    {
        throw new InvalidOperationException("Model state is invalid!");
    }
}
```


### 06 Action results

* Returning objects that implement `IActionResult` or `Task<IActionResult>` gives us a lot of very convenient prebuilt functionality.

* Edit the POST method in order to return an `IActionResult` and use `BadRequest` and `CreatedAtAction`.

```
// POST api/<controller>
[HttpPost]        
public IActionResult Post([FromBody]Value value)
{
   if (!ModelState.IsValid)
   {
       return BadRequest(ModelState);
   }

   // save the value to db etc...

   return CreatedAtAction("Get", new { id = value.Id }, value);
}
```

* Edit the GET by Id method in order to return an `IActionResult` and use `Ok`.

```
// GET api/<controller>/5
[HttpGet("{id}")]
public IActionResult Get(int id)
{
    return Ok(new Value { Id = id, Text = "okeyvalue" + id });
}
```


### 07 Formatters

* Remember to use **[FromBody]** in order to use input formatters.

* Output formatters handle response content negotiation. 

* Constrain formats per action using **[Produces/Consumes]**.

```
/ GET: api/<controller>
[HttpGet]
[Produces("application/json")] // restricts the response to JSON format only
public IEnumerable<string> Get()
{
    return new string[] { "value1", "value2" };
}
````
