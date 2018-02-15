@echo off

REM ss64.com/nt
REM git-scm.com

REM For the updater (different document) I want the user to write:
REM (update) to pull commits from the remote repository and merge them into the local
REM if their local is not committed then this tool cannot update unless they commit or revert the merge focuses on "theirs"

REM this should get commits and merge them (test at home).
REM figure out how to check if they have commit problems and solve it according to guidelines.

REM test#4

call git fetch --all
call git merge -X theirs



