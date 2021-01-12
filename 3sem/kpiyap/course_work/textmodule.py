def find_task_data(number_of_task):
    task = {"Задание": "Задание {}\n".format(number_of_task), "Формат входных данных": "", "Формат выходных данных": "", "Тесты": ""}
    with open("/home/kor/university/course2/term1/kpiyap/course_work/Tasks.txt") as file:
        for line in file:
            if line == "Задание {}\n".format(number_of_task):
                break
        for line in file:
            if line == "\n":
                break
            else:
                task["Задание"] += line
        for line in file:
            if line == "\n":
                break
            else:
                task["Формат входных данных"] += line
        for line in file:
            if line == "\n":
                break
            else:
                task["Формат выходных данных"] += line
        for line in file:
            if line == "\n":
                break
            else:
                task["Тесты"] += line
    return task