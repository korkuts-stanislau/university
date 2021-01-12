@echo off
set /P pset="Enter folder name..."
set /P number="Enter quantity of students..."
md %pset%
cd %pset%
for /l %%i in (1,1,%number%) do md Student%%i