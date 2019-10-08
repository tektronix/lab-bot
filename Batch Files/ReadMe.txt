...\SSPL-SQA\SQA\SAPL Test Framework\Batch Files 

NOTE: You should have the following environment variables set:
 - DOORS_ROOT: Should be set to the folder where your DOORS.EXE resides
 - STRESS_ROOT: Should be set to the local snapshot view ...\SQA\Test Tools\PI_Stress folder
 - SAPLL_TEST_ROOT: Should be set to the location where your local snapshot version of the Pascal Test Framework.csproj files resides. 
 
Folders:
\blat306_32 - Contains the BLAT.EXE program that handles the e-mailing of the test report to a mailing list.

\deprecated - Folder with older versions of scripts that are not currently used, but may provide examples for developing your own batch files

Files:

AWG_FirstBoot.bat - Used by the overnight test automation to launch an AutoIt script on the first reboot following a software upgrade. You need the delay in the batch file so that the executable is not started too soon (it will fail, or interfere with AWG app start up if it does).

BuildSolution.bat - Runs the command-line compiler on the test framework to produce the SAPLTests.dll assembly.

CopyDirectoriesInClearCase.bat - 

DailyCheckouts.bat - Run your scheduled tasks manager each day to let you know what files yo have checked out at the end of the day.

GenerateSpecflow.bat - Generates *.cs files from *.feature files downloaded with GetSAPLTests.bat in the local test framework snapshot \Tests folder.

GenerateTestReport.bat - Generates the HTML report from the MSTest *.trx output file using SpecFlow on the PC running the script. SpecFlow must be installed on the machine running the script (and not necessarily the target instrument). The report is generated from the trx output located on the target instrument and the html file is created on the target instrument.

GetSAPLTests.bat - Downloads the current crop of Pascal automated tests to your local test framework \Tests folder as *.feature files. Note, although the script was written to close DOORS when it is done, DOORS often will not close and you have to do it manually.

kavinGetPascalTests.bat - This is a script that Kavitha runs from Bangalore that runs DOORS and exports tests to PC-BEAV-1081 so that she can copy them locally more efficiently than she can from her location.

LaunchAutomatedFunctionalTest.bat - This is a view-private batch file created by the automated overnight test system (specifically, PC-Monitor.exe) that runs the functional testing.

LaunchAutomatedStressTest.bat - This is a view-private batch file created by the automated overnight test system (specifically, PC-Monitor.exe) that runs the stress testing. 

LaunchStressTest.bat - Runs the stress test manually. You will need to edit the instrument name and starting seed value.

LaunchStressTest_DUT1.bat - An example of how to configure several stress sessions to run concurrently from a single PC against several target instruments (DUT1, DUT 2, etc...)

LaunchStressTest_DUT2.bat - An example of how to configure several stress sessions to run concurrently from a single PC against several target instruments (DUT1, DUT 2, etc...)

LaunchStressTest_DUT3.bat - An example of how to configure several stress sessions to run concurrently from a single PC against several target instruments (DUT1, DUT 2, etc...)

LaunchStressTest_DUT4.bat - An example of how to configure several stress sessions to run concurrently from a single PC against several target instruments (DUT1, DUT 2, etc...)

LaunchStressTest_opt06.bat - An example of how to run a stress test using an alternate command file name. In this case, the command file is edited to exclude commands that are affected or are invalid when Kepler Option 06 is present.

PingTest.bat - Used to manually check a list of instrumentes for the DNS server/name resolution problems we have been having. It stands alone, and is not called by any other scripting.

PullFromDoors.exe - Called by Automated Functional Tests to export text from DOORS into *.feature files based on the DUT's options

RunTestsLocally.bat - Uses MSTEst to run the compiled test framework asset file (PascalTests.dll) on the target instrument. You will need to edit the command line for the AWG you are running tests on, and the output from the Pascal Test Framework compile copied to the C:\PascalTestBinaries folder.

sequential.bat - An example of how to run stress command files sequentially. Very useful for syntax checking of new commands.

setupstress.bat - Needed to set up PC environment for stress testing. DO NOT CHANGE THIS FILE! You will need to have a valid STRESS_ROOT environment variable set to the local snapshot view ...\SQA\Test Tools\PI_Stress folder

sleep.exe - Needed by various batch files and scripts as a pause mechanism.

VXITalkerListener.exe - Quick-use exe which can take a query or command as a parameter and return the response from the specified instrument