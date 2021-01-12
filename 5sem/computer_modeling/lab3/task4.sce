x1 = []
y1 = []

x2 = []
y2 = []

x3 = []
y3 = []

for i = -11:0.01:11
    if i > 2 then
        x1($+1) = i
        y1($+1) = sqrt(i)
    elseif i >= -10 && i <= -3 then
        x2($+1) = i
        y2($+1) = sqrt(abs(i))
    else
        x3($+1) = i
        y3($+1) = 2 * i^2
    end
end

xtitle("Third lab", "Argument", "Function")

plot(x1, y1, "r-o")
plot(x2, y2, "b->")
plot(x3, y3, "g+")

legend("sqrt(x)", "sqrt(abs(x))", "2 * x^2")
set(gca(),"grid",[1 1], "font_size", 2)
xstring(-9.5, 225, "First fragment")
xstring(-10, 1, "Second fragment")
xstring(-2.5, 15, "Third fragment")
xstring(5, 1, "Fourth fragment")
