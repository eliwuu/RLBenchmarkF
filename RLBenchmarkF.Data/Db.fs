namespace RLBenchmark.Data

open Microsoft.Extensions.Configuration
open System.IO

open MongoDB.Bson
open MongoDB.Driver
open System.IO

module AppSettings = 
    let configuration = 
        ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()

module internal Db = 
    let connectionString = 
        AppSettings
            .configuration
            .GetConnectionString("db");

    let settings = connectionString.Replace("myFirstDatabase", "RLDB") |> MongoClientSettings.FromConnectionString
    settings.ServerApi <- ServerApiVersion.V1 |> ServerApi

    let client = settings |> MongoClient