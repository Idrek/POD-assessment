# POD assessment

Home assessment for the [POD group](https://podgroup.com/).

## Usage

### Clone repository:

`$ git clone https://github.com/Idrek/POD-assessment && cd $_`

### Install dotnet tools listed in the manifest file:

`$ dotnet tool restore`

### Run build script to build the application, run tests and package it:

`$ dotnet fake run build.fsx`

### Test the package in a different project:

`$ nuget add packages/POD.1.0.0.nupkg -Source /tmp/source/nuget`

`$ cd /tmp && dotnet new console --language F# --name Demo && cd $_`

`$ dotnet add package POD --source /tmp/source/nuget --version 1.0.0`


Replace the code in `Program.fs` with:

```
module R = Roman

R.fromDecimal 19 |> printfn "Output: %A"
```

And run: 

`$ dotnet run --project Demo.fsproj`

## Note:

To avoid losing the code formatting with fantomas as a client git hook, I have saved it in `githooks/pre-commit`, so a symlink is neccesary from the `.git/hooks` directory, like:

`$ ln -s '../../githooks/pre-commit' '.git/hooks/pre-commit'`
