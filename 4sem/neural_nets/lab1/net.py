X = [[0, 0], 
    [0, 1], 
    [1, 0],
    [1, 1]]

nu = 0.1

w = [0] * 9
a = [0] * 3
d = [0, 1, 1, 1]
y = [0, 0, 0, 0]



for count in range(300):
    for i in range(4):
        x = X[i]
        #генерируем значения внутреннего слоя
        a[0] = 1 if x[0] * w[0] + x[1] * w[3] > 1 else 0
        a[1] = 1 if x[0] * w[1] + x[1] * w[4] > 1 else 0
        a[2] = 1 if x[0] * w[2] + x[1] * w[5] > 1 else 0
        #генерируем значение выходного слоя
        y[i] = 1 if a[0] * w[6] + a[1] * w[7] + a[2] * w[8] else 0
        if y[i] != d[i]:
            #изменяем значения весов
            if y[i] > d[i]:
                w[6] -= nu
                w[7] -= nu
                w[8] -= nu
                if x[0] == 1:
                    w[0] -= nu
                    w[1] -= nu
                    w[2] -= nu
                if x[1] == 1:
                    w[3] -= nu
                    w[4] -= nu
                    w[5] -= nu
            else:
                w[6] += nu
                w[7] += nu
                w[8] += nu
                if x[0] == 1:
                    w[0] += nu
                    w[1] += nu
                    w[2] += nu
                if x[1] == 1:
                    w[3] += nu
                    w[4] += nu
                    w[5] += nu

print([round(weight, 2) for weight in w], y)