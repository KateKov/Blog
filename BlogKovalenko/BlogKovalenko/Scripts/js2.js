
    if (window.addEventListener) window.addEventListener("load", init, false);
else if (window.attachEvent) window.attachEvent("onload", init);
function init() {
    form1.rev.onclick = addtext1;
}
function addtext1()
{
    var str1=" <div class='form_row'> <h3>Оставить отзыв</h3> <label><strong>Имя</strong></label> <br /> <input type='text' name='Person' /> </div>";
    var str2="<div class='form_row'> <label><strong>Отзыв</strong></label> <br /> <textarea name='Text' ></textarea> </div>";
    var str3 = "<input type='submit' name='Submit' value='Отправить' class='submit_btn' />";
    document.getElementById("comments").innerHTML = str1 + str2 + str3;
    form1.rev.hidden = true;
    form2.hidden = "";
        
}
    