@echo off
setlocal

SET CONF_REDIRECT=configuracoes.redirect.xml
SET CONFIG_FILE=Configuracoes.xml

::-------------------------------------------------------------------
:: Build and Publish Webadmin
echo Building and publishing WebAdmin...
cd ..\WebAdmin
powershell -ExecutionPolicy Bypass -File .\publish-linux.ps1
if %ERRORLEVEL% neq 0 (
    echo Error: publish-linux.ps1 failed with exit code %ERRORLEVEL%
    exit /b %ERRORLEVEL%
)

:: Remove old config
IF EXIST ".\publish-linux\%CONFIG_FILE%" (
    del ".\publish-linux\%CONFIG_FILE%"
)

:: Remove old config redirect
IF EXIST ".\publish-linux\%CONF_REDIRECT%" (
    del ".\publish-linux\%CONF_REDIRECT%"
)

:: Return to root execution folder
cd ..\FLAT_VUE

::-------------------------------------------------------------------
:: Build and Publish FLAT_VUE
echo Building and publishing FLAT_VUE...
powershell -ExecutionPolicy Bypass -File .\publish-linux.ps1
if %ERRORLEVEL% neq 0 (
    echo Error: publish-linux.ps1 failed with exit code %ERRORLEVEL%
    exit /b %ERRORLEVEL%
)

:: Remove old config
IF EXIST ".\publish-linux\%CONFIG_FILE%" (
    del ".\publish-linux\%CONFIG_FILE%"
)

:: Remove old config redirect
IF EXIST ".\publish-linux\%CONF_REDIRECT%" (
    del ".\publish-linux\%CONF_REDIRECT%"
)

::-------------------------------------------------------------------
:: Deploy Solution
echo Starting Docker Compose...
docker compose up -d --build
if %ERRORLEVEL% neq 0 (
    echo Error: Docker Compose failed with exit code %ERRORLEVEL%
    exit /b %ERRORLEVEL%
)
echo Deployment complete!
endlocal