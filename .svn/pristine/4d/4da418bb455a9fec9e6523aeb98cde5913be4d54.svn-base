@echo off

set deletepath=E:\Ourgis_ProjectFiles\CloudDiskFolder

::delete the files that passed 7 days in the deletepath
forfiles /p %deletepath% /d -1 /c "cmd /c IF @isdir == TRUE rd /S /Q @path"
