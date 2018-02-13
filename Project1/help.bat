@echo off

REM ss64.com/nt
REM git-scm.com

REM For the updater (different document) I want the user to write:
REM (update) to pull commits from the remote repository and merge them into the local
REM if their local is not committed then this tool cannot update unless they commit or revert the merge focuses on "theirs"

set usernameemail=%1
set display1=%2
set 2usernameemail=%3
set display2=%4

call git.exe 



