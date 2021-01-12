x = [-2 * %pi: %pi / 10: 2 * %pi]
y = [-2 * %pi: %pi / 10: 2 * %pi]
z = (1 + sin(x')/x') * (sin(y)/y)
//z = sin(x') * cos(y)

subplot(221)
plot3d(x, y, z)

subplot(222)
mesh(x, y, z)

subplot(223)
mesh(x, y, z)

subplot(224)
surf(x, y, z)


