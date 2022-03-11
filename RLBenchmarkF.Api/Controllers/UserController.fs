namespace RLBenchmarkF.Api.Controllers

open RLBenchmarkF.Models
open RLBenchmarkF.Data.Collection
open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open RLBenchmarkF.Api
open RLBenchmarkF.Data
open MongoDB.Driver


[<ApiController>]
[<Route("[controller]")>]

type UserController (logger : ILogger<UserController>) =
    inherit ControllerBase()

    [<HttpGet("getinit")>]
    member _.Getinit =
        Collection.outdb.GetDatabase("RLDB").CreateCollectionAsync("User") |> Async.AwaitTask |> ignore
        "OK" |> JsonResult

    [<HttpPost("create")>]
    member _.Create(registerDto : User.RegisterDto) = 
        match User.exist(registerDto.Email) with 
            | false -> registerUser(registerDto) |> JsonResult
            | true -> JsonResult($"User already exist")

    [<HttpGet("omg")>]
    member _.Get() =
        getUsers (FilterDefinition.Empty) |> fun x -> x.ToString