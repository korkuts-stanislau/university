//Task data
a = [6, 7, 3;
     3, 1, 0;
     2, 2, 1]
     
b = [2, 0, 5;
     4, -1, -2;
     4, 3, 7]
     
//1.1
v1 = a(2, :)
v2 = b(:, 3)
v3 = a(:, 2)

//1.2
disp(v1 * v2)
disp(a * v2)

//1.3
disp(a * b)
disp(1 / a)
disp(inv(a) * a)
disp(a')
disp(b')

//1.4
disp(det(a))
disp(det(b))

//1.5
disp(v3 .* v2)
disp(a .* b)
