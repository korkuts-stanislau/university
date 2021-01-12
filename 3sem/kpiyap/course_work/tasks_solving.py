import math
# First task Task L - PPI
def task1_ppi(string):
    raz, inch = string.split(' ')
    raz1, raz2 = raz.split('x')
    square = (int(raz1) ** 2 + int(raz2) ** 2) ** 0.5
    return round(square / float(inch[:-1]))


# Second task Task K - Roads
def task2_roads(inp):
    t, r = (int(i) for i in inp.split('\n')[0].split())
    connections = {key: [] for key in range(1, t + 1)}
    order = []
    for i in range(r):
        t1, t2 = (int(town) for town in inp.split('\n')[i + 1].split())
        connections[t1].append(t2)
        connections[t2].append(t1)
        order.append((t1, t2))

    def connect_func(town, conset):  # Проверяет, соединён ли город со всеми городами
        flag = True
        for i in connections[town]:
            if i not in conset:
                flag = False
                break
        if flag:
            return conset
        else:
            for i in connections[town]:
                if i not in conset:
                    conset.add(i)
                    conset.union(connect_func(i, conset))
            return conset

    road_number = 1
    for town1, town2 in order:
        connections[town1].remove(town2)
        connections[town2].remove(town1)
        if len(connect_func(1, set())) != t:
            return road_number
        else:
            road_number += 1


