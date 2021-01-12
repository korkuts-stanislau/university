import sys
from menu import *
import textmodule
import tasks_solving
from PyQt5 import QtCore, QtGui, QtWidgets

class MyWin(QtWidgets.QMainWindow):
    def __init__(self, parent = None):
        QtWidgets.QWidget.__init__(self, parent)
        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)
        # Кнопки
        self.ui.task1_button.clicked.connect(self.task1_button_clicked)
        self.ui.task2_button.clicked.connect(self.task2_button_clicked)
        self.ui.task3_button.clicked.connect(self.task3_button_clicked)
        self.ui.task4_button.clicked.connect(self.task4_button_clicked)
        self.ui.task5_button.clicked.connect(self.task5_button_clicked)
        self.ui.task6_button.clicked.connect(self.task6_button_clicked)
        self.ui.task7_button.clicked.connect(self.task7_button_clicked)
        self.ui.task8_button.clicked.connect(self.task8_button_clicked)
        self.ui.task9_button.clicked.connect(self.task9_button_clicked)
        self.ui.task10_button.clicked.connect(self.task10_button_clicked)
        #Решение задания
        self.ui.solve_button.clicked.connect(self.solve_task)

    # Функции при нажатии на кнопки
    def task1_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(1).values():
            self.ui.tasks_data_text.appendPlainText(item)
    
    def task2_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(2).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task3_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(3).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task4_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(4).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task5_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(5).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task6_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(6).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task7_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(7).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task8_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(8).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task9_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(9).values():
            self.ui.tasks_data_text.appendPlainText(item)

    def task10_button_clicked(self):
        self.ui.tasks_data_text.clear()
        for item in textmodule.find_task_data(10).values():
            self.ui.tasks_data_text.appendPlainText(item)

    #Функция для решения задания
    def solve_task(self):
        tasks = {"Задание 1": tasks_solving.task1_ppi, "Задание 2": tasks_solving.task2_roads,
                "Задание 3": tasks_solving.task3_puzzle, "Задание 4": tasks_solving.task4_median,
                "Задание 5": tasks_solving.task5_progression, "Задание 6": tasks_solving.task6_polygon,
                "Задание 7": None, "Задание 8": tasks_solving.task8_egypt_approx,
                "Задание 9": tasks_solving.task9_disconnect, "Задание 10": tasks_solving.task10_chess_queen}
        try:
            inp = self.ui.input_text.toPlainText()
            """Вызывают функцию из словаря по имени исполняемого задания"""
            self.ui.output_text.setPlainText(str(tasks[self.ui.tasks_data_text.toPlainText().split('\n')[0]](inp)))
        except:
            self.ui.statusbar.showMessage("Неверный ввод")
        

def main():
    app = QtWidgets.QApplication(sys.argv)
    myapp = MyWin()
    myapp.show()
    sys.exit(app.exec_())


if __name__ == "__main__":
    main()
