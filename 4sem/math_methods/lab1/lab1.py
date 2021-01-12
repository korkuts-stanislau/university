#Решение первой лабораторной работы "Нахождение корней нелинейных уравнений
import matplotlib.pyplot as plt
import numpy as np

# x - переменная, подставляемая в функцию
# a - левое значение интервала
# b - правое значение интервала
# eps - точность расчёта

def func(x): # функция вычисляющая значение искомой функции в точке x
    return x - 1. / 3 + 2 * np.sin(3.6 * x)


def func_diff(x): # производная от искомой функции в точке x
    return 7.2 * np.cos(3.6 * x) + 1


def generate_values(func): # функция генерирует значения x и y от x
    x_range = np.arange(-2.0, 5.0, 0.05)
    y_range = [func(value) for value in x_range]
    return x_range, y_range


def graph_plot(x_range, y_range): # функция, рисующая график
    _, ax = plt.subplots()
    ax.plot(x_range, y_range)
    ax.grid()
    plt.show()


def half_division_method(func, a, b, eps=1e-3): # метод половинного деления
    c = 0
    while True:
        c = (a + b) / 2.
        if func(c) * func(a) < 0:
            b = c
        else:
            a = c
        if abs(a - b) < eps:
            break
    return c


def chord_method(func, a, b, eps=1e-3): # метод хорд
    c = 0
    while True:
        c = a - (func(a) / (func(b) - func(a)) * (b - a))
        if func(c) * func(a) > 0:
            a = c
        else:
            b = c
        if abs(func(c)) < eps:
            break
    return c
    

def tangent_method(func, a, b, eps=1e-3): # метод касательных
    c = 0
    if func(a) * func_diff(a) > 0:
        c = a
    else:
        c = b
    while True:
        c = c - func(c) / func_diff(c)
        if abs(func(c)) < eps:
            break
    return c


def simple_iterarion_method(func, x1, eps=1e-2): # метод случайной итерации
    x0 = x1
    while True:
        x0 = x1
        x1 = x0 + eps
        if abs(func(x1)) < eps:
            break
    return x1

def menu(): # вывод меню
    n = input("Выберите, какой метод хотите использовать.\n" +
    "1 - метод половинного деления\n2 - метод хорд\n" +
    "3 - метод касательных\n4 - метод простых итераций\n")
    eps = float(input("Введите точность вычисления\n"))
    if n == "1":
        a, b = map(float, input("Введите левый и правый предел интервала\n").split())
        print(f"Метод половинного деления дал корень = {half_division_method(func, a, b, eps)}")
    elif n == "2":
        a, b = map(float, input("Введите левый и правый предел интервала\n").split())
        print(f"Метод хорд дал корень = {chord_method(func, a, b, eps)}")
    elif n == "3":
        a, b = map(float, input("Введите левый и правый предел интервала\n").split())
        print(f"Метод касательных дал корень = {tangent_method(func, a, b, eps)}")
    elif n == "4":
        x0 = float(input("Введите значение левее корня, от которого будем приближать\n"))
        print(f"Метод простых итераций дал корень = {simple_iterarion_method(func, x0, eps)}")
    

menu()
graph_plot(*generate_values(func))