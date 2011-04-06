@echo off
nunit-console %1
specflow.exe nunitexecutionreport %2 /xmlTestResult:%3
if NOT %errorlevel% == 0 (
	echo "Error generating report - %errorlevel%"
	GOTO :exit
)
if %errorlevel% ==0 TestResult.html
:exit