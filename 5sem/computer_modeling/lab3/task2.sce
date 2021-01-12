
x1 = linspace(-2, 2, 1000)
y1 = 2 * x1^3 - 6 * x1^2 - 18 * x1 + 7
plot(x1, y1, 'r')

x2 = linspace(-2, 2, 1000)
y2 = 2 * x2^3 - 3 * x2^2
plot(x2, y2, 'g')

xtitle("Third lab", "Argument", "Function")
legend("2 * x1^3 - 6 * x1^2 - 18 * x1 + 7", "2 * x2^3 - 3 * x2^2")
set(gca(),"grid",[1 1], "font_size", 2)
xstring(0, 0, "Point of intersection")
