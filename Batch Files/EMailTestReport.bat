Cd\

CD %SAPL_Test_Root%\Batch Files\blat306_32
blat.exe -body "See attached ZIP file for HTML report, error image captures and test scripts for this run. Open the HTML file in a browser for full link functionality." -s "%1 %2 options 150 Overnight Test Results" -tf MailingList.txt -server mail.tek.com -f %4 -attach "C:\temp\SAPL VOE\%2_v%1_wOPT%3_TestResults.zip" -embed "C:\SAPLTestResults\%2_v%1_wOPT%3_TestResults.htm"


