from math import sin, exp, cos


def task1(a, b, c):
    return a * b / 2, a + b + c


def find_max_num(ar):
    return ar.find(max(ar))


def task2(x_list, y_list, z_list):
    return 2.2 * sin(find_max_num(x_list)) - exp(-find_max_num(y_list)) + find_max_num(z_list) ** 3


def task3(a_matrix, b_matrix):
    return list(zip(*a_matrix)), list(zip(*b_matrix))


def func_1(x):
    return (x ** 3) / ((9 + x ** 2) ** (3 / 2))


def func_2(x):
    return (10 * cos(0.65 * x)) / (x ** 2 + 10 * x - 200)


def func_3(x):
    return 0.5 * x ** 2 + 16 * x - 3


def task4(start_x, finish_x, eps, func):
    ds = (finish_x - start_x) * func(finish_x - start_x)
    n = 16
    s = 0
    while abs(ds) > eps:
        dx = (finish_x - start_x) / n
        ds = 0
        s = 0
        x = start_x
        while x < finish_x:
            ds = dx * func((2 * x + dx) / 2)
            x += dx
            s += abs(ds)
        n *= 2
    return s
