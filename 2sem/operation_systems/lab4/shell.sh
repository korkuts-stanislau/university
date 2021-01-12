#!/bin/bash

n=1
while [ $n != 4 ]
do
clear
echo -------------------------------------
echo Меню
echo 1.ФИО
echo 2.Перенос файлов
echo 3.Пакетный файл для перехода
echo 4.Выход
echo -------------------------------------
echo Выберите действие
read n
echo -------------------------------------
case $n in
	1)
	echo Фадеев Николай Андреевич
	;;
	2)
	echo Введите откуда переместить файлы
	read pathin
	echo Введите куда переместить файлы
	read pathout
	mv $pathin $pathout
	echo Перемещение завершено
	;;
	3)
	echo В какой каталог необходимо перейти?
	read path
	path=${path}"/"
	echo $path
	if [ -d $path ]; then
		cd $path
		path=${path}"**"
		zip -r arch.zip $path
	else
		echo Такого каталога нет
	fi
	;;
	4)
	;;
	*)
	echo Вы ввели неверное число
	n=0
	;;
esac
echo Нажмите любую клавишу
read
done
