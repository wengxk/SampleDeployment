rm -Recurse -Force  ..\Publish\SampleCoreApp\
dotnet publish ..\SampleCoreApp\SampleCoreApp.csproj -o ..\Publish\SampleCoreApp\  -c Release -r linux-x64 --self-contained true /p:PublishSingleFile=true
pause