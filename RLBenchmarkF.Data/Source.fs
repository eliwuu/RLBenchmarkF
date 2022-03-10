namespace RLBenchmarkF.Data

open System
open RLBenchmark.Data
open MongoDB.Driver
open System.Collections.Generic

module Collection = 

    let db = Db.client.GetDatabase("RLDB")
    let get<'T> (collectionName: string, predicate: FilterDefinition<'T>) = 
        db
            .GetCollection(collectionName)
            .FindAsync(predicate)
    let insertMany<'T> (collectionName: string, data: IEnumerable<'T>) = 
        db
            .GetCollection(collectionName)
            .InsertManyAsync(data)

    let insertOne<'T> (collectionName: string, data: 'T) =
        db
            .GetCollection(collectionName)
            .InsertOneAsync(data)
    let update<'T> (collectionName: string, predicate: FilterDefinition<'T>, data: 'T ) = 
        match typeof(IEnumerable) with
            | IsAssignableFrom
        db
            .GetCollection(collectionName)
            
    let delete<'T> (collectionName: string, predicate: Func<'T, bool>) = db
