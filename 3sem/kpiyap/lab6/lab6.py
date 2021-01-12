def enter_matrix(matrix_name):
    matrix = []
    with open('input.txt') as file:
        flag = False
        for line in file:
            if line.strip() == matrix_name:
                flag = True
                continue
            if flag and line in ['', '\n']:
                break
            try:
                if flag:
                    matrix.append([float(item) for item in line.split()])
            except:
                raise ValueError("You have entered wrong values")
        if not flag:
            raise ValueError("You have entered wrong matrix name")
    return matrix


def matrix_output(matrix, matrix_name):
    result = 'Matrix {}\n'.format(matrix_name)
    for row in matrix:
        for item in row:
            result += '{:>10.2f}'.format(item)
        result += '\n'
    return result


def task1(matrix_name, d):
    matrix = enter_matrix(matrix_name)
    sum = 0
    for i in range(1, len(matrix), 2):
        for item in matrix[i]:
            if item >= d:
                sum += item
    return matrix_output(matrix, matrix_name) + 'Sum of elements = {}\n'.format(sum)


def task2(matrix_name):
    matrix = enter_matrix(matrix_name)
    sum = 0
    for row in matrix:
        prod = 1
        for item in row:
            if item < 0:
                prod *= item
        sum += prod
    return matrix_output(matrix, matrix_name) + 'Sum of productions = {}\n'.format(sum)


def find_new_matrix(matrix):
    new_matrix = []
    for i in range(len(matrix)):
        wrap_matrix = []
        for j in range(len(matrix[0])):
            neighbours = []
            try:
                neighbours.append(matrix[i + 1][j])
            except:
                pass
            try:
                neighbours.append(matrix[i][j + 1])
            except:
                pass
            if j - 1 >= 0:
                try:
                    neighbours.append(matrix[i][j - 1])
                except:
                    pass
            if i - 1 >= 0:
                try:
                    neighbours.append(matrix[i - 1][j])
                except:
                    pass
            wrap_matrix.append(sum(neighbours) / len(neighbours))
        new_matrix.append(wrap_matrix)
    return new_matrix


def task3(matrix_name):
    matrix = find_new_matrix(enter_matrix(matrix_name))
    abs_sum = 0
    for i in range(1, len(matrix)):
        for j in range(i - 1):
            abs_sum += abs(matrix[i][j])
    return matrix_output(enter_matrix(matrix_name), matrix_name) + matrix_output(matrix, 'New Matrix') + \
           'Sum of abs(n) lower than main diagonal = {}'.format(abs_sum)
