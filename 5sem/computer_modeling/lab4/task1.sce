//Инициализируем данные
E1 = 50
E2 = 60
E3 = 20
J = 5
R1 = 6
R2 = 4
R3 = 8
R4 = 3
R5 = 7
R6 = 9

//Создаём матрицу коэффициентов и вектор ответов
A=[(R2 + R5 + R1), 0,         R5 + R1; 
    0,            (R4 - R6), (R5 + R6);
    (R2 + R5),     R3,       (R3 + R5 + R1)]
B=[E1;
   E2;
   E2 - E3]
 
//Решаем уравнение и находим неизвестные силы тока
J_arr=linsolve(A,B)

J2 = J_arr(1)
J4 = J_arr(2)
J5 = J_arr(3)

J1 = J2 + J5
J3 = J4 + J5
J6 = J5 - J4

//Находим напряжения на резисторах
u1=J1*R1
u2=J2*R2
u3=J3*R3
u4=J4*R4
u5=J5*R5
u6=J6*R6

//Вывод данных
disp("Силы тока")
disp("I1 = " + string(J1) + " I2 = " + string(J2) + " I3 = " + string(J3))
disp("I4 = " + string(J4) + " I5 = " + string(J5) + " I6 = " + string(J6))
disp("Напряжения")
disp(abs(u1),abs(u2),abs(u3),abs(u4),abs(u5),abs(u6))
