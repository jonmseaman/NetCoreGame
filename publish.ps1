dotnet restore
dotnet build

$runtimes = "win10-x64", "win7-x64", "ubuntu.16.04-x64"

New-Item -ItemType Directory -Force -Path Bin\publish\
foreach ($r in $runtimes) {
    dotnet publish Game -c Release -f netcoreapp1.1 -r $r
    Compress-Archive -Force ".\Game\bin\Release\netcoreapp1.1\${r}\publish\*" "Bin\publish\${r}.zip"
}
