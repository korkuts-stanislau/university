clear

clf()

xlabel("x",'fontsize',2);

ylabel("y",'fontsize',2);

zlabel("z",'fontsize',2);

xquad = [0 5 0 0 5 5 0 0 0 0 5 5
        5 5 0 5 5 5 0 5 5 5 5 5
        5 5 0 5 0 5 0 5 5 5 5 5
        0 5 0 0 0 5 0 0 0 0 5 5];
 
yquad = [3 3 3 3 11 5 5 5 9 3 7 7
        3 11 11 3 9 9 9 5 9 3 9 9
        11 9 9 5 9 11 11 3 11 11 5 5
        11 5 5 5 11 3 3 3 11 11 7 7];

zquad = [0 0 0 0 0 5 5 5 5 10 5 5
        0 0 0 0 5 5 5 5 5 10 8 2
        0 5 5 5 5 10 10 10 10 10 8 2
        0 5 5 5 0 10 10 10 10 10 5 5];


tcolor = [8 8 8 8 8 8 8 8 8 8 8 8];

plot3d(xquad,yquad,list(zquad,tcolor));

xtitle('Z buffer');
