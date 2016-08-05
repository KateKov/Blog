if (window.addEventListener) window.addEventListener("load", init, false);
else if (window.attachEvent) window.attachEvent("onload", init);
function init() {
    form1.Name.onchange = nameOnChange;
    form1.Surname.onchange = nameOnChange;
    form1.Email.onchange = emailOnChange;
    form1.Address.onchange = addressOnChange;
    form1.Phone.onchange = phoneOnChange;
    form1.IqQuestion.onchange = nameOnChange;
    form1.onsubmit = onsubmiHandler;
}
function validate(elem, pattern) {
    var res = elem.value.search(pattern);
    if (res == -1) elem.className = "invalid";
    else elem.className = "valid";
}
function addressOnChange() {
    var pattern = /([a-zA-Zа-яА-Я]|\d){5,25}/;
    validate(this, pattern);
}
function nameOnChange() {
    var pattern = /[a-zA-Zа-яА-Я]+/;
    validate(this, pattern);
}
function phoneOnChange() {
    var pattern = /(\(\d{3}\)\d{7})|(\d{9})/;
    validate(this, pattern);
}
function emailOnChange() {
    var pattern = /[^\u0040]+\u0040[^\u0040]+\.[a-zA-Z]{2,6}/;
    validate(this, pattern);
}
function onsubmiHandler() {
    
    var invalid = false;

    for (var i = 0; i < form1.elements.length; ++i) {
        var e = form1.elements[i];
        if (e.type == "text" && e.onchange) {
            e.onchange();
            if (e.className == "invalid") invalid = true;
        }
    }

    if (invalid) {
        alert("Допущены ошибки при заполнении формы.");
        return false;
    }


}