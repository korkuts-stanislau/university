var inform=document.getElementById('inform-block');
var first=document.getElementById('first-task');
var second=document.getElementById('second-task');
var third=document.getElementById('third-task');

function informOn(n)
{
    var divsArray=[inform,first,second,third];
    for(i=0;i<4;i++)
    {
        if(i==n)
            divsArray[i].style.display='block';
        else 
            divsArray[i].style.display='none'; 
    }
    if(n==1)
        firstTask();
    else if(n==2)
        secondTask();
    else if(n==3)  
        thirdTask();       
}

function firstTask()
{
    let x,y,z,b;
    x=prompt("Введите x");
    y=prompt("Введите y");
    z=prompt("Введите z");
    b=Math.exp(Math.abs(x-y))*Math.pow((Math.pow(Math.tan(z),2)+1),x);
    alert("Ответ: b = "+b);
}
function secondTask()
{
    let x,y,z,b;
    x=prompt("Введите x");
    y=prompt("Введите y");
    z=prompt("Введите z");
    b=Math.exp(Math.abs(x-y))*Math.pow((Math.pow(Math.tan(z),2)+1),x);
    second.innerHTML+='<br><h2>Задание 2<h2><br><h3>Ответ b = '+b+'<h3>';
}
function thirdTask()
{
    var questions=[
        'Какую первую программу обычно пишут программисты?',
        'Бывает ли так, что программа скомпилировалась с первого раза и без ошибок?',
        'Представим гипотетическую ситуацию, в которой программа скомпилировалась с первого раза. Как вы поступите?',
        'Допустим, вы пишете проект, и заказчик утвердил документ, в котором чётко написано, что он хочет получить в результате. Назовём его ТЗ. Изменятся ли требования в процессе работы над проектом?',
        'Какой правильный ответ на вопрос про рекурсию?',
        'Представьте, что вы пишете программу и при попытке её сборки компилятор выдал вам одну ошибку. Вы исправили её и пробуете собрать проект ещё раз. Сколько теперь будет ошибок?',
        'Вы пришли на проект, над которым раньше работал другой программист. Что можно сказать о его коде?',
        'Перед вами четыре дерева. На втором дереве с конца сидит кот. На дереве с каким индексом сидит кот?',
        'Что такое Пик Балмера?',
        'Что такое стринги?'
    ];
    var answers=[
        ['Hello World','Сортировку пузырьком','Взлом Вконтакте','Вопрос с подвохом. Они чинят утюги!'],
        ['Да, конечно','Это за гранью фантастики','Всё зависит от нас самих','Что такое "скомпилировалась"?'],
        ['Спокойно пойду спать - дело сделано','Порадуюсь и продолжу писать код','Буду искать ошибку, где то она должна быть','Мне кто-нибудь объяснит что такое "скомпилировалась"?'],
        ['Изменятся, конечно','Нет. Вы же сами сказали что чётко зафиксировано','Заказчик есть - уже хорошо','А он заплатит?'],
        ['Да','Нет','42','Какой правильный ответ на вопрос про рекурсию?'],
        ['Была одна теперь 0','2','Неизвестно','Сори, я не шарю в химии'],
        ['Надо детально изучить проект что бы сказать','УЖАСНО','КТО СТАВИТ ПРОБЕЛЫ ВМЕСТО ТАБУЛЯЦИИИИИ?','42'],
        ['2','3','Второе дерево','Повторите вопрос'],
        ['Гора в Северной Америке','Феномен о том, что при определённой концентрации алкоголя в крови программистские способности резко возрастают','Яхта Стива Балмера — бывшего генерального директора Microsoft','Я уже устал давай последний вопрос'],
        ['Разновидность мини трусиков','Веревки на английском','Несколько переменных определенного типа','Этот тест точно по программированию?']
    ];
    var letters=['A.','B.','C.','D.'];
    var rightAnswers=['A','B','C','A','D','C','B','A','B','C'];
    var userAnswers=[];
    let fio,age,sex='';
    let tdLeft='<td>',tdRight='</td>',tr='</tr><tr>',tableEnd='</tr></table>';
    var string;
    var time=new Array(10);
    var variable='';
    if(confirm('Хотите ли вы пройти тест?'))
    {
        var maxTime=0;
        var posMaxTime;
        do
        {
            fio=prompt('Как вас зовут?');
        }while(!isNaN(fio));
        do
        {
            age=parseInt(prompt('Сколько вам лет?'));
        }while(isNaN(age));
        while(sex!='мужчина' && sex!='женщина')
            sex=prompt('Вы мужчина или женщина?');
        if(sex=='мужчина')
            sex='мужской';
        else
            sex='женский';    
        for(i=0;i<10;i++)
        {
            string=questions[i]
            for(j=0;j<4;j++)
            {
                string+='\n'+letters[j]+answers[i][j];
            }
            time[i]=new Date();
            userAnswers[i]=prompt(string);
            if(new Date() - time[i]>maxTime)
            {
                maxTime=new Date() - time[i];
                posMaxTime=i;
            }  
            time[i] = Math.ceil((new Date()-time[i])/100)/10;
        }
        third.innerHTML+='<h1>Результаты прохождения теста "Насколько вы программист"</h1>';
        third.innerHTML+='<h3>Имя: '+fio+'</h3><h3>Возраст: '+age+'</h3><h3>Пол: '+sex+'</h3>';
        variable+='<h2>Таблица ответов</h2><table bgcolor="white" width="100%" cellpadding="2px" cellspacing="2px" align="center" border="3px"><tr><td>№</td><td>Вопрос</td><td>Правильный ответ</td><td>Ответ пользователя</td><td>Время ответа</td></tr><tr>'
        for(i=0;i<10;i++)
        {
            for(j=0;j<5;j++)
            {
                switch(j)
                {
                    case 0:
                        variable+=tdLeft+(i+1)+tdRight;
                    break;
                    case 1:
                        variable+=tdLeft+questions[i]+tdRight;
                    break;
                    case 2:
                        variable+=tdLeft+rightAnswers[i]+tdRight;
                    break;
                    case 3:
                    {
                        if(rightAnswers[i]==userAnswers[i])
                        {
                            variable+='<td class="right">'+userAnswers[i]+tdRight;
                        }
                        else
                        {
                            variable+='<td class="wrong">'+userAnswers[i]+tdRight;
                        }
                    }  
                    break;
                    case 4:
                        variable+=tdLeft+time[i]+'с.'+tdRight;
                    break;
                }  
            }
            variable+=tr;
        }
        variable+=tableEnd;
        third.innerHTML+=variable;
        //Закончилась таблица
        var rqq=0;
        var iqq=0;
        third.innerHTML+='<h2>Список вопросов с правильным ответом</h2>';
        for(i=0;i<10;i++)
        {
            if(userAnswers[i]==rightAnswers[i])
            {
                rqq++;
                third.innerHTML+=(i+1)+'.'+questions[i]+'<br>';
            }
        }
        third.innerHTML+='<h2>Список вопросов с неправильным ответом</h2>';
        for(i=0;i<10;i++)
        {
            if(userAnswers[i]!=rightAnswers[i])
            {
                iqq++;
                third.innerHTML+=(i+1)+'.'+questions[i]+'<br>';
            }
        }
        third.innerHTML+='<h2>Вопрос на который было затрачено больше всего времени</h2>';
        third.innerHTML+=questions[posMaxTime];
        third.innerHTML+='<h2>Среднее время ответа на вопрос</h2>';
        var midTime=0;
        for(i=0;i<10;i++)
        {
            midTime+=time[i];
        }
        midTime/=10;
        third.innerHTML+=Math.ceil(midTime*10)/10+'сек.';
        third.innerHTML+='<h2>Процент правильных ответов</h2>';
        third.innerHTML+=Math.ceil(rqq*10)+'%';
        third.innerHTML+='<h2>Процент неправильных ответов</h2>';
        third.innerHTML+=Math.ceil(iqq*10)+'%';
        third.innerHTML+='<h2>Вопрос, на который затрачено времени больше среднего значения</h2>';
        for(i=0;i<10;i++)
        {
            if(time[i]>midTime)
            {
                third.innerHTML+=i+'.'+questions[i]+'<br>';
            }
        }
    }
}