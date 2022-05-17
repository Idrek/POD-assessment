#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.DotNet.Testing.Expecto
nuget Fake.IO.FileSystem
nuget Fake.Core.Target //"

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

Target.initEnvironment ()

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "test/**/bin"
    ++ "test/**/obj"
    |> Shell.cleanDirs)

Target.create "BuildApp" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "BuildTests" (fun _ ->
    !! "test/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "RunTests" (fun _ ->
    let assemblyName : string = "./test/bin/Release/net6.0/PODTest.dll"
    Fake.DotNet.Testing.Expecto.run
        (fun parameters -> { parameters with WorkingDirectory = "."}) 
        (Seq.singleton assemblyName) 
)

Target.create "CreatePackage" (fun _ ->
    let project : string = "./src/POD.fsproj"
    let packConfiguration (defaults: DotNet.PackOptions) =
        { defaults with
            Configuration = DotNet.Release
            OutputPath = Some "./packages"
        }
    DotNet.pack packConfiguration project
)

Target.create "All" ignore

"Clean" 
    ==> "BuildApp" 
    ==> "BuildTests"
    ==> "RunTests"
    ==> "CreatePackage"
    ==> "All"

Target.runOrDefault "All"
