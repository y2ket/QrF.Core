@echo off
title Ids4
echo Starting...
set ASPNETCORE_ENVIRONMENT=Development
dotnet bin/Debug/netcoreapp2.2/QrF.Core.Admin.dll --console
