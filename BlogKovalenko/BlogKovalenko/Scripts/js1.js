if (window.addEventListener) window.addEventListener("load", init, false);
else if (window.attachEvent) window.attachEvent("onload", init);
function init() {
    form1.butt1.onclick = addtext1;
    form1.butt2.onclick = addtext2;
    form1.butt3.onclick = addtext3;
    form1.butt4.onclick = addtext4;
    form1.butt5.onclick = addtext5;
}

function addtext1() {
    if (form1.butt1.value != "Скрыть") {
        var str1 = "Рекомендуется использовать (и на Западе уже используется) во всех новых проектах сложнее выпадающего меню и украденного с CodePen прелоадера — например, новая версия Angular от Google написана именно на TypeScript.";
        var str2 = "В качестве альтернатив — чистые ES 6 & ES 7 с последующей компиляцией в ES 5 через babel. Но на самом деле не стоит бояться TypeScript — за ним стоит такая крупная корпорация, как Microsoft, которая вряд ли бросит всё на произвол.";
        document.getElementById("ind1").innerHTML += str1 + str2;
        form1.butt1.value = "Скрыть";
    }
    else {
        document.getElementById("ind1").innerHTML = "";
        form1.butt1.value = "Показать текст";
    }
}
function addtext2() {
    if (form1.butt2.value != "Скрыть") {
        var str1 = "Как только Вы начинаете пользоваться SASS, препроцессор компилирует ваш SASS-файл и сохраняет его как простой CSS-файл, который вы можете использовать как обычно.";
        var str2 = "На SASS написаны все современные UI фреймворки, в том числе Bootstrap и Foundation. И если раньше вы использовали их без SASS, то возможности, которые откроются перед вами, очень приятно вас удивят.";
        document.getElementById("ind2").innerHTML += str1 + str2;
        form1.butt2.value = "Скрыть";
    }
    else {
        document.getElementById("ind2").innerHTML = "";
        form1.butt2.value = "Показать текст";
    }
}
function addtext3() {
    if (form1.butt3.value != "Скрыть") {
        var str1 = "Однако как они работает изнутри и как начать их использовать самому? Предлагаем поставить себе цель на лето — узнать ответ на эти вопросы и создать свою собственною нейронку.";
        document.getElementById("ind3").innerHTML += str1;
        form1.butt3.value = "Скрыть";
    }
    else {
        document.getElementById("ind3").innerHTML = "";
        form1.butt3.value = "Показать текст";
    }
}
function addtext4() {
    if (form1.butt4.value != "Скрыть") {
        var str1 = "Как минимум, это будет весомая ачивка в вашем резюме, как максимум — вы станете одним из первых экспертов на растущем рынке.";
        document.getElementById("ind4").innerHTML += str1;
        form1.butt4.value = "Скрыть";
    }
    else {
        document.getElementById("ind4").innerHTML = "";
        form1.butt4.value = "Показать текст";
    }
}
function addtext5() {
    if (form1.butt5.value != "Скрыть") {
        var str1 = "Разработанная в Facebook технология была выпущена не так давно и в этом году всё чаще и чаще выбирается для разработки крупных веб, Android и iOS приложений. React.js часто используют в связке с TypeScript. Кстати, разработка приложений для мобильных устройств — ещё одна возможная цель и потенциальное достижение за лето. В таком случае вам понадобятся языки Java и Swift — начать кодить на них реально даже за месяц.";
        document.getElementById("ind5").innerHTML += str1;
        form1.butt5.value = "Скрыть";
    }
    else {
        document.getElementById("ind5").innerHTML = "";
        form1.butt5.value = "Показать текст";
    }
}