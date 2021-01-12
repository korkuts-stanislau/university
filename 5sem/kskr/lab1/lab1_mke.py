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
#Коэффициент теплообмена воздуха
H = 55

def get_rod(rod_length=200, node_length=0.2, cross_area=1, q=100, temperature_of_env=20):
    coef_for_latun = cross_area * LATUN / node_length
    coef_for_poli = cross_area * POLI / node_length
    nodes = int(rod_length / node_length)
    stiffness_matrix = np.zeros((nodes, nodes))
    load_vector = np.zeros(nodes)
    for i in range(1, nodes - 1):
        stiffness_matrix[i, i - 1] = - coef_for_poli if nodes // 3 < i < nodes // 3 * 2 else - coef_for_latun
        stiffness_matrix[i, i] = (coef_for_poli if nodes // 3 < i < nodes // 3 * 2 else coef_for_latun) + \
                                 (coef_for_poli if nodes // 3 < i + 1 < nodes // 3 * 2 else coef_for_latun)
        stiffness_matrix[i, i + 1] = - coef_for_poli if nodes // 3 < i + 1 < nodes // 3 * 2 else - coef_for_latun
    stiffness_matrix[0, 0] = coef_for_latun
    stiffness_matrix[0, 1] = - coef_for_latun
    load_vector[0] = - q * cross_area
    stiffness_matrix[nodes - 1, nodes - 2] = - coef_for_latun
    stiffness_matrix[nodes - 1, nodes - 1] = coef_for_latun + H * cross_area
    load_vector[nodes - 1] = H * cross_area * temperature_of_env
    derivatives = np.linalg.solve(stiffness_matrix, load_vector)
    rod = [100]
    for i in range(nodes):
        rod.append(derivatives[i] * node_length * 0.01 - rod[i])
    return rod


rod = get_rod()
plt.plot(np.arange(0, len(rod) // 3, 1), rod[:len(rod) // 3], color="yellow")
plt.plot(np.arange(len(rod) // 3, len(rod) // 3 * 2, 1), rod[len(rod) // 3: len(rod) // 3 * 2], color="grey")
plt.plot(np.arange(len(rod) // 3 * 2, len(rod), 1), rod[len(rod) // 3 * 2:], color="yellow")
plt.show()
