module Manager

open System
open Xunit
open RLBenchmarkF.Manager

[<Fact>]
let ``Password hash and verify true`` () =
    let password = "abcd";
    let (hash, salt) = Password.create(password);
    let verify = Password.verify(password, hash, salt)
    Assert.True(verify)
