@echo off

set initialize=%1
set usernameemail=%2
set display1=%3
set 2usernameemail=%4
set display2=%5

IF "%1"=="initialize" (
	echo pizza
	IF "%2"=="username" (
		echo username: %3
		
	) ELSE IF "%2"=="email" (
		echo email: %3
	)
)