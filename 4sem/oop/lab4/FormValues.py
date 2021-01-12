import math

with open(r"C:\Users\korku\Desktop\FuncValues.txt", "w") as file:
    file.write("0 10\n")
    value = 0
    while value <= 10:
        file.write(str(round(math.sin(value), 2)) + "\n")
        value += 0.3