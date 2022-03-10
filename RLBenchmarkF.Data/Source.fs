namespace RLBenchmarkF.Data

open System

module Source = 
    let db = 1
    let get<'T> (sourceName: string, predicate: Func<'T, bool>) = db
    let set<'T> (sourceName: string, data: 'T) = db
    let update<'T> (sourceName: string, predicate: Func<'T, bool>, data: 'T ) = db
    let delete<'T> (sourceName: string, predicate: Func<'T, bool>) = db