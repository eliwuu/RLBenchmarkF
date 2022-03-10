namespace RLBenchmarkF.Models
open Microsoft.Extensions.Logging
open RLBenchmarkF.Manager



module User = 

    let logger (_logger: ILogger, logLevel: LogLevel, message: string) = _logger.Log(logLevel, message)
    //let get ()

    type Role = Client | Manager | Admin

    type LoginDto = { Email: string; Password: string }
    type RegisterDto = { First: string; Last: string; Email: string; Password: string }

    type Model = { 
        Id: string; 
        Role: Role; 
        First: string; 
        Last: string; 
        Salt: byte[]; 
        Hash: byte[]; 
        Email: string 
        } 

    let create (userRegister: RegisterDto) = 
        Password.create(userRegister.Password)
    let exist (email: string) = true
    let delete (email: string) = true
    let update (user: Model) = user
    let get (email: string) = exist

    let authenticate (userLogin: LoginDto) = 
        match exist(userLogin.Email) with
            | true -> Password.verify(userLogin.Password)
            | false -> 
    let authorize (user: Model) = Role.Client



