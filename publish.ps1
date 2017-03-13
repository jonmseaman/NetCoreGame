dotnet restore
dotnet build

dotnet publish Game -c Release -f netcoreapp1.1 -r win10-x64
dotnet publish Game -c Release -f netcoreapp1.1 -r win7-x64
dotnet publish Game -c Release -f netcoreapp1.1 -r ubuntu.16.04-x64
