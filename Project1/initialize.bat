@echo off

REM ss64.com/nt
REM git-scm.com

REM For the initializer (this document) I want the user to write:
REM (initialize <repository>) to simply create the spot on the computer this might also involve pulling branches
REM (initialize username <username> email <email>) to configure the environment
REM think about how to "check out" a development branch

set choice=%1
set display1=%2
set choice2=%3
set display2=%4

REM basic get repository and pull branches. (initialize repository <repository>)
If %1==repository (
	call git clone %1
	call git fetch --all
	call git pull --all
	call git branch Development
	call git checkout Development
	GOTO:ending
)

REM config the name and email (initialize name <name> email <email>)
If %1==name (
	call git config --global user.name "%2"
	echo user.name is set to %2
	IF %3==email (
		call git config --global user.email "%4"
		echo user.email is set to %4
		GOTO ending
	) ELSE (
		GOTO:ending
	)
	
)

REM config the name and email (initialize email <email> name <name>)
IF %1==email (
	call git config --global user.email "%2"
	echo user.email is set to %2
	IF %3==name (
		call git config --global user.name "%4"
		echo user.name is set to %4
		GOTO ending
	) ELSE (
		GOTO:ending
	)
	
)

:ending


