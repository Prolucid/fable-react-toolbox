// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"

open System
open System.IO
open Fake
open Fake.NpmHelper
open Fake.ReleaseNotesHelper
open Fake.Git

let yarn = ProcessHelper.tryFindFileOnPath (if isWindows then "yarn.cmd" else "yarn")
           |> Option.get // make sure there's npm yarn is installed

// Filesets
let projects  = !! "src/**.fsproj"


let dotnetcliVersion = "1.0.1"
let mutable dotnetExePath = "dotnet"

let runDotnet workingDir =
    DotNetCli.RunCommand (fun p -> { p with ToolPath = dotnetExePath
                                            WorkingDir = workingDir } )

Target "InstallDotNetCore" (fun _ ->
   dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)


// Target "Install" (fun _ ->
//     Npm (fun p ->
//     { p with
//         NpmFilePath = yarn
//     })
//     projects
//     |> Seq.iter (fun s -> 
//         let dir = IO.Path.GetDirectoryName s
//         runDotnet dir "restore"
//        )
//     "paket-files" </> "xyncro" </> "aether" </> "src" </> "Aether" </> "Aether.fs"
//     |> CopyFile "src"
// )

Target "Build" (fun _ ->
    runDotnet "src" "build"
)

Target "Test" (fun _ ->
    runDotnet "tests" "fable npm-run test"
)

let release = LoadReleaseNotes "RELEASE_NOTES.md"

Target "Meta" (fun _ ->
    [ "<Project xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"
      "<PropertyGroup>"
      "<Description>Fable bindings for React Toolbox</Description>"
      "<PackageProjectUrl>https://github.com/Prolucid/fable-react-toolbox</PackageProjectUrl>"
      "<PackageLicenseUrl>https://raw.githubusercontent.com/prolucid/fable-react-toolbox/master/LICENSE</PackageLicenseUrl>"
      "<RepositoryUrl>https://github.com/Prolucid/fable-react-toolbox.git</RepositoryUrl>"
      "<PackageTags>material;design;react;fsharp;fable</PackageTags>"
      "<Authors>Justin Sacks</Authors>" 
      sprintf "<Version>%s</Version>" (string release.SemVer)
      "</PropertyGroup>"
      "</Project>"]
    |> WriteToFile false "Meta.props"
)

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target "Package" (fun _ ->
    runDotnet "src" "pack"
)

Target "PublishNuget" (fun _ ->
    let args = sprintf "nuget push Fable.ReactToolbox.%s.nupkg -s nuget.org -k %s" (string release.SemVer) (environVar "nugetkey")
    runDotnet "src/bin/Debug" args
)


let gitOwner = "prolucid"
let gitName = "fable-react-toolbox"
let gitHome= sprintf "https://github.com/%s" gitOwner

#load "paket-files/build/fsharp/FAKE/modules/Octokit/Octokit.fsx"
open Octokit

Target "Release" (fun _ ->
    let user =
        match getBuildParam "github-user" with
        | s when not (String.IsNullOrWhiteSpace s) -> s
        | _ -> getUserInput "Username: "
    let pw =
        match getBuildParam "github-pw" with
        | s when not (String.IsNullOrWhiteSpace s) -> s
        | _ -> getUserPassword "Password: "
    let remote =
        Git.CommandHelper.getGitResult "" "remote -v"
        |> Seq.filter (fun (s: string) -> s.EndsWith("(push)"))
        |> Seq.tryFind (fun (s: string) -> s.Contains(gitOwner + "/" + gitName))
        |> function None -> gitHome + "/" + gitName | Some (s: string) -> s.Split().[0]

    StageAll ""
    Git.Commit.Commit "" (sprintf "Bump version to %s" release.NugetVersion)
    Branches.pushBranch "" remote (Information.getBranchName "")

    Branches.tag "" release.NugetVersion
    Branches.pushTag "" remote release.NugetVersion

    // release on github
    createClient user pw
    |> createDraft gitOwner gitName release.NugetVersion (release.SemVer.PreRelease <> None) release.Notes
    |> releaseDraft
    |> Async.RunSynchronously
)

Target "Publish" DoNothing

// Build order
"Meta"
  ==> "InstallDotNetCore"
//   ==> "Install"
  ==> "Build"
//  ==> "Test"
  ==> "Package"


"Publish"
  <== [ "Build"
        "PublishNuget"
        "Release" ]
  
  
// start build
RunTargetOrDefault "Build"
