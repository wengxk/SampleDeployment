rm -Recurse -Force  ..\Publish\SampleBlazorApp\
dotnet publish ..\SampleBlazorApp\SampleBlazorApp.csproj -o ..\Publish\SampleBlazorApp\  -c Release -r linux-x64 --self-contained true
pause