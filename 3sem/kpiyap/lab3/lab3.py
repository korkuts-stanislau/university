from math import tan, fabs, log, exp


def task1(x1, x2, dx, a, b):  # calcs values of y in range x1 -> x2 with step = dx
    result = 'x1 = {}, x2 = {}, dx = {}, a = {}, b = {}\n'.format(x1, x2, dx, a, b)
    x = x1
    while x <= x2:
        result += 'x = {}, y = {:.2f}\n'.format(x, ((a * x) ** 0.5 - b) / (tan(x) ** 2))
        x += dx
    return result


def task2(x1, x2, dx):  # calcs values of y with 'for' loop in range x1 -> x2 with step = dx
    result = 'x1 = {}, x2 = {}, dx = {}\n'.format(x1, x2, dx)
    for x in range(int(x1), int(x2), int(dx)):
        if x >= 4:
            result += 'x = {}, y = {}, n = {}\n'.format(x, round(fabs(x / 2 - x ** 2) ** 0.5, 2), 1)
        elif 1 < x < 4:
            result += 'x = {}, y = {}, n = {}\n'.format((x, round(log(x) ** 2 - exp(x / 2), 2), 2))
        else:
            result += 'x = {}, y = {}, n = {}\n'.format((x, round(0.3 * x, 2), 3))
    return result


def task3(x1, x2, dx):  # calcs values of y with 'while' loop in range x1 -> x2 with step = dx
    result = 'x1 = {}, x2 = {}, dx = {}\n'.format(x1, x2, dx)
    x = x1
    while x < x2:
        if x >= 4:
            result += 'x = {}, y = {}, n = {}\n'.format(x, round(fabs(x / 2 - x ** 2) ** 0.5, 2), 1)
        elif 1 < x < 4:
            result += 'x = {}, y = {}, n = {}\n'.format((x, round(log(x) ** 2 - exp(x / 2), 2), 2))
        else:
            result += 'x = {}, y = {}, n = {}\n'.format((x, round(0.3 * x, 2), 3))
        x += dx
    return result


def task4(n):  # checks if number is sum of cubes A = i^3 + j^3 + k^3?
    itr = round(n ** 1 / 3) + 1
    for i in range(itr):
        for j in range(itr):
            for k in range(itr):
                if n == i ** 3 + j ** 3 + k ** 3:
                    return 'Number {} is sum of cubes {}, {}, {}'.format(n, i, j, k)
    return 'Number {} is\'t sum of cubes'.format(n)


def find_divisors_quan(n):  # finds all divisors of a number
    divs = set()
    for i in range(2, round(n ** 0.5) + 1):
        if n % i == 0:
            divs.add(i)
    return len(divs)


def task5(n, k):  # finds number in range n -> k with max quantity of divisors
    max_divisor = 0
    for num in range(n, k + 1):
        if find_divisors_quan(num) > max_divisor:
            max_divisor = find_divisors_quan(num)
    for num in range(k, n - 1, -1):
        if find_divisors_quan(num) == max_divisor:
            return 'Number with max quantity of divisors in range n -> k is {}'.format(num)


def task6(n):  # finds all simple-number fours before n
    result = 'Simple number fours before {}\n'.format(n)
    for i in range(n // 10):
        simple_nums = set()
        for j in range(i * 10, (i + 1) * 10):
            if find_divisors_quan(j) == 0:
                simple_nums.add(j)
        if len(simple_nums) == 4:
            result += str(sorted(list(simple_nums))) + '\n'
    return result


def task7(k):  # return k-digit of the natural-number-square sequence
    s = k
    i = 1
    while k > 0:
        k -= len(str(i ** 2))
        i += 1
    k += len(str((i - 1) ** 2)) - 1
    return 'Digit on the {} position of the sequence of natural numbers\' squares is {}'.format(s, str((i - 1) ** 2)[k])
