@echo off

REM ss64.com/nt
REM git-scm.com

REM For the Reverter (different document) I want the user to write:
REM (revert) to discard all changes since the last commit

setlocal

set /P yesOrNo=Are you sure you want to reset to the last commit (Y/N)?
IF %yesOrNo%==Y	(
	call git reset --hard
	endlocal
) ELSE (
	echo revert cancelled
)