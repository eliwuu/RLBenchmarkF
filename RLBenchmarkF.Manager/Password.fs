namespace RLBenchmarkF.Manager
open System.Security.Cryptography

module Password =
    let create (password: string) = 
        let hmac = new HMACSHA512()
        let salt = hmac.Key
        let passwordAsBytes = System.Text.Encoding.UTF8.GetBytes(password)
        let hash = hmac.ComputeHash(passwordAsBytes)

        (hash, salt)

    let verify (password: string, hash: byte[], salt: byte[]) = 
        let hmac = new HMACSHA512(salt)
        let passwordAsBytes = System.Text.Encoding.UTF8.GetBytes(password)
        let computedHash = hmac.ComputeHash(passwordAsBytes)

        hash = computedHash
        
