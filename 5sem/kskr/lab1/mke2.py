import numpy as np
import matplotlib.pyplot as plt


def get_stiffness_matrix(n: int, h: float):
    """
    Вычисление матрицы жесткости
    :param h: Шаг сетки
    :param n: Количество узлов сетки
    :return: Матрицу жесткости размера nxn
    """
    diagonal_stiffness = 1 / h - h / 3
    near_stiffness = - 1 / h - h / 6
    stiffness_matrix = np.zeros((n, n))  # Формирование матрицы nxn, заполненной нулями
    for i in range(n - 1):
        stiffness_matrix[i, i] += diagonal_stiffness
        stiffness_matrix[i + 1, i + 1] += diagonal_stiffness
        stiffness_matrix[i, i + 1] += near_stiffness
        stiffness_matrix[i + 1, i] += near_stiffness
    return stiffness_matrix


def get_answer_vector(n: int, h: float):
    """
    Вычисление вектора ответов
    :param h: Шаг сетки
    :param n: Количество узлов сетки
    :return: Вектор ответов размера n
    """
    answer_vector = np.zeros((n,))
    answer_vector[1:n-1] = -h
    answer_vector[0] = -h / 2
    answer_vector[n - 1] = -h / 2
    return answer_vector


def make_constraint(K: np.array, f: np.array, t0: float, tn: float):
    """
    Применяет граничные условия
    :param tn: Правое граничное условие
    :param t0: Левое граничное условие
    :param K: Матрица жесткости
    :param f: Вектор ответов
    :return: Матрицу жесткости и вектор ответов после применения граничных условий
    """
    # Задаю условия для левой границы
    f[0] = t0
    K[0, 0] = 1
    K[0, 1:] = 0

    f[1:] -= K[1:, 0].T * t0
    K[1:, 0] = 0
    # И для правой
    f[-1] = tn
    K[-1, -1] = 1
    K[-1, :-1] = 0

    f[:-1] -= K[:-1, -1].T * tn
    K[:-1, -1] = 0

    return K, f


def solution(n: int, length: float, t0: float, tn: float):
    """
    Решение одномерной задачи теплопроводности методом конечных элементов
    :param tn: Температура на правой границе стержня
    :param t0: Температура на левой границе
    :param length: Длина стержня
    :param n: Количество узлов
    :return:
    """
    m = n - 1  # Количество элементов
    h = length / m  # Шаг сетки
    K = get_stiffness_matrix(n, h)
    f = get_answer_vector(n, h)
    K, f = make_constraint(K, f, t0, tn)
    T = np.linalg.solve(K, f)
    plt.plot(T)
    plt.show()


if __name__ == "__main__":
    solution(100, 10, 100, 10)



