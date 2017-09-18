open System

// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。

let XOR a b =
    if a = b then 0b0
    else 0b1

let KeyGen k =
    let random = Random()
    let key = Array.create k 0b0
    for i in 0..(k - 1) do
        let rdm = random.Next(100)
        let which =
            if rdm <= 50 then
                0b0
            else
                0b1
        key.[i] <- which
    key

let Enc (key: int[]) (data: int[]) =
    let cipher = Array.create data.Length 0b0
    for i in 0..(data.Length - 1) do
        cipher.[i] <- XOR key.[i] data.[i]
    cipher

let Dec (key: int[]) (cipher: int[]) =
    Enc key cipher
    
[<EntryPoint>]
let main argv =
    let raw = [|0b0; 0b1; 0b0; 0b0; 0b1; 0b0; 0b1; 0b0|]
    let key = KeyGen raw.Length
    let cipher = Enc key raw
    let data = Dec key cipher
    printfn "raw\t%A" raw
    printfn "key\t%A" key
    printfn "cipher\t%A" cipher
    printfn "data\t%A" data

    Console.ReadKey() |> ignore

    0 // 整数の終了コードを返します
