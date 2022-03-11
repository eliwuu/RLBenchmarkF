namespace RLBenchmarkF.Data

open System
open RLBenchmarkF.Models
open MongoDB.Driver
open MongoDB.Bson
open System.Collections.Generic
open RLBenchmarkF.Manager

module Collection =

    let outdb = Db.client;

    let internal db = Db.client.GetDatabase("RLDB")
    let internal get<'T> (collectionName: string, predicate: FilterDefinition<'T>) = 
        db
            .GetCollection(collectionName)
            .FindAsync(predicate) |> Async.AwaitTask
    let internal insertMany<'T> (collectionName: string, data: IEnumerable<'T>) = 
        db
            .GetCollection(collectionName)
            .InsertManyAsync(data)

    let internal insertOne<'T> (collectionName: string, data: 'T) =
        db
            .GetCollection(collectionName)
            .InsertOneAsync(data) |> Async.AwaitTask
        

    let internal update<'T> (collectionName: string, predicate: FilterDefinition<'T>, data: 'T ) = 
        db
            .GetCollection(collectionName)

            
    let internal delete<'T> (collectionName: string, predicate: Func<'T, bool>) = db


    let getUsers predicate  = get<User.Model>("User", predicate)
    let insertUser data = insertOne<User.Model>("User", data)
    let registerUser (registerDto : User.RegisterDto) =
        let hash, salt = Password.create(registerDto.Password)

        insertUser(
            {
                Id = new ObjectId();
                Role = User.Role.Client;
                First = registerDto.First;
                Last = registerDto.Last;
                Email = registerDto.Email;
                Hash = hash;
                Salt = salt
            }) |> fun x -> x.ToJson()

        