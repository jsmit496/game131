@echo off

REM ss64.com/nt
REM git-scm.com

REM For the initializer (this document) I want the user to write:
REM (initialize <repository>) to simply create the spot on the computer this might also involve pulling branches
REM (initialize username <username> email <email>) to configure the environment
REM think about how to "check out" a development branch

set repository=%1
set display1=%2
set 2usernameemail=%3
set display2=%4

REM basic get repository and pull branches. (initialize repository <repository>)
If %1==repository (
	call git clone %1
	call git fetch --all
	call git pull --all
	call git branch Development
	call git checkout Development
)





