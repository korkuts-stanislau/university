function del()//функция очистки полей
{
    document.getElementById('surname').value='';
    document.getElementById('name').value='';
    document.getElementById('age').value='';
    document.getElementById('login').value='';
    document.getElementById('password').value='';
    document.getElementById('email').value='';
}

var surname,name,age,login,password,email,sex;

function main()
{
    surname=document.getElementById('surname').value;
    name = document.getElementById('name').value;
    age = document.getElementById('age').value;
    login = document.getElementById('login').value;
    password = document.getElementById('password').value;
    email = document.getElementById('email').value;
    sex = document.getElementById('sex').value;
    if(!validation(surname,name,age,login,password,email))
    {
        alert('Регистрация успешно завершена.');
        document.getElementById('registration-block').style.display='none';
        document.getElementById('test').style.display='block';
        /////////////Основной блок кода
        var testDes="";
        testDes += '<h2>Тест "Художник-Мыслитель"</h2><p>Ответьте на следующие вопросы, пользуясь десятибалльной шкалой. Категорическому отрицанию соответствует 0 баллов, безоговорочному согласию — 10 баллов. Но если, например, первый же вопрос поставит вас в тупик, поскольку вы не относите себя к мрачным личностям, но в то же время и не счастливый оптимист, то в вашем распоряжении все остальные баллы от 1 до 9. Постарайтесь поставить себе справедливую оценку "за настроение".</p>';
        testDes += '<h2>Хотите ли вы пройти этот тест?</h2>'
        testDes += '<button onclick="test()">Конечно хочу</button><button onclick="goodbye()">Не сегодня</button>';
        document.getElementById('test').innerHTML += testDes;
        /////////////Конец основного блока кода
    }
    else
    {
        switch(validation(surname,name,age,login,password,email))
        {
            case 1:
                alert("Неверная фамилия");
                break;
            case 2:
                alert("Неверное имя");
                break;
            case 3:
                alert("Неверный возраст");
                break;
            case 4:
                alert("Неверный логин");
                break;
            case 5:
                alert("Неверный пароль");
                break;
            case 6:
                alert("Неверный email");
                break;    
            default:
                alert("Поля заполнены неверно");
                break;    
        }
    }
}

function validation(s,n,a,l,p,e)
{
    if(!isNaN(s) || s.length<5)
    {
        return 1;
    }
    if(!isNaN(n) || n.length<3)
    {
        return 2;
    }
    if(a>100 || a<4)
    {
        return 3;
    }
    if(l.length<8)
    {
        return 4;
    }
    if(p.length<8)
    {
        return 5;
    }
    if(e.length<6)
    {
        return 6;
    }
    return 0;   
}

var questions = 
    [
        '1.У меня преобладает хорошее настроение.',
        '2.Я помню то, чему учился несколько лет назад.',
        '3.Прослушав раз-другой мелодию, я могу правильно воспроизвести ее.',
        '4.Когда я слушаю рассказ, то представляю его в образах.',
        '5.Я считаю, что эмоции в разговоре только мешают.',
        '6.Мне трудно дается алгебра.',
        '7.Я легко запоминаю незнакомые лица.',
        '8.В группе приятелей я первым начинаю разговор.',
        '9.Если обсуждают чьи-то идеи, то я требую аргументов.',
        '10.У меня преобладает плохое настроение.',
   ]
var points = [10];
var date;
var time;

function test()
{
    date = new Date();
    time = date.getTime();
    document.getElementById('test').innerHTML='';
    var text='';
    for(i=0;i<10;i++)
    {
        text+='<div id="div'+i+'">';
        text+=questions[i]+'<br>';
        text+='<input id="'+i+'" type="number"><br>';
        if(i==9)
            text+='<button onclick="nextQuestion('+(i+1)+')">Закончить тест</button>';
        else
            text+='<button onclick="nextQuestion('+(i+1)+')">Следующий вопрос</button>';
        text+='<button onclick="cancel()">Отмена</button>';
        text+='</div>';
    }
    document.getElementById('test').innerHTML=text;
    nextQuestion(0);
}

function goodbye()
{
    document.getElementById('test').innerHTML='<img src="img/pok.png">';
    alert('До свидания!');
}

function nextQuestion(i)
{
    if(i==0)
    {
        if(document.getElementById(''+0).value>10 || document.getElementById(''+0).value<0)
        {
            alert("Вы ввели неверное число");
        }
        else
            document.getElementById('div'+i).style.display='block';
    }
    else if(i<10)
    {
        if(document.getElementById(''+(i-1)).value>10 || document.getElementById(''+(i-1)).value<0)
        {
            alert("Вы ввели неверное число");
        }
        else
        {
            document.getElementById('div'+i).style.display='block';
            document.getElementById('div'+(i-1)).style.display='none';
            points[i-1]=document.getElementById(''+(i-1)+'').value;
        }
        
    }
    else
    {
        if(document.getElementById(''+(i-1)).value>10 || document.getElementById(''+(i-1)).value<0)
        {
            alert("Вы ввели неверное число");
        }
        else
        {
            points[i-1]=document.getElementById(''+(i-1)+'').value;
            results();
        }
        
    }
}

function results()
{
    date=new Date;
    time=date.getTime()-time;
    document.getElementById('div9').style.display='none';
    var text='';
    text+='<h3>Фамилия: '+surname+'</h3><br>';
    text+='<h3>Имя: '+name+'</h3><br>';
    text+='<h3>Пол: '+sex+'</h3><br>';
    text+='<h3>Возраст: '+age+'</h3><br>';
    text+='<h3>Логин: '+login+'</h3><br>';
    text+='<h3>Пароль: '+password+'</h3><br>';
    text+='<h3>Email: '+email+'</h3><br>';
    var leftcount=0,rightcount=0;
    leftcount+=points[0]+points[1]+points[4]+points[7]+points[8];
    rightcount+=points[2]+points[3]+points[5]+points[6]+points[9];
    text+='<h3>Результаты: '
    if(leftcount-rightcount>5)
    {
        text+='У вас преобладает логический тип мышления(Левое полушарие мозга)</h3><img class="images" src="img/logic.jpg">';
    }
    else if(rightcount-leftcount>5)
    {
        text+='У вас преобладает творческий тип мышления(Правое полушарие мозга)</h3><img class="images" src="img/creative.jpg">';
    }
    else
    {
        text+='У вас равномерно развитый мозг</h3><img class="images" src="img/rubiks.jpg">';
    }
    text+='<h3>Время прохождения теста: '+(time/1000)+'секунд</h3><br><br><br><br><br><br><br><br>';
    document.getElementById('test').innerHTML=text;
}

function cancel()
{
    document.getElementById('test').innerHTML='';
    document.getElementById('test').style.display='none';
    document.getElementById('registration-block').style.display='block';
}