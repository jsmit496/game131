@echo off

REM ss64.com/nt
REM git-scm.com

REM For the Committer (different document) I want the user to write:
REM (commit) to commit and push all of their changes

set commitMessage=%1

call git add -A
call git commit -m %1
call git push



