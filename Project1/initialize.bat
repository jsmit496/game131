@echo off

REM For the initializer (this document) I want the user to write:
REM (initialize <repository>) to simply create the spot on the computer this might also involve pulling branches
REM (initialize username <username> email <email>) to configure the environment
REM think about how to "check out" a development branch

REM For the updater (different document) I want the user to write:
REM (update) to pull commits from the remote repository and merge them into the local
REM if their local is not committed then this tool cannot update unless they commit or revert the merge focuses on "theirs"

REM For the Committer (different document) I want the user to write:
REM (commit) to commit and push all of their changes

REM For the Reverter (different document) I want the user to write:
REM (revert) to discard all changes since the last commit

set usernameemail=%1
set display1=%2
set 2usernameemail=%3
set display2=%4

REM IF "%1"=="username" (
REM	 echo username: %2
REM	 IF "%3"=="email" (
REM	 	echo email: %4
REM	 )
REM ) ELSE IF "%1"=="email" (
REM	 echo email: %2
REM	 IF "%3"=="username" (
REM	 	echo username: %4
REM	 )
REM )

