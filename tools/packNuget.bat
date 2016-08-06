@echo off
nuget pack nuget\EFRepository.1.0.0.nuspec -Version %APPVEYOR_REPO_TAG_NAME%