# Third task Task J - Puzzle
def task3_puzzle(inp):
    k, n = [int(i) for i in inp.split()]
    if n < k or n <= 0 or k <= 0:
        return 'Epic fail'
    if n % k == 0:
        return '{} '.format(n // k) * (3 * k - 3)
    lst = [n // k] * (3 * k - 3)
    if n % k == 2:
        lst[0] += 1
        lst[k - 1] += 1
        lst[2 * k - 2] += 1
    elif n % k == k - 1:
        for i in range(len(lst)):
            lst[i] += 1
        lst[1] -= 1
        lst[k] -= 1
        try:
            lst[2 * k - 1] -= 1
        except:
            return 'Epic fail'
    else:
        for i in range(n % k):
            lst[1 + i] += 1
            lst[k + i] += 1
            lst[2 * k - 1 + i] += 1
    lst = [str(item) for item in lst]
    return ' '.join(lst)


# Fourth task Task G - Median
def task4_median(inp):
    numbers = [int(number) for number in inp.split()]
    median_numbers = list()
    output = []
    for number in numbers:
        if number == 0:
            median_numbers.sort()
            if len(median_numbers) % 2 == 1:
                output.append(median_numbers[len(median_numbers) // 2])
                continue
            else:
                output.append((median_numbers[len(median_numbers) // 2] + median_numbers[len(median_numbers) // 2 - 1]) / 2.0)
                continue
        else:
            median_numbers.append(number)
    return "\n".join([str(number) for number in output])


# 5th task Task I - Progression
def task5_progression(inp):
    array = [int(number) for number in inp.split()[1:]]  # массив чисел
    mean = 0  # средняя разность массива чисел
    for i in range(len(array) - 1):
        mean += array[i + 1] - array[i]
    mean = round(float(mean) / (len(array) - 1))
    for i in range(len(array) - 1):
        if abs((array[i + 1] - array[i]) - mean) > 2:
            return "Epic fail"
    # Вторая часть кода
    first_array = [array[0] - 1] + array[1:]
    second_array = array
    third_array = [array[0] + 1] + array[1:]
    changed_numbers = [None, None, None]
    changed_numbers[0] = 1  # количество измененных чисел при первом значении = буфер - 1
    changed_numbers[1] = 0  # количество измененных чисел при первом значении = буфер
    changed_numbers[2] = 1  # количество измененных чисел при первом значении = буфер + 1
    for index, arr in enumerate([first_array, second_array, third_array]):
        for i in range(len(arr) - 1):
            if mean - (arr[i + 1] - arr[i]) != 0:
                if abs(mean - (arr[i + 1] - arr[i])) != 1:
                    changed_numbers[index] = 10000000
                    break
                else:
                    arr[i + 1] += mean - (arr[i + 1] - arr[i])
                    changed_numbers[index] += 1
    return str(min(changed_numbers))


# 6th task Task H - Polygon
def task6_polygon(inp):
    number = int(inp)
    if number == 1:
        return "Epic fail"
    for i in [2, 3, 5]:
        if number % i == 0:
            return ("1" * (number // i) + "0" * ((30 - number) // i)) * i
    if 30 % number == 0:
        return ("1" + "0" * (30 // number - 1)) * number
    return "Epic fail"


# 8th task Task E - Egypt Approximation
def task8_egypt_approx(inp):
    a, b = (float(number) for number in inp.split())
    aprox_array = list()
    first_approx = math.ceil(1 / (a / b))
    if (a / b) <= (1 / first_approx):
        return "1\n" + str(first_approx)
    else:
        aprox_array.append(first_approx)
    while((a / b) > sum([(1 / number) for number in aprox_array])):
        number_to_append = math.ceil(1 / (a / b - sum([(1 / number) for number in aprox_array])))
        aprox_array.append(number_to_append)
    return f"{len(aprox_array)}\n" + " ".join([str(number) for number in aprox_array])


# 9th task Task D - Disconnect
def task9_disconnect(inp):
    def connect_func(vertex, conset, connections):
        ''' Проверяет, соединена ли вершина со всеми остальными вершинами
            vertex - вершина, которую проверяем
            conset - множество пройденных вершин
            connections - словарь, содержащий все соединения (Например {1:[2, 3],2:[3, 1]})'''
        flag = True
        for i in connections[vertex]:
            if i not in conset:
                flag = False
                break
        if flag:
            return conset
        else:
            for i in connections[vertex]:
                if i not in conset:
                    conset.add(i)
                    conset.union(connect_func(i, conset, connections))
            return conset
    result = []
    # Ввод
    tests = []
    pointer = 1
    inp_list = inp.split('\n')
    for ind in range(int(inp_list[0])): # формирование массивов тестов
        current_test = inp_list[pointer:pointer + int(inp_list[pointer].split()[1]) + 1]
        pointer = pointer + int(inp_list[pointer].split()[1]) + 1
        tests.append(current_test)
    # Начало алгоритма
    for test in tests:
        vertex_count, edges_count = map(int, test[0].split())
        connections = {k:list() for k in range(1, vertex_count + 1)}
        edges = test[1:]
        for edge in edges:
            e1, e2 = map(int, edge.split())
            connections[e1].append(e2)
            connections[e2].append(e1)
        edges.append("1 1") # для холостого прогона по рёбрам если развязывающее множество заканчивается последним ребром
        count = -1
        for edge in edges:
            e1, e2 = map(int, edge.split())
            if (len(connect_func(1, set(), connections)) != vertex_count):
                if count <= 0:
                    result.append(str(count))
                else:
                    result.append(str(count) + "\n" + " ".join([str(i) for i in range(1, count + 1)]))
                break
            else:
                connections[e1].remove(e2)
                connections[e2].remove(e1)
                count += 1
    return "\n".join(result)


# 10th task Task B - Chess Queen
def task10_chess_queen(inp):
    k = int(inp)
    dic = {1: 'a', 2: 'b', 3: 'c', 4: 'd', 5: 'e', 6: 'f', 7: 'g', 8: 'h'}
    matrix = [[(i + 1, j + 1) for i in range(8)] for j in range(8)]
    for row in matrix:
        for item in row:
            atk = 14
            xt = item[0]
            yt = item[1]
            while xt - 1 > 0 and yt - 1 > 0:
                atk += 1
                xt -= 1
                yt -= 1
            xt = item[0]
            yt = item[1]
            while xt - 1 > 0 and yt + 1 < 9:
                atk += 1
                xt -= 1
                yt += 1
            xt = item[0]
            yt = item[1]
            while xt + 1 < 9 and yt - 1 > 0:
                atk += 1
                xt += 1
                yt -= 1
            xt = item[0]
            yt = item[1]
            while xt + 1 < 9 and yt + 1 < 9:
                atk += 1
                xt += 1
                yt += 1
            if atk == k:
                return '{}{}'.format(dic[item[0]], 8 - item[1])
    return 'Epic fail'