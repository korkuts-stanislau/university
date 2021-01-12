"""
Метод конечных разностей
Вариант 7. Схема В. Материалы - латунь и полипропилен
"""

import numpy as np
import matplotlib.pyplot as plt

"""
Модель состоит из трех областей
Слева происходит конвективный обмен с внешней средой
Справа подводится тепловой поток
"""

#Коэффициент теплопроводности латуни l62 при температуре 27 градусов
LATUN = 110
#Коэффициент теплопроводности полипропилена
POLI = 0.24


def get_rod(rod_size=10, nodes=10000, q=100, temper_left=20, temper_right=100):
    """
    Функция возвращает вектор с распределениями температур в стержне
    :param rod_size: размер стержня (единиц)
    :param nodes: количество узлов
    :param q: мощность теплового потока
    :param temper_left: температура слева от узла
    :param temper_right: температура справа от узла
    :return: вектор с распределением температур стержня
    """
    delta_x = rod_size / nodes
    # В областях с латунью и полипропиленом коэффициенты справа от уравнения равны соответственно
    latun_coef = - q * delta_x ** 2 / LATUN
    poli_coef = - q * delta_x ** 2 / POLI

    # Объявляю матрицу коэффициентов и вектор ответов
    coef_matrix = np.zeros((nodes, nodes))
    answer_vector = np.zeros(nodes)

    # Инициализирую вектор ответов
    for i in range(nodes):
        answer_vector[i] = poli_coef if round(rod_size / 3) < i < round(rod_size / 3) * 2 else latun_coef
    answer_vector[0] = temper_left
    answer_vector[-1] = temper_right

    # Создаю граничные условия
    coef_matrix[0, 0] = 1
    coef_matrix[-1, -1] = 1

    for i in range(1, nodes - 1):
        coef_matrix[i, i - 1] = 1
        coef_matrix[i, i] = -2
        coef_matrix[i, i + 1] = 1

    # Решаю уравнение и получаю распределение температур
    return np.linalg.solve(coef_matrix, answer_vector)


rod = get_rod()
print(rod)
plt.plot(np.arange(0, len(rod) // 3, 1), rod[:len(rod) // 3], color="yellow")
plt.plot(np.arange(len(rod) // 3, len(rod) // 3 * 2, 1), rod[len(rod) // 3: len(rod) // 3 * 2], color="grey")
plt.plot(np.arange(len(rod) // 3 * 2, len(rod), 1), rod[len(rod) // 3 * 2:], color="yellow")
plt.show()