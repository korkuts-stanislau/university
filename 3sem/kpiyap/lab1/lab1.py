from math import tan, cos, exp, pi, log


def task1(a, b):  # calculates square of the right triangle
    return 'a = {}, b = {}, square = {}'.format(a, b, a * b / 2)


def task2(a, b, c):  # calculates perimeter of the right triangle
    return 'a = {}, b = {}, c = {}, perimeter = {}'.format(a, b, c, a + b + c)


def task3(x, y, z):  # calculates function 1
    return 'x = {}, y = {}, z = {}, function(x, y, z) = {}'.format(x, y, z, x * (tan(z) + cos(y) ** 2))


def task4(x):  # calculates function 2
    return 'x = {}, func(x) = {}'.format(x, (cos(exp(x)) + (1 / x) ** 0.5 + cos(pi * x ** 3) + log(1 + x) ** 2
                                        + exp(x ** 2)) / (log(1 + x) ** 2 + cos(pi * x ** 3)) ** 0.5)


def task5(value):  # returns tuple with value in order 5 and value in order 19
    a = value  # 1 value
    b = a * a  # 2 value
    c = b * b  # 4 value
    d = c * c  # 8 value
    e = d * d  # 16 value
    return 'a = {}, a^5 = {}, a^19 = {}'.format(a, c + a, e + b + a)
