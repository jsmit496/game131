@echo off

REM ss64.com/nt
REM git-scm.com

REM For the Committer (different document) I want the user to write:
REM (commit) to commit and push all of their changes

set usernameemail=%1
set display1=%2
set 2usernameemail=%3
set display2=%4

call git.exe commit -a



