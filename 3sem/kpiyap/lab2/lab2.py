from math import fabs, cos, sin


def task1(x):  # calculates function and return x, y, number of the function
    if x >= 8 and x != 10:
        return 'x = {0}, y = {1}, n = {2}'.format(x, x ** 3 + 1, 1)
    elif x <= 1:
        return 'x = {0}, y = {1}, n = {2}'.format(x, (2 * x ** 2) + (x ** (1/3)), 2)
    else:
        return 'x = {0}, y = {1}, n = {2}'.format(x, x ** 0.5, 3)


def task2(a, b):  # replaces numbers with formula and return sum of nums and max value of this nums * 1.5
    return 'a = {}, b = {}, values are equal to {} and {}'.format(a, b, max(a, b) * 1.5, a + b)


def task3(a, b):  # calculates function of the perpendicular line
    if a == 0 and b == 0:
        return 'There is no perpendicular line equation'
    else:
        return 'Equation is {}(y - y0) - {}(x - x0) = 0'.format(a, b)


def task4(n):  # checks number ABCD -> A % B == C % D
    num = str(n)
    return 'A % B equal to C % D' if (int(num[0]) % int(num[1])) == (int(num[2]) % int(num[3])) \
        else 'A % B doesn\'t equal to C % D'


def task5(x, y):  # checks if a point belongs to the polygon
    bel_false = 'Point ({}, {}) doesn\'t belong to the poligon'.format(x, y)
    if x > 1 or y > 1 or x < -2 or y < -1: return bel_false
    if y - 2 * x > 3: return bel_false
    if y <= 0:
        if x - 3 * y > 1: return bel_false
    else:  # if y > 0
        if x > 0: return bel_false
        if x > -1 and x + y > 0: return bel_false
    return 'Point ({}, {}) belongs to the poligon'.format(x, y)


def task6(num):  # checks if sum of digits of the number is even
    return 'Sum of digits of a number {} is even'.format(num) if sum([int(i) for i in str(num)]) % 2 == 0 \
        else 'Sum of digits of a number {} isn\'t even'.format(num)


def task7(a, b):  # returns tuple of 2 zeros if a == b else returns tuple of two max(a, b)
    if a == b:
        return 'a = {}, b = {}, values are equal to {0} and {1}'.format(a, b, 0, 0)
    else:
        return 'a = {}, b = {}, values are equal to {0} and {1}'.format(a, b, max(a, b), max(a, b))


def task8(orient, n1, n2):  # calculates location of a locator after 2 turns (n1, n2)
    locations = ['север', 'запад', 'юг', 'восток']
    orient = orient - 1 - n1 - n2
    result = 'Started orientation = {}, n1 = {}, n2 = {}, finished orientation = '.format(orient, n1, n2)
    return result + locations[orient] if (0 < orient < 4) \
        else result + locations[orient - 4] if orient >= 4 \
        else result + locations[orient + 4]


def task9(work_type, x):  # calculates a salary with work_type (A, B, C) and workload - x
    salary = 0
    tax_coef = 1
    if work_type == 1:
        salary = (10000 * fabs(9.2 * cos(x ** 2) - fabs(sin(x / 1.1) + 5000)))
        tax_coef = 0.9
    elif work_type == 2:
        salary = (15000 * fabs(cos(2.1 * x) * sin(fabs(x) / 0.15) - 5.8 + 1350))
        tax_coef = 0.95
    else:
        salary = (20000 * fabs(cos(2.1 * x) * sin(fabs(x) / 0.15) - 5.8 + 3350)) * 0.8
        tax_coef = 0.8
    return 'Salary without taxes = {0},' \
           'taxes = {1},' \
           'your salary = {2}.'.format(round(salary, 2), round(salary - salary * tax_coef, 2), round(salary * tax_coef,2))


def task10(*coordinates):  # checks if the rectangle is a square
    c_dict = {'x1': coordinates[0], 'y1': coordinates[1],
                  'x2': coordinates[2], 'y2': coordinates[3],
                  'x3': coordinates[4], 'y3': coordinates[5],
                  'x4': coordinates[6], 'y4': coordinates[7]}
    if (((c_dict['x1'] - c_dict['x2']) ** 2 + (c_dict['y1'] - c_dict['y2']) ** 2) ** 0.5 ==
    ((c_dict['x2'] - c_dict['x3']) ** 2 + (c_dict['y2'] - c_dict['y3']) ** 2) ** 0.5 ==
    ((c_dict['x3'] - c_dict['x4']) ** 2 + (c_dict['y3'] - c_dict['y4']) ** 2) ** 0.5 ==
    ((c_dict['x4'] - c_dict['x1']) ** 2 + (c_dict['y4'] - c_dict['y1']) ** 2) ** 0.5):
        vector_a = c_dict['x2'] - c_dict['x1'], c_dict['y2'] - c_dict['y1']
        vector_b = c_dict['x4'] - c_dict['x1'], c_dict['y4'] - c_dict['y1']
        if vector_a[0] * vector_b[0] + vector_a[1] * vector_b[1] == 0:
            return 'Rectangle with coordinates: {} is a square'.format(coordinates)
    return 'Rectangle with coordinates: {} isn\'t a square'.format(coordinates)