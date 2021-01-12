
subplot(221)

x1 = linspace(-2, 2, 1000)
y1 = 2 * x1^3 - 6 * x1^2 - 18 * x1 + 7
plot(x1, y1, 'r')
legend("2 * x1^3 - 6 * x1^2 - 18 * x1 + 7")

subplot(222)

x2 = linspace(-2, 2, 1000)
y2 = 2 * x2^3 - 3 * x2^2
plot(x2, y2, 'g')
legend("2 * x2^3 - 3 * x2^2")

subplot(223)

x3 = linspace(-2, 2, 1000)
y3 = sin(x3)
plot(x3, y3, 'b')
legend("sin(x)")

subplot(224)

x4 = linspace(-2, 2, 1000)
y4 = cos(x4)
plot(x4, y4, 'y')
legend("cos(x)")
