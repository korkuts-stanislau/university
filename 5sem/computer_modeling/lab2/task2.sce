summa = 0
for i = 1:1:10
    summa = summa + (-1)^(-i) / (i + 1)^2
end

product = 1
for i = 4:1:10
    product = product * i^2 / factorial(i)
end
