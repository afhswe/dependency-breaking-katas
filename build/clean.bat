@if exist %~n0%~x0 @cd ..



cd Java
call mvn clean
cd ..



cd CSharp
call dotnet clean
rmdir /S /Q DependencyBreakingKatas\bin
rmdir /S /Q DependencyBreakingKatas\obj
rmdir /S /Q DependencyBreakingTests\bin
rmdir /S /Q DependencyBreakingTests\obj
cd ..



pause
