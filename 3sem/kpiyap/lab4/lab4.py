def task1(k):  # finds k number of sequence where xi = x(i-1) / 2x(i-2) - x(i-1)
    if k == 1: return 2.8
    j = 2
    x1, x2 = 2.8, -3.9
    for i in range(j, k):
        x1, x2 = x2, x2 / (2 * x1 - x2)
    return 'Number on the {} position of the sequence is {}'.format(k, x2)


def task2(x, eps = 0.000001):  # finds sum of row where S = 1 - (x / (1 * 3)) + (x^2 / (2 * 4)) - (x^3 / (3 * 5)) + ......
    if x ** 2 > 1: return 'Sum of given row with x = {} is equal to infinity'.format(x)
    check_eps = 1
    s = 1
    sign = False
    power = 1
    n1, n2 = 1, 3
    while check_eps > eps:
        if not sign:
            s -= x ** power / (n1 * n2)
        else:
            s += x ** power / (n1 * n2)
        sign = not sign
        power += 1
        n1, n2 = n1 + 2, n2 + 2
        check_eps = x ** power / (n1 * n2)
    return 'Sum of the given row with x = {} equal to {} '.format(x, s)


def task3(sequence):  # finds length of subsequence of the sequence where all elements are squares of int
    max_subseq = 0
    subseq = 0
    for i in sequence:
        if int(i ** 0.5) == float(i ** 0.5):
            subseq += 1
            if subseq > max_subseq:
                max_subseq = subseq
        else:
            subseq = 0
    return 'Input sequence = {}\n' \
           'Max length of the subsequence with squares of natural numbers is equal to {}'.format(sequence, max_subseq)


def task4(x1, x2, dx, eps = 0.000001):  # finds values of the Teilor row in range x1 -> x2 with step dx
    def find_func_value(x, eps):
        if x ** 2 <= 1:
            return 'infinity'
        power = 1
        coef = 1
        check_eps = 2
        s = 0
        while check_eps > eps:
            s += 1 / (coef * x ** power)
            coef += 2
            power += 2
            check_eps = 1 / (coef * x ** power)
        return str(s * 2)

    table = '\n|     x    |     y    |\n'
    while x1 < x2:
        if find_func_value(x1, eps) != 'infinity':
            table += '|{0:>10.3f}|{1:>10.3f}|\n'.format(x1, find_func_value(x1, eps))
        else:
            table += '|{0:>10.3f}| infinity |\n'.format(x1)
        x1 += dx
    return table


def fact(n):
    return fact(n - 1) if n != 1 else 1


def task5(x1, x2, dx, eps = 0.000001):
    def find_sin_teilor_function(x, eps):
        sign = False
        coef = 1
        sin = x
        check_eps = x
        while check_eps > eps:
            coef += 2
            check_eps = (x ** coef) / fact(coef)
            if not sign:
                sin -= (x ** coef) / fact(coef)
            else:
                sin += (x ** coef) / fact(coef)
            sign = not sign
        return sin

    table = '\n|     x    |     y    |\n'
    while x1 < x2:
        table += '|{0:>10.3f}|{1:>10.3f}|\n'.format(x1, find_sin_teilor_function(x1, eps) +
                                                    find_sin_teilor_function(2 * x1, eps))
        x1 += dx
    return table


def task6(x, eps = 0.000001):
    if not (0 < x <= 1):
        return 'Sum of the row with x = {} is equal to infinity'.format(x)
    s = 0
    k = 1
    element = x
    while element > eps:
        element = (((-1) ** (k + 1)) * (x ** (2 * k - 1))) / ((2 * k - 1) * fact(2 * k + 1))
        s += element
        k += 1
    return 'Sum of the row with x = {} is equal to {}'.format(x, s)


def task7(x, n):
    k = 1
    s = 0
    while k <= n:
        s += (((-1) ** k) * (x ** k)) / fact(fact(k) + 1)
        k += 1
    return 'Sum of the first n elements with x = {} of row is equal to {}'.format(x, s)


def task8(x, n):
    s = 0
    while n >= 1:
        s += (((-1) ** n) * (x ** n)) / fact(fact(n) + 1)
        n -= 1
    return 'Sum of the first n elements with x = {} of row is equal to {}'.format(x, s)