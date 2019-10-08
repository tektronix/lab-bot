@Echo ON
@cls
@ECHO ***********************************************************
@ECHO *                     TIME TO WRAP IT UP!                 *
@ECHO ***********************************************************
@ECHO ClearCase says you have the following files checked out:
@cd %SAPL_TEST_ROOT%
cleartool lscheckout -cview -me -avobs
@pause