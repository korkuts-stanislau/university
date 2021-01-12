
p = poly([31.36 -27.125 -7.575 4.65 1], "x", "c")
R = roots(p)

coefs = [3, -2, -5;
         2, 3, -4;
         1, -2, 3]
         
answs = [9; -2; 12]

x = linsolve(coefs, answs)
