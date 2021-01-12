var time = 0;
var running = 0;
var tenths=0, mins=0, secs=0, hours=0;
function startPause(){
 if(running == 0){
  running = 1;
  increment();
 document.getElementById("start").innerHTML = "Пауза";
 document.getElementById("startPause").style.backgroundColor = "#469FB4"; 
 document.getElementById("startPause").style.borderColor = "#469FB4";
 }
 else{
  running = 0;
 document.getElementById("start").innerHTML = ">>>"; 
 document.getElementById("startPause").style.backgroundColor = "#5AD2F0"; 
 document.getElementById("startPause").style.borderColor = "#5AD2F0";
 }
}
function reset(){
 running = 0;
 time = 0;
 document.getElementById("start").innerHTML = "Старт";
 document.getElementById("output").innerHTML = "0:00:00:00";
 document.getElementById("startPause").style.backgroundColor = "#5AD2F0"; 
 document.getElementById("startPause").style.borderColor = "#5AD2F0";
}
function increment(){
 if(running == 1){
  setTimeout(function(){
   time++;
   mins = Math.floor(time/10/60);
   secs = Math.floor(time/10 % 60);
   hours = Math.floor(time/10/60/60); 
   tenths = time % 10;
   if(mins < 10){
    mins = "0" + mins;
   } 
   if(secs < 10){
    secs = "0" + secs;
   }
   document.getElementById("output").innerHTML = hours + ":" + mins + ":" + secs + ":" + tenths;
   increment();
  },100)
 }
}
function loop() {
 var para = document.createElement("p");
 var node = document.createTextNode(hours + ":" + mins + ":" + secs + ":" + tenths);
 para.appendChild(node);
 var element = document.getElementById("div1");
 element.appendChild(para);
 //document.getElementById("output").innerHTML = hours + ":" + mins + ":" + secs + ":" + tenths + "0";
}﻿