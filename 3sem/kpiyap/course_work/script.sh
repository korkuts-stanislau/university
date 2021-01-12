#!/bin/bash
# Скрипт для конвертации UI в PY
pyuic5 menu.ui -o menu.py
python3 program.py
