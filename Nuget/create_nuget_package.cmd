@echo off
forfiles /m *.nuspec /c "cmd /c nuget.exe pack @file"
pause