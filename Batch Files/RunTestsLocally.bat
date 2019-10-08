@REM Next line runs tests through MSTEST, using the DLL that the project builds.
CALL "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\MSTest.exe" /nologo /testcontainer:c:\SAPLTestBinaries\Release\SAPLTests.dll /resultsfile:c:\SAPLTestResults\SAPLTestResults.trx

@REM Generate the HTML report
"%SAPL_TEST_ROOT%\packages\SpecFlow.1.9.0\tools\SpecFlow" mstestexecutionreport "C:\SAPLTestBinaries\SAPL Test Framework.csproj" /testResult:C:\SAPLTestResults\SAPLTestresults.trx /out:C:\SAPLTestResults\AWG70001PQ002_v3.1.0133_Testresults.htm

