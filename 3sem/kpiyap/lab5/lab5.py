def enter_array(array_name):
    arr = []
    with open('input.txt') as file:
        flag = False
        for line in file:
            if line.strip() == array_name:
                flag = True
                continue
            if flag and line in ['', '\n']:
                break
            try:
                if flag:
                    arr.extend([int(item) for item in line.split()])
            except:
                raise ValueError("You have entered wrong values")
        if not flag:
            raise ValueError("You have entered wrong array name")
    return arr


def task1(a, b, array_name):
    arr = enter_array(array_name)
    sum = 0
    count = 0
    for i, item in enumerate(arr):
        if a <= i + 1 <= b:
            sum += item
        if (i + 1) % 4 == 0 and item > 0:
            count += 1
    mean = sum / (b - a)
    return '{0}\nAryphmetic mean = {1}, quantity of positive numbers = {2}'.format(arr, mean, count)


def task2(array_name):
    arr = enter_array(array_name)
    result = 'Input array = {0}\n'.format(arr)
    arr[-3], arr[arr.index(min(arr))] = arr[arr.index(min(arr))], 101
    return result + 'Output array = {0}'.format(arr)


def task3(array_name1, array_name2):
    arr1 = enter_array(array_name1)
    arr2 = enter_array(array_name2)
    res_arr = [item for item in arr1 if item <= arr1[0] + arr2[0]] + [item for item in arr2 if item <= arr1[0] + arr2[0]]
    return 'The first input array = {0}\nThe second input array = {1}\nOutput array = {2}'.format(arr1, arr2, res_arr)


def task4(array_name):
    arr = enter_array(array_name)
    if arr != sorted(arr):
        return 'This array isn\'t sorted'
    result = ''
    if arr[-1] > 0:
        result += 'This array has positive numbers\n'
    else:
        result += 'This array has not any positive numbers\n'
    prod = 1
    for item in arr:
        if item >= 0:
            break
        prod *= item
    return 'Array = {}\n'.format(arr) + result + 'Production of negative numbers = {}'.format(prod)


def task5(array_name):
    arr = enter_array(array_name)
    return 'Array = {0}\nMost effective month = {1}\nMost uneffective month = {2}'.format(arr, max(arr), min(arr))


def task6(array_name):
    arr = enter_array(array_name)
    if len(set(arr)) == 1:
        return 'All elements of this array are the same.'
    res_arr = []
    flag = False
    for i in range(8):
        if arr[i] != arr[-1]:
            flag = True
        if flag:
            res_arr.append(arr[i])
    return 'Input array = {0}\nOutput array = {1}'.format(arr, res_arr)
