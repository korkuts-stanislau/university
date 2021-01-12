
x=[0 5 0 0 5 5 0 0 0 0 5 5
   5 5 0 5 5 5 0 5 5 5 5 5
   5 5 0 5 0 5 0 5 5 5 5 5
   0 5 0 0 0 5 0 0 0 0 5 5];
y=[3 3 3 3 11 5 5 5 9 3 7 7
   3 11 11 3 9 9 9 5 9 3 9 9
   11 9 9 5 9 11 11 3 11 11 5 5
   11 5 5 5 11 3 3 3 11 11 7 7];
z=[0 0 0 0 0 5 5 5 5 10 5 5
   0 0 0 0 5 5 5 5 5 10 8 2
   0 5 5 5 5 10 10 10 10 10 8 2
   0 5 5 5 0 10 10 10 10 10 5 5];

tcolor = [8 8 8 8 8 8 8 8 8 8 8 8]; 
plot3d(x,y,list(z,tcolor),flag=[1,1,4],alpha=35,theta=245,ebox=[-5,15,-5,15,-5,15]);
//функция включения тусклого света
function color_t
    s=plot3d(x,y,z,alpha=45,theta=225);
    l = light();
    s.color_flag=0;
    s.thickness=0;
    l.light_type = "point";
    l.direction = [1 1 1];
    l.position = [-1 -1 7];
    l.diffuse_color = [0.2 0.1 0.1];
    l.ambient_color = [0.05 0.05 0.05];
    l.specular_color = [0.1 0.1 0.1];
endfunction
//функция включения яркого света
function color_i
    s=plot3d(x,y,z,alpha=45,theta=225);
    l = light();
    s.color_flag=0;
    s.thickness=0;
    l.light_type = "point";
    l.direction = [1 1 1];
    l.position = [-1 -1 7];
    l.diffuse_color = [1, 1, 1];
    l.ambient_color = [1 1 1];
    l.specular_color = [1 1 1];
endfunction
//функция выключения света
function color_off
    s=plot3d(x,y,z,alpha=45,theta=225);
    l = light();
    s.color_flag=0;
    s.thickness=0;
    l.light_type = "point";
    l.direction = [0 0 0];
    l.position = [0 0 0];
    l.diffuse_color = [0 0 0];
    l.ambient_color = [0 0 0];
    l.specular_color = [0 0 0];
endfunction
button=uicontrol('style','pushbutton','string','Включить тусклый свет','position',[50,10,170,30],'CallBack','color_t');
button=uicontrol('style','pushbutton','string','Включить яркий свет','position',[230,10,170,30],'CallBack','color_i');
button=uicontrol('style','pushbutton','string','Выключить свет','position',[410,10,170,30],'CallBack','color_off');
