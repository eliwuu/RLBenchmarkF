namespace RLBenchmarkF.Api.Controllers

open RLBenchmarkF.Models
open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open RLBenchmarkF.Api


[<ApiController>]
[<Route("[controller]")>]

type UserController (logger : ILogger<UserController>) =
    inherit ControllerBase()

    [<HttpPost("create")>]
    member _.Create(registerDto : User.RegisterDto) = 
        match User.exist(registerDto.Email) with 
            | false -> User.create(registerDto) |> JsonResult
            | true -> JsonResult($"User already exist")
