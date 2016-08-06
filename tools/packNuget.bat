@echo off
nuget pack nuget\KirkChen.EFRepository.nuspec -Version %APPVEYOR_REPO_TAG_NAME%