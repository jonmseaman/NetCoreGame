dotnet build

# $runtimes = "win10-x64", "win7-x64", "linux-x64"
$runtimes = "win10-x64"

New-Item -ItemType Directory -Force -Path Bin\publish\
foreach ($r in $runtimes) {
    dotnet publish Game -c Release -f netcoreapp2.0 -r $r
    Compress-Archive -Force ".\Game\bin\Release\netcoreapp2.0\${r}\publish\*" "Bin\publish\${r}.zip"
}

echo "Success"
