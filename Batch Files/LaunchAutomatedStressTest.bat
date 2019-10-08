REM Example 2 Channel random stress command line. %STRESS_ROOT% needs to be set as a USER environment variable to the 
REM local snapshot view path where AWGStress.exe is located.
c:
cd %STRESS_ROOT%
awgstress -f "C:\cc_storage\jmanning_PC-BEAV-1081_snapshot\SSPL-SQA\SQA\Test Tools\UltimateStress\Command Groups\Pascal_commands_TwoChannel.txt" -a AWG70002Q004 -c 2000000 -d 20 -t 30 -s 755837005 -OverlappedTimeout 90 -Log AWG70002Q004_v3.1.0150_stress_log.txt -Playback AWG70002Q004_v3.1.0150_playback.txt
