function[y] = calculateFunc(xn, xk, dx)
    x = [xn: dx: xk]
    if x > 2 then
        y = sqrt(x)
    elseif x < -3 && x >= -10 then
        y = sqrt(abs(x))
    else
        y = 2 * x^2
    end
endfunction

y = calculateFunc(1, 10, 1)
disp(y)